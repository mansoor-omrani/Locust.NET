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
print 'Creating usp0_Log_error sproc ...'
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

print 'Creating IsEmpty UDF ...'

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
	 CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED 
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



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

if not exists (select 1 from sys.tables where name = 'ApplicationLogs')
begin
	print 'Creating ApplicationLogs table ...'

	CREATE TABLE [dbo].[ApplicationLogs](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[LogDate] [datetime] NOT NULL,
		[Member] [nvarchar](200) NULL,
		[Line] [int] NULL,
		[FilePath] [nvarchar](2000) NULL,
		[Category] [nvarchar](4000) NULL,
		[Message] [nvarchar](max) NULL,
	 CONSTRAINT [PK_ApplicationLogs] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	ALTER TABLE [dbo].[ApplicationLogs] ADD CONSTRAINT [DF_ApplicationLogs_LogDate]  DEFAULT (getdate()) FOR [LogDate]

	print 'created'
end
else
	print 'table ApplicationLogs already exists'
	
GO

print 'Checking usp0_Paging_calc sproc existence ...'

IF (OBJECT_ID('dbo.usp0_Paging_calc') IS NOT NULL)
begin
	print '		Already exists. dropping it ...'
	
	drop procedure dbo.usp0_Log_error

	print '		Dropped'
end

GO
print 'Creating usp0_Paging_calc sproc ...'
go

CREATE PROCEDURE [dbo].[usp0_Paging_calc]
(
	@CurrentPage	int out,
	@PageSize		int,
	@RecordCount	int out,
	@PageCount		int out,
	@FromRow		int out,
	@ToRow			int out
)
AS
BEGIN
	SET @CurrentPage = isnull(@CurrentPage, 0)
	IF @CurrentPage <= 0
		SET @CurrentPage = 1

	SET @PageSize = isnull(@PageSize, 0)
	IF @PageSize <= 0
		SET @PageSize = 10

	SET @RecordCount = isnull(@RecordCount, 0)
	IF @RecordCount <= 0
		SET @RecordCount = 0

	SET @PageCount = @RecordCount / @PageSize
	IF @RecordCount > @PageCount * @PageSize
		SET @PageCount = @PageCount + 1

	IF @CurrentPage > @PageCount
		SET @CurrentPage = @PageCount

	SET @FromRow = (@CurrentPage - 1) * @PageSize + 1
	SET @ToRow = @FromRow + @PageCount - 1
END
GO
print 'created'
GO


print 'Checking usp1_ApplicationLogs_get_page sproc existence ...'

IF (OBJECT_ID('dbo.usp1_ApplicationLogs_get_page') IS NOT NULL)
begin
	print '		Already exists. dropping it ...'
	
	drop procedure dbo.usp0_Log_error

	print '		Dropped'
end

GO
print 'Creating usp1_ApplicationLogs_get_page sproc ...'
go

CREATE PROCEDURE [dbo].[usp1_ApplicationLogs_get_page]
(
	@CurrentPage	int out,
	@PageSize		int out,
	@RecordCount	int out,
	@PageCount		int out,
	@Member			nvarchar(200),
	@Category		nvarchar(200),
	@Message		nvarchar(500),
	@FromDate		datetime,
	@ToDate			datetime,
	@OrderBy		nvarchar(100),
	@OrderDir		varchar(10)
)
as
begin
	declare @from_row	int
	declare @to_row		int
	declare @query		nvarchar(max)
	declare @where		nvarchar(1000)
	declare @ob			nvarchar(100)
	declare @od			varchar(10)

	set @where = N'
	where 1 = 1 ' +
		case when dbo.IsEmpty(@Member) = 1		then '' else ' and al.Member like @Member + N''%'' ' end +
		case when dbo.IsEmpty(@Category) = 1	then '' else ' and al.Category like @Category + N''%'' ' end +
		case when dbo.IsEmpty(@Message) = 1		then '' else ' and al.Message like N''%''+ @Message + N''%'' ' end +
		case when @FromDate is null				then '' else ' and al.LogDate >= @FromDate ' end +
		case when @ToDate is null				then '' else ' and al.LogDate < @ToDate ' end

	set @query = N'
	SET @RecordCount = 
	(
		select count(Id) from [dbo].[ApplicationLogs] al ' + @where +
	')'

	EXECUTE sp_executesql @query, N'@Member			nvarchar(200),
									@Category		nvarchar(200),
									@Message		nvarchar(500),
									@FromDate		datetime,
									@ToDate			datetime,
									@RecordCount	int output',
									@Member			= @Member,
									@Category		= @Category,
									@Message		= @Message,
									@FromDate		= @FromDate,
									@ToDate			= @ToDate,
									@RecordCount	= @RecordCount output

	exec [dbo].[usp0_Paging_calc] @CurrentPage	= @CurrentPage,
								  @PageSize		= @PageSize,
								  @RecordCount	= @RecordCount out,
								  @PageCount	= @PageCount out,
								  @fromrow		= @from_row out,
								  @torow		= @to_row out

	set @ob = TRIM(isnull(@OrderBy, ''))
	if @ob not in ('Id', 'LogDate', 'Member', 'Category', 'FilePath')
		set @ob = 'LogDate'

	set @od = TRIM(isnull(@OrderDir, ''))
	if @od not in ('asc', 'desc', 'ascending', 'descending')
		set @od = 'desc'
	
	set @od =	case	when @od = 'ascending' then 'asc'
						when @od = 'descending' then 'desc'
						else @od
				end
	
	set @query = N'
	select * from
	(
		select
			ROW_NUMBER() over(order by ' + @ob + ' ' + @od + ') as [Row],
			*
		from [dbo].[ApplicationLogs] al
		' + @where +
	') q where q.Row between @from_row and @to_row'

	EXECUTE sp_executesql @query, N'@Member			nvarchar(200),
									@Category		nvarchar(200),
									@Message		nvarchar(500),
									@FromDate		datetime,
									@ToDate			datetime,
									@from_row		int,
									@to_row			int',
									@Member			= @Member,
									@Category		= @Category,
									@Message		= @Message,
									@FromDate		= @FromDate,
									@ToDate			= @ToDate,
									@from_row		= @from_row,
									@to_row			= @to_row
end
go
print 'Created'
go


GO
print 'created'
GO


print 'Checking usp1_ApplicationLogs_purge sproc existence ...'

IF (OBJECT_ID('dbo.usp1_ApplicationLogs_purge') IS NOT NULL)
begin
	print '		Already exists. dropping it ...'
	
	drop procedure dbo.usp1_ApplicationLogs_purge

	print '		Dropped'
end

GO
print 'Creating usp1_ApplicationLogs_purge sproc ...'
go


CREATE PROCEDURE [dbo].[usp1_ApplicationLogs_purge]
(
	@Result			nvarchar(100) out,
	@Info			nvarchar(max) out,
	@FromDate		datetime,
	@ToDate			datetime
)
as
begin
	begin try
		if @FromDate is null and @ToDate is null
			truncate table dbo.ApplicationLogs
		else
		if @FromDate is null
			delete from dbo.ApplicationLogs where LogDate < @ToDate
		else
			delete from dbo.ApplicationLogs where LogDate between @FromDate and @ToDate

		set @Result = 'Success'
	end try
	begin catch
		set @Info = '{' +
						'  Line: ' + cast(ERROR_LINE() as varchar(10)) +
						', Message: "' + ERROR_MESSAGE() + '"' +
						', Number: ' + cast(ERROR_NUMBER() as varchar(10)) +
					'}'
		set @Result = 'Faulted'
	end catch
end

GO
print 'created'
GO