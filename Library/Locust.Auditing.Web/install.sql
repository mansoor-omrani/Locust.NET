SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if not exists (select 1 from sys.tables where name = 'Browsers')
begin
	CREATE TABLE [dbo].[Browsers](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
	 CONSTRAINT [PK_Browsers] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
	) ON [FLG_DATA]
end
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if not exists (select 1 from sys.tables where name = 'BrowserVersions')
begin
	CREATE TABLE [dbo].[BrowserVersions](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[BrowserId] [int] NOT NULL,
		[Version] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_BrowserVersions] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
	) ON [FLG_DATA]
end
GO

ALTER TABLE [dbo].[BrowserVersions]  WITH CHECK ADD  CONSTRAINT [FK_BrowserVersions_Browsers] FOREIGN KEY([BrowserId])
REFERENCES [dbo].[Browsers] ([Id])
GO
ALTER TABLE [dbo].[BrowserVersions] CHECK CONSTRAINT [FK_BrowserVersions_Browsers]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if not exists (select 1 from sys.tables where name = 'OperationTypes')
begin
	CREATE TABLE [dbo].[OperationTypes](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] [varchar](200) NOT NULL,
		[Title] [nvarchar](200) NULL,
		[Description] [nvarchar](1000) NULL,
		[Code] [varchar](50) NOT NULL,
		[ApplicationId] [int] NOT NULL,
	 CONSTRAINT [PK_OperationTypes] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
	) ON [FLG_DATA]
end
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if not exists (select 1 from sys.tables where name = 'OperationLogs')
begin
	CREATE TABLE [dbo].[OperationLogs](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[ApplicationId] [int] NOT NULL,
		[OperationTypeId] [int] NOT NULL,
		[UserName] [varchar](100) NULL,
		[RoleName] [varchar](50) NULL,
		[OperationDate] [datetime] NOT NULL,
		[LanguageId] [int] NULL,
		[RelatedRecordId] [int] NULL,
		[BrowserVersionId] [int] NULL,
		[IP] [varchar](64) NULL,
		[SessionId] [varchar](100) NULL,
		[AssignedCode] [nvarchar](500) NULL,
		[Data] [nvarchar](max) NULL,
	 CONSTRAINT [PK_OperationLogs] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_LOG]
	) ON [FLG_LOG] TEXTIMAGE_ON [FLG_LOG]
end
GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[OperationLogs] ADD  CONSTRAINT [DF_OperationLogs_OperationDate]  DEFAULT (getdate()) FOR [OperationDate]
GO
ALTER TABLE [dbo].[OperationLogs]  WITH CHECK ADD  CONSTRAINT [FK_OperationLogs_Applications] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([Id])
GO
ALTER TABLE [dbo].[OperationLogs] CHECK CONSTRAINT [FK_OperationLogs_Applications]
GO
ALTER TABLE [dbo].[OperationLogs]  WITH CHECK ADD  CONSTRAINT [FK_OperationLogs_BrowserVersions] FOREIGN KEY([BrowserVersionId])
REFERENCES [dbo].[BrowserVersions] ([Id])
GO
ALTER TABLE [dbo].[OperationLogs] CHECK CONSTRAINT [FK_OperationLogs_BrowserVersions]
GO
ALTER TABLE [dbo].[OperationLogs]  WITH CHECK ADD  CONSTRAINT [FK_OperationLogs_OperationTypes] FOREIGN KEY([OperationTypeId])
REFERENCES [dbo].[OperationTypes] ([Id])
GO
ALTER TABLE [dbo].[OperationLogs] CHECK CONSTRAINT [FK_OperationLogs_OperationTypes]
GO
ALTER TABLE [dbo].[OperationTypes]  WITH CHECK ADD  CONSTRAINT [FK_OperationTypes_Applications] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([Id])
GO
ALTER TABLE [dbo].[OperationTypes] CHECK CONSTRAINT [FK_OperationTypes_Applications]
GO


IF (OBJECT_ID('usp0_Audit_web_direct') IS NOT NULL)
begin
	print '''usp0_Audit_web_direct'' already exists. dropping it ...'
	
	drop procedure dbo.usp0_Audit_web_direct
end


GO
/****** Object:  StoredProcedure [dbo].[usp0_Audit_web_direct]    Script Date: 24/03/1396 11:52:04 Þ.Ù ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp0_Audit_web_direct]
(
	@result					varchar(100) out,
	@args					nvarchar(2000) out,
	@ApplicationID			int = 0,
	@UserName				varchar(100),
	@RoleName				varchar(50),
	@Lang					varchar(10),
	@RelatedRecordId		int,
	@BrowserName			nvarchar(50),
	@BrowserVersion			varchar(50),
	@Code					varchar(50),
	@SessionId				varchar(100),
	@AssignedCode			nvarchar(500),
	@IP						varchar(40),
	@Data					nvarchar(max) = null
)
as
begin
	set @result = 'None'

	declare @LanguageId int
	declare @BrowserVersionId int

	select @LanguageId = Id from dbo.Languages where ShortName = @Lang
	select @BrowserVersionId = bv.Id from [dbo].[BrowserVersions] bv inner join [dbo].[Browsers] b on bv.BrowserId = b.Id where b.Name = @BrowserName and bv.Version = @BrowserVersion
	
	if @BrowserVersionId is null
	begin
		declare @BrowserId int
		begin try
			begin tran

			select @BrowserId = Id from [dbo].[Browsers] where Name = @BrowserName
			if @BrowserId is null
			begin
				insert into [dbo].[Browsers](Name) values (@BrowserName)
				set @BrowserId = SCOPE_IDENTITY()
			end

			insert into [dbo].[BrowserVersions](BrowserId, [Version]) values (@BrowserId, @BrowserVersion)
			set @BrowserVersionId = SCOPE_IDENTITY()
			commit
		end try
		begin catch
			if @@TRANCOUNT > 0
				rollback
			
			set @BrowserVersionId = null
		end catch
	end

	begin try
		INSERT INTO [dbo].[OperationLogs]
			   ([ApplicationId]
			   ,[OperationTypeId]
			   ,[UserName]
			   ,[RoleName]
			   ,[LanguageId]
			   ,[RelatedRecordId]
			   ,[BrowserVersionId]
			   ,[IP]
			   ,[SessionId]
			   ,[AssignedCode]
			   ,[Data])
		VALUES
		(
			 @ApplicationID,
			(select Id from dbo.OperationTypes where ApplicationId = @ApplicationID and Code = @Code),
			case when dbo.IsEmpty(@UserName) = 0 then @UserName else null end,
			case when dbo.IsEmpty(@RoleName) = 0 then @RoleName else null end,
			@LanguageId,
			@RelatedRecordId,
			@BrowserVersionId,
			case when dbo.IsEmpty(@IP) = 0 then @IP else null end,
			case when dbo.IsEmpty(@SessionId) = 0 then @SessionId else null end,
			case when dbo.IsEmpty(@AssignedCode) = 0 then @AssignedCode else null end,
			case when dbo.IsEmpty(@Data) = 0 then @Data else null end
		)

		set @result = 'AuditSucceeded'
	end try
	begin catch
		exec dbo.usp0_Log_error @args out

		set @result = 'AuditFailed'
	end catch
end
GO
