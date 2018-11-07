SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

if not exists (select 1 from sys.tables where name = 'OperationType')
begin
	CREATE TABLE [dbo].[OperationType](
		[OperationTypeId] [smallint] IDENTITY(1,1) NOT NULL,
		[AppId] [int] NOT NULL,
		[Name] [varchar](50) NULL,
		[Title] [nvarchar](50) NULL,
		[Code] [varchar](10) NULL,
		[Description] [nvarchar](250) NULL,
	 CONSTRAINT [PK_OperationType] PRIMARY KEY CLUSTERED 
	(
		[OperationTypeId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
end
GO

SET ANSI_PADDING ON
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
if not exists (select 1 from sys.tables where name = 'OperationLog')
begin
	CREATE TABLE [dbo].[OperationLog](
		[OperationLogId] [int] IDENTITY(1,1) NOT NULL,
		[AppId] [int] NOT NULL,
		[OperationTypeId] [smallint] NOT NULL,
		[OperationDate] [datetime] NOT NULL,
		[Host] [nvarchar(80)] NULL,
		[IP] [varchar(40)] NULL,
		[UserName] [varchar](100) NULL,
		[RoleName] [nvarchar](100) NULL,
		[IP] [varchar](40) NULL,
		[Data] [nvarchar](max) SPARSE  NULL,
	 CONSTRAINT [PK_OperationLog] PRIMARY KEY CLUSTERED 
	(
		[OperationLogId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_LOG]
	) ON [FLG_LOG] TEXTIMAGE_ON [PRIMARY]
end
GO

SET ANSI_PADDING ON
GO

if exists (select 1 from sys.tables where name = 'OperationLog')
	ALTER TABLE [dbo].[OperationLog] ADD  CONSTRAINT [DF_OperationLog_OperationDate]  DEFAULT (getdate()) FOR [OperationDate]
GO

if exists (select 1 from sys.tables where name = 'OperationLog') and exists (select 1 from sys.tables where name = 'Application')
	ALTER TABLE [dbo].[OperationLog]  WITH CHECK ADD  CONSTRAINT [FK_OperationLog_Application] FOREIGN KEY([AppId]) REFERENCES [dbo].[Application] ([AppId])
GO
if exists (select 1 from sys.tables where name = 'OperationLog') and exists (select 1 from sys.tables where name = 'Application')
	ALTER TABLE [dbo].[OperationLog] CHECK CONSTRAINT [FK_OperationLog_Application]
GO

if exists (select 1 from sys.tables where name = 'OperationLog') and exists (select 1 from sys.tables where name = 'OperationType')
	ALTER TABLE [dbo].[OperationLog]  WITH CHECK ADD  CONSTRAINT [FK_OperationLog_OperationType] FOREIGN KEY([OperationTypeId]) REFERENCES [dbo].[OperationType] ([OperationTypeId])
GO
if exists (select 1 from sys.tables where name = 'OperationLog') and exists (select 1 from sys.tables where name = 'OperationType')
	ALTER TABLE [dbo].[OperationLog] CHECK CONSTRAINT [FK_OperationLog_OperationType]
GO

IF (OBJECT_ID('usp0_Audit_direct') IS NOT NULL)
begin
	print '''usp0_Audit_direct'' already exists. dropping it ...'
	
	drop procedure dbo.usp0_Audit_direct
end


GO
/****** Object:  StoredProcedure [dbo].[usp0_Audit_direct]    Script Date: 24/03/1396 11:52:04 Þ.Ù ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp0_Audit_direct]
(
	@AppID					INT = 0,
	@Host					VARCHAR(80) = null,
	@IP						VARCHAR(40) = null,
	@Username				nvarchar(30) = null,
	@Role					nvarchar(30) = null,
	@Code					varchar(50),
	@Data					nvarchar(max) = null
)
as
begin
	insert into [dbo].[OperationLogTbl]
	(
		 [AppId]
		,[Host]
		,IP
		,[UserName]
		,[RoleName]
		,[OperationTypeId]
		,[Data]
	)
	values
	(
		 (select AppId from ApplicationTbl where AppId = @AppId)
		,@Host
		,case when dbo.IsEmpty(@IP) = 0 then @IP else null end
		,@Username
		,@Role
		,(select OperationTypeId from base.OperationTypeTbl where AppId = @AppId and Code = @Code)
		,case when dbo.IsEmpty(@Data) = 0 then @Data else null end
	)
end
GO
IF (OBJECT_ID('usp0_Audit_by_context') IS NOT NULL)
begin
	print '''usp0_Audit_by_context'' already exists. dropping it ...'
	
	drop procedure dbo.usp0_Audit_by_context
end
GO
/****** Object:  StoredProcedure [dbo].[usp0_Audit_by_context]    Script Date: 24/03/1396 11:52:04 Þ.Ù ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp0_Audit_by_context]
(
	@Code varchar(50),
	@Data nvarchar(max) = null
)
as
begin
	DECLARE @AppID		INT = 0
	DECLARE @Host		VARCHAR(80) = null
	DECLARE @IP			VARCHAR(40) = null
	DECLARE @Username	nvarchar(30)
	DECLARE @Role		nvarchar(30)

	exec dbo.usp0_Context_get @AppId out, @Host out, @IP out, @Username out, @Role out
	
	insert into [dbo].[OperationLogTbl]
	(
		 [AppId]
		,[Host]
		,[IP]
		,[UserName]
		,[RoleName]
		,[OperationTypeId]
		,[Data]
	)
	values
	(
		 (select AppId from ApplicationTbl where AppId = @AppId)
		,@Host
		,case when dbo.IsNullOrEmpty(@IP) = 0 then @IP else null end
		,@Username
		,@Role
		,(select OperationTypeId from base.OperationTypeTbl where AppId = @AppId and Code = @Code)
		,case when dbo.IsNullOrEmpty(@Data) = 0 then @Data else null end
	)
end
