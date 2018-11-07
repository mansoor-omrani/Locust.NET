
GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_transfer]    Script Date: 8/20/2018 6:25:27 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp1_Credit_singletrader_transfer]
GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_get_page]    Script Date: 8/20/2018 6:25:27 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp1_Credit_singletrader_get_page]
GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_end_transfer]    Script Date: 8/20/2018 6:25:27 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp1_Credit_singletrader_end_transfer]
GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_end_apply]    Script Date: 8/20/2018 6:25:27 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp1_Credit_singletrader_end_apply]
GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_begin_transfer]    Script Date: 8/20/2018 6:25:27 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp1_Credit_singletrader_begin_transfer]
GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_begin_apply]    Script Date: 8/20/2018 6:25:27 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp1_Credit_singletrader_begin_apply]
GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_apply]    Script Date: 8/20/2018 6:25:27 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp1_Credit_singletrader_apply]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SingleTraderCreditTransactions]') AND type in (N'U'))
ALTER TABLE [dbo].[SingleTraderCreditTransactions] DROP CONSTRAINT IF EXISTS [FK_SingleTraderCreditTransactions_AspNetUsers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SingleTraderCreditTransactions]') AND type in (N'U'))
ALTER TABLE [dbo].[SingleTraderCreditTransactions] DROP CONSTRAINT IF EXISTS [DF_SingleTraderCreditTransactions_BalanceBefore]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SingleTraderCreditTransactions]') AND type in (N'U'))
ALTER TABLE [dbo].[SingleTraderCreditTransactions] DROP CONSTRAINT IF EXISTS [DF_SingleTraderCreditTransactions_CreditTransactionDate]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SingleTraderCreditTransactions]') AND type in (N'U'))
ALTER TABLE [dbo].[SingleTraderCreditTransactions] DROP CONSTRAINT IF EXISTS [DF_Table_1_IsApproved]
GO
/****** Object:  Index [IX_SingleTraderCreditTransactions_TransactionKey]    Script Date: 8/20/2018 6:25:27 PM ******/
DROP INDEX IF EXISTS [IX_SingleTraderCreditTransactions_TransactionKey] ON [dbo].[SingleTraderCreditTransactions]
GO
/****** Object:  Table [dbo].[SingleTraderCreditTransactions]    Script Date: 8/20/2018 6:25:27 PM ******/
DROP TABLE IF EXISTS [dbo].[SingleTraderCreditTransactions]
GO
/****** Object:  Table [dbo].[SingleTraderCreditTransactions]    Script Date: 8/20/2018 6:25:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SingleTraderCreditTransactions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SingleTraderCreditTransactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Acknowledged] [bit] NOT NULL,
	[CreditTransactionDate] [datetime] NOT NULL,
	[CreditTransactionAcknowledgeDate] [datetime] NULL,
	[BalanceBefore] [decimal](18, 2) NOT NULL,
	[RelatedTransactionId] [int] NULL,
	[TransactionKey] [varchar](50) NULL,
	[Info] [nvarchar](250) NULL,
	[TranType]  AS (case when [RelatedTransactionId] IS NULL then case when [Amount]>(0) then 'Deposit' else 'Withdraw' end else case when [Amount]>(0) then 'TransferFrom' else 'TransferTo' end end),
 CONSTRAINT [PK_SingleTraderCreditTransactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
) ON [FLG_DATA]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SingleTraderCreditTransactions_TransactionKey]    Script Date: 8/20/2018 6:25:27 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SingleTraderCreditTransactions]') AND name = N'IX_SingleTraderCreditTransactions_TransactionKey')
CREATE NONCLUSTERED INDEX [IX_SingleTraderCreditTransactions_TransactionKey] ON [dbo].[SingleTraderCreditTransactions]
(
	[TransactionKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Table_1_IsApproved]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SingleTraderCreditTransactions] ADD  CONSTRAINT [DF_Table_1_IsApproved]  DEFAULT ((0)) FOR [Acknowledged]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SingleTraderCreditTransactions_CreditTransactionDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SingleTraderCreditTransactions] ADD  CONSTRAINT [DF_SingleTraderCreditTransactions_CreditTransactionDate]  DEFAULT (getdate()) FOR [CreditTransactionDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SingleTraderCreditTransactions_BalanceBefore]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SingleTraderCreditTransactions] ADD  CONSTRAINT [DF_SingleTraderCreditTransactions_BalanceBefore]  DEFAULT ((0)) FOR [BalanceBefore]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SingleTraderCreditTransactions_AspNetUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[SingleTraderCreditTransactions]'))
ALTER TABLE [dbo].[SingleTraderCreditTransactions]  WITH CHECK ADD  CONSTRAINT [FK_SingleTraderCreditTransactions_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SingleTraderCreditTransactions_AspNetUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[SingleTraderCreditTransactions]'))
ALTER TABLE [dbo].[SingleTraderCreditTransactions] CHECK CONSTRAINT [FK_SingleTraderCreditTransactions_AspNetUsers]
GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_apply]    Script Date: 8/20/2018 6:25:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp1_Credit_singletrader_apply]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp1_Credit_singletrader_apply] AS' 
END
GO
ALTER PROCEDURE [dbo].[usp1_Credit_singletrader_apply]
(
	@Result varchar(80) out,
	@UserName nvarchar(50),
	@Amount decimal(18,2),
	@Info nvarchar(4000)
)
AS
BEGIN
	SET NOCOUNT ON;

	begin try
		declare @UserId int
		declare @BalanceBefore decimal(18, 2)
		declare @tbl table(Credit decimal(18, 2))

		if dbo.IsEmpty(@UserName) = 1
		begin
			set @Result = 'NoUserName'
			goto end_sproc
		end

		select @UserId = u.Id from AspNetUsers u where u.UserName = @UserName
		if @UserId is null
		begin
			set @Result = 'InvalidUser'
			goto end_sproc
		end

		if isnull(@Amount, 0) = 0
		begin
			set @Result = 'InvalidAmount'
			goto end_sproc
		end
	
		begin tran

		update AspNetUsers set Credit = Credit + @Amount output deleted.Credit into @tbl where Id = @UserId

		set @BalanceBefore = (select Credit from @tbl)

		if @BalanceBefore + @Amount < 0
		begin
			set @Result = 'NotEnoughCredit'

			rollback
		end
		else
		begin
			insert into SingleTraderCreditTransactions(UserId, Amount, Info, BalanceBefore, Acknowledged, CreditTransactionAcknowledgeDate)
			values (@UserId, @Amount, @Info, @BalanceBefore, 1, getdate())

			set @Result = 'Success'

			commit
		end
	end try
	begin catch
		if @@TRANCOUNT > 0
			rollback

		set @Result = 'Faulted'

		exec [dbo].[usp0_Log_error] null
	end catch
end_sproc:
	return
END

GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_begin_apply]    Script Date: 8/20/2018 6:25:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp1_Credit_singletrader_begin_apply]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp1_Credit_singletrader_begin_apply] AS' 
END
GO
ALTER PROCEDURE [dbo].[usp1_Credit_singletrader_begin_apply]
(
	@Result varchar(80) out,
	@Key varchar(50) out,
	@UserName nvarchar(50),
	@Amount decimal(18,2),
	@Info nvarchar(4000)
)
AS
BEGIN
	SET NOCOUNT ON;

	begin try
		declare @UserId int
		
		if dbo.IsEmpty(@UserName) = 1
		begin
			set @Result = 'NoUserName'
			goto end_sproc
		end

		select @UserId = u.Id from AspNetUsers u where u.UserName = @UserName
		if @UserId is null
		begin
			set @Result = 'InvalidUser'
			goto end_sproc
		end

		if isnull(@Amount, 0) = 0
		begin
			set @Result = 'InvalidAmount'
			goto end_sproc
		end
	
		set @Key = cast(NEWID() as varchar(50))

		insert into SingleTraderCreditTransactions(UserId, Amount, Info, TransactionKey)
		values (@UserId, @Amount, @Info, @Key)

		set @Result = 'Success'
	end try
	begin catch
		set @Result = 'Faulted'

		exec [dbo].[usp0_Log_error] null
	end catch
end_sproc:
	return
END

GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_begin_transfer]    Script Date: 8/20/2018 6:25:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp1_Credit_singletrader_begin_transfer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp1_Credit_singletrader_begin_transfer] AS' 
END
GO
ALTER PROCEDURE [dbo].[usp1_Credit_singletrader_begin_transfer]
(
	@Result varchar(80) out,
	@Key varchar(50) out,
	@FromUserName nvarchar(50),
	@ToUserName nvarchar(50),
	@Amount decimal(18,2),
	@FromInfo nvarchar(4000),
	@ToInfo nvarchar(4000)
)
AS
BEGIN
	SET NOCOUNT ON;

	begin try
		declare @FromId int
		declare @ToId int
		declare @FromUserId int
		declare @ToUserId int
		
		if dbo.IsEmpty(@FromUserName) = 1
		begin
			set @Result = 'NoFromUserName'
			goto end_sproc
		end

		select @FromUserId = u.Id from AspNetUsers u where u.UserName = @FromUserName
		if @FromUserId is null
		begin
			set @Result = 'InvalidFromUser'
			goto end_sproc
		end

		if dbo.IsEmpty(@ToUserName) = 1
		begin
			set @Result = 'NoToUserName'
			goto end_sproc
		end

		select @ToUserId = u.Id from AspNetUsers u where u.UserName = @ToUserName
		if @ToUserId is null
		begin
			set @Result = 'InvalidToUser'
			goto end_sproc
		end

		if isnull(@Amount, 0) = 0
		begin
			set @Result = 'NoAmount'
			goto end_sproc
		end
	
		if @Amount < 0
		begin
			set @Result = 'InvalidAmount'
			goto end_sproc
		end
	
		set @Key = cast(NEWID() as varchar(50))

		begin tran

		insert into SingleTraderCreditTransactions(UserId, Amount, Info)
		values (@ToUserId, @Amount, @ToInfo)

		set @ToId = SCOPE_IDENTITY()

		insert into SingleTraderCreditTransactions(UserId, Amount, Info, TransactionKey, RelatedTransactionId)
		values (@FromUserId, -@Amount, @FromInfo, @Key, @ToId)

		set @FromId = SCOPE_IDENTITY()

		update SingleTraderCreditTransactions set RelatedTransactionId = @FromId where Id = @ToId

		set @Result = 'Success'

		commit
	end try
	begin catch
		if @@TRANCOUNT > 0
			rollback

		set @Result = 'Faulted'

		exec [dbo].[usp0_Log_error] null
	end catch
end_sproc:
	return
END

GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_end_apply]    Script Date: 8/20/2018 6:25:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp1_Credit_singletrader_end_apply]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp1_Credit_singletrader_end_apply] AS' 
END
GO
ALTER PROCEDURE [dbo].[usp1_Credit_singletrader_end_apply]
(
	@Result varchar(80) out,
	@TransactionKey varchar(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	begin try
		declare @CreditTransactionId int
		declare @UserId int
		declare @Amount decimal(18, 2)
		declare @BalanceBefore decimal(18, 2)
		declare @tbl table(Credit decimal(18, 2))
		declare @Acknowledged bit

		if dbo.IsEmpty(@TransactionKey) = 1
		begin
			set @Result = 'NoTransactionKey'
			goto end_sproc
		end

		select
			@CreditTransactionId = Id,
			@Amount = Amount,
			@UserId = UserId,
			@Acknowledged = Acknowledged
		from SingleTraderCreditTransactions where TransactionKey = @TransactionKey

		if @CreditTransactionId is null
		begin
			set @Result = 'InvalidCreditTransaction'
			goto end_sproc
		end

		if @Amount is null or @UserId is null
		begin
			set @Result = 'CreditTransactionProblematic'
			goto end_sproc
		end

		if @Acknowledged = 1
		begin
			set @Result = 'AlreadyEnded'
			goto end_sproc
		end

		begin tran

		update AspNetUsers set Credit = Credit + @Amount output deleted.Credit into @tbl where Id = @UserId

		set @BalanceBefore = (select Credit from @tbl)

		if @BalanceBefore + @Amount < 0
		begin
			set @Result = 'NotEnoughCredit'

			rollback
		end
		else
		begin
			update SingleTraderCreditTransactions set Acknowledged = 1, BalanceBefore = @BalanceBefore, CreditTransactionAcknowledgeDate = getdate() where Id = @CreditTransactionId
			
			set @Result = 'Success'

			commit
		end
	end try
	begin catch
		if @@TRANCOUNT > 0
			rollback

		set @Result = 'Faulted'

		exec [dbo].[usp0_Log_error] null
	end catch
end_sproc:
	return
END

GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_end_transfer]    Script Date: 8/20/2018 6:25:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp1_Credit_singletrader_end_transfer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp1_Credit_singletrader_end_transfer] AS' 
END
GO
ALTER PROCEDURE [dbo].[usp1_Credit_singletrader_end_transfer]
(
	@Result varchar(80) out,
	@TransactionKey varchar(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	begin try
		declare @FromId int
		declare @ToId int
		declare @ToRelatedTransactionId int
		declare @ToUserId int
		declare @FromUserId int
		declare @FromAmount decimal(18, 2)
		declare @ToAmount decimal(18, 2)
		declare @FromBalanceBefore decimal(18, 2)
		declare @ToBalanceBefore decimal(18, 2)
		declare @tbl table(Credit decimal(18, 2))
		declare @FromAcknowledged bit
		declare @ToAcknowledged bit

		if dbo.IsEmpty(@TransactionKey) = 1
		begin
			set @Result = 'NoTransactionKey'
			goto end_sproc
		end

		select
			@FromId = Id,
			@FromAmount = Amount,
			@FromUserId = UserId,
			@FromAcknowledged = Acknowledged,
			@ToId = RelatedTransactionId
		from SingleTraderCreditTransactions where TransactionKey = @TransactionKey

		if @FromId is null
		begin
			set @Result = 'InvalidCreditTransaction'
			goto end_sproc
		end

		if @FromAmount is null or @FromAmount >= 0
		begin
			set @Result = 'FromAmountProblematic'
			goto end_sproc
		end

		if @FromUserId is null
		begin
			set @Result = 'FromUserProblematic'
			goto end_sproc
		end

		if @ToId is null
		begin
			set @Result = 'FromProblematic'
			goto end_sproc
		end

		if @FromAcknowledged = 1
		begin
			set @Result = 'FromAlreadyEnded'
			goto end_sproc
		end

		select
			@ToId = Id,
			@ToAmount = Amount,
			@ToUserId = UserId,
			@ToAcknowledged = Acknowledged,
			@ToRelatedTransactionId = RelatedTransactionId
		from SingleTraderCreditTransactions where Id = @ToId

		if @ToId is null
		begin
			set @Result = 'ToTransactionNotFound'
			goto end_sproc
		end

		if @ToAmount is null or @ToAmount <= 0
		begin
			set @Result = 'ToAmountProblematic'
			goto end_sproc
		end

		if @FromAmount <> @ToAmount
		begin
			set @Result = 'AmountMismatch'
			goto end_sproc
		end

		if @ToUserId is null
		begin
			set @Result = 'ToUserProblematic'
			goto end_sproc
		end

		if @ToRelatedTransactionId is null
		begin
			set @Result = 'ToProblematic'
			goto end_sproc
		end

		if @FromId <> @ToRelatedTransactionId
		begin
			set @Result = 'TransactionMismatch'
			goto end_sproc
		end

		if @ToAcknowledged = 1
		begin
			set @Result = 'ToAlreadyEnded'
			goto end_sproc
		end

		begin tran

		update AspNetUsers set Credit = Credit + @FromAmount output deleted.Credit into @tbl where Id = @FromUserId

		set @FromBalanceBefore = (select Credit from @tbl)

		if @FromBalanceBefore + @FromAmount < 0
		begin
			set @Result = 'NotEnoughCredit'

			rollback
		end
		else
		begin
			delete from @tbl

			update AspNetUsers set Credit = Credit + @FromAmount output deleted.Credit into @tbl where Id = @ToUserId

			set @ToBalanceBefore = (select Credit from @tbl)

			update SingleTraderCreditTransactions set Acknowledged = 1, BalanceBefore = @ToBalanceBefore, CreditTransactionAcknowledgeDate = getdate() where Id = @ToId
			update SingleTraderCreditTransactions set Acknowledged = 1, BalanceBefore = @FromBalanceBefore, CreditTransactionAcknowledgeDate = getdate() where Id = @FromId
			
			set @Result = 'Success'

			commit
		end
	end try
	begin catch
		if @@TRANCOUNT > 0
			rollback

		set @Result = 'Faulted'

		exec [dbo].[usp0_Log_error] null
	end catch
end_sproc:
	return
END

GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_get_page]    Script Date: 8/20/2018 6:25:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp1_Credit_singletrader_get_page]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp1_Credit_singletrader_get_page] AS' 
END
GO

ALTER PROCEDURE[dbo].[usp1_Credit_singletrader_get_page]
(
	@UserName				nvarchar(100),
	@CreditTransactionDate	datetime,
	@Acknowledged			bit,
	@TranType				varchar(20),
	@CurrentPage			int,
	@PageSize				int,
	@order					varchar(30),
	@RecordCount			int out,
	@PageCount				int out
)
AS
BEGIN
    SET NOCOUNT ON

	declare @query				nvarchar(max)
	declare @where				nvarchar(max)
	declare @from_row			int
	declare @to_row				int

	set @where = N' where 1 = 1'
		+ case when dbo.IsEmpty(@UserName) = 0 then ' and u.UserName like @UserName + ''%''' else '' end
		+ case when @CreditTransactionDate is null then '' else ' and ct.CreditTransactionDate = @CreditTransactionDate' end
		+ case when @TranType is null then '' else ' and ct.TranType = @TranType' end
		+ case when @Acknowledged is null then '' else ' and ct.Acknowledged = @Acknowledged' end

	set @query = 
	N'select
		@RecordCount = count(ct.Id)
	from			SingleTraderCreditTransactions	ct
		left  join	AspNetUsers			u	on ct.UserId = u.Id' +
	  @where

	print @query

	EXECUTE sp_executesql @query, N'@UserName				nvarchar(100),
									@CreditTransactionDate	datetime,
									@Acknowledged			bit,
									@TranType				varchar(20),
									@RecordCount			int output',
									@UserName				= @UserName				,	
									@CreditTransactionDate	= @CreditTransactionDate,
									@Acknowledged			= @Acknowledged			,
									@TranType				= @TranType				,
									@RecordCount			= @RecordCount output

	exec [dbo].[usp0_Paging_calc] @CurrentPage	= @CurrentPage,
								  @PageSize		= @PageSize,
								  @RecordCount	= @RecordCount out,
								  @PageCount	= @PageCount out,
								  @from_row		= @from_row out,
								  @to_row		= @to_row out

	set @query = N'
	select q.*
	from
	(
		select
			ROW_NUMBER() over (order by ' +
				case when dbo.IsEmpty(@order) = 0 then @order else 'ct.Id desc' end +
			') as [Row],
			ct.Id,
			u.UserName,
			u.Credit,
			ct.Amount,
			ct.TranType,
			ct.Info,
			ct.Acknowledged,
			ct.CreditTransactionDate,
			ct.BalanceBefore
		from			SingleTraderCreditTransactions	ct
			left  join	AspNetUsers			u	on ct.UserId = u.Id' +
		  @where + '
	) q
	where q.Row between @from_row and @to_row'

	print @query

	EXECUTE sp_executesql @query, N'@UserName				nvarchar(100),
									@CreditTransactionDate	datetime,
									@Acknowledged			bit,
									@TranType				varchar(20),
									@from_row				int,
									@to_row					int',
									@UserName				= @UserName				,	
									@CreditTransactionDate	= @CreditTransactionDate,
									@Acknowledged			= @Acknowledged			,
									@TranType				= @TranType				,
									@from_row				= @from_row				,
									@to_row					= @to_row
END


GO
/****** Object:  StoredProcedure [dbo].[usp1_Credit_singletrader_transfer]    Script Date: 8/20/2018 6:25:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp1_Credit_singletrader_transfer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp1_Credit_singletrader_transfer] AS' 
END
GO
ALTER PROCEDURE [dbo].[usp1_Credit_singletrader_transfer]
(
	@Result varchar(80) out,
	@FromUserName nvarchar(50),
	@ToUserName nvarchar(50),
	@Amount decimal(18,2),
	@FromInfo nvarchar(4000),
	@ToInfo nvarchar(4000)
)
AS
BEGIN
	SET NOCOUNT ON;

	begin try
		declare @FromId int
		declare @ToId int
		declare @FromUserId int
		declare @ToUserId int
		declare @FromBalanceBefore decimal(18, 2)
		declare @ToBalanceBefore decimal(18, 2)
		declare @tbl table(Credit decimal(18, 2))

		if dbo.IsEmpty(@FromUserName) = 1
		begin
			set @Result = 'NoFromUserName'
			goto end_sproc
		end

		select @FromUserId = u.Id from AspNetUsers u where u.UserName = @FromUserName
		if @FromUserId is null
		begin
			set @Result = 'InvalidFromUser'
			goto end_sproc
		end

		if dbo.IsEmpty(@ToUserName) = 1
		begin
			set @Result = 'NoToUserName'
			goto end_sproc
		end

		select @ToUserId = u.Id from AspNetUsers u where u.UserName = @ToUserName
		if @ToUserId is null
		begin
			set @Result = 'InvalidToUser'
			goto end_sproc
		end

		if isnull(@Amount, 0) = 0
		begin
			set @Result = 'NoAmount'
			goto end_sproc
		end
	
		if @Amount < 0
		begin
			set @Result = 'InvalidAmount'
			goto end_sproc
		end

		begin tran

		update AspNetUsers set Credit = Credit - @Amount output deleted.Credit into @tbl where Id = @FromUserId

		set @FromBalanceBefore = (select Credit from @tbl)

		if @FromBalanceBefore - @Amount < 0
		begin
			set @Result = 'NotEnoughCredit'

			rollback
		end
		else
		begin
			delete from @tbl

			update AspNetUsers set Credit = Credit + @Amount output deleted.Credit into @tbl where Id = @ToUserId

			set @ToBalanceBefore = (select Credit from @tbl)

			insert into SingleTraderCreditTransactions(UserId, Amount, Info, BalanceBefore, Acknowledged, CreditTransactionAcknowledgeDate)
			values (@ToUserId, @Amount, @ToInfo, @ToBalanceBefore, 1, getdate())

			set @ToId = SCOPE_IDENTITY()

			insert into SingleTraderCreditTransactions(UserId, Amount, Info, BalanceBefore, Acknowledged, CreditTransactionAcknowledgeDate, RelatedTransactionId)
			values (@FromUserId, @Amount, @FromInfo, @FromBalanceBefore, 1, getdate(), @ToId)

			set @FromId = SCOPE_IDENTITY()

			update SingleTraderCreditTransactions set RelatedTransactionId = @FromId where Id = @ToId

			set @Result = 'Success'

			commit
		end
	end try
	begin catch
		if @@TRANCOUNT > 0
			rollback

		set @Result = 'Faulted'

		exec [dbo].[usp0_Log_error] null
	end catch
end_sproc:
	return
END

GO
