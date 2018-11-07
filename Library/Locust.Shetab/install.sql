/****** Object:  Table [dbo].[BankTypes]    Script Date: 8/25/2018 11:50:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[CodeName] [varchar](50) NULL,
	[Icon] [nvarchar](200) NULL,
 CONSTRAINT [PK_BankTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
) ON [FLG_DATA]
GO
/****** Object:  Table [dbo].[BankTypeTexts]    Script Date: 8/25/2018 11:50:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankTypeTexts](
	[LanguageId] [int] NOT NULL,
	[RecordId] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_BankTypeTexts] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC,
	[RecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
) ON [FLG_DATA]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 8/25/2018 11:50:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentCode] [varchar](50) NOT NULL,
	[BankTypeId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Info] [nvarchar](250) NULL,
	[Data] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
) ON [FLG_DATA]
GO
/****** Object:  Table [dbo].[PaymentSteps]    Script Date: 8/25/2018 11:50:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentSteps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentId] [int] NOT NULL,
	[PaymentStepTypeId] [int] NOT NULL,
	[StepDate] [datetime] NOT NULL,
	[StepStatus] [varchar](20) NULL,
	[StepCode] [varchar](60) NULL,
	[Succeeded] [bit] NOT NULL,
	[StepData] [nvarchar](2000) NULL,
 CONSTRAINT [PK_PaymentSteps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
) ON [FLG_DATA]
GO
/****** Object:  Table [dbo].[PaymentStepTypes]    Script Date: 8/25/2018 11:50:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentStepTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[CodeName] [varchar](50) NULL,
 CONSTRAINT [PK_PaymentStepTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
) ON [FLG_DATA]
GO
/****** Object:  Table [dbo].[PaymentStepTypeTexts]    Script Date: 8/25/2018 11:50:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentStepTypeTexts](
	[LanguageId] [int] NOT NULL,
	[RecordId] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_PaymentStepTypeTexts] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC,
	[RecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
) ON [FLG_DATA]
GO
ALTER TABLE [dbo].[PaymentSteps] ADD  CONSTRAINT [DF_PaymentSteps_StepDate]  DEFAULT (getdate()) FOR [StepDate]
GO
ALTER TABLE [dbo].[BankTypes]  WITH CHECK ADD  CONSTRAINT [FK_BankTypes_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[BankTypes] CHECK CONSTRAINT [FK_BankTypes_Country]
GO
ALTER TABLE [dbo].[BankTypeTexts]  WITH CHECK ADD  CONSTRAINT [FK_BankTypeTexts_BankTypes] FOREIGN KEY([RecordId])
REFERENCES [dbo].[BankTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BankTypeTexts] CHECK CONSTRAINT [FK_BankTypeTexts_BankTypes]
GO
ALTER TABLE [dbo].[BankTypeTexts]  WITH CHECK ADD  CONSTRAINT [FK_BankTypeTexts_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[BankTypeTexts] CHECK CONSTRAINT [FK_BankTypeTexts_Languages]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_BankTypes] FOREIGN KEY([BankTypeId])
REFERENCES [dbo].[BankTypes] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_BankTypes]
GO
ALTER TABLE [dbo].[PaymentSteps]  WITH CHECK ADD  CONSTRAINT [FK_PaymentSteps_Payments] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaymentSteps] CHECK CONSTRAINT [FK_PaymentSteps_Payments]
GO
ALTER TABLE [dbo].[PaymentSteps]  WITH CHECK ADD  CONSTRAINT [FK_PaymentSteps_PaymentStepTypes] FOREIGN KEY([PaymentStepTypeId])
REFERENCES [dbo].[PaymentStepTypes] ([Id])
GO
ALTER TABLE [dbo].[PaymentSteps] CHECK CONSTRAINT [FK_PaymentSteps_PaymentStepTypes]
GO
ALTER TABLE [dbo].[PaymentStepTypeTexts]  WITH CHECK ADD  CONSTRAINT [FK_PaymentStepTypeTexts_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[PaymentStepTypeTexts] CHECK CONSTRAINT [FK_PaymentStepTypeTexts_Languages]
GO
ALTER TABLE [dbo].[PaymentStepTypeTexts]  WITH CHECK ADD  CONSTRAINT [FK_PaymentStepTypeTexts_PaymentStepTypes] FOREIGN KEY([RecordId])
REFERENCES [dbo].[PaymentStepTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaymentStepTypeTexts] CHECK CONSTRAINT [FK_PaymentStepTypeTexts_PaymentStepTypes]
GO
/****** Object:  StoredProcedure [dbo].[GenerateRandom]    Script Date: 8/25/2018 11:50:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GenerateRandom](@length int, @type varchar(20), @customchars varchar(100), @result varchar(500) out)
AS
BEGIN
	declare @upper_chars char(26) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
	declare @lower_chars char(26) = 'abcdefghijklmnopqrstuvwxyz'
	declare @digits char(10) = '0123456789'
	declare @digits_no_zero char(9) = '123456789'
	declare @chars varchar(100) = ''
	declare @x tinyint
	declare @max tinyint

	if isnull(@length, 0) <= 0
		set @length = 8

	if @type in ('Alpha', 'AlphaNum') or charindex('Upper', @type) > 0
		set @chars = @chars + @upper_chars
	if @type in ('Alpha', 'AlphaNum') or charindex('Lower', @type) > 0
		set @chars = @chars + @lower_chars
	if charindex('Num', @type) > 0
		set @chars = @chars + @digits
	if charindex('NoZero', @type) > 0
		set @chars = @chars + @digits_no_zero
	if charindex('Custom', @type) > 0
		set @chars = @chars + @customchars
	
	set @max = len(@chars)

	while ( 1 = 1 )
	begin
		set @result = ''
		while len(@result) < @length
		begin
			set @x = FLOOR(rand() * @max + 1)
			set @result = @result + substring(@chars, @x, 1)
		end

		if not exists (select 1 from Payments where PaymentCode = @result)
			break
	end
END
GO
/****** Object:  StoredProcedure [dbo].[usp1_Payment_save_begin_step]    Script Date: 8/25/2018 11:50:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[usp1_Payment_save_begin_step]
(
	@Result varchar(80) out,
	@PaymentCode varchar(50),
	@BankType varchar(50),
	@Amount decimal(18, 2),
	@Info nvarchar(250),
	@Data nvarchar(4000),
	@StepCode varchar(60),
	@StepStatus varchar(20),
	@StepDate datetime,
	@StepSucceeded bit,
	@StepData nvarchar(2000)
)
AS
BEGIN
    SET NOCOUNT ON

	declare @PaymentId int
	declare @BankTypeId int
	declare @PaymentStepTypeId int

	while ( 1 = 1 )
	begin
		if dbo.IsEmpty(@PaymentCode) = 1
		begin
			set @Result = 'NoPaymentCode'
			break
		end
		
		if dbo.IsEmpty(@BankType) = 1
		begin
			set @Result = 'NoBankCode'
			break
		end
		
		set @BankTypeId = (select Id from BankTypes where CodeName = @BankType)

		if @BankTypeId is null
		begin
			set @Result = 'InvalidBankCode'
			break
		end
			
		if isnull(@Amount , 0) = 0
		begin
			set @Result = 'NoAmount'
			break
		end
			
		if isnull(@Amount , 0) < 0
		begin
			set @Result = 'InvalidAmount'
			break
		end
			
		set @PaymentStepTypeId = (select Id from PaymentStepTypes where CodeName = 'BeginPayment')
	
		if @PaymentStepTypeId is null
		begin
			set @Result = 'BeginPaymentStepTypeNotFound'
			break
		end

		if dbo.IsEmpty(@StepCode) = 1
		begin
			set @Result = 'NoStepCode'
			break
		end

		if dbo.IsEmpty(@StepStatus) = 1
		begin
			set @Result = 'NoStepStatus'
			break
		end

		if @StepDate is null
			set @StepDate = getdate()

		if @StepSucceeded is null
			set @StepSucceeded = 0

		begin try
			begin tran

			insert into [dbo].[Payments]
			(
				PaymentCode,
				BankTypeId,
				Amount,
				Info,
				[Data]
			)
			values
			(
				@PaymentCode,
				@BankTypeId,
				@Amount,
				@Info,
				case when dbo.IsEmpty(@Data) = 1 then null else @Data end
			)

			set @PaymentId = SCOPE_IDENTITY()

			INSERT INTO [dbo].[PaymentSteps]
			   ([PaymentId]
			   ,[PaymentStepTypeId]
			   ,[StepDate]
			   ,[StepStatus]
			   ,[StepCode]
			   ,[Succeeded]
			   ,[StepData])
			 VALUES
				(@PaymentId
				,@PaymentStepTypeId
				,@StepDate
				,@StepStatus
				,@StepCode
				,@StepSucceeded
				,case when dbo.IsEmpty(@StepData) = 1 then null else @StepData end)

			commit

			set @Result = 'Success'
		end try
		begin catch
			if @@TRANCOUNT > 0
				rollback

			exec dbo.usp0_Log_error ''

			print 'error: ' + error_message()

			set @Result = 'Faulted'
		end catch

		break
	end
END


GO
/****** Object:  StoredProcedure [dbo].[usp1_Payment_save_end_step]    Script Date: 8/25/2018 11:50:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[usp1_Payment_save_end_step]
(
	@Result varchar(80) out,
	@PaymentCode varchar(50),
	@BankType varchar(50),
	@BeginStepCode varchar(60),
	@StepCode varchar(60),
	@StepStatus varchar(20),
	@StepDate datetime,
	@StepSucceeded bit,
	@StepData nvarchar(2000)
)
AS
BEGIN
    SET NOCOUNT ON

	declare @PaymentId int
	declare @BankTypeId int
	declare @PaymentStepTypeId int

	while ( 1 = 1 )
	begin
		if dbo.IsEmpty(@PaymentCode) = 1
		begin
			set @Result = 'NoPaymentCode'
			break
		end
		
		set @PaymentId =
			(
				select	p.Id
				from			Payments			p
					inner join	PaymentSteps		ps	on p.Id = ps.PaymentId
					inner join	PaymentStepTypes	pst	on ps.PaymentStepTypeId = pst.Id
					inner join	BankTypes			bt	on p.BankTypeId = bt.Id
				where bt.CodeName = @BankType and p.PaymentCode = @PaymentCode and ps.StepCode = @BeginStepCode and pst.CodeName = 'BeginPayment' and ps.Succeeded = 1
			)

		if @PaymentId is null
		begin
			set @Result = 'BeginPaymentNotFound'
			break
		end

		set @PaymentStepTypeId = (select Id from PaymentStepTypes where CodeName = 'EndPayment')
	
		if @PaymentStepTypeId is null
		begin
			set @Result = 'EndPaymentStepTypeNotFound'
			break
		end

		if dbo.IsEmpty(@StepCode) = 1
		begin
			set @Result = 'NoStepCode'
			break
		end

		if dbo.IsEmpty(@StepStatus) = 1
		begin
			set @Result = 'NoStepStatus'
			break
		end

		if @StepDate is null
			set @StepDate = getdate()

		if @StepSucceeded is null
			set @StepSucceeded = 0

		begin try
			INSERT INTO [dbo].[PaymentSteps]
			   ([PaymentId]
			   ,[PaymentStepTypeId]
			   ,[StepDate]
			   ,[StepStatus]
			   ,[StepCode]
			   ,[Succeeded]
			   ,[StepData])
			 VALUES
				(@PaymentId
				,@PaymentStepTypeId
				,@StepDate
				,@StepStatus
				,@StepCode
				,@StepSucceeded
				,case when dbo.IsEmpty(@StepData) = 1 then null else @StepData end)

			set @Result = 'Success'
		end try
		begin catch
			exec dbo.usp0_Log_error ''

			print 'error: ' + error_message()

			set @Result = 'Faulted'
		end catch

		break
	end
END


GO
/****** Object:  StoredProcedure [dbo].[usp1_Payment_save_reversal_step]    Script Date: 8/25/2018 11:50:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[usp1_Payment_save_reversal_step]
(
	@Result varchar(80) out,
	@PaymentCode varchar(50),
	@BankType varchar(50),
	@StepStatus varchar(20),
	@StepDate datetime,
	@StepSucceeded bit,
	@StepData nvarchar(2000)
)
AS
BEGIN
    SET NOCOUNT ON

	declare @PaymentId int
	declare @BankTypeId int
	declare @PaymentStepTypeId int

	begin try
		while ( 1 = 1 )
		begin
			if dbo.IsEmpty(@PaymentCode) = 1
			begin
				set @Result = 'NoPaymentCode'
				break
			end
		
			set @PaymentId =
				(
					select	p.Id
					from			Payments			p
						inner join	BankTypes			bt	on p.BankTypeId = bt.Id
					where bt.CodeName = @BankType and p.PaymentCode = @PaymentCode
				)

			if @PaymentId is null
			begin
				set @Result = 'BeginPaymentNotFound'
				break
			end

			set @PaymentStepTypeId = (select Id from PaymentStepTypes where CodeName = 'ReversalPayment')
	
			if @PaymentStepTypeId is null
			begin
				set @Result = 'ReversalPaymentStepTypeNotFound'
				break
			end

			if dbo.IsEmpty(@StepStatus) = 1
			begin
				set @Result = 'NoStepStatus'
				break
			end

			if @StepDate is null
				set @StepDate = getdate()

			if @StepSucceeded is null
				set @StepSucceeded = 0

			begin try
				INSERT INTO [dbo].[PaymentSteps]
				   ([PaymentId]
				   ,[PaymentStepTypeId]
				   ,[StepDate]
				   ,[StepStatus]
				   ,[Succeeded]
				   ,[StepData])
				 VALUES
					(@PaymentId
					,@PaymentStepTypeId
					,@StepDate
					,@StepStatus
					,@StepSucceeded
					,case when dbo.IsEmpty(@StepData) = 1 then null else @StepData end)

				set @Result = 'Success'
			end try
			begin catch
				exec dbo.usp0_Log_error ''

				print 'error: ' + error_message()

				set @Result = 'Faulted'
			end catch

			break
		end
	end try
	begin catch
		exec dbo.usp0_Log_error ''

		print 'error: ' + error_message()

		set @Result = 'Faulted'
	end catch
END


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کُد خرید یا سفارش. کُدی یکتا به ازای سفارش یا خرید محصول تولید میشود و مشخص میکند پرداخت فعلی مربوط به چه چیزی بوده است. با توجه به این که پرداخت میتواند موفق نباشد در جدول پرداخت ها چند رکورد با کُد خرید یکسان میتواند وجود داشته باشد.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Payments', @level2type=N'COLUMN',@level2name=N'PaymentCode'
GO
