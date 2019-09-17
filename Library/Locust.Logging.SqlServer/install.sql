SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

if not exists (select 1 from sys.tables where name = 'DbErrorLogs')
begin
	print 'Creating DbErrorLogs table ...'

	CREATE TABLE [dbo].[DbErrorLogs](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Command] [nvarchar](200) NULL,
		[Number] [int] NULL,
		[Description] [nvarchar](2048) NULL,
		[Line] [int] NULL,
		[State] [int] NULL,
		[Severity] [int] NULL,
		[Args] [nvarchar](2000) NULL,
		[ErrorLogDate] [datetime] NULL,
		[Procedure] [nvarchar](200) NULL,
	 CONSTRAINT [PK_DbErrorLogs] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	ALTER TABLE [dbo].[DbErrorLogs] ADD CONSTRAINT [DF_DbErrorLogs_ExceptionDate]  DEFAULT (getdate()) FOR [ErrorLogDate]

	print 'created'
end
else
	print 'table DbErrorLogs already exists'
	
GO

print 'Checking usp0_Log_error sproc existence ...'

IF (OBJECT_ID('dbo.usp0_Log_error') IS NOT NULL)
begin
	print '		Already exists. dropping it ...'
	
	drop procedure dbo.usp0_Log_error

	print '		Dropped'
end

GO
print 'Creating usp0_Log_error sproc existence ...'
go
/****** Object:  StoredProcedure [dbo].[usp0_Log_error]    Script Date: 5/13/2018 4:14:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp0_Log_error]
(
	@args		nvarchar(1000) out 
)
AS
BEGIN
	SET NOCOUNT ON;

	declare @error_line int
	declare @error_message nvarchar(2048)
	declare @error_number int
	declare @error_procedure nvarchar(500)
	declare @error_severity int
	declare @error_state int

	set @error_line			= ERROR_LINE()
	set @error_message		= ERROR_MESSAGE()
	set @error_number		= ERROR_NUMBER()
	set @error_procedure	= ERROR_PROCEDURE()
	set @error_severity		= ERROR_SEVERITY()
	set @error_state		= ERROR_STATE()

	declare @result nvarchar(1000)

	INSERT INTO [dbo].[DbErrorLogs]
    (
		 [Command]
        ,[Number]
        ,[Description]
        ,[Line]
        ,[State]
        ,[Severity]
        ,[Args]
	)
    VALUES
    (
		 @error_procedure
        ,@error_number
        ,@error_message
        ,@error_line
        ,@error_state
        ,@error_severity
        ,@args
	)

	set @result =
				'{' +
					 '"Line":'			+ cast(isnull(@error_line, 0) as varchar(20)) +
					',"Number":'		+ cast(isnull(@error_number, 0) as varchar(20)) +
					',"Message":"'		+ isnull(@error_message, '') + '"' +
					',"Procedure":"'	+ isnull(@error_procedure, '') + '"' +
					',"Severity":'		+ cast(isnull(@error_severity, 0) as varchar(20)) +
					',"Args":"'			+ isnull(@args, '') + '"' +
					',"State":'			+ cast(isnull(@error_state, 0) as varchar(20)) +
				'}'

	set @args = @result
END
go
print '		Created'

print 'Checking IsEmpty UDF existence ...'
go
IF (OBJECT_ID('dbo.IsEmpty') IS NOT NULL)
begin
	print '		Already exists. dropping it ...'
	
	drop function dbo.IsEmpty

	print '		Dropped'
end
go

print 'Creating IsEmpty UDF existence ...'

GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create function [dbo].[IsEmpty](@x nvarchar(max)) returns bit
as
begin
	declare @result bit = 0

	if len(ltrim(rtrim(ISNULL(@x, '')))) = 0
		set @result = 1

	return @result
end
GO

print '		Created'

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if not exists (select 1 from sys.tables where name = 'ExceptionLog')
begin
	print 'Creating ExceptionLog table ...'

	CREATE TABLE [dbo].[ExceptionLog](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[ExceptionDate] [datetime] NOT NULL,
		[Message] [nvarchar](4000) NULL,
		[Source] [nvarchar](500) NULL,
		[Member] [nvarchar](500) NULL,
		[FilePath] [nvarchar](1000) NULL,
		[Line] [int] NULL,
		[StackTrace] [nvarchar](max) NULL,
		[Data] [nvarchar](max) NULL,
		[Info] [nvarchar](max) NULL,
	 CONSTRAINT [@pkConstraintName] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	ALTER TABLE [dbo].[ExceptionLog] ADD  CONSTRAINT [DF_ExceptionLog_ExceptionDate]  DEFAULT (getdate()) FOR [ExceptionDate]

	print 'created'
end
else
	print 'table ExceptionLog already exists'
GO


