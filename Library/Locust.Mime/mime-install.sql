GO
/****** Object:  Table [dbo].[FileTypes]    Script Date: 6/10/2018 10:15:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileTypes](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Extensions] [varchar](500) NULL,
 CONSTRAINT [PK_FileTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
) ON [FLG_DATA]
GO
/****** Object:  Table [dbo].[FileTypes_MimeTypes]    Script Date: 6/10/2018 10:15:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileTypes_MimeTypes](
	[FileTypeId] [tinyint] NOT NULL,
	[MimeTypeId] [smallint] NOT NULL,
 CONSTRAINT [PK_FileTypes_MimeTypes] PRIMARY KEY CLUSTERED 
(
	[FileTypeId] ASC,
	[MimeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
) ON [FLG_DATA]
GO
/****** Object:  Table [dbo].[Mimes]    Script Date: 6/10/2018 10:15:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mimes](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](85) NOT NULL,
	[Source] [varchar](15) NULL,
	[Compressible] [bit] NULL,
	[Charset] [varchar](10) NULL,
	[Extensions] [varchar](150) NULL,
 CONSTRAINT [PK_Mimes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
) ON [FLG_DATA]
GO
/****** Object:  Table [dbo].[MimeTypes]    Script Date: 6/10/2018 10:15:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MimeTypes](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[MimeId] [smallint] NOT NULL,
	[Extension] [varchar](20) NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_MimeTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
) ON [FLG_DATA]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FileTypeTexts](
	[LanguageId] [int] NOT NULL,
	[RecordId] [tinyint] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_FileTypeTexts] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC,
	[RecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FLG_DATA]
) ON [FLG_DATA]
GO

SET IDENTITY_INSERT [dbo].[FileTypes] ON 
GO
declare @FileTypeId int

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (1, '0', N'*.dll, *.cfg, *.exe')
set @FileTypeId = 1
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'System', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'سیستم', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (2, N'1', '*.*')
set @FileTypeId = 2
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'General', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'عمومی', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (3, N'2', '*.jpg, *.gif, *.png, *.pcx, *.bmp')
set @FileTypeId = 3
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Photo', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'عکس', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (4, N'3', N'*.avi, *.mp4, *.webm, *.wav, *.mp3')
set @FileTypeId = 4
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Multimedia', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'مالتی مدیا', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (5, N'4', N'*.avi, *.mp4, *.webm')
set @FileTypeId = 5
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Video', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'ویدئو', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (6, N'5', N'*.wav, *.mp3')
set @FileTypeId = 6
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Audio', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'صوت', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (7, N'6', N'*.doc, *.docx')
set @FileTypeId = 7
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Document', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'سند', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (8, N'7', N'*.txt')
set @FileTypeId = 8
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Text', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'سند متنی', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (9, N'8', NULL)
set @FileTypeId = 9
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Business Document', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'سند بیزینسی', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (10, N'9', NULL)
set @FileTypeId = 10
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Business', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'بیزینس', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (11, N'10', N'*.exe, *.rar, *.zip')
set @FileTypeId = 11
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Application', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'برنامه', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (12, N'11', N'*.pdf, *.epub')
set @FileTypeId = 12
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'eBook', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'کتاب الکترونیکی', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (13, N'12', N'*.cs, *.asp, *.aspx, *.vb, *.dll, *.exe, *.config')
set @FileTypeId = 13
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Development', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'برنامه‌نویسی و توسعه', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (14, N'13', N'*.psd, *.cdr')
set @FileTypeId = 14
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Design', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'طراحی', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (15, N'14', N'*.pdf, *.xls, *.xlsx')
set @FileTypeId = 15
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Report', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'گزارش', NULL)

INSERT [dbo].[FileTypes] ([Id], [Code], [Extensions]) VALUES (16, N'15', N'*.zip, *.rar, *.ace, *.tar, *.gz, *.lha')
set @FileTypeId = 16
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (1, @FileTypeId, N'Compresed', NULL)
INSERT INTO [dbo].[FileTypeTexts]([LanguageId],[RecordId],[Title],[Description]) VALUES (2, @FileTypeId, N'فایل فشرده', NULL)
GO
SET IDENTITY_INSERT [dbo].[FileTypes] OFF
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (3, 829)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (3, 832)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (3, 835)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (3, 836)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (3, 838)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (3, 878)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (4, 783)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (4, 803)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (4, 1019)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (4, 1048)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (4, 1064)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (5, 1019)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (5, 1048)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (5, 1064)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (6, 783)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (6, 803)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (7, 65)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (7, 458)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (8, 935)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (11, 75)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (11, 80)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (12, 21)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (12, 100)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (15, 100)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (15, 383)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (15, 456)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (16, 584)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (16, 660)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (16, 706)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (16, 722)
GO
INSERT [dbo].[FileTypes_MimeTypes] ([FileTypeId], [MimeTypeId]) VALUES (16, 768)
GO
SET IDENTITY_INSERT [dbo].[Mimes] ON 
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1, N'application/1d-interleaved-parityfec', N'iana', 0, N'UTF-8', NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (2, N'application/3gpdash-qoe-report+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (3, N'application/3gpp-ims+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (4, N'application/a2l', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (5, N'application/activemessage', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (6, N'application/alto-costmap+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (7, N'application/alto-costmapfilter+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (8, N'application/alto-directory+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (9, N'application/alto-endpointcost+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (10, N'application/alto-endpointcostparams+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (11, N'application/alto-endpointprop+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (12, N'application/alto-endpointpropparams+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (13, N'application/alto-error+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (14, N'application/alto-networkmap+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (15, N'application/alto-networkmapfilter+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (16, N'application/aml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (17, N'application/andrew-inset', N'iana', 0, NULL, N'ez')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (18, N'application/applefile', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (19, N'application/applixware', N'apache', 0, NULL, N'aw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (20, N'application/atf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (21, N'application/atfx', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (22, N'application/atom+xml', N'iana', 1, NULL, N'atom')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (23, N'application/atomcat+xml', N'iana', 0, NULL, N'atomcat')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (24, N'application/atomdeleted+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (25, N'application/atomicmail', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (26, N'application/atomsvc+xml', N'iana', 0, NULL, N'atomsvc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (27, N'application/atxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (28, N'application/auth-policy+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (29, N'application/bacnet-xdd+zip', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (30, N'application/batch-smtp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (31, N'application/bdoc', NULL, 0, NULL, N'bdoc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (32, N'application/beep+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (33, N'application/calendar+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (34, N'application/calendar+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (35, N'application/call-completion', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (36, N'application/cals-1840', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (37, N'application/cbor', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (38, N'application/ccmp+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (39, N'application/ccxml+xml', N'iana', 0, NULL, N'ccxml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (40, N'application/cdfx+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (41, N'application/cdmi-capability', N'iana', 0, NULL, N'cdmia')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (42, N'application/cdmi-container', N'iana', 0, NULL, N'cdmic')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (43, N'application/cdmi-domain', N'iana', 0, NULL, N'cdmid')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (44, N'application/cdmi-object', N'iana', 0, NULL, N'cdmio')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (45, N'application/cdmi-queue', N'iana', 0, NULL, N'cdmiq')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (46, N'application/cdni', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (47, N'application/cea', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (48, N'application/cea-2018+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (49, N'application/cellml+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (50, N'application/cfw', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (51, N'application/cms', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (52, N'application/cnrp+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (53, N'application/coap-group+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (54, N'application/commonground', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (55, N'application/conference-info+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (56, N'application/cpl+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (57, N'application/csrattrs', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (58, N'application/csta+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (59, N'application/cstadata+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (60, N'application/csvm+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (61, N'application/cu-seeme', N'apache', 0, NULL, N'cu')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (62, N'application/cybercash', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (63, N'application/dart', NULL, 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (64, N'application/dash+xml', N'iana', 0, NULL, N'mpd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (65, N'application/dashdelta', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (66, N'application/davmount+xml', N'iana', 0, NULL, N'davmount')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (67, N'application/dca-rft', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (68, N'application/dcd', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (69, N'application/dec-dx', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (70, N'application/dialog-info+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (71, N'application/dicom', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (72, N'application/dii', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (73, N'application/dit', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (74, N'application/dns', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (75, N'application/docbook+xml', N'apache', 0, NULL, N'dbk')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (76, N'application/dskpp+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (77, N'application/dssc+der', N'iana', 0, NULL, N'dssc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (78, N'application/dssc+xml', N'iana', 0, NULL, N'xdssc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (79, N'application/dvcs', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (80, N'application/ecmascript', N'iana', 1, NULL, N'ecma')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (81, N'application/edi-consent', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (82, N'application/edi-x12', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (83, N'application/edifact', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (84, N'application/efi', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (85, N'application/emergencycalldata.comment+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (86, N'application/emergencycalldata.deviceinfo+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (87, N'application/emergencycalldata.providerinfo+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (88, N'application/emergencycalldata.serviceinfo+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (89, N'application/emergencycalldata.subscriberinfo+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (90, N'application/emma+xml', N'iana', 0, NULL, N'emma')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (91, N'application/emotionml+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (92, N'application/encaprtp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (93, N'application/epp+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (94, N'application/epub+zip', N'iana', 0, NULL, N'epub')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (95, N'application/eshop', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (96, N'application/exi', N'iana', 0, NULL, N'exi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (97, N'application/fastinfoset', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (98, N'application/fastsoap', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (99, N'application/fdt+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (100, N'application/fits', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (101, N'application/font-sfnt', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (102, N'application/font-tdpfr', N'iana', 0, NULL, N'pfr')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (103, N'application/font-woff', N'iana', 0, NULL, N'woff')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (104, N'application/font-woff2', NULL, 0, NULL, N'woff2')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (105, N'application/framework-attributes+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (106, N'application/gml+xml', N'apache', 0, NULL, N'gml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (107, N'application/gpx+xml', N'apache', 0, NULL, N'gpx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (108, N'application/gxf', N'apache', 0, NULL, N'gxf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (109, N'application/gzip', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (110, N'application/h224', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (111, N'application/held+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (112, N'application/http', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (113, N'application/hyperstudio', N'iana', 0, NULL, N'stk')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (114, N'application/ibe-key-request+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (115, N'application/ibe-pkg-reply+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (116, N'application/ibe-pp-data', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (117, N'application/iges', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (118, N'application/im-iscomposing+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (119, N'application/index', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (120, N'application/index.cmd', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (121, N'application/index.obj', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (122, N'application/index.response', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (123, N'application/index.vnd', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (124, N'application/inkml+xml', N'iana', 0, NULL, N'ink, inkml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (125, N'application/iotp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (126, N'application/ipfix', N'iana', 0, NULL, N'ipfix')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (127, N'application/ipp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (128, N'application/isup', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (129, N'application/its+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (130, N'application/java-archive', N'apache', 0, NULL, N'jar, war, ear')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (131, N'application/java-serialized-object', N'apache', 0, NULL, N'ser')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (132, N'application/java-vm', N'apache', 0, NULL, N'class')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (133, N'application/javascript', N'iana', 1, N'UTF-8', N'js')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (134, N'application/jose', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (135, N'application/jose+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (136, N'application/jrd+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (137, N'application/json', N'iana', 1, N'UTF-8', N'json, map')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (138, N'application/json-patch+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (139, N'application/json-seq', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (140, N'application/json5', NULL, 0, NULL, N'json5')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (141, N'application/jsonml+json', N'apache', 1, NULL, N'jsonml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (142, N'application/jwk+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (143, N'application/jwk-set+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (144, N'application/jwt', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (145, N'application/kpml-request+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (146, N'application/kpml-response+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (147, N'application/ld+json', N'iana', 1, NULL, N'jsonld')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (148, N'application/link-format', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (149, N'application/load-control+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (150, N'application/lost+xml', N'iana', 0, NULL, N'lostxml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (151, N'application/lostsync+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (152, N'application/lxf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (153, N'application/mac-binhex40', N'iana', 0, NULL, N'hqx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (154, N'application/mac-compactpro', N'apache', 0, NULL, N'cpt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (155, N'application/macwriteii', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (156, N'application/mads+xml', N'iana', 0, NULL, N'mads')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (157, N'application/manifest+json', NULL, 1, N'UTF-8', N'webmanifest')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (158, N'application/marc', N'iana', 0, NULL, N'mrc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (159, N'application/marcxml+xml', N'iana', 0, NULL, N'mrcx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (160, N'application/mathematica', N'iana', 0, NULL, N'ma, nb, mb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (161, N'application/mathml+xml', N'iana', 0, NULL, N'mathml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (162, N'application/mathml-content+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (163, N'application/mathml-presentation+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (164, N'application/mbms-associated-procedure-description+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (165, N'application/mbms-deregister+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (166, N'application/mbms-envelope+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (167, N'application/mbms-msk+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (168, N'application/mbms-msk-response+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (169, N'application/mbms-protection-description+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (170, N'application/mbms-reception-report+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (171, N'application/mbms-register+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (172, N'application/mbms-register-response+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (173, N'application/mbms-schedule+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (174, N'application/mbms-user-service-description+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (175, N'application/mbox', N'iana', 0, NULL, N'mbox')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (176, N'application/media-policy-dataset+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (177, N'application/media_control+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (178, N'application/mediaservercontrol+xml', N'iana', 0, NULL, N'mscml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (179, N'application/merge-patch+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (180, N'application/metalink+xml', N'apache', 0, NULL, N'metalink')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (181, N'application/metalink4+xml', N'iana', 0, NULL, N'meta4')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (182, N'application/mets+xml', N'iana', 0, NULL, N'mets')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (183, N'application/mf4', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (184, N'application/mikey', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (185, N'application/mods+xml', N'iana', 0, NULL, N'mods')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (186, N'application/moss-keys', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (187, N'application/moss-signature', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (188, N'application/mosskey-data', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (189, N'application/mosskey-request', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (190, N'application/mp21', N'iana', 0, NULL, N'm21, mp21')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (191, N'application/mp4', N'iana', 0, NULL, N'mp4s, m4p')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (192, N'application/mpeg4-generic', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (193, N'application/mpeg4-iod', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (194, N'application/mpeg4-iod-xmt', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (195, N'application/mrb-consumer+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (196, N'application/mrb-publish+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (197, N'application/msc-ivr+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (198, N'application/msc-mixer+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (199, N'application/msword', N'iana', 0, NULL, N'doc, dot')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (200, N'application/mxf', N'iana', 0, NULL, N'mxf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (201, N'application/nasdata', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (202, N'application/news-checkgroups', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (203, N'application/news-groupinfo', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (204, N'application/news-transmission', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (205, N'application/nlsml+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (206, N'application/nss', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (207, N'application/ocsp-request', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (208, N'application/ocsp-response', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (209, N'application/octet-stream', N'iana', 0, NULL, N'bin, dms, lrf, mar, so, dist, distz, pkg, bpk, dump, elc, deploy, exe, dll, deb, dmg, iso, img, msi, msp, msm, buffer')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (210, N'application/oda', N'iana', 0, NULL, N'oda')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (211, N'application/odx', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (212, N'application/oebps-package+xml', N'iana', 0, NULL, N'opf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (213, N'application/ogg', N'iana', 0, NULL, N'ogx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (214, N'application/omdoc+xml', N'apache', 0, NULL, N'omdoc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (215, N'application/onenote', N'apache', 0, NULL, N'onetoc, onetoc2, onetmp, onepkg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (216, N'application/oxps', N'iana', 0, NULL, N'oxps')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (217, N'application/p2p-overlay+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (218, N'application/parityfec', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (219, N'application/patch-ops-error+xml', N'iana', 0, NULL, N'xer')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (220, N'application/pdf', N'iana', 0, NULL, N'pdf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (221, N'application/pdx', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (222, N'application/pgp-encrypted', N'iana', 0, NULL, N'pgp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (223, N'application/pgp-keys', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (224, N'application/pgp-signature', N'iana', 0, NULL, N'asc, sig')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (225, N'application/pics-rules', N'apache', 0, NULL, N'prf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (226, N'application/pidf+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (227, N'application/pidf-diff+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (228, N'application/pkcs10', N'iana', 0, NULL, N'p10')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (229, N'application/pkcs12', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (230, N'application/pkcs7-mime', N'iana', 0, NULL, N'p7m, p7c')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (231, N'application/pkcs7-signature', N'iana', 0, NULL, N'p7s')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (232, N'application/pkcs8', N'iana', 0, NULL, N'p8')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (233, N'application/pkix-attr-cert', N'iana', 0, NULL, N'ac')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (234, N'application/pkix-cert', N'iana', 0, NULL, N'cer')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (235, N'application/pkix-crl', N'iana', 0, NULL, N'crl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (236, N'application/pkix-pkipath', N'iana', 0, NULL, N'pkipath')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (237, N'application/pkixcmp', N'iana', 0, NULL, N'pki')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (238, N'application/pls+xml', N'iana', 0, NULL, N'pls')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (239, N'application/poc-settings+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (240, N'application/postscript', N'iana', 1, NULL, N'ai, eps, ps')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (241, N'application/ppsp-tracker+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (242, N'application/problem+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (243, N'application/problem+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (244, N'application/provenance+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (245, N'application/prs.alvestrand.titrax-sheet', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (246, N'application/prs.cww', N'iana', 0, NULL, N'cww')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (247, N'application/prs.hpub+zip', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (248, N'application/prs.nprend', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (249, N'application/prs.plucker', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (250, N'application/prs.rdf-xml-crypt', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (251, N'application/prs.xsf+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (252, N'application/pskc+xml', N'iana', 0, NULL, N'pskcxml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (253, N'application/qsig', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (254, N'application/raptorfec', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (255, N'application/rdap+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (256, N'application/rdf+xml', N'iana', 1, NULL, N'rdf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (257, N'application/reginfo+xml', N'iana', 0, NULL, N'rif')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (258, N'application/relax-ng-compact-syntax', N'iana', 0, NULL, N'rnc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (259, N'application/remote-printing', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (260, N'application/reputon+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (261, N'application/resource-lists+xml', N'iana', 0, NULL, N'rl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (262, N'application/resource-lists-diff+xml', N'iana', 0, NULL, N'rld')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (263, N'application/rfc+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (264, N'application/riscos', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (265, N'application/rlmi+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (266, N'application/rls-services+xml', N'iana', 0, NULL, N'rs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (267, N'application/rpki-ghostbusters', N'iana', 0, NULL, N'gbr')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (268, N'application/rpki-manifest', N'iana', 0, NULL, N'mft')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (269, N'application/rpki-roa', N'iana', 0, NULL, N'roa')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (270, N'application/rpki-updown', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (271, N'application/rsd+xml', N'apache', 0, NULL, N'rsd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (272, N'application/rss+xml', N'apache', 1, NULL, N'rss')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (273, N'application/rtf', N'iana', 1, NULL, N'rtf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (274, N'application/rtploopback', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (275, N'application/rtx', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (276, N'application/samlassertion+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (277, N'application/samlmetadata+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (278, N'application/sbml+xml', N'iana', 0, NULL, N'sbml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (279, N'application/scaip+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (280, N'application/scim+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (281, N'application/scvp-cv-request', N'iana', 0, NULL, N'scq')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (282, N'application/scvp-cv-response', N'iana', 0, NULL, N'scs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (283, N'application/scvp-vp-request', N'iana', 0, NULL, N'spq')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (284, N'application/scvp-vp-response', N'iana', 0, NULL, N'spp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (285, N'application/sdp', N'iana', 0, NULL, N'sdp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (286, N'application/sep+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (287, N'application/sep-exi', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (288, N'application/session-info', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (289, N'application/set-payment', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (290, N'application/set-payment-initiation', N'iana', 0, NULL, N'setpay')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (291, N'application/set-registration', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (292, N'application/set-registration-initiation', N'iana', 0, NULL, N'setreg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (293, N'application/sgml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (294, N'application/sgml-open-catalog', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (295, N'application/shf+xml', N'iana', 0, NULL, N'shf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (296, N'application/sieve', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (297, N'application/simple-filter+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (298, N'application/simple-message-summary', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (299, N'application/simplesymbolcontainer', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (300, N'application/slate', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (301, N'application/smil', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (302, N'application/smil+xml', N'iana', 0, NULL, N'smi, smil')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (303, N'application/smpte336m', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (304, N'application/soap+fastinfoset', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (305, N'application/soap+xml', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (306, N'application/sparql-query', N'iana', 0, NULL, N'rq')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (307, N'application/sparql-results+xml', N'iana', 0, NULL, N'srx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (308, N'application/spirits-event+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (309, N'application/sql', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (310, N'application/srgs', N'iana', 0, NULL, N'gram')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (311, N'application/srgs+xml', N'iana', 0, NULL, N'grxml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (312, N'application/sru+xml', N'iana', 0, NULL, N'sru')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (313, N'application/ssdl+xml', N'apache', 0, NULL, N'ssdl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (314, N'application/ssml+xml', N'iana', 0, NULL, N'ssml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (315, N'application/tamp-apex-update', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (316, N'application/tamp-apex-update-confirm', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (317, N'application/tamp-community-update', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (318, N'application/tamp-community-update-confirm', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (319, N'application/tamp-error', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (320, N'application/tamp-sequence-adjust', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (321, N'application/tamp-sequence-adjust-confirm', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (322, N'application/tamp-status-query', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (323, N'application/tamp-status-response', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (324, N'application/tamp-update', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (325, N'application/tamp-update-confirm', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (326, N'application/tar', NULL, 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (327, N'application/tei+xml', N'iana', 0, NULL, N'tei, teicorpus')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (328, N'application/thraud+xml', N'iana', 0, NULL, N'tfi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (329, N'application/timestamp-query', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (330, N'application/timestamp-reply', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (331, N'application/timestamped-data', N'iana', 0, NULL, N'tsd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (332, N'application/ttml+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (333, N'application/tve-trigger', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (334, N'application/ulpfec', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (335, N'application/urc-grpsheet+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (336, N'application/urc-ressheet+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (337, N'application/urc-targetdesc+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (338, N'application/urc-uisocketdesc+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (339, N'application/vcard+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (340, N'application/vcard+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (341, N'application/vemmi', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (342, N'application/vividence.scriptfile', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (343, N'application/vnd.3gpp-prose+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (344, N'application/vnd.3gpp-prose-pc3ch+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (345, N'application/vnd.3gpp.access-transfer-events+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (346, N'application/vnd.3gpp.bsf+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (347, N'application/vnd.3gpp.mid-call+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (348, N'application/vnd.3gpp.pic-bw-large', N'iana', 0, NULL, N'plb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (349, N'application/vnd.3gpp.pic-bw-small', N'iana', 0, NULL, N'psb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (350, N'application/vnd.3gpp.pic-bw-var', N'iana', 0, NULL, N'pvb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (351, N'application/vnd.3gpp.sms', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (352, N'application/vnd.3gpp.sms+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (353, N'application/vnd.3gpp.srvcc-ext+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (354, N'application/vnd.3gpp.srvcc-info+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (355, N'application/vnd.3gpp.state-and-event-info+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (356, N'application/vnd.3gpp.ussd+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (357, N'application/vnd.3gpp2.bcmcsinfo+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (358, N'application/vnd.3gpp2.sms', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (359, N'application/vnd.3gpp2.tcap', N'iana', 0, NULL, N'tcap')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (360, N'application/vnd.3lightssoftware.imagescal', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (361, N'application/vnd.3m.post-it-notes', N'iana', 0, NULL, N'pwn')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (362, N'application/vnd.accpac.simply.aso', N'iana', 0, NULL, N'aso')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (363, N'application/vnd.accpac.simply.imp', N'iana', 0, NULL, N'imp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (364, N'application/vnd.acucobol', N'iana', 0, NULL, N'acu')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (365, N'application/vnd.acucorp', N'iana', 0, NULL, N'atc, acutc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (366, N'application/vnd.adobe.air-application-installer-package+zip', N'apache', 0, NULL, N'air')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (367, N'application/vnd.adobe.flash.movie', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (368, N'application/vnd.adobe.formscentral.fcdt', N'iana', 0, NULL, N'fcdt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (369, N'application/vnd.adobe.fxp', N'iana', 0, NULL, N'fxp, fxpl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (370, N'application/vnd.adobe.partial-upload', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (371, N'application/vnd.adobe.xdp+xml', N'iana', 0, NULL, N'xdp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (372, N'application/vnd.adobe.xfdf', N'iana', 0, NULL, N'xfdf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (373, N'application/vnd.aether.imp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (374, N'application/vnd.ah-barcode', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (375, N'application/vnd.ahead.space', N'iana', 0, NULL, N'ahead')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (376, N'application/vnd.airzip.filesecure.azf', N'iana', 0, NULL, N'azf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (377, N'application/vnd.airzip.filesecure.azs', N'iana', 0, NULL, N'azs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (378, N'application/vnd.amazon.ebook', N'apache', 0, NULL, N'azw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (379, N'application/vnd.americandynamics.acc', N'iana', 0, NULL, N'acc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (380, N'application/vnd.amiga.ami', N'iana', 0, NULL, N'ami')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (381, N'application/vnd.amundsen.maze+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (382, N'application/vnd.android.package-archive', N'apache', 0, NULL, N'apk')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (383, N'application/vnd.anki', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (384, N'application/vnd.anser-web-certificate-issue-initiation', N'iana', 0, NULL, N'cii')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (385, N'application/vnd.anser-web-funds-transfer-initiation', N'apache', 0, NULL, N'fti')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (386, N'application/vnd.antix.game-component', N'iana', 0, NULL, N'atx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (387, N'application/vnd.apache.thrift.binary', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (388, N'application/vnd.apache.thrift.compact', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (389, N'application/vnd.apache.thrift.json', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (390, N'application/vnd.api+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (391, N'application/vnd.apple.installer+xml', N'iana', 0, NULL, N'mpkg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (392, N'application/vnd.apple.mpegurl', N'iana', 0, NULL, N'm3u8')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (393, N'application/vnd.apple.pkpass', NULL, 0, NULL, N'pkpass')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (394, N'application/vnd.arastra.swi', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (395, N'application/vnd.aristanetworks.swi', N'iana', 0, NULL, N'swi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (396, N'application/vnd.artsquare', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (397, N'application/vnd.astraea-software.iota', N'iana', 0, NULL, N'iota')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (398, N'application/vnd.audiograph', N'iana', 0, NULL, N'aep')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (399, N'application/vnd.autopackage', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (400, N'application/vnd.avistar+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (401, N'application/vnd.balsamiq.bmml+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (402, N'application/vnd.balsamiq.bmpr', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (403, N'application/vnd.bekitzur-stech+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (404, N'application/vnd.biopax.rdf+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (405, N'application/vnd.blueice.multipass', N'iana', 0, NULL, N'mpm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (406, N'application/vnd.bluetooth.ep.oob', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (407, N'application/vnd.bluetooth.le.oob', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (408, N'application/vnd.bmi', N'iana', 0, NULL, N'bmi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (409, N'application/vnd.businessobjects', N'iana', 0, NULL, N'rep')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (410, N'application/vnd.cab-jscript', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (411, N'application/vnd.canon-cpdl', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (412, N'application/vnd.canon-lips', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (413, N'application/vnd.cendio.thinlinc.clientconf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (414, N'application/vnd.century-systems.tcp_stream', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (415, N'application/vnd.chemdraw+xml', N'iana', 0, NULL, N'cdxml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (416, N'application/vnd.chipnuts.karaoke-mmd', N'iana', 0, NULL, N'mmd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (417, N'application/vnd.cinderella', N'iana', 0, NULL, N'cdy')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (418, N'application/vnd.cirpack.isdn-ext', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (419, N'application/vnd.citationstyles.style+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (420, N'application/vnd.claymore', N'iana', 0, NULL, N'cla')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (421, N'application/vnd.cloanto.rp9', N'iana', 0, NULL, N'rp9')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (422, N'application/vnd.clonk.c4group', N'iana', 0, NULL, N'c4g, c4d, c4f, c4p, c4u')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (423, N'application/vnd.cluetrust.cartomobile-config', N'iana', 0, NULL, N'c11amc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (424, N'application/vnd.cluetrust.cartomobile-config-pkg', N'iana', 0, NULL, N'c11amz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (425, N'application/vnd.coffeescript', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (426, N'application/vnd.collection+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (427, N'application/vnd.collection.doc+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (428, N'application/vnd.collection.next+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (429, N'application/vnd.commerce-battelle', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (430, N'application/vnd.commonspace', N'iana', 0, NULL, N'csp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (431, N'application/vnd.contact.cmsg', N'iana', 0, NULL, N'cdbcmsg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (432, N'application/vnd.coreos.ignition+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (433, N'application/vnd.cosmocaller', N'iana', 0, NULL, N'cmc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (434, N'application/vnd.crick.clicker', N'iana', 0, NULL, N'clkx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (435, N'application/vnd.crick.clicker.keyboard', N'iana', 0, NULL, N'clkk')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (436, N'application/vnd.crick.clicker.palette', N'iana', 0, NULL, N'clkp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (437, N'application/vnd.crick.clicker.template', N'iana', 0, NULL, N'clkt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (438, N'application/vnd.crick.clicker.wordbank', N'iana', 0, NULL, N'clkw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (439, N'application/vnd.criticaltools.wbs+xml', N'iana', 0, NULL, N'wbs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (440, N'application/vnd.ctc-posml', N'iana', 0, NULL, N'pml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (441, N'application/vnd.ctct.ws+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (442, N'application/vnd.cups-pdf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (443, N'application/vnd.cups-postscript', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (444, N'application/vnd.cups-ppd', N'iana', 0, NULL, N'ppd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (445, N'application/vnd.cups-raster', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (446, N'application/vnd.cups-raw', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (447, N'application/vnd.curl', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (448, N'application/vnd.curl.car', N'apache', 0, NULL, N'car')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (449, N'application/vnd.curl.pcurl', N'apache', 0, NULL, N'pcurl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (450, N'application/vnd.cyan.dean.root+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (451, N'application/vnd.cybank', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (452, N'application/vnd.dart', N'iana', 1, NULL, N'dart')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (453, N'application/vnd.data-vision.rdz', N'iana', 0, NULL, N'rdz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (454, N'application/vnd.debian.binary-package', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (455, N'application/vnd.dece.data', N'iana', 0, NULL, N'uvf, uvvf, uvd, uvvd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (456, N'application/vnd.dece.ttml+xml', N'iana', 0, NULL, N'uvt, uvvt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (457, N'application/vnd.dece.unspecified', N'iana', 0, NULL, N'uvx, uvvx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (458, N'application/vnd.dece.zip', N'iana', 0, NULL, N'uvz, uvvz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (459, N'application/vnd.denovo.fcselayout-link', N'iana', 0, NULL, N'fe_launch')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (460, N'application/vnd.desmume-movie', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (461, N'application/vnd.desmume.movie', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (462, N'application/vnd.dir-bi.plate-dl-nosuffix', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (463, N'application/vnd.dm.delegation+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (464, N'application/vnd.dna', N'iana', 0, NULL, N'dna')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (465, N'application/vnd.document+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (466, N'application/vnd.dolby.mlp', N'apache', 0, NULL, N'mlp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (467, N'application/vnd.dolby.mobile.1', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (468, N'application/vnd.dolby.mobile.2', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (469, N'application/vnd.doremir.scorecloud-binary-document', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (470, N'application/vnd.dpgraph', N'iana', 0, NULL, N'dpg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (471, N'application/vnd.dreamfactory', N'iana', 0, NULL, N'dfac')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (472, N'application/vnd.drive+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (473, N'application/vnd.ds-keypoint', N'apache', 0, NULL, N'kpxx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (474, N'application/vnd.dtg.local', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (475, N'application/vnd.dtg.local.flash', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (476, N'application/vnd.dtg.local.html', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (477, N'application/vnd.dvb.ait', N'iana', 0, NULL, N'ait')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (478, N'application/vnd.dvb.dvbj', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (479, N'application/vnd.dvb.esgcontainer', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (480, N'application/vnd.dvb.ipdcdftnotifaccess', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (481, N'application/vnd.dvb.ipdcesgaccess', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (482, N'application/vnd.dvb.ipdcesgaccess2', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (483, N'application/vnd.dvb.ipdcesgpdd', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (484, N'application/vnd.dvb.ipdcroaming', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (485, N'application/vnd.dvb.iptv.alfec-base', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (486, N'application/vnd.dvb.iptv.alfec-enhancement', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (487, N'application/vnd.dvb.notif-aggregate-root+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (488, N'application/vnd.dvb.notif-container+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (489, N'application/vnd.dvb.notif-generic+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (490, N'application/vnd.dvb.notif-ia-msglist+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (491, N'application/vnd.dvb.notif-ia-registration-request+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (492, N'application/vnd.dvb.notif-ia-registration-response+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (493, N'application/vnd.dvb.notif-init+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (494, N'application/vnd.dvb.pfr', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (495, N'application/vnd.dvb.service', N'iana', 0, NULL, N'svc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (496, N'application/vnd.dxr', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (497, N'application/vnd.dynageo', N'iana', 0, NULL, N'geo')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (498, N'application/vnd.dzr', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (499, N'application/vnd.easykaraoke.cdgdownload', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (500, N'application/vnd.ecdis-update', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (501, N'application/vnd.ecowin.chart', N'iana', 0, NULL, N'mag')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (502, N'application/vnd.ecowin.filerequest', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (503, N'application/vnd.ecowin.fileupdate', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (504, N'application/vnd.ecowin.series', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (505, N'application/vnd.ecowin.seriesrequest', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (506, N'application/vnd.ecowin.seriesupdate', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (507, N'application/vnd.emclient.accessrequest+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (508, N'application/vnd.enliven', N'iana', 0, NULL, N'nml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (509, N'application/vnd.enphase.envoy', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (510, N'application/vnd.eprints.data+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (511, N'application/vnd.epson.esf', N'iana', 0, NULL, N'esf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (512, N'application/vnd.epson.msf', N'iana', 0, NULL, N'msf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (513, N'application/vnd.epson.quickanime', N'iana', 0, NULL, N'qam')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (514, N'application/vnd.epson.salt', N'iana', 0, NULL, N'slt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (515, N'application/vnd.epson.ssf', N'iana', 0, NULL, N'ssf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (516, N'application/vnd.ericsson.quickcall', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (517, N'application/vnd.eszigno3+xml', N'iana', 0, NULL, N'es3, et3')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (518, N'application/vnd.etsi.aoc+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (519, N'application/vnd.etsi.asic-e+zip', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (520, N'application/vnd.etsi.asic-s+zip', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (521, N'application/vnd.etsi.cug+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (522, N'application/vnd.etsi.iptvcommand+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (523, N'application/vnd.etsi.iptvdiscovery+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (524, N'application/vnd.etsi.iptvprofile+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (525, N'application/vnd.etsi.iptvsad-bc+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (526, N'application/vnd.etsi.iptvsad-cod+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (527, N'application/vnd.etsi.iptvsad-npvr+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (528, N'application/vnd.etsi.iptvservice+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (529, N'application/vnd.etsi.iptvsync+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (530, N'application/vnd.etsi.iptvueprofile+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (531, N'application/vnd.etsi.mcid+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (532, N'application/vnd.etsi.mheg5', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (533, N'application/vnd.etsi.overload-control-policy-dataset+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (534, N'application/vnd.etsi.pstn+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (535, N'application/vnd.etsi.sci+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (536, N'application/vnd.etsi.simservs+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (537, N'application/vnd.etsi.timestamp-token', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (538, N'application/vnd.etsi.tsl+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (539, N'application/vnd.etsi.tsl.der', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (540, N'application/vnd.eudora.data', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (541, N'application/vnd.ezpix-album', N'iana', 0, NULL, N'ez2')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (542, N'application/vnd.ezpix-package', N'iana', 0, NULL, N'ez3')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (543, N'application/vnd.f-secure.mobile', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (544, N'application/vnd.fastcopy-disk-image', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (545, N'application/vnd.fdf', N'iana', 0, NULL, N'fdf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (546, N'application/vnd.fdsn.mseed', N'iana', 0, NULL, N'mseed')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (547, N'application/vnd.fdsn.seed', N'iana', 0, NULL, N'seed, dataless')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (548, N'application/vnd.ffsns', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (549, N'application/vnd.filmit.zfc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (550, N'application/vnd.fints', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (551, N'application/vnd.firemonkeys.cloudcell', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (552, N'application/vnd.flographit', N'iana', 0, NULL, N'gph')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (553, N'application/vnd.fluxtime.clip', N'iana', 0, NULL, N'ftc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (554, N'application/vnd.font-fontforge-sfd', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (555, N'application/vnd.framemaker', N'iana', 0, NULL, N'fm, frame, maker, book')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (556, N'application/vnd.frogans.fnc', N'iana', 0, NULL, N'fnc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (557, N'application/vnd.frogans.ltf', N'iana', 0, NULL, N'ltf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (558, N'application/vnd.fsc.weblaunch', N'iana', 0, NULL, N'fsc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (559, N'application/vnd.fujitsu.oasys', N'iana', 0, NULL, N'oas')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (560, N'application/vnd.fujitsu.oasys2', N'iana', 0, NULL, N'oa2')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (561, N'application/vnd.fujitsu.oasys3', N'iana', 0, NULL, N'oa3')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (562, N'application/vnd.fujitsu.oasysgp', N'iana', 0, NULL, N'fg5')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (563, N'application/vnd.fujitsu.oasysprs', N'iana', 0, NULL, N'bh2')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (564, N'application/vnd.fujixerox.art-ex', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (565, N'application/vnd.fujixerox.art4', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (566, N'application/vnd.fujixerox.ddd', N'iana', 0, NULL, N'ddd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (567, N'application/vnd.fujixerox.docuworks', N'iana', 0, NULL, N'xdw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (568, N'application/vnd.fujixerox.docuworks.binder', N'iana', 0, NULL, N'xbd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (569, N'application/vnd.fujixerox.docuworks.container', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (570, N'application/vnd.fujixerox.hbpl', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (571, N'application/vnd.fut-misnet', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (572, N'application/vnd.fuzzysheet', N'iana', 0, NULL, N'fzs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (573, N'application/vnd.genomatix.tuxedo', N'iana', 0, NULL, N'txd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (574, N'application/vnd.geo+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (575, N'application/vnd.geocube+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (576, N'application/vnd.geogebra.file', N'iana', 0, NULL, N'ggb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (577, N'application/vnd.geogebra.tool', N'iana', 0, NULL, N'ggt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (578, N'application/vnd.geometry-explorer', N'iana', 0, NULL, N'gex, gre')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (579, N'application/vnd.geonext', N'iana', 0, NULL, N'gxt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (580, N'application/vnd.geoplan', N'iana', 0, NULL, N'g2w')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (581, N'application/vnd.geospace', N'iana', 0, NULL, N'g3w')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (582, N'application/vnd.gerber', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (583, N'application/vnd.globalplatform.card-content-mgt', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (584, N'application/vnd.globalplatform.card-content-mgt-response', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (585, N'application/vnd.gmx', N'iana', 0, NULL, N'gmx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (586, N'application/vnd.google-apps.document', NULL, 0, NULL, N'gdoc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (587, N'application/vnd.google-apps.presentation', NULL, 0, NULL, N'gslides')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (588, N'application/vnd.google-apps.spreadsheet', NULL, 0, NULL, N'gsheet')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (589, N'application/vnd.google-earth.kml+xml', N'iana', 1, NULL, N'kml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (590, N'application/vnd.google-earth.kmz', N'iana', 0, NULL, N'kmz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (591, N'application/vnd.gov.sk.e-form+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (592, N'application/vnd.gov.sk.e-form+zip', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (593, N'application/vnd.gov.sk.xmldatacontainer+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (594, N'application/vnd.grafeq', N'iana', 0, NULL, N'gqf, gqs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (595, N'application/vnd.gridmp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (596, N'application/vnd.groove-account', N'iana', 0, NULL, N'gac')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (597, N'application/vnd.groove-help', N'iana', 0, NULL, N'ghf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (598, N'application/vnd.groove-identity-message', N'iana', 0, NULL, N'gim')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (599, N'application/vnd.groove-injector', N'iana', 0, NULL, N'grv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (600, N'application/vnd.groove-tool-message', N'iana', 0, NULL, N'gtm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (601, N'application/vnd.groove-tool-template', N'iana', 0, NULL, N'tpl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (602, N'application/vnd.groove-vcard', N'iana', 0, NULL, N'vcg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (603, N'application/vnd.hal+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (604, N'application/vnd.hal+xml', N'iana', 0, NULL, N'hal')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (605, N'application/vnd.handheld-entertainment+xml', N'iana', 0, NULL, N'zmm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (606, N'application/vnd.hbci', N'iana', 0, NULL, N'hbci')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (607, N'application/vnd.hcl-bireports', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (608, N'application/vnd.hdt', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (609, N'application/vnd.heroku+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (610, N'application/vnd.hhe.lesson-player', N'iana', 0, NULL, N'les')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (611, N'application/vnd.hp-hpgl', N'iana', 0, NULL, N'hpgl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (612, N'application/vnd.hp-hpid', N'iana', 0, NULL, N'hpid')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (613, N'application/vnd.hp-hps', N'iana', 0, NULL, N'hps')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (614, N'application/vnd.hp-jlyt', N'iana', 0, NULL, N'jlt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (615, N'application/vnd.hp-pcl', N'iana', 0, NULL, N'pcl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (616, N'application/vnd.hp-pclxl', N'iana', 0, NULL, N'pclxl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (617, N'application/vnd.httphone', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (618, N'application/vnd.hydrostatix.sof-data', N'iana', 0, NULL, N'sfd-hdstx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (619, N'application/vnd.hyperdrive+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (620, N'application/vnd.hzn-3d-crossword', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (621, N'application/vnd.ibm.afplinedata', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (622, N'application/vnd.ibm.electronic-media', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (623, N'application/vnd.ibm.minipay', N'iana', 0, NULL, N'mpy')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (624, N'application/vnd.ibm.modcap', N'iana', 0, NULL, N'afp, listafp, list3820')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (625, N'application/vnd.ibm.rights-management', N'iana', 0, NULL, N'irm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (626, N'application/vnd.ibm.secure-container', N'iana', 0, NULL, N'sc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (627, N'application/vnd.iccprofile', N'iana', 0, NULL, N'icc, icm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (628, N'application/vnd.ieee.1905', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (629, N'application/vnd.igloader', N'iana', 0, NULL, N'igl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (630, N'application/vnd.immervision-ivp', N'iana', 0, NULL, N'ivp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (631, N'application/vnd.immervision-ivu', N'iana', 0, NULL, N'ivu')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (632, N'application/vnd.ims.imsccv1p1', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (633, N'application/vnd.ims.imsccv1p2', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (634, N'application/vnd.ims.imsccv1p3', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (635, N'application/vnd.ims.lis.v2.result+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (636, N'application/vnd.ims.lti.v2.toolconsumerprofile+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (637, N'application/vnd.ims.lti.v2.toolproxy+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (638, N'application/vnd.ims.lti.v2.toolproxy.id+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (639, N'application/vnd.ims.lti.v2.toolsettings+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (640, N'application/vnd.ims.lti.v2.toolsettings.simple+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (641, N'application/vnd.informedcontrol.rms+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (642, N'application/vnd.informix-visionary', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (643, N'application/vnd.infotech.project', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (644, N'application/vnd.infotech.project+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (645, N'application/vnd.innopath.wamp.notification', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (646, N'application/vnd.insors.igm', N'iana', 0, NULL, N'igm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (647, N'application/vnd.intercon.formnet', N'iana', 0, NULL, N'xpw, xpx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (648, N'application/vnd.intergeo', N'iana', 0, NULL, N'i2g')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (649, N'application/vnd.intertrust.digibox', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (650, N'application/vnd.intertrust.nncp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (651, N'application/vnd.intu.qbo', N'iana', 0, NULL, N'qbo')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (652, N'application/vnd.intu.qfx', N'iana', 0, NULL, N'qfx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (653, N'application/vnd.iptc.g2.catalogitem+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (654, N'application/vnd.iptc.g2.conceptitem+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (655, N'application/vnd.iptc.g2.knowledgeitem+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (656, N'application/vnd.iptc.g2.newsitem+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (657, N'application/vnd.iptc.g2.newsmessage+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (658, N'application/vnd.iptc.g2.packageitem+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (659, N'application/vnd.iptc.g2.planningitem+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (660, N'application/vnd.ipunplugged.rcprofile', N'iana', 0, NULL, N'rcprofile')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (661, N'application/vnd.irepository.package+xml', N'iana', 0, NULL, N'irp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (662, N'application/vnd.is-xpr', N'iana', 0, NULL, N'xpr')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (663, N'application/vnd.isac.fcs', N'iana', 0, NULL, N'fcs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (664, N'application/vnd.jam', N'iana', 0, NULL, N'jam')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (665, N'application/vnd.japannet-directory-service', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (666, N'application/vnd.japannet-jpnstore-wakeup', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (667, N'application/vnd.japannet-payment-wakeup', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (668, N'application/vnd.japannet-registration', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (669, N'application/vnd.japannet-registration-wakeup', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (670, N'application/vnd.japannet-setstore-wakeup', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (671, N'application/vnd.japannet-verification', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (672, N'application/vnd.japannet-verification-wakeup', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (673, N'application/vnd.jcp.javame.midlet-rms', N'iana', 0, NULL, N'rms')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (674, N'application/vnd.jisp', N'iana', 0, NULL, N'jisp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (675, N'application/vnd.joost.joda-archive', N'iana', 0, NULL, N'joda')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (676, N'application/vnd.jsk.isdn-ngn', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (677, N'application/vnd.kahootz', N'iana', 0, NULL, N'ktz, ktr')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (678, N'application/vnd.kde.karbon', N'iana', 0, NULL, N'karbon')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (679, N'application/vnd.kde.kchart', N'iana', 0, NULL, N'chrt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (680, N'application/vnd.kde.kformula', N'iana', 0, NULL, N'kfo')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (681, N'application/vnd.kde.kivio', N'iana', 0, NULL, N'flw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (682, N'application/vnd.kde.kontour', N'iana', 0, NULL, N'kon')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (683, N'application/vnd.kde.kpresenter', N'iana', 0, NULL, N'kpr, kpt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (684, N'application/vnd.kde.kspread', N'iana', 0, NULL, N'ksp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (685, N'application/vnd.kde.kword', N'iana', 0, NULL, N'kwd, kwt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (686, N'application/vnd.kenameaapp', N'iana', 0, NULL, N'htke')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (687, N'application/vnd.kidspiration', N'iana', 0, NULL, N'kia')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (688, N'application/vnd.kinar', N'iana', 0, NULL, N'kne, knp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (689, N'application/vnd.koan', N'iana', 0, NULL, N'skp, skd, skt, skm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (690, N'application/vnd.kodak-descriptor', N'iana', 0, NULL, N'sse')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (691, N'application/vnd.las.las+xml', N'iana', 0, NULL, N'lasxml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (692, N'application/vnd.liberty-request+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (693, N'application/vnd.llamagraphics.life-balance.desktop', N'iana', 0, NULL, N'lbd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (694, N'application/vnd.llamagraphics.life-balance.exchange+xml', N'iana', 0, NULL, N'lbe')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (695, N'application/vnd.lotus-1-2-3', N'iana', 0, NULL, N'123')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (696, N'application/vnd.lotus-approach', N'iana', 0, NULL, N'apr')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (697, N'application/vnd.lotus-freelance', N'iana', 0, NULL, N'pre')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (698, N'application/vnd.lotus-notes', N'iana', 0, NULL, N'nsf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (699, N'application/vnd.lotus-organizer', N'iana', 0, NULL, N'org')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (700, N'application/vnd.lotus-screencam', N'iana', 0, NULL, N'scm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (701, N'application/vnd.lotus-wordpro', N'iana', 0, NULL, N'lwp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (702, N'application/vnd.macports.portpkg', N'iana', 0, NULL, N'portpkg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (703, N'application/vnd.mapbox-vector-tile', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (704, N'application/vnd.marlin.drm.actiontoken+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (705, N'application/vnd.marlin.drm.conftoken+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (706, N'application/vnd.marlin.drm.license+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (707, N'application/vnd.marlin.drm.mdcf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (708, N'application/vnd.mason+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (709, N'application/vnd.maxmind.maxmind-db', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (710, N'application/vnd.mcd', N'iana', 0, NULL, N'mcd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (711, N'application/vnd.medcalcdata', N'iana', 0, NULL, N'mc1')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (712, N'application/vnd.mediastation.cdkey', N'iana', 0, NULL, N'cdkey')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (713, N'application/vnd.meridian-slingshot', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (714, N'application/vnd.mfer', N'iana', 0, NULL, N'mwf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (715, N'application/vnd.mfmp', N'iana', 0, NULL, N'mfm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (716, N'application/vnd.micro+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (717, N'application/vnd.micrografx.flo', N'iana', 0, NULL, N'flo')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (718, N'application/vnd.micrografx.igx', N'iana', 0, NULL, N'igx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (719, N'application/vnd.microsoft.portable-executable', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (720, N'application/vnd.miele+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (721, N'application/vnd.mif', N'iana', 0, NULL, N'mif')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (722, N'application/vnd.minisoft-hp3000-save', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (723, N'application/vnd.mitsubishi.misty-guard.trustweb', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (724, N'application/vnd.mobius.daf', N'iana', 0, NULL, N'daf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (725, N'application/vnd.mobius.dis', N'iana', 0, NULL, N'dis')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (726, N'application/vnd.mobius.mbk', N'iana', 0, NULL, N'mbk')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (727, N'application/vnd.mobius.mqy', N'iana', 0, NULL, N'mqy')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (728, N'application/vnd.mobius.msl', N'iana', 0, NULL, N'msl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (729, N'application/vnd.mobius.plc', N'iana', 0, NULL, N'plc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (730, N'application/vnd.mobius.txf', N'iana', 0, NULL, N'txf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (731, N'application/vnd.mophun.application', N'iana', 0, NULL, N'mpn')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (732, N'application/vnd.mophun.certificate', N'iana', 0, NULL, N'mpc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (733, N'application/vnd.motorola.flexsuite', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (734, N'application/vnd.motorola.flexsuite.adsi', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (735, N'application/vnd.motorola.flexsuite.fis', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (736, N'application/vnd.motorola.flexsuite.gotap', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (737, N'application/vnd.motorola.flexsuite.kmr', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (738, N'application/vnd.motorola.flexsuite.ttc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (739, N'application/vnd.motorola.flexsuite.wem', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (740, N'application/vnd.motorola.iprm', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (741, N'application/vnd.mozilla.xul+xml', N'iana', 1, NULL, N'xul')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (742, N'application/vnd.ms-3mfdocument', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (743, N'application/vnd.ms-artgalry', N'iana', 0, NULL, N'cil')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (744, N'application/vnd.ms-asf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (745, N'application/vnd.ms-cab-compressed', N'iana', 0, NULL, N'cab')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (746, N'application/vnd.ms-color.iccprofile', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (747, N'application/vnd.ms-excel', N'iana', 0, NULL, N'xls, xlm, xla, xlc, xlt, xlw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (748, N'application/vnd.ms-excel.addin.macroenabled.12', N'iana', 0, NULL, N'xlam')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (749, N'application/vnd.ms-excel.sheet.binary.macroenabled.12', N'iana', 0, NULL, N'xlsb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (750, N'application/vnd.ms-excel.sheet.macroenabled.12', N'iana', 0, NULL, N'xlsm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (751, N'application/vnd.ms-excel.template.macroenabled.12', N'iana', 0, NULL, N'xltm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (752, N'application/vnd.ms-fontobject', N'iana', 1, NULL, N'eot')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (753, N'application/vnd.ms-htmlhelp', N'iana', 0, NULL, N'chm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (754, N'application/vnd.ms-ims', N'iana', 0, NULL, N'ims')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (755, N'application/vnd.ms-lrm', N'iana', 0, NULL, N'lrm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (756, N'application/vnd.ms-office.activex+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (757, N'application/vnd.ms-officetheme', N'iana', 0, NULL, N'thmx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (758, N'application/vnd.ms-opentype', N'apache', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (759, N'application/vnd.ms-package.obfuscated-opentype', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (760, N'application/vnd.ms-pki.seccat', N'apache', 0, NULL, N'cat')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (761, N'application/vnd.ms-pki.stl', N'apache', 0, NULL, N'stl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (762, N'application/vnd.ms-playready.initiator+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (763, N'application/vnd.ms-powerpoint', N'iana', 0, NULL, N'ppt, pps, pot')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (764, N'application/vnd.ms-powerpoint.addin.macroenabled.12', N'iana', 0, NULL, N'ppam')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (765, N'application/vnd.ms-powerpoint.presentation.macroenabled.12', N'iana', 0, NULL, N'pptm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (766, N'application/vnd.ms-powerpoint.slide.macroenabled.12', N'iana', 0, NULL, N'sldm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (767, N'application/vnd.ms-powerpoint.slideshow.macroenabled.12', N'iana', 0, NULL, N'ppsm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (768, N'application/vnd.ms-powerpoint.template.macroenabled.12', N'iana', 0, NULL, N'potm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (769, N'application/vnd.ms-printdevicecapabilities+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (770, N'application/vnd.ms-printing.printticket+xml', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (771, N'application/vnd.ms-printschematicket+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (772, N'application/vnd.ms-project', N'iana', 0, NULL, N'mpp, mpt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (773, N'application/vnd.ms-tnef', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (774, N'application/vnd.ms-windows.devicepairing', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (775, N'application/vnd.ms-windows.nwprinting.oob', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (776, N'application/vnd.ms-windows.printerpairing', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (777, N'application/vnd.ms-windows.wsd.oob', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (778, N'application/vnd.ms-wmdrm.lic-chlg-req', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (779, N'application/vnd.ms-wmdrm.lic-resp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (780, N'application/vnd.ms-wmdrm.meter-chlg-req', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (781, N'application/vnd.ms-wmdrm.meter-resp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (782, N'application/vnd.ms-word.document.macroenabled.12', N'iana', 0, NULL, N'docm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (783, N'application/vnd.ms-word.template.macroenabled.12', N'iana', 0, NULL, N'dotm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (784, N'application/vnd.ms-works', N'iana', 0, NULL, N'wps, wks, wcm, wdb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (785, N'application/vnd.ms-wpl', N'iana', 0, NULL, N'wpl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (786, N'application/vnd.ms-xpsdocument', N'iana', 0, NULL, N'xps')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (787, N'application/vnd.msa-disk-image', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (788, N'application/vnd.mseq', N'iana', 0, NULL, N'mseq')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (789, N'application/vnd.msign', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (790, N'application/vnd.multiad.creator', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (791, N'application/vnd.multiad.creator.cif', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (792, N'application/vnd.music-niff', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (793, N'application/vnd.musician', N'iana', 0, NULL, N'mus')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (794, N'application/vnd.muvee.style', N'iana', 0, NULL, N'msty')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (795, N'application/vnd.mynfc', N'iana', 0, NULL, N'taglet')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (796, N'application/vnd.ncd.control', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (797, N'application/vnd.ncd.reference', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (798, N'application/vnd.nervana', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (799, N'application/vnd.netfpx', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (800, N'application/vnd.neurolanguage.nlu', N'iana', 0, NULL, N'nlu')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (801, N'application/vnd.nintendo.nitro.rom', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (802, N'application/vnd.nintendo.snes.rom', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (803, N'application/vnd.nitf', N'iana', 0, NULL, N'ntf, nitf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (804, N'application/vnd.noblenet-directory', N'iana', 0, NULL, N'nnd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (805, N'application/vnd.noblenet-sealer', N'iana', 0, NULL, N'nns')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (806, N'application/vnd.noblenet-web', N'iana', 0, NULL, N'nnw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (807, N'application/vnd.nokia.catalogs', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (808, N'application/vnd.nokia.conml+wbxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (809, N'application/vnd.nokia.conml+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (810, N'application/vnd.nokia.iptv.config+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (811, N'application/vnd.nokia.isds-radio-presets', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (812, N'application/vnd.nokia.landmark+wbxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (813, N'application/vnd.nokia.landmark+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (814, N'application/vnd.nokia.landmarkcollection+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (815, N'application/vnd.nokia.n-gage.ac+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (816, N'application/vnd.nokia.n-gage.data', N'iana', 0, NULL, N'ngdat')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (817, N'application/vnd.nokia.n-gage.symbian.install', N'iana', 0, NULL, N'n-gage')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (818, N'application/vnd.nokia.ncd', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (819, N'application/vnd.nokia.pcd+wbxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (820, N'application/vnd.nokia.pcd+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (821, N'application/vnd.nokia.radio-preset', N'iana', 0, NULL, N'rpst')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (822, N'application/vnd.nokia.radio-presets', N'iana', 0, NULL, N'rpss')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (823, N'application/vnd.novadigm.edm', N'iana', 0, NULL, N'edm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (824, N'application/vnd.novadigm.edx', N'iana', 0, NULL, N'edx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (825, N'application/vnd.novadigm.ext', N'iana', 0, NULL, N'ext')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (826, N'application/vnd.ntt-local.content-share', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (827, N'application/vnd.ntt-local.file-transfer', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (828, N'application/vnd.ntt-local.ogw_remote-access', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (829, N'application/vnd.ntt-local.sip-ta_remote', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (830, N'application/vnd.ntt-local.sip-ta_tcp_stream', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (831, N'application/vnd.oasis.opendocument.chart', N'iana', 0, NULL, N'odc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (832, N'application/vnd.oasis.opendocument.chart-template', N'iana', 0, NULL, N'otc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (833, N'application/vnd.oasis.opendocument.database', N'iana', 0, NULL, N'odb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (834, N'application/vnd.oasis.opendocument.formula', N'iana', 0, NULL, N'odf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (835, N'application/vnd.oasis.opendocument.formula-template', N'iana', 0, NULL, N'odft')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (836, N'application/vnd.oasis.opendocument.graphics', N'iana', 0, NULL, N'odg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (837, N'application/vnd.oasis.opendocument.graphics-template', N'iana', 0, NULL, N'otg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (838, N'application/vnd.oasis.opendocument.image', N'iana', 0, NULL, N'odi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (839, N'application/vnd.oasis.opendocument.image-template', N'iana', 0, NULL, N'oti')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (840, N'application/vnd.oasis.opendocument.presentation', N'iana', 0, NULL, N'odp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (841, N'application/vnd.oasis.opendocument.presentation-template', N'iana', 0, NULL, N'otp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (842, N'application/vnd.oasis.opendocument.spreadsheet', N'iana', 0, NULL, N'ods')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (843, N'application/vnd.oasis.opendocument.spreadsheet-template', N'iana', 0, NULL, N'ots')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (844, N'application/vnd.oasis.opendocument.text', N'iana', 0, NULL, N'odt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (845, N'application/vnd.oasis.opendocument.text-master', N'iana', 0, NULL, N'odm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (846, N'application/vnd.oasis.opendocument.text-template', N'iana', 0, NULL, N'ott')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (847, N'application/vnd.oasis.opendocument.text-web', N'iana', 0, NULL, N'oth')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (848, N'application/vnd.obn', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (849, N'application/vnd.oftn.l10n+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (850, N'application/vnd.oipf.contentaccessdownload+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (851, N'application/vnd.oipf.contentaccessstreaming+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (852, N'application/vnd.oipf.cspg-hexbinary', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (853, N'application/vnd.oipf.dae.svg+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (854, N'application/vnd.oipf.dae.xhtml+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (855, N'application/vnd.oipf.mippvcontrolmessage+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (856, N'application/vnd.oipf.pae.gem', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (857, N'application/vnd.oipf.spdiscovery+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (858, N'application/vnd.oipf.spdlist+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (859, N'application/vnd.oipf.ueprofile+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (860, N'application/vnd.oipf.userprofile+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (861, N'application/vnd.olpc-sugar', N'iana', 0, NULL, N'xo')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (862, N'application/vnd.oma-scws-config', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (863, N'application/vnd.oma-scws-http-request', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (864, N'application/vnd.oma-scws-http-response', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (865, N'application/vnd.oma.bcast.associated-procedure-parameter+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (866, N'application/vnd.oma.bcast.drm-trigger+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (867, N'application/vnd.oma.bcast.imd+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (868, N'application/vnd.oma.bcast.ltkm', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (869, N'application/vnd.oma.bcast.notification+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (870, N'application/vnd.oma.bcast.provisioningtrigger', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (871, N'application/vnd.oma.bcast.sgboot', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (872, N'application/vnd.oma.bcast.sgdd+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (873, N'application/vnd.oma.bcast.sgdu', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (874, N'application/vnd.oma.bcast.simple-symbol-container', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (875, N'application/vnd.oma.bcast.smartcard-trigger+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (876, N'application/vnd.oma.bcast.sprov+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (877, N'application/vnd.oma.bcast.stkm', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (878, N'application/vnd.oma.cab-address-book+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (879, N'application/vnd.oma.cab-feature-handler+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (880, N'application/vnd.oma.cab-pcc+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (881, N'application/vnd.oma.cab-subs-invite+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (882, N'application/vnd.oma.cab-user-prefs+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (883, N'application/vnd.oma.dcd', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (884, N'application/vnd.oma.dcdc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (885, N'application/vnd.oma.dd2+xml', N'iana', 0, NULL, N'dd2')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (886, N'application/vnd.oma.drm.risd+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (887, N'application/vnd.oma.group-usage-list+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (888, N'application/vnd.oma.pal+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (889, N'application/vnd.oma.poc.detailed-progress-report+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (890, N'application/vnd.oma.poc.final-report+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (891, N'application/vnd.oma.poc.groups+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (892, N'application/vnd.oma.poc.invocation-descriptor+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (893, N'application/vnd.oma.poc.optimized-progress-report+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (894, N'application/vnd.oma.push', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (895, N'application/vnd.oma.scidm.messages+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (896, N'application/vnd.oma.xcap-directory+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (897, N'application/vnd.omads-email+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (898, N'application/vnd.omads-file+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (899, N'application/vnd.omads-folder+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (900, N'application/vnd.omaloc-supl-init', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (901, N'application/vnd.onepager', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (902, N'application/vnd.openblox.game+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (903, N'application/vnd.openblox.game-binary', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (904, N'application/vnd.openeye.oeb', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (905, N'application/vnd.openofficeorg.extension', N'apache', 0, NULL, N'oxt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (906, N'application/vnd.openxmlformats-officedocument.custom-properties+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (907, N'application/vnd.openxmlformats-officedocument.customxmlproperties+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (908, N'application/vnd.openxmlformats-officedocument.drawing+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (909, N'application/vnd.openxmlformats-officedocument.drawingml.chart+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (910, N'application/vnd.openxmlformats-officedocument.drawingml.chartshapes+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (911, N'application/vnd.openxmlformats-officedocument.drawingml.diagramcolors+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (912, N'application/vnd.openxmlformats-officedocument.drawingml.diagramdata+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (913, N'application/vnd.openxmlformats-officedocument.drawingml.diagramlayout+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (914, N'application/vnd.openxmlformats-officedocument.drawingml.diagramstyle+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (915, N'application/vnd.openxmlformats-officedocument.extended-properties+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (916, N'application/vnd.openxmlformats-officedocument.presentationml-template', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (917, N'application/vnd.openxmlformats-officedocument.presentationml.commentauthors+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (918, N'application/vnd.openxmlformats-officedocument.presentationml.comments+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (919, N'application/vnd.openxmlformats-officedocument.presentationml.handoutmaster+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (920, N'application/vnd.openxmlformats-officedocument.presentationml.notesmaster+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (921, N'application/vnd.openxmlformats-officedocument.presentationml.notesslide+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (922, N'application/vnd.openxmlformats-officedocument.presentationml.presentation', N'iana', 0, NULL, N'pptx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (923, N'application/vnd.openxmlformats-officedocument.presentationml.presentation.main+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (924, N'application/vnd.openxmlformats-officedocument.presentationml.presprops+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (925, N'application/vnd.openxmlformats-officedocument.presentationml.slide', N'iana', 0, NULL, N'sldx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (926, N'application/vnd.openxmlformats-officedocument.presentationml.slide+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (927, N'application/vnd.openxmlformats-officedocument.presentationml.slidelayout+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (928, N'application/vnd.openxmlformats-officedocument.presentationml.slidemaster+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (929, N'application/vnd.openxmlformats-officedocument.presentationml.slideshow', N'iana', 0, NULL, N'ppsx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (930, N'application/vnd.openxmlformats-officedocument.presentationml.slideshow.main+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (931, N'application/vnd.openxmlformats-officedocument.presentationml.slideupdateinfo+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (932, N'application/vnd.openxmlformats-officedocument.presentationml.tablestyles+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (933, N'application/vnd.openxmlformats-officedocument.presentationml.tags+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (934, N'application/vnd.openxmlformats-officedocument.presentationml.template', N'apache', 0, NULL, N'potx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (935, N'application/vnd.openxmlformats-officedocument.presentationml.template.main+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (936, N'application/vnd.openxmlformats-officedocument.presentationml.viewprops+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (937, N'application/vnd.openxmlformats-officedocument.spreadsheetml-template', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (938, N'application/vnd.openxmlformats-officedocument.spreadsheetml.calcchain+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (939, N'application/vnd.openxmlformats-officedocument.spreadsheetml.chartsheet+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (940, N'application/vnd.openxmlformats-officedocument.spreadsheetml.comments+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (941, N'application/vnd.openxmlformats-officedocument.spreadsheetml.connections+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (942, N'application/vnd.openxmlformats-officedocument.spreadsheetml.dialogsheet+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (943, N'application/vnd.openxmlformats-officedocument.spreadsheetml.externallink+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (944, N'application/vnd.openxmlformats-officedocument.spreadsheetml.pivotcachedefinition+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (945, N'application/vnd.openxmlformats-officedocument.spreadsheetml.pivotcacherecords+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (946, N'application/vnd.openxmlformats-officedocument.spreadsheetml.pivottable+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (947, N'application/vnd.openxmlformats-officedocument.spreadsheetml.querytable+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (948, N'application/vnd.openxmlformats-officedocument.spreadsheetml.revisionheaders+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (949, N'application/vnd.openxmlformats-officedocument.spreadsheetml.revisionlog+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (950, N'application/vnd.openxmlformats-officedocument.spreadsheetml.sharedstrings+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (951, N'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', N'iana', 0, NULL, N'xlsx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (952, N'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (953, N'application/vnd.openxmlformats-officedocument.spreadsheetml.sheetmetadata+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (954, N'application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (955, N'application/vnd.openxmlformats-officedocument.spreadsheetml.table+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (956, N'application/vnd.openxmlformats-officedocument.spreadsheetml.tablesinglecells+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (957, N'application/vnd.openxmlformats-officedocument.spreadsheetml.template', N'apache', 0, NULL, N'xltx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (958, N'application/vnd.openxmlformats-officedocument.spreadsheetml.template.main+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (959, N'application/vnd.openxmlformats-officedocument.spreadsheetml.usernames+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (960, N'application/vnd.openxmlformats-officedocument.spreadsheetml.volatiledependencies+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (961, N'application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (962, N'application/vnd.openxmlformats-officedocument.theme+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (963, N'application/vnd.openxmlformats-officedocument.themeoverride+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (964, N'application/vnd.openxmlformats-officedocument.vmldrawing', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (965, N'application/vnd.openxmlformats-officedocument.wordprocessingml-template', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (966, N'application/vnd.openxmlformats-officedocument.wordprocessingml.comments+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (967, N'application/vnd.openxmlformats-officedocument.wordprocessingml.document', N'iana', 0, NULL, N'docx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (968, N'application/vnd.openxmlformats-officedocument.wordprocessingml.document.glossary+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (969, N'application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (970, N'application/vnd.openxmlformats-officedocument.wordprocessingml.endnotes+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (971, N'application/vnd.openxmlformats-officedocument.wordprocessingml.fonttable+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (972, N'application/vnd.openxmlformats-officedocument.wordprocessingml.footer+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (973, N'application/vnd.openxmlformats-officedocument.wordprocessingml.footnotes+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (974, N'application/vnd.openxmlformats-officedocument.wordprocessingml.numbering+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (975, N'application/vnd.openxmlformats-officedocument.wordprocessingml.settings+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (976, N'application/vnd.openxmlformats-officedocument.wordprocessingml.styles+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (977, N'application/vnd.openxmlformats-officedocument.wordprocessingml.template', N'apache', 0, NULL, N'dotx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (978, N'application/vnd.openxmlformats-officedocument.wordprocessingml.template.main+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (979, N'application/vnd.openxmlformats-officedocument.wordprocessingml.websettings+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (980, N'application/vnd.openxmlformats-package.core-properties+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (981, N'application/vnd.openxmlformats-package.digital-signature-xmlsignature+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (982, N'application/vnd.openxmlformats-package.relationships+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (983, N'application/vnd.oracle.resource+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (984, N'application/vnd.orange.indata', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (985, N'application/vnd.osa.netdeploy', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (986, N'application/vnd.osgeo.mapguide.package', N'iana', 0, NULL, N'mgp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (987, N'application/vnd.osgi.bundle', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (988, N'application/vnd.osgi.dp', N'iana', 0, NULL, N'dp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (989, N'application/vnd.osgi.subsystem', N'iana', 0, NULL, N'esa')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (990, N'application/vnd.otps.ct-kip+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (991, N'application/vnd.oxli.countgraph', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (992, N'application/vnd.pagerduty+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (993, N'application/vnd.palm', N'iana', 0, NULL, N'pdb, pqa, oprc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (994, N'application/vnd.panoply', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (995, N'application/vnd.paos+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (996, N'application/vnd.paos.xml', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (997, N'application/vnd.pawaafile', N'iana', 0, NULL, N'paw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (998, N'application/vnd.pcos', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (999, N'application/vnd.pg.format', N'iana', 0, NULL, N'str')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1000, N'application/vnd.pg.osasli', N'iana', 0, NULL, N'ei6')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1001, N'application/vnd.piaccess.application-licence', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1002, N'application/vnd.picsel', N'iana', 0, NULL, N'efif')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1003, N'application/vnd.pmi.widget', N'iana', 0, NULL, N'wg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1004, N'application/vnd.poc.group-advertisement+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1005, N'application/vnd.pocketlearn', N'iana', 0, NULL, N'plf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1006, N'application/vnd.powerbuilder6', N'iana', 0, NULL, N'pbd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1007, N'application/vnd.powerbuilder6-s', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1008, N'application/vnd.powerbuilder7', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1009, N'application/vnd.powerbuilder7-s', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1010, N'application/vnd.powerbuilder75', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1011, N'application/vnd.powerbuilder75-s', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1012, N'application/vnd.preminet', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1013, N'application/vnd.previewsystems.box', N'iana', 0, NULL, N'box')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1014, N'application/vnd.proteus.magazine', N'iana', 0, NULL, N'mgz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1015, N'application/vnd.publishare-delta-tree', N'iana', 0, NULL, N'qps')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1016, N'application/vnd.pvi.ptid1', N'iana', 0, NULL, N'ptid')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1017, N'application/vnd.pwg-multiplexed', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1018, N'application/vnd.pwg-xhtml-print+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1019, N'application/vnd.qualcomm.brew-app-res', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1020, N'application/vnd.quark.quarkxpress', N'iana', 0, NULL, N'qxd, qxt, qwd, qwt, qxl, qxb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1021, N'application/vnd.quobject-quoxdocument', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1022, N'application/vnd.radisys.moml+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1023, N'application/vnd.radisys.msml+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1024, N'application/vnd.radisys.msml-audit+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1025, N'application/vnd.radisys.msml-audit-conf+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1026, N'application/vnd.radisys.msml-audit-conn+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1027, N'application/vnd.radisys.msml-audit-dialog+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1028, N'application/vnd.radisys.msml-audit-stream+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1029, N'application/vnd.radisys.msml-conf+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1030, N'application/vnd.radisys.msml-dialog+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1031, N'application/vnd.radisys.msml-dialog-base+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1032, N'application/vnd.radisys.msml-dialog-fax-detect+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1033, N'application/vnd.radisys.msml-dialog-fax-sendrecv+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1034, N'application/vnd.radisys.msml-dialog-group+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1035, N'application/vnd.radisys.msml-dialog-speech+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1036, N'application/vnd.radisys.msml-dialog-transform+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1037, N'application/vnd.rainstor.data', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1038, N'application/vnd.rapid', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1039, N'application/vnd.realvnc.bed', N'iana', 0, NULL, N'bed')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1040, N'application/vnd.recordare.musicxml', N'iana', 0, NULL, N'mxl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1041, N'application/vnd.recordare.musicxml+xml', N'iana', 0, NULL, N'musicxml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1042, N'application/vnd.renlearn.rlprint', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1043, N'application/vnd.rig.cryptonote', N'iana', 0, NULL, N'cryptonote')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1044, N'application/vnd.rim.cod', N'apache', 0, NULL, N'cod')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1045, N'application/vnd.rn-realmedia', N'apache', 0, NULL, N'rm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1046, N'application/vnd.rn-realmedia-vbr', N'apache', 0, NULL, N'rmvb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1047, N'application/vnd.route66.link66+xml', N'iana', 0, NULL, N'link66')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1048, N'application/vnd.rs-274x', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1049, N'application/vnd.ruckus.download', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1050, N'application/vnd.s3sms', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1051, N'application/vnd.sailingtracker.track', N'iana', 0, NULL, N'st')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1052, N'application/vnd.sbm.cid', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1053, N'application/vnd.sbm.mid2', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1054, N'application/vnd.scribus', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1055, N'application/vnd.sealed.3df', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1056, N'application/vnd.sealed.csf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1057, N'application/vnd.sealed.doc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1058, N'application/vnd.sealed.eml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1059, N'application/vnd.sealed.mht', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1060, N'application/vnd.sealed.net', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1061, N'application/vnd.sealed.ppt', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1062, N'application/vnd.sealed.tiff', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1063, N'application/vnd.sealed.xls', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1064, N'application/vnd.sealedmedia.softseal.html', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1065, N'application/vnd.sealedmedia.softseal.pdf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1066, N'application/vnd.seemail', N'iana', 0, NULL, N'see')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1067, N'application/vnd.sema', N'iana', 0, NULL, N'sema')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1068, N'application/vnd.semd', N'iana', 0, NULL, N'semd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1069, N'application/vnd.semf', N'iana', 0, NULL, N'semf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1070, N'application/vnd.shana.informed.formdata', N'iana', 0, NULL, N'ifm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1071, N'application/vnd.shana.informed.formtemplate', N'iana', 0, NULL, N'itp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1072, N'application/vnd.shana.informed.interchange', N'iana', 0, NULL, N'iif')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1073, N'application/vnd.shana.informed.package', N'iana', 0, NULL, N'ipk')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1074, N'application/vnd.simtech-mindmapper', N'iana', 0, NULL, N'twd, twds')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1075, N'application/vnd.siren+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1076, N'application/vnd.smaf', N'iana', 0, NULL, N'mmf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1077, N'application/vnd.smart.notebook', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1078, N'application/vnd.smart.teacher', N'iana', 0, NULL, N'teacher')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1079, N'application/vnd.software602.filler.form+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1080, N'application/vnd.software602.filler.form-xml-zip', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1081, N'application/vnd.solent.sdkm+xml', N'iana', 0, NULL, N'sdkm, sdkd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1082, N'application/vnd.spotfire.dxp', N'iana', 0, NULL, N'dxp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1083, N'application/vnd.spotfire.sfs', N'iana', 0, NULL, N'sfs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1084, N'application/vnd.sss-cod', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1085, N'application/vnd.sss-dtf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1086, N'application/vnd.sss-ntf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1087, N'application/vnd.stardivision.calc', N'apache', 0, NULL, N'sdc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1088, N'application/vnd.stardivision.draw', N'apache', 0, NULL, N'sda')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1089, N'application/vnd.stardivision.impress', N'apache', 0, NULL, N'sdd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1090, N'application/vnd.stardivision.math', N'apache', 0, NULL, N'smf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1091, N'application/vnd.stardivision.writer', N'apache', 0, NULL, N'sdw, vor')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1092, N'application/vnd.stardivision.writer-global', N'apache', 0, NULL, N'sgl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1093, N'application/vnd.stepmania.package', N'iana', 0, NULL, N'smzip')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1094, N'application/vnd.stepmania.stepchart', N'iana', 0, NULL, N'sm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1095, N'application/vnd.street-stream', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1096, N'application/vnd.sun.wadl+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1097, N'application/vnd.sun.xml.calc', N'apache', 0, NULL, N'sxc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1098, N'application/vnd.sun.xml.calc.template', N'apache', 0, NULL, N'stc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1099, N'application/vnd.sun.xml.draw', N'apache', 0, NULL, N'sxd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1100, N'application/vnd.sun.xml.draw.template', N'apache', 0, NULL, N'std')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1101, N'application/vnd.sun.xml.impress', N'apache', 0, NULL, N'sxi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1102, N'application/vnd.sun.xml.impress.template', N'apache', 0, NULL, N'sti')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1103, N'application/vnd.sun.xml.math', N'apache', 0, NULL, N'sxm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1104, N'application/vnd.sun.xml.writer', N'apache', 0, NULL, N'sxw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1105, N'application/vnd.sun.xml.writer.global', N'apache', 0, NULL, N'sxg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1106, N'application/vnd.sun.xml.writer.template', N'apache', 0, NULL, N'stw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1107, N'application/vnd.sus-calendar', N'iana', 0, NULL, N'sus, susp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1108, N'application/vnd.svd', N'iana', 0, NULL, N'svd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1109, N'application/vnd.swiftview-ics', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1110, N'application/vnd.symbian.install', N'apache', 0, NULL, N'sis, sisx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1111, N'application/vnd.syncml+xml', N'iana', 0, NULL, N'xsm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1112, N'application/vnd.syncml.dm+wbxml', N'iana', 0, NULL, N'bdm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1113, N'application/vnd.syncml.dm+xml', N'iana', 0, NULL, N'xdm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1114, N'application/vnd.syncml.dm.notification', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1115, N'application/vnd.syncml.dmddf+wbxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1116, N'application/vnd.syncml.dmddf+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1117, N'application/vnd.syncml.dmtnds+wbxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1118, N'application/vnd.syncml.dmtnds+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1119, N'application/vnd.syncml.ds.notification', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1120, N'application/vnd.tao.intent-module-archive', N'iana', 0, NULL, N'tao')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1121, N'application/vnd.tcpdump.pcap', N'iana', 0, NULL, N'pcap, cap, dmp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1122, N'application/vnd.tmd.mediaflex.api+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1123, N'application/vnd.tml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1124, N'application/vnd.tmobile-livetv', N'iana', 0, NULL, N'tmo')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1125, N'application/vnd.trid.tpt', N'iana', 0, NULL, N'tpt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1126, N'application/vnd.triscape.mxs', N'iana', 0, NULL, N'mxs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1127, N'application/vnd.trueapp', N'iana', 0, NULL, N'tra')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1128, N'application/vnd.truedoc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1129, N'application/vnd.ubisoft.webplayer', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1130, N'application/vnd.ufdl', N'iana', 0, NULL, N'ufd, ufdl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1131, N'application/vnd.uiq.theme', N'iana', 0, NULL, N'utz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1132, N'application/vnd.umajin', N'iana', 0, NULL, N'umj')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1133, N'application/vnd.unity', N'iana', 0, NULL, N'unityweb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1134, N'application/vnd.uoml+xml', N'iana', 0, NULL, N'uoml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1135, N'application/vnd.uplanet.alert', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1136, N'application/vnd.uplanet.alert-wbxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1137, N'application/vnd.uplanet.bearer-choice', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1138, N'application/vnd.uplanet.bearer-choice-wbxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1139, N'application/vnd.uplanet.cacheop', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1140, N'application/vnd.uplanet.cacheop-wbxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1141, N'application/vnd.uplanet.channel', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1142, N'application/vnd.uplanet.channel-wbxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1143, N'application/vnd.uplanet.list', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1144, N'application/vnd.uplanet.list-wbxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1145, N'application/vnd.uplanet.listcmd', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1146, N'application/vnd.uplanet.listcmd-wbxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1147, N'application/vnd.uplanet.signal', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1148, N'application/vnd.uri-map', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1149, N'application/vnd.valve.source.material', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1150, N'application/vnd.vcx', N'iana', 0, NULL, N'vcx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1151, N'application/vnd.vd-study', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1152, N'application/vnd.vectorworks', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1153, N'application/vnd.vel+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1154, N'application/vnd.verimatrix.vcas', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1155, N'application/vnd.vidsoft.vidconference', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1156, N'application/vnd.visio', N'iana', 0, NULL, N'vsd, vst, vss, vsw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1157, N'application/vnd.visionary', N'iana', 0, NULL, N'vis')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1158, N'application/vnd.vividence.scriptfile', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1159, N'application/vnd.vsf', N'iana', 0, NULL, N'vsf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1160, N'application/vnd.wap.sic', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1161, N'application/vnd.wap.slc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1162, N'application/vnd.wap.wbxml', N'iana', 0, NULL, N'wbxml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1163, N'application/vnd.wap.wmlc', N'iana', 0, NULL, N'wmlc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1164, N'application/vnd.wap.wmlscriptc', N'iana', 0, NULL, N'wmlsc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1165, N'application/vnd.webturbo', N'iana', 0, NULL, N'wtb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1166, N'application/vnd.wfa.p2p', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1167, N'application/vnd.wfa.wsc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1168, N'application/vnd.windows.devicepairing', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1169, N'application/vnd.wmc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1170, N'application/vnd.wmf.bootstrap', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1171, N'application/vnd.wolfram.mathematica', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1172, N'application/vnd.wolfram.mathematica.package', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1173, N'application/vnd.wolfram.player', N'iana', 0, NULL, N'nbp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1174, N'application/vnd.wordperfect', N'iana', 0, NULL, N'wpd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1175, N'application/vnd.wqd', N'iana', 0, NULL, N'wqd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1176, N'application/vnd.wrq-hp3000-labelled', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1177, N'application/vnd.wt.stf', N'iana', 0, NULL, N'stf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1178, N'application/vnd.wv.csp+wbxml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1179, N'application/vnd.wv.csp+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1180, N'application/vnd.wv.ssp+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1181, N'application/vnd.xacml+json', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1182, N'application/vnd.xara', N'iana', 0, NULL, N'xar')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1183, N'application/vnd.xfdl', N'iana', 0, NULL, N'xfdl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1184, N'application/vnd.xfdl.webform', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1185, N'application/vnd.xmi+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1186, N'application/vnd.xmpie.cpkg', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1187, N'application/vnd.xmpie.dpkg', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1188, N'application/vnd.xmpie.plan', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1189, N'application/vnd.xmpie.ppkg', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1190, N'application/vnd.xmpie.xlim', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1191, N'application/vnd.yamaha.hv-dic', N'iana', 0, NULL, N'hvd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1192, N'application/vnd.yamaha.hv-script', N'iana', 0, NULL, N'hvs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1193, N'application/vnd.yamaha.hv-voice', N'iana', 0, NULL, N'hvp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1194, N'application/vnd.yamaha.openscoreformat', N'iana', 0, NULL, N'osf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1195, N'application/vnd.yamaha.openscoreformat.osfpvg+xml', N'iana', 0, NULL, N'osfpvg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1196, N'application/vnd.yamaha.remote-setup', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1197, N'application/vnd.yamaha.smaf-audio', N'iana', 0, NULL, N'saf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1198, N'application/vnd.yamaha.smaf-phrase', N'iana', 0, NULL, N'spf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1199, N'application/vnd.yamaha.through-ngn', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1200, N'application/vnd.yamaha.tunnel-udpencap', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1201, N'application/vnd.yaoweme', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1202, N'application/vnd.yellowriver-custom-menu', N'iana', 0, NULL, N'cmp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1203, N'application/vnd.zul', N'iana', 0, NULL, N'zir, zirz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1204, N'application/vnd.zzazz.deck+xml', N'iana', 0, NULL, N'zaz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1205, N'application/voicexml+xml', N'iana', 0, NULL, N'vxml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1206, N'application/vq-rtcpxr', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1207, N'application/watcherinfo+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1208, N'application/whoispp-query', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1209, N'application/whoispp-response', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1210, N'application/widget', N'iana', 0, NULL, N'wgt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1211, N'application/winhlp', N'apache', 0, NULL, N'hlp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1212, N'application/wita', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1213, N'application/wordperfect5.1', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1214, N'application/wsdl+xml', N'iana', 0, NULL, N'wsdl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1215, N'application/wspolicy+xml', N'iana', 0, NULL, N'wspolicy')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1216, N'application/x-7z-compressed', N'apache', 0, NULL, N'7z')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1217, N'application/x-abiword', N'apache', 0, NULL, N'abw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1218, N'application/x-ace-compressed', N'apache', 0, NULL, N'ace')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1219, N'application/x-amf', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1220, N'application/x-apple-diskimage', N'apache', 0, NULL, N'dmg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1221, N'application/x-authorware-bin', N'apache', 0, NULL, N'aab, x32, u32, vox')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1222, N'application/x-authorware-map', N'apache', 0, NULL, N'aam')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1223, N'application/x-authorware-seg', N'apache', 0, NULL, N'aas')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1224, N'application/x-bcpio', N'apache', 0, NULL, N'bcpio')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1225, N'application/x-bdoc', NULL, 0, NULL, N'bdoc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1226, N'application/x-bittorrent', N'apache', 0, NULL, N'torrent')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1227, N'application/x-blorb', N'apache', 0, NULL, N'blb, blorb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1228, N'application/x-bzip', N'apache', 0, NULL, N'bz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1229, N'application/x-bzip2', N'apache', 0, NULL, N'bz2, boz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1230, N'application/x-cbr', N'apache', 0, NULL, N'cbr, cba, cbt, cbz, cb7')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1231, N'application/x-cdlink', N'apache', 0, NULL, N'vcd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1232, N'application/x-cfs-compressed', N'apache', 0, NULL, N'cfs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1233, N'application/x-chat', N'apache', 0, NULL, N'chat')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1234, N'application/x-chess-pgn', N'apache', 0, NULL, N'pgn')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1235, N'application/x-chrome-extension', NULL, 0, NULL, N'crx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1236, N'application/x-cocoa', N'nginx', 0, NULL, N'cco')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1237, N'application/x-compress', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1238, N'application/x-conference', N'apache', 0, NULL, N'nsc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1239, N'application/x-cpio', N'apache', 0, NULL, N'cpio')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1240, N'application/x-csh', N'apache', 0, NULL, N'csh')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1241, N'application/x-deb', NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1242, N'application/x-debian-package', N'apache', 0, NULL, N'deb, udeb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1243, N'application/x-dgc-compressed', N'apache', 0, NULL, N'dgc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1244, N'application/x-director', N'apache', 0, NULL, N'dir, dcr, dxr, cst, cct, cxt, w3d, fgd, swa')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1245, N'application/x-doom', N'apache', 0, NULL, N'wad')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1246, N'application/x-dtbncx+xml', N'apache', 0, NULL, N'ncx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1247, N'application/x-dtbook+xml', N'apache', 0, NULL, N'dtb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1248, N'application/x-dtbresource+xml', N'apache', 0, NULL, N'res')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1249, N'application/x-dvi', N'apache', 0, NULL, N'dvi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1250, N'application/x-envoy', N'apache', 0, NULL, N'evy')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1251, N'application/x-eva', N'apache', 0, NULL, N'eva')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1252, N'application/x-font-bdf', N'apache', 0, NULL, N'bdf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1253, N'application/x-font-dos', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1254, N'application/x-font-framemaker', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1255, N'application/x-font-ghostscript', N'apache', 0, NULL, N'gsf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1256, N'application/x-font-libgrx', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1257, N'application/x-font-linux-psf', N'apache', 0, NULL, N'psf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1258, N'application/x-font-otf', N'apache', 1, NULL, N'otf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1259, N'application/x-font-pcf', N'apache', 0, NULL, N'pcf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1260, N'application/x-font-snf', N'apache', 0, NULL, N'snf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1261, N'application/x-font-speedo', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1262, N'application/x-font-sunos-news', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1263, N'application/x-font-ttf', N'apache', 1, NULL, N'ttf, ttc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1264, N'application/x-font-type1', N'apache', 0, NULL, N'pfa, pfb, pfm, afm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1265, N'application/x-font-vfont', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1266, N'application/x-freearc', N'apache', 0, NULL, N'arc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1267, N'application/x-futuresplash', N'apache', 0, NULL, N'spl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1268, N'application/x-gca-compressed', N'apache', 0, NULL, N'gca')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1269, N'application/x-glulx', N'apache', 0, NULL, N'ulx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1270, N'application/x-gnumeric', N'apache', 0, NULL, N'gnumeric')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1271, N'application/x-gramps-xml', N'apache', 0, NULL, N'gramps')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1272, N'application/x-gtar', N'apache', 0, NULL, N'gtar')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1273, N'application/x-gzip', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1274, N'application/x-hdf', N'apache', 0, NULL, N'hdf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1275, N'application/x-httpd-php', NULL, 1, NULL, N'php')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1276, N'application/x-install-instructions', N'apache', 0, NULL, N'install')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1277, N'application/x-iso9660-image', N'apache', 0, NULL, N'iso')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1278, N'application/x-java-archive-diff', N'nginx', 0, NULL, N'jardiff')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1279, N'application/x-java-jnlp-file', N'apache', 0, NULL, N'jnlp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1280, N'application/x-javascript', NULL, 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1281, N'application/x-latex', N'apache', 0, NULL, N'latex')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1282, N'application/x-lua-bytecode', NULL, 0, NULL, N'luac')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1283, N'application/x-lzh-compressed', N'apache', 0, NULL, N'lzh, lha')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1284, N'application/x-makeself', N'nginx', 0, NULL, N'run')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1285, N'application/x-mie', N'apache', 0, NULL, N'mie')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1286, N'application/x-mobipocket-ebook', N'apache', 0, NULL, N'prc, mobi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1287, N'application/x-mpegurl', NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1288, N'application/x-ms-application', N'apache', 0, NULL, N'application')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1289, N'application/x-ms-shortcut', N'apache', 0, NULL, N'lnk')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1290, N'application/x-ms-wmd', N'apache', 0, NULL, N'wmd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1291, N'application/x-ms-wmz', N'apache', 0, NULL, N'wmz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1292, N'application/x-ms-xbap', N'apache', 0, NULL, N'xbap')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1293, N'application/x-msaccess', N'apache', 0, NULL, N'mdb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1294, N'application/x-msbinder', N'apache', 0, NULL, N'obd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1295, N'application/x-mscardfile', N'apache', 0, NULL, N'crd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1296, N'application/x-msclip', N'apache', 0, NULL, N'clp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1297, N'application/x-msdos-program', NULL, 0, NULL, N'exe')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1298, N'application/x-msdownload', N'apache', 0, NULL, N'exe, dll, com, bat, msi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1299, N'application/x-msmediaview', N'apache', 0, NULL, N'mvb, m13, m14')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1300, N'application/x-msmetafile', N'apache', 0, NULL, N'wmf, wmz, emf, emz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1301, N'application/x-msmoney', N'apache', 0, NULL, N'mny')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1302, N'application/x-mspublisher', N'apache', 0, NULL, N'pub')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1303, N'application/x-msschedule', N'apache', 0, NULL, N'scd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1304, N'application/x-msterminal', N'apache', 0, NULL, N'trm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1305, N'application/x-mswrite', N'apache', 0, NULL, N'wri')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1306, N'application/x-netcdf', N'apache', 0, NULL, N'nc, cdf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1307, N'application/x-ns-proxy-autoconfig', NULL, 1, NULL, N'pac')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1308, N'application/x-nzb', N'apache', 0, NULL, N'nzb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1309, N'application/x-perl', N'nginx', 0, NULL, N'pl, pm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1310, N'application/x-pilot', N'nginx', 0, NULL, N'prc, pdb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1311, N'application/x-pkcs12', N'apache', 0, NULL, N'p12, pfx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1312, N'application/x-pkcs7-certificates', N'apache', 0, NULL, N'p7b, spc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1313, N'application/x-pkcs7-certreqresp', N'apache', 0, NULL, N'p7r')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1314, N'application/x-rar-compressed', N'apache', 0, NULL, N'rar')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1315, N'application/x-redhat-package-manager', N'nginx', 0, NULL, N'rpm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1316, N'application/x-research-info-systems', N'apache', 0, NULL, N'ris')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1317, N'application/x-sea', N'nginx', 0, NULL, N'sea')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1318, N'application/x-sh', N'apache', 1, NULL, N'sh')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1319, N'application/x-shar', N'apache', 0, NULL, N'shar')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1320, N'application/x-shockwave-flash', N'apache', 0, NULL, N'swf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1321, N'application/x-silverlight-app', N'apache', 0, NULL, N'xap')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1322, N'application/x-sql', N'apache', 0, NULL, N'sql')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1323, N'application/x-stuffit', N'apache', 0, NULL, N'sit')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1324, N'application/x-stuffitx', N'apache', 0, NULL, N'sitx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1325, N'application/x-subrip', N'apache', 0, NULL, N'srt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1326, N'application/x-sv4cpio', N'apache', 0, NULL, N'sv4cpio')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1327, N'application/x-sv4crc', N'apache', 0, NULL, N'sv4crc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1328, N'application/x-t3vm-image', N'apache', 0, NULL, N't3')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1329, N'application/x-tads', N'apache', 0, NULL, N'gam')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1330, N'application/x-tar', N'apache', 1, NULL, N'tar')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1331, N'application/x-tcl', N'apache', 0, NULL, N'tcl, tk')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1332, N'application/x-tex', N'apache', 0, NULL, N'tex')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1333, N'application/x-tex-tfm', N'apache', 0, NULL, N'tfm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1334, N'application/x-texinfo', N'apache', 0, NULL, N'texinfo, texi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1335, N'application/x-tgif', N'apache', 0, NULL, N'obj')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1336, N'application/x-ustar', N'apache', 0, NULL, N'ustar')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1337, N'application/x-wais-source', N'apache', 0, NULL, N'src')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1338, N'application/x-web-app-manifest+json', NULL, 1, NULL, N'webapp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1339, N'application/x-www-form-urlencoded', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1340, N'application/x-x509-ca-cert', N'apache', 0, NULL, N'der, crt, pem')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1341, N'application/x-xfig', N'apache', 0, NULL, N'fig')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1342, N'application/x-xliff+xml', N'apache', 0, NULL, N'xlf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1343, N'application/x-xpinstall', N'apache', 0, NULL, N'xpi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1344, N'application/x-xz', N'apache', 0, NULL, N'xz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1345, N'application/x-zmachine', N'apache', 0, NULL, N'z1, z2, z3, z4, z5, z6, z7, z8')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1346, N'application/x400-bp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1347, N'application/xacml+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1348, N'application/xaml+xml', N'apache', 0, NULL, N'xaml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1349, N'application/xcap-att+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1350, N'application/xcap-caps+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1351, N'application/xcap-diff+xml', N'iana', 0, NULL, N'xdf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1352, N'application/xcap-el+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1353, N'application/xcap-error+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1354, N'application/xcap-ns+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1355, N'application/xcon-conference-info+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1356, N'application/xcon-conference-info-diff+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1357, N'application/xenc+xml', N'iana', 0, NULL, N'xenc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1358, N'application/xhtml+xml', N'iana', 1, NULL, N'xhtml, xht')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1359, N'application/xhtml-voice+xml', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1360, N'application/xml', N'iana', 1, NULL, N'xml, xsl, xsd, rng')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1361, N'application/xml-dtd', N'iana', 1, NULL, N'dtd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1362, N'application/xml-external-parsed-entity', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1363, N'application/xml-patch+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1364, N'application/xmpp+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1365, N'application/xop+xml', N'iana', 1, NULL, N'xop')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1366, N'application/xproc+xml', N'apache', 0, NULL, N'xpl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1367, N'application/xslt+xml', N'iana', 0, NULL, N'xslt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1368, N'application/xspf+xml', N'apache', 0, NULL, N'xspf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1369, N'application/xv+xml', N'iana', 0, NULL, N'mxml, xhvml, xvml, xvm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1370, N'application/yang', N'iana', 0, NULL, N'yang')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1371, N'application/yin+xml', N'iana', 0, NULL, N'yin')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1372, N'application/zip', N'iana', 0, NULL, N'zip')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1373, N'application/zlib', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1374, N'audio/1d-interleaved-parityfec', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1375, N'audio/32kadpcm', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1376, N'audio/3gpp', N'iana', 0, NULL, N'3gpp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1377, N'audio/3gpp2', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1378, N'audio/ac3', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1379, N'audio/adpcm', N'apache', 0, NULL, N'adp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1380, N'audio/amr', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1381, N'audio/amr-wb', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1382, N'audio/amr-wb+', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1383, N'audio/aptx', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1384, N'audio/asc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1385, N'audio/atrac-advanced-lossless', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1386, N'audio/atrac-x', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1387, N'audio/atrac3', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1388, N'audio/basic', N'iana', 0, NULL, N'au, snd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1389, N'audio/bv16', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1390, N'audio/bv32', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1391, N'audio/clearmode', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1392, N'audio/cn', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1393, N'audio/dat12', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1394, N'audio/dls', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1395, N'audio/dsr-es201108', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1396, N'audio/dsr-es202050', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1397, N'audio/dsr-es202211', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1398, N'audio/dsr-es202212', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1399, N'audio/dv', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1400, N'audio/dvi4', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1401, N'audio/eac3', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1402, N'audio/encaprtp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1403, N'audio/evrc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1404, N'audio/evrc-qcp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1405, N'audio/evrc0', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1406, N'audio/evrc1', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1407, N'audio/evrcb', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1408, N'audio/evrcb0', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1409, N'audio/evrcb1', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1410, N'audio/evrcnw', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1411, N'audio/evrcnw0', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1412, N'audio/evrcnw1', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1413, N'audio/evrcwb', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1414, N'audio/evrcwb0', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1415, N'audio/evrcwb1', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1416, N'audio/evs', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1417, N'audio/fwdred', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1418, N'audio/g711-0', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1419, N'audio/g719', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1420, N'audio/g722', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1421, N'audio/g7221', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1422, N'audio/g723', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1423, N'audio/g726-16', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1424, N'audio/g726-24', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1425, N'audio/g726-32', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1426, N'audio/g726-40', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1427, N'audio/g728', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1428, N'audio/g729', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1429, N'audio/g7291', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1430, N'audio/g729d', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1431, N'audio/g729e', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1432, N'audio/gsm', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1433, N'audio/gsm-efr', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1434, N'audio/gsm-hr-08', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1435, N'audio/ilbc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1436, N'audio/ip-mr_v2.5', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1437, N'audio/isac', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1438, N'audio/l16', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1439, N'audio/l20', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1440, N'audio/l24', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1441, N'audio/l8', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1442, N'audio/lpc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1443, N'audio/midi', N'apache', 0, NULL, N'mid, midi, kar, rmi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1444, N'audio/mobile-xmf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1445, N'audio/mp4', N'iana', 0, NULL, N'm4a, mp4a')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1446, N'audio/mp4a-latm', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1447, N'audio/mpa', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1448, N'audio/mpa-robust', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1449, N'audio/mpeg', N'iana', 0, NULL, N'mpga, mp2, mp2a, mp3, m2a, m3a')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1450, N'audio/mpeg4-generic', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1451, N'audio/musepack', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1452, N'audio/ogg', N'iana', 0, NULL, N'oga, ogg, spx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1453, N'audio/opus', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1454, N'audio/parityfec', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1455, N'audio/pcma', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1456, N'audio/pcma-wb', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1457, N'audio/pcmu', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1458, N'audio/pcmu-wb', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1459, N'audio/prs.sid', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1460, N'audio/qcelp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1461, N'audio/raptorfec', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1462, N'audio/red', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1463, N'audio/rtp-enc-aescm128', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1464, N'audio/rtp-midi', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1465, N'audio/rtploopback', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1466, N'audio/rtx', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1467, N'audio/s3m', N'apache', 0, NULL, N's3m')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1468, N'audio/silk', N'apache', 0, NULL, N'sil')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1469, N'audio/smv', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1470, N'audio/smv-qcp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1471, N'audio/smv0', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1472, N'audio/sp-midi', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1473, N'audio/speex', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1474, N'audio/t140c', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1475, N'audio/t38', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1476, N'audio/telephone-event', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1477, N'audio/tone', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1478, N'audio/uemclip', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1479, N'audio/ulpfec', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1480, N'audio/vdvi', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1481, N'audio/vmr-wb', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1482, N'audio/vnd.3gpp.iufp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1483, N'audio/vnd.4sb', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1484, N'audio/vnd.audiokoz', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1485, N'audio/vnd.celp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1486, N'audio/vnd.cisco.nse', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1487, N'audio/vnd.cmles.radio-events', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1488, N'audio/vnd.cns.anp1', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1489, N'audio/vnd.cns.inf1', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1490, N'audio/vnd.dece.audio', N'iana', 0, NULL, N'uva, uvva')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1491, N'audio/vnd.digital-winds', N'iana', 0, NULL, N'eol')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1492, N'audio/vnd.dlna.adts', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1493, N'audio/vnd.dolby.heaac.1', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1494, N'audio/vnd.dolby.heaac.2', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1495, N'audio/vnd.dolby.mlp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1496, N'audio/vnd.dolby.mps', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1497, N'audio/vnd.dolby.pl2', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1498, N'audio/vnd.dolby.pl2x', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1499, N'audio/vnd.dolby.pl2z', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1500, N'audio/vnd.dolby.pulse.1', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1501, N'audio/vnd.dra', N'iana', 0, NULL, N'dra')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1502, N'audio/vnd.dts', N'iana', 0, NULL, N'dts')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1503, N'audio/vnd.dts.hd', N'iana', 0, NULL, N'dtshd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1504, N'audio/vnd.dvb.file', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1505, N'audio/vnd.everad.plj', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1506, N'audio/vnd.hns.audio', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1507, N'audio/vnd.lucent.voice', N'iana', 0, NULL, N'lvp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1508, N'audio/vnd.ms-playready.media.pya', N'iana', 0, NULL, N'pya')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1509, N'audio/vnd.nokia.mobile-xmf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1510, N'audio/vnd.nortel.vbk', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1511, N'audio/vnd.nuera.ecelp4800', N'iana', 0, NULL, N'ecelp4800')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1512, N'audio/vnd.nuera.ecelp7470', N'iana', 0, NULL, N'ecelp7470')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1513, N'audio/vnd.nuera.ecelp9600', N'iana', 0, NULL, N'ecelp9600')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1514, N'audio/vnd.octel.sbc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1515, N'audio/vnd.qcelp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1516, N'audio/vnd.rhetorex.32kadpcm', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1517, N'audio/vnd.rip', N'iana', 0, NULL, N'rip')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1518, N'audio/vnd.rn-realaudio', NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1519, N'audio/vnd.sealedmedia.softseal.mpeg', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1520, N'audio/vnd.vmx.cvsd', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1521, N'audio/vnd.wave', NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1522, N'audio/vorbis', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1523, N'audio/vorbis-config', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1524, N'audio/wav', NULL, 0, NULL, N'wav')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1525, N'audio/wave', NULL, 0, NULL, N'wav')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1526, N'audio/webm', N'apache', 0, NULL, N'weba')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1527, N'audio/x-aac', N'apache', 0, NULL, N'aac')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1528, N'audio/x-aiff', N'apache', 0, NULL, N'aif, aiff, aifc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1529, N'audio/x-caf', N'apache', 0, NULL, N'caf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1530, N'audio/x-flac', N'apache', 0, NULL, N'flac')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1531, N'audio/x-m4a', N'nginx', 0, NULL, N'm4a')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1532, N'audio/x-matroska', N'apache', 0, NULL, N'mka')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1533, N'audio/x-mpegurl', N'apache', 0, NULL, N'm3u')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1534, N'audio/x-ms-wax', N'apache', 0, NULL, N'wax')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1535, N'audio/x-ms-wma', N'apache', 0, NULL, N'wma')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1536, N'audio/x-pn-realaudio', N'apache', 0, NULL, N'ram, ra')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1537, N'audio/x-pn-realaudio-plugin', N'apache', 0, NULL, N'rmp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1538, N'audio/x-realaudio', N'nginx', 0, NULL, N'ra')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1539, N'audio/x-tta', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1540, N'audio/x-wav', N'apache', 0, NULL, N'wav')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1541, N'audio/xm', N'apache', 0, NULL, N'xm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1542, N'chemical/x-cdx', N'apache', 0, NULL, N'cdx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1543, N'chemical/x-cif', N'apache', 0, NULL, N'cif')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1544, N'chemical/x-cmdf', N'apache', 0, NULL, N'cmdf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1545, N'chemical/x-cml', N'apache', 0, NULL, N'cml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1546, N'chemical/x-csml', N'apache', 0, NULL, N'csml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1547, N'chemical/x-pdb', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1548, N'chemical/x-xyz', N'apache', 0, NULL, N'xyz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1549, N'font/opentype', NULL, 1, NULL, N'otf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1550, N'image/bmp', N'apache', 1, NULL, N'bmp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1551, N'image/cgm', N'iana', 0, NULL, N'cgm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1552, N'image/fits', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1553, N'image/g3fax', N'iana', 0, NULL, N'g3')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1554, N'image/gif', N'iana', 0, NULL, N'gif')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1555, N'image/ief', N'iana', 0, NULL, N'ief')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1556, N'image/jp2', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1557, N'image/jpeg', N'iana', 0, NULL, N'jpeg, jpg, jpe')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1558, N'image/jpm', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1559, N'image/jpx', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1560, N'image/ktx', N'iana', 0, NULL, N'ktx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1561, N'image/naplps', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1562, N'image/pjpeg', NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1563, N'image/png', N'iana', 0, NULL, N'png')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1564, N'image/prs.btif', N'iana', 0, NULL, N'btif')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1565, N'image/prs.pti', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1566, N'image/pwg-raster', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1567, N'image/sgi', N'apache', 0, NULL, N'sgi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1568, N'image/svg+xml', N'iana', 1, NULL, N'svg, svgz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1569, N'image/t38', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1570, N'image/tiff', N'iana', 0, NULL, N'tiff, tif')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1571, N'image/tiff-fx', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1572, N'image/vnd.adobe.photoshop', N'iana', 1, NULL, N'psd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1573, N'image/vnd.airzip.accelerator.azv', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1574, N'image/vnd.cns.inf2', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1575, N'image/vnd.dece.graphic', N'iana', 0, NULL, N'uvi, uvvi, uvg, uvvg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1576, N'image/vnd.djvu', N'iana', 0, NULL, N'djvu, djv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1577, N'image/vnd.dvb.subtitle', N'iana', 0, NULL, N'sub')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1578, N'image/vnd.dwg', N'iana', 0, NULL, N'dwg')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1579, N'image/vnd.dxf', N'iana', 0, NULL, N'dxf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1580, N'image/vnd.fastbidsheet', N'iana', 0, NULL, N'fbs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1581, N'image/vnd.fpx', N'iana', 0, NULL, N'fpx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1582, N'image/vnd.fst', N'iana', 0, NULL, N'fst')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1583, N'image/vnd.fujixerox.edmics-mmr', N'iana', 0, NULL, N'mmr')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1584, N'image/vnd.fujixerox.edmics-rlc', N'iana', 0, NULL, N'rlc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1585, N'image/vnd.globalgraphics.pgb', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1586, N'image/vnd.microsoft.icon', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1587, N'image/vnd.mix', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1588, N'image/vnd.mozilla.apng', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1589, N'image/vnd.ms-modi', N'iana', 0, NULL, N'mdi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1590, N'image/vnd.ms-photo', N'apache', 0, NULL, N'wdp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1591, N'image/vnd.net-fpx', N'iana', 0, NULL, N'npx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1592, N'image/vnd.radiance', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1593, N'image/vnd.sealed.png', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1594, N'image/vnd.sealedmedia.softseal.gif', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1595, N'image/vnd.sealedmedia.softseal.jpg', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1596, N'image/vnd.svf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1597, N'image/vnd.tencent.tap', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1598, N'image/vnd.valve.source.texture', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1599, N'image/vnd.wap.wbmp', N'iana', 0, NULL, N'wbmp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1600, N'image/vnd.xiff', N'iana', 0, NULL, N'xif')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1601, N'image/vnd.zbrush.pcx', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1602, N'image/webp', N'apache', 0, NULL, N'webp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1603, N'image/x-3ds', N'apache', 0, NULL, N'3ds')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1604, N'image/x-cmu-raster', N'apache', 0, NULL, N'ras')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1605, N'image/x-cmx', N'apache', 0, NULL, N'cmx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1606, N'image/x-freehand', N'apache', 0, NULL, N'fh, fhc, fh4, fh5, fh7')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1607, N'image/x-icon', N'apache', 1, NULL, N'ico')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1608, N'image/x-jng', N'nginx', 0, NULL, N'jng')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1609, N'image/x-mrsid-image', N'apache', 0, NULL, N'sid')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1610, N'image/x-ms-bmp', N'nginx', 1, NULL, N'bmp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1611, N'image/x-pcx', N'apache', 0, NULL, N'pcx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1612, N'image/x-pict', N'apache', 0, NULL, N'pic, pct')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1613, N'image/x-portable-anymap', N'apache', 0, NULL, N'pnm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1614, N'image/x-portable-bitmap', N'apache', 0, NULL, N'pbm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1615, N'image/x-portable-graymap', N'apache', 0, NULL, N'pgm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1616, N'image/x-portable-pixmap', N'apache', 0, NULL, N'ppm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1617, N'image/x-rgb', N'apache', 0, NULL, N'rgb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1618, N'image/x-tga', N'apache', 0, NULL, N'tga')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1619, N'image/x-xbitmap', N'apache', 0, NULL, N'xbm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1620, N'image/x-xcf', NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1621, N'image/x-xpixmap', N'apache', 0, NULL, N'xpm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1622, N'image/x-xwindowdump', N'apache', 0, NULL, N'xwd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1623, N'message/cpim', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1624, N'message/delivery-status', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1625, N'message/disposition-notification', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1626, N'message/external-body', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1627, N'message/feedback-report', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1628, N'message/global', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1629, N'message/global-delivery-status', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1630, N'message/global-disposition-notification', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1631, N'message/global-headers', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1632, N'message/http', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1633, N'message/imdn+xml', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1634, N'message/news', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1635, N'message/partial', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1636, N'message/rfc822', N'iana', 1, NULL, N'eml, mime')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1637, N'message/s-http', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1638, N'message/sip', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1639, N'message/sipfrag', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1640, N'message/tracking-status', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1641, N'message/vnd.si.simp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1642, N'message/vnd.wfa.wsc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1643, N'model/iges', N'iana', 0, NULL, N'igs, iges')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1644, N'model/mesh', N'iana', 0, NULL, N'msh, mesh, silo')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1645, N'model/vnd.collada+xml', N'iana', 0, NULL, N'dae')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1646, N'model/vnd.dwf', N'iana', 0, NULL, N'dwf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1647, N'model/vnd.flatland.3dml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1648, N'model/vnd.gdl', N'iana', 0, NULL, N'gdl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1649, N'model/vnd.gs-gdl', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1650, N'model/vnd.gs.gdl', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1651, N'model/vnd.gtw', N'iana', 0, NULL, N'gtw')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1652, N'model/vnd.moml+xml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1653, N'model/vnd.mts', N'iana', 0, NULL, N'mts')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1654, N'model/vnd.opengex', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1655, N'model/vnd.parasolid.transmit.binary', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1656, N'model/vnd.parasolid.transmit.text', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1657, N'model/vnd.rosette.annotated-data-model', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1658, N'model/vnd.valve.source.compiled-map', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1659, N'model/vnd.vtu', N'iana', 0, NULL, N'vtu')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1660, N'model/vrml', N'iana', 0, NULL, N'wrl, vrml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1661, N'model/x3d+binary', N'apache', 0, NULL, N'x3db, x3dbz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1662, N'model/x3d+fastinfoset', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1663, N'model/x3d+vrml', N'apache', 0, NULL, N'x3dv, x3dvz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1664, N'model/x3d+xml', N'iana', 1, NULL, N'x3d, x3dz')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1665, N'model/x3d-vrml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1666, N'multipart/alternative', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1667, N'multipart/appledouble', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1668, N'multipart/byteranges', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1669, N'multipart/digest', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1670, N'multipart/encrypted', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1671, N'multipart/form-data', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1672, N'multipart/header-set', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1673, N'multipart/mixed', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1674, N'multipart/parallel', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1675, N'multipart/related', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1676, N'multipart/report', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1677, N'multipart/signed', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1678, N'multipart/voice-message', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1679, N'multipart/x-mixed-replace', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1680, N'text/1d-interleaved-parityfec', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1681, N'text/cache-manifest', N'iana', 1, NULL, N'appcache, manifest')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1682, N'text/calendar', N'iana', 0, NULL, N'ics, ifb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1683, N'text/calender', NULL, 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1684, N'text/cmd', NULL, 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1685, N'text/coffeescript', NULL, 0, NULL, N'coffee, litcoffee')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1686, N'text/css', N'iana', 1, NULL, N'css')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1687, N'text/csv', N'iana', 1, NULL, N'csv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1688, N'text/csv-schema', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1689, N'text/directory', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1690, N'text/dns', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1691, N'text/ecmascript', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1692, N'text/encaprtp', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1693, N'text/enriched', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1694, N'text/fwdred', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1695, N'text/grammar-ref-list', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1696, N'text/json', NULL, 0, NULL, N'json')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1697, N'text/html', N'iana', 1, NULL, N'html, htm, shtml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1698, N'text/jade', NULL, 0, NULL, N'jade')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1699, N'text/javascript', N'iana', 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1700, N'text/jcr-cnd', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1701, N'text/jsx', NULL, 1, NULL, N'jsx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1702, N'text/less', NULL, 0, NULL, N'less')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1703, N'text/markdown', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1704, N'text/mathml', N'nginx', 0, NULL, N'mml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1705, N'text/mizar', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1706, N'text/n3', N'iana', 1, NULL, N'n3')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1707, N'text/parameters', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1708, N'text/parityfec', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1709, N'text/plain', N'iana', 1, NULL, N'txt, text, conf, def, list, log, in, ini')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1710, N'text/provenance-notation', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1711, N'text/prs.fallenstein.rst', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1712, N'text/prs.lines.tag', N'iana', 0, NULL, N'dsc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1713, N'text/prs.prop.logic', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1714, N'text/raptorfec', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1715, N'text/red', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1716, N'text/rfc822-headers', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1717, N'text/richtext', N'iana', 1, NULL, N'rtx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1718, N'text/rtf', N'iana', 1, NULL, N'rtf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1719, N'text/rtp-enc-aescm128', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1720, N'text/rtploopback', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1721, N'text/rtx', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1722, N'text/sgml', N'iana', 0, NULL, N'sgml, sgm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1723, N'text/slim', NULL, 0, NULL, N'slim, slm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1724, N'text/stylus', NULL, 0, NULL, N'stylus, styl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1725, N'text/t140', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1726, N'text/tab-separated-values', N'iana', 1, NULL, N'tsv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1727, N'text/troff', N'iana', 0, NULL, N't, tr, roff, man, me, ms')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1728, N'text/turtle', N'iana', 0, NULL, N'ttl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1729, N'text/ulpfec', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1730, N'text/uri-list', N'iana', 1, NULL, N'uri, uris, urls')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1731, N'text/vcard', N'iana', 1, NULL, N'vcard')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1732, N'text/vnd.a', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1733, N'text/vnd.abc', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1734, N'text/vnd.curl', N'iana', 0, NULL, N'curl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1735, N'text/vnd.curl.dcurl', N'apache', 0, NULL, N'dcurl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1736, N'text/vnd.curl.mcurl', N'apache', 0, NULL, N'mcurl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1737, N'text/vnd.curl.scurl', N'apache', 0, NULL, N'scurl')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1738, N'text/vnd.debian.copyright', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1739, N'text/vnd.dmclientscript', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1740, N'text/vnd.dvb.subtitle', N'iana', 0, NULL, N'sub')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1741, N'text/vnd.esmertec.theme-descriptor', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1742, N'text/vnd.fly', N'iana', 0, NULL, N'fly')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1743, N'text/vnd.fmi.flexstor', N'iana', 0, NULL, N'flx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1744, N'text/vnd.graphviz', N'iana', 0, NULL, N'gv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1745, N'text/vnd.in3d.3dml', N'iana', 0, NULL, N'3dml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1746, N'text/vnd.in3d.spot', N'iana', 0, NULL, N'spot')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1747, N'text/vnd.iptc.newsml', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1748, N'text/vnd.iptc.nitf', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1749, N'text/vnd.latex-z', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1750, N'text/vnd.motorola.reflex', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1751, N'text/vnd.ms-mediapackage', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1752, N'text/vnd.net2phone.commcenter.command', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1753, N'text/vnd.radisys.msml-basic-layout', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1754, N'text/vnd.si.uricatalogue', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1755, N'text/vnd.sun.j2me.app-descriptor', N'iana', 0, NULL, N'jad')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1756, N'text/vnd.trolltech.linguist', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1757, N'text/vnd.wap.si', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1758, N'text/vnd.wap.sl', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1759, N'text/vnd.wap.wml', N'iana', 0, NULL, N'wml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1760, N'text/vnd.wap.wmlscript', N'iana', 0, NULL, N'wmls')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1761, N'text/vtt', NULL, 1, N'UTF-8', N'vtt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1762, N'text/x-asm', N'apache', 0, NULL, N's, asm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1763, N'text/x-c', N'apache', 0, NULL, N'c, cc, cxx, cpp, h, hh, dic')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1764, N'text/x-component', N'nginx', 0, NULL, N'htc')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1765, N'text/x-fortran', N'apache', 0, NULL, N'f, for, f77, f90')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1766, N'text/x-gwt-rpc', NULL, 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1767, N'text/x-handlebars-template', NULL, 0, NULL, N'hbs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1768, N'text/x-java-source', N'apache', 0, NULL, N'java')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1769, N'text/x-jquery-tmpl', NULL, 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1770, N'text/x-lua', NULL, 0, NULL, N'lua')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1771, N'text/x-markdown', NULL, 1, NULL, N'markdown, md, mkd')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1772, N'text/x-nfo', N'apache', 0, NULL, N'nfo')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1773, N'text/x-opml', N'apache', 0, NULL, N'opml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1774, N'text/x-pascal', N'apache', 0, NULL, N'p, pas')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1775, N'text/x-processing', NULL, 1, NULL, N'pde')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1776, N'text/x-sass', NULL, 0, NULL, N'sass')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1777, N'text/x-scss', NULL, 0, NULL, N'scss')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1778, N'text/x-setext', N'apache', 0, NULL, N'etx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1779, N'text/x-sfv', N'apache', 0, NULL, N'sfv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1780, N'text/x-suse-ymp', NULL, 1, NULL, N'ymp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1781, N'text/x-uuencode', N'apache', 0, NULL, N'uu')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1782, N'text/x-vcalendar', N'apache', 0, NULL, N'vcs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1783, N'text/x-vcard', N'apache', 0, NULL, N'vcf')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1784, N'text/xml', N'iana', 1, NULL, N'xml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1785, N'text/xml-external-parsed-entity', N'iana', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1786, N'text/yaml', NULL, 0, NULL, N'yaml, yml')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1787, N'video/1d-interleaved-parityfec', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1788, N'video/3gpp', N'apache', 0, NULL, N'3gp, 3gpp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1789, N'video/3gpp-tt', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1790, N'video/3gpp2', N'apache', 0, NULL, N'3g2')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1791, N'video/bmpeg', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1792, N'video/bt656', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1793, N'video/celb', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1794, N'video/dv', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1795, N'video/encaprtp', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1796, N'video/h261', N'apache', 0, NULL, N'h261')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1797, N'video/h263', N'apache', 0, NULL, N'h263')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1798, N'video/h263-1998', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1799, N'video/h263-2000', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1800, N'video/h264', N'apache', 0, NULL, N'h264')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1801, N'video/h264-rcdo', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1802, N'video/h264-svc', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1803, N'video/h265', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1804, N'video/iso.segment', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1805, N'video/jpeg', N'apache', 0, NULL, N'jpgv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1806, N'video/jpeg2000', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1807, N'video/jpm', N'apache', 0, NULL, N'jpm, jpgm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1808, N'video/mj2', N'apache', 0, NULL, N'mj2, mjp2')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1809, N'video/mp1s', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1810, N'video/mp2p', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1811, N'video/mp2t', N'apache', 0, NULL, N'ts')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1812, N'video/mp4', N'apache', 0, NULL, N'mp4, mp4v, mpg4')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1813, N'video/mp4v-es', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1814, N'video/mpeg', N'apache', 0, NULL, N'mpeg, mpg, mpe, m1v, m2v')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1815, N'video/mpeg4-generic', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1816, N'video/mpv', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1817, N'video/nv', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1818, N'video/ogg', N'apache', 0, NULL, N'ogv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1819, N'video/parityfec', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1820, N'video/pointer', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1821, N'video/quicktime', N'apache', 0, NULL, N'qt, mov')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1822, N'video/raptorfec', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1823, N'video/raw', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1824, N'video/rtp-enc-aescm128', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1825, N'video/rtploopback', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1826, N'video/rtx', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1827, N'video/smpte292m', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1828, N'video/ulpfec', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1829, N'video/vc1', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1830, N'video/vnd.cctv', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1831, N'video/vnd.dece.hd', N'apache', 0, NULL, N'uvh, uvvh')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1832, N'video/vnd.dece.mobile', N'apache', 0, NULL, N'uvm, uvvm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1833, N'video/vnd.dece.mp4', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1834, N'video/vnd.dece.pd', N'apache', 0, NULL, N'uvp, uvvp')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1835, N'video/vnd.dece.sd', N'apache', 0, NULL, N'uvs, uvvs')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1836, N'video/vnd.dece.video', N'apache', 0, NULL, N'uvv, uvvv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1837, N'video/vnd.directv.mpeg', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1838, N'video/vnd.directv.mpeg-tts', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1839, N'video/vnd.dlna.mpeg-tts', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1840, N'video/vnd.dvb.file', N'apache', 0, NULL, N'dvb')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1841, N'video/vnd.fvt', N'apache', 0, NULL, N'fvt')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1842, N'video/vnd.hns.video', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1843, N'video/vnd.iptvforum.1dparityfec-1010', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1844, N'video/vnd.iptvforum.1dparityfec-2005', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1845, N'video/vnd.iptvforum.2dparityfec-1010', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1846, N'video/vnd.iptvforum.2dparityfec-2005', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1847, N'video/vnd.iptvforum.ttsavc', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1848, N'video/vnd.iptvforum.ttsmpeg2', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1849, N'video/vnd.motorola.video', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1850, N'video/vnd.motorola.videop', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1851, N'video/vnd.mpegurl', N'apache', 0, NULL, N'mxu, m4u')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1852, N'video/vnd.ms-playready.media.pyv', N'apache', 0, NULL, N'pyv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1853, N'video/vnd.nokia.interleaved-multimedia', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1854, N'video/vnd.nokia.videovoip', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1855, N'video/vnd.objectvideo', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1856, N'video/vnd.radgamettools.bink', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1857, N'video/vnd.radgamettools.smacker', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1858, N'video/vnd.sealed.mpeg1', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1859, N'video/vnd.sealed.mpeg4', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1860, N'video/vnd.sealed.swf', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1861, N'video/vnd.sealedmedia.softseal.mov', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1862, N'video/vnd.uvvu.mp4', N'apache', 0, NULL, N'uvu, uvvu')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1863, N'video/vnd.vivo', N'apache', 0, NULL, N'viv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1864, N'video/vp8', N'apache', 0, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1865, N'video/webm', N'apache', 0, NULL, N'webm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1866, N'video/x-f4v', N'apache', 0, NULL, N'f4v')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1867, N'video/x-fli', N'apache', 0, NULL, N'fli')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1868, N'video/x-flv', N'apache', 0, NULL, N'flv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1869, N'video/x-m4v', N'apache', 0, NULL, N'm4v')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1870, N'video/x-matroska', N'apache', 0, NULL, N'mkv, mk3d, mks')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1871, N'video/x-mng', N'apache', 0, NULL, N'mng')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1872, N'video/x-ms-asf', N'apache', 0, NULL, N'asf, asx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1873, N'video/x-ms-vob', N'apache', 0, NULL, N'vob')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1874, N'video/x-ms-wm', N'apache', 0, NULL, N'wm')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1875, N'video/x-ms-wmv', N'apache', 0, NULL, N'wmv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1876, N'video/x-ms-wmx', N'apache', 0, NULL, N'wmx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1877, N'video/x-ms-wvx', N'apache', 0, NULL, N'wvx')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1878, N'video/x-msvideo', N'apache', 0, NULL, N'avi')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1879, N'video/x-sgi-movie', N'apache', 0, NULL, N'movie')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1880, N'video/x-smv', N'apache', 0, NULL, N'smv')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1881, N'x-conference/x-cooltalk', N'apache', 0, NULL, N'ice')
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1882, N'x-shader/x-fragment', NULL, 1, NULL, NULL)
GO
INSERT [dbo].[Mimes] ([Id], [Value], [Source], [Compressible], [Charset], [Extensions]) VALUES (1883, N'x-shader/x-vertex', NULL, 1, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Mimes] OFF
GO
SET IDENTITY_INSERT [dbo].[MimeTypes] ON 
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1, 17, N'ez', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (2, 19, N'aw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (3, 22, N'atom', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (4, 23, N'atomcat', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (5, 26, N'atomsvc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (6, 31, N'bdoc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (7, 39, N'ccxml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (8, 41, N'cdmia', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (9, 42, N'cdmic', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (10, 43, N'cdmid', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (11, 44, N'cdmio', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (12, 45, N'cdmiq', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (13, 61, N'cu', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (14, 64, N'mpd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (15, 66, N'davmount', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (16, 75, N'dbk', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (17, 77, N'dssc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (18, 78, N'xdssc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (19, 80, N'ecma', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (20, 90, N'emma', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (21, 94, N'epub', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (22, 96, N'exi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (23, 102, N'pfr', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (24, 103, N'woff', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (25, 104, N'woff2', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (26, 106, N'gml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (27, 107, N'gpx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (28, 108, N'gxf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (29, 113, N'stk', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (30, 124, N'ink', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (31, 124, N'inkml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (32, 126, N'ipfix', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (33, 130, N'ear', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (34, 130, N'jar', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (35, 130, N'war', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (36, 131, N'ser', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (37, 132, N'class', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (38, 133, N'js', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (39, 137, N'json', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (40, 137, N'map', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (41, 140, N'json5', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (42, 141, N'jsonml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (43, 147, N'jsonld', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (44, 150, N'lostxml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (45, 153, N'hqx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (46, 154, N'cpt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (47, 156, N'mads', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (48, 157, N'webmanifest', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (49, 158, N'mrc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (50, 159, N'mrcx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (51, 160, N'ma', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (52, 160, N'mb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (53, 160, N'nb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (54, 161, N'mathml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (55, 175, N'mbox', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (56, 178, N'mscml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (57, 180, N'metalink', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (58, 181, N'meta4', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (59, 182, N'mets', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (60, 185, N'mods', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (61, 190, N'm21', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (62, 190, N'mp21', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (63, 191, N'm4p', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (64, 191, N'mp4s', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (65, 199, N'doc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (66, 199, N'dot', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (67, 200, N'mxf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (68, 209, N'bin', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (69, 209, N'bpk', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (70, 209, N'buffer', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (71, 209, N'deb', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (72, 209, N'deploy', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (73, 209, N'dist', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (74, 209, N'distz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (75, 209, N'dll', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (76, 209, N'dmg', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (77, 209, N'dms', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (78, 209, N'dump', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (79, 209, N'elc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (80, 209, N'exe', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (81, 209, N'img', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (82, 209, N'iso', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (83, 209, N'lrf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (84, 209, N'mar', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (85, 209, N'msi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (86, 209, N'msm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (87, 209, N'msp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (88, 209, N'pkg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (89, 209, N'so', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (90, 210, N'oda', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (91, 212, N'opf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (92, 213, N'ogx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (93, 214, N'omdoc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (94, 215, N'onepkg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (95, 215, N'onetmp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (96, 215, N'onetoc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (97, 215, N'onetoc2', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (98, 216, N'oxps', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (99, 219, N'xer', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (100, 220, N'pdf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (101, 222, N'pgp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (102, 224, N'asc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (103, 224, N'sig', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (104, 225, N'prf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (105, 228, N'p10', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (106, 230, N'p7c', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (107, 230, N'p7m', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (108, 231, N'p7s', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (109, 232, N'p8', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (110, 233, N'ac', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (111, 234, N'cer', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (112, 235, N'crl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (113, 236, N'pkipath', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (114, 237, N'pki', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (115, 238, N'pls', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (116, 240, N'ai', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (117, 240, N'eps', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (118, 240, N'ps', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (119, 246, N'cww', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (120, 252, N'pskcxml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (121, 256, N'rdf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (122, 257, N'rif', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (123, 258, N'rnc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (124, 261, N'rl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (125, 262, N'rld', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (126, 266, N'rs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (127, 267, N'gbr', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (128, 268, N'mft', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (129, 269, N'roa', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (130, 271, N'rsd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (131, 272, N'rss', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (132, 273, N'rtf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (133, 278, N'sbml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (134, 281, N'scq', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (135, 282, N'scs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (136, 283, N'spq', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (137, 284, N'spp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (138, 285, N'sdp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (139, 290, N'setpay', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (140, 292, N'setreg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (141, 295, N'shf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (142, 302, N'smi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (143, 302, N'smil', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (144, 306, N'rq', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (145, 307, N'srx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (146, 310, N'gram', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (147, 311, N'grxml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (148, 312, N'sru', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (149, 313, N'ssdl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (150, 314, N'ssml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (151, 327, N'tei', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (152, 327, N'teicorpus', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (153, 328, N'tfi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (154, 331, N'tsd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (155, 348, N'plb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (156, 349, N'psb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (157, 350, N'pvb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (158, 359, N'tcap', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (159, 361, N'pwn', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (160, 362, N'aso', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (161, 363, N'imp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (162, 364, N'acu', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (163, 365, N'acutc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (164, 365, N'atc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (165, 366, N'air', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (166, 368, N'fcdt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (167, 369, N'fxp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (168, 369, N'fxpl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (169, 371, N'xdp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (170, 372, N'xfdf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (171, 375, N'ahead', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (172, 376, N'azf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (173, 377, N'azs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (174, 378, N'azw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (175, 379, N'acc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (176, 380, N'ami', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (177, 382, N'apk', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (178, 384, N'cii', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (179, 385, N'fti', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (180, 386, N'atx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (181, 391, N'mpkg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (182, 392, N'm3u8', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (183, 393, N'pkpass', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (184, 395, N'swi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (185, 397, N'iota', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (186, 398, N'aep', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (187, 405, N'mpm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (188, 408, N'bmi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (189, 409, N'rep', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (190, 415, N'cdxml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (191, 416, N'mmd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (192, 417, N'cdy', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (193, 420, N'cla', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (194, 421, N'rp9', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (195, 422, N'c4d', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (196, 422, N'c4f', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (197, 422, N'c4g', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (198, 422, N'c4p', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (199, 422, N'c4u', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (200, 423, N'c11amc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (201, 424, N'c11amz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (202, 430, N'csp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (203, 431, N'cdbcmsg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (204, 433, N'cmc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (205, 434, N'clkx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (206, 435, N'clkk', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (207, 436, N'clkp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (208, 437, N'clkt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (209, 438, N'clkw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (210, 439, N'wbs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (211, 440, N'pml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (212, 444, N'ppd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (213, 448, N'car', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (214, 449, N'pcurl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (215, 452, N'dart', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (216, 453, N'rdz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (217, 455, N'uvd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (218, 455, N'uvf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (219, 455, N'uvvd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (220, 455, N'uvvf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (221, 456, N'uvt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (222, 456, N'uvvt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (223, 457, N'uvvx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (224, 457, N'uvx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (225, 458, N'uvvz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (226, 458, N'uvz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (227, 459, N'fe_launch', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (228, 464, N'dna', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (229, 466, N'mlp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (230, 470, N'dpg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (231, 471, N'dfac', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (232, 473, N'kpxx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (233, 477, N'ait', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (234, 495, N'svc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (235, 497, N'geo', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (236, 501, N'mag', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (237, 508, N'nml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (238, 511, N'esf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (239, 512, N'msf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (240, 513, N'qam', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (241, 514, N'slt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (242, 515, N'ssf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (243, 517, N'es3', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (244, 517, N'et3', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (245, 541, N'ez2', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (246, 542, N'ez3', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (247, 545, N'fdf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (248, 546, N'mseed', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (249, 547, N'dataless', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (250, 547, N'seed', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (251, 552, N'gph', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (252, 553, N'ftc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (253, 555, N'book', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (254, 555, N'fm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (255, 555, N'frame', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (256, 555, N'maker', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (257, 556, N'fnc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (258, 557, N'ltf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (259, 558, N'fsc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (260, 559, N'oas', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (261, 560, N'oa2', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (262, 561, N'oa3', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (263, 562, N'fg5', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (264, 563, N'bh2', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (265, 566, N'ddd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (266, 567, N'xdw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (267, 568, N'xbd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (268, 572, N'fzs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (269, 573, N'txd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (270, 576, N'ggb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (271, 577, N'ggt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (272, 578, N'gex', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (273, 578, N'gre', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (274, 579, N'gxt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (275, 580, N'g2w', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (276, 581, N'g3w', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (277, 585, N'gmx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (278, 586, N'gdoc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (279, 587, N'gslides', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (280, 588, N'gsheet', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (281, 589, N'kml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (282, 590, N'kmz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (283, 594, N'gqf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (284, 594, N'gqs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (285, 596, N'gac', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (286, 597, N'ghf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (287, 598, N'gim', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (288, 599, N'grv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (289, 600, N'gtm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (290, 601, N'tpl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (291, 602, N'vcg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (292, 604, N'hal', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (293, 605, N'zmm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (294, 606, N'hbci', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (295, 610, N'les', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (296, 611, N'hpgl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (297, 612, N'hpid', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (298, 613, N'hps', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (299, 614, N'jlt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (300, 615, N'pcl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (301, 616, N'pclxl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (302, 618, N'sfd-hdstx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (303, 623, N'mpy', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (304, 624, N'afp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (305, 624, N'list3820', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (306, 624, N'listafp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (307, 625, N'irm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (308, 626, N'sc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (309, 627, N'icc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (310, 627, N'icm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (311, 629, N'igl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (312, 630, N'ivp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (313, 631, N'ivu', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (314, 646, N'igm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (315, 647, N'xpw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (316, 647, N'xpx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (317, 648, N'i2g', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (318, 651, N'qbo', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (319, 652, N'qfx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (320, 660, N'rcprofile', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (321, 661, N'irp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (322, 662, N'xpr', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (323, 663, N'fcs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (324, 664, N'jam', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (325, 673, N'rms', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (326, 674, N'jisp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (327, 675, N'joda', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (328, 677, N'ktr', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (329, 677, N'ktz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (330, 678, N'karbon', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (331, 679, N'chrt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (332, 680, N'kfo', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (333, 681, N'flw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (334, 682, N'kon', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (335, 683, N'kpr', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (336, 683, N'kpt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (337, 684, N'ksp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (338, 685, N'kwd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (339, 685, N'kwt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (340, 686, N'htke', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (341, 687, N'kia', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (342, 688, N'kne', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (343, 688, N'knp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (344, 689, N'skd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (345, 689, N'skm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (346, 689, N'skp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (347, 689, N'skt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (348, 690, N'sse', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (349, 691, N'lasxml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (350, 693, N'lbd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (351, 694, N'lbe', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (352, 695, N'123', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (353, 696, N'apr', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (354, 697, N'pre', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (355, 698, N'nsf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (356, 699, N'org', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (357, 700, N'scm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (358, 701, N'lwp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (359, 702, N'portpkg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (360, 710, N'mcd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (361, 711, N'mc1', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (362, 712, N'cdkey', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (363, 714, N'mwf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (364, 715, N'mfm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (365, 717, N'flo', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (366, 718, N'igx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (367, 721, N'mif', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (368, 724, N'daf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (369, 725, N'dis', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (370, 726, N'mbk', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (371, 727, N'mqy', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (372, 728, N'msl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (373, 729, N'plc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (374, 730, N'txf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (375, 731, N'mpn', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (376, 732, N'mpc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (377, 741, N'xul', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (378, 743, N'cil', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (379, 745, N'cab', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (380, 747, N'xla', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (381, 747, N'xlc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (382, 747, N'xlm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (383, 747, N'xls', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (384, 747, N'xlt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (385, 747, N'xlw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (386, 748, N'xlam', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (387, 749, N'xlsb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (388, 750, N'xlsm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (389, 751, N'xltm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (390, 752, N'eot', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (391, 753, N'chm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (392, 754, N'ims', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (393, 755, N'lrm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (394, 757, N'thmx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (395, 760, N'cat', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (396, 761, N'stl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (397, 763, N'pot', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (398, 763, N'pps', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (399, 763, N'ppt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (400, 764, N'ppam', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (401, 765, N'pptm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (402, 766, N'sldm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (403, 767, N'ppsm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (404, 768, N'potm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (405, 772, N'mpp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (406, 772, N'mpt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (407, 782, N'docm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (408, 783, N'dotm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (409, 784, N'wcm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (410, 784, N'wdb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (411, 784, N'wks', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (412, 784, N'wps', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (413, 785, N'wpl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (414, 786, N'xps', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (415, 788, N'mseq', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (416, 793, N'mus', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (417, 794, N'msty', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (418, 795, N'taglet', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (419, 800, N'nlu', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (420, 803, N'nitf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (421, 803, N'ntf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (422, 804, N'nnd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (423, 805, N'nns', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (424, 806, N'nnw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (425, 816, N'ngdat', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (426, 817, N'n-gage', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (427, 821, N'rpst', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (428, 822, N'rpss', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (429, 823, N'edm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (430, 824, N'edx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (431, 825, N'ext', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (432, 831, N'odc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (433, 832, N'otc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (434, 833, N'odb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (435, 834, N'odf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (436, 835, N'odft', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (437, 836, N'odg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (438, 837, N'otg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (439, 838, N'odi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (440, 839, N'oti', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (441, 840, N'odp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (442, 841, N'otp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (443, 842, N'ods', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (444, 843, N'ots', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (445, 844, N'odt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (446, 845, N'odm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (447, 846, N'ott', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (448, 847, N'oth', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (449, 861, N'xo', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (450, 885, N'dd2', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (451, 905, N'oxt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (452, 922, N'pptx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (453, 925, N'sldx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (454, 929, N'ppsx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (455, 934, N'potx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (456, 951, N'xlsx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (457, 957, N'xltx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (458, 967, N'docx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (459, 977, N'dotx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (460, 986, N'mgp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (461, 988, N'dp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (462, 989, N'esa', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (463, 993, N'oprc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (464, 993, N'pdb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (465, 993, N'pqa', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (466, 997, N'paw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (467, 999, N'str', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (468, 1000, N'ei6', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (469, 1002, N'efif', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (470, 1003, N'wg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (471, 1005, N'plf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (472, 1006, N'pbd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (473, 1013, N'box', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (474, 1014, N'mgz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (475, 1015, N'qps', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (476, 1016, N'ptid', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (477, 1020, N'qwd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (478, 1020, N'qwt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (479, 1020, N'qxb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (480, 1020, N'qxd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (481, 1020, N'qxl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (482, 1020, N'qxt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (483, 1039, N'bed', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (484, 1040, N'mxl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (485, 1041, N'musicxml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (486, 1043, N'cryptonote', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (487, 1044, N'cod', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (488, 1045, N'rm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (489, 1046, N'rmvb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (490, 1047, N'link66', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (491, 1051, N'st', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (492, 1066, N'see', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (493, 1067, N'sema', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (494, 1068, N'semd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (495, 1069, N'semf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (496, 1070, N'ifm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (497, 1071, N'itp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (498, 1072, N'iif', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (499, 1073, N'ipk', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (500, 1074, N'twd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (501, 1074, N'twds', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (502, 1076, N'mmf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (503, 1078, N'teacher', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (504, 1081, N'sdkd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (505, 1081, N'sdkm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (506, 1082, N'dxp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (507, 1083, N'sfs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (508, 1087, N'sdc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (509, 1088, N'sda', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (510, 1089, N'sdd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (511, 1090, N'smf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (512, 1091, N'sdw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (513, 1091, N'vor', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (514, 1092, N'sgl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (515, 1093, N'smzip', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (516, 1094, N'sm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (517, 1097, N'sxc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (518, 1098, N'stc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (519, 1099, N'sxd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (520, 1100, N'std', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (521, 1101, N'sxi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (522, 1102, N'sti', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (523, 1103, N'sxm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (524, 1104, N'sxw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (525, 1105, N'sxg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (526, 1106, N'stw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (527, 1107, N'sus', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (528, 1107, N'susp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (529, 1108, N'svd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (530, 1110, N'sis', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (531, 1110, N'sisx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (532, 1111, N'xsm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (533, 1112, N'bdm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (534, 1113, N'xdm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (535, 1120, N'tao', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (536, 1121, N'cap', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (537, 1121, N'dmp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (538, 1121, N'pcap', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (539, 1124, N'tmo', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (540, 1125, N'tpt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (541, 1126, N'mxs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (542, 1127, N'tra', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (543, 1130, N'ufd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (544, 1130, N'ufdl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (545, 1131, N'utz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (546, 1132, N'umj', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (547, 1133, N'unityweb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (548, 1134, N'uoml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (549, 1150, N'vcx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (550, 1156, N'vsd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (551, 1156, N'vss', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (552, 1156, N'vst', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (553, 1156, N'vsw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (554, 1157, N'vis', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (555, 1159, N'vsf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (556, 1162, N'wbxml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (557, 1163, N'wmlc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (558, 1164, N'wmlsc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (559, 1165, N'wtb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (560, 1173, N'nbp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (561, 1174, N'wpd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (562, 1175, N'wqd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (563, 1177, N'stf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (564, 1182, N'xar', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (565, 1183, N'xfdl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (566, 1191, N'hvd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (567, 1192, N'hvs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (568, 1193, N'hvp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (569, 1194, N'osf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (570, 1195, N'osfpvg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (571, 1197, N'saf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (572, 1198, N'spf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (573, 1202, N'cmp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (574, 1203, N'zir', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (575, 1203, N'zirz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (576, 1204, N'zaz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (577, 1205, N'vxml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (578, 1210, N'wgt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (579, 1211, N'hlp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (580, 1214, N'wsdl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (581, 1215, N'wspolicy', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (582, 1216, N'7z', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (583, 1217, N'abw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (584, 1218, N'ace', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (585, 1220, N'dmg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (586, 1221, N'aab', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (587, 1221, N'u32', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (588, 1221, N'vox', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (589, 1221, N'x32', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (590, 1222, N'aam', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (591, 1223, N'aas', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (592, 1224, N'bcpio', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (593, 1225, N'bdoc', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (594, 1226, N'torrent', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (595, 1227, N'blb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (596, 1227, N'blorb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (597, 1228, N'bz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (598, 1229, N'boz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (599, 1229, N'bz2', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (600, 1230, N'cb7', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (601, 1230, N'cba', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (602, 1230, N'cbr', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (603, 1230, N'cbt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (604, 1230, N'cbz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (605, 1231, N'vcd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (606, 1232, N'cfs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (607, 1233, N'chat', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (608, 1234, N'pgn', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (609, 1235, N'crx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (610, 1236, N'cco', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (611, 1238, N'nsc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (612, 1239, N'cpio', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (613, 1240, N'csh', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (614, 1242, N'deb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (615, 1242, N'udeb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (616, 1243, N'dgc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (617, 1244, N'cct', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (618, 1244, N'cst', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (619, 1244, N'cxt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (620, 1244, N'dcr', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (621, 1244, N'dir', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (622, 1244, N'dxr', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (623, 1244, N'fgd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (624, 1244, N'swa', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (625, 1244, N'w3d', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (626, 1245, N'wad', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (627, 1246, N'ncx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (628, 1247, N'dtb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (629, 1248, N'res', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (630, 1249, N'dvi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (631, 1250, N'evy', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (632, 1251, N'eva', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (633, 1252, N'bdf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (634, 1255, N'gsf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (635, 1257, N'psf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (636, 1258, N'otf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (637, 1259, N'pcf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (638, 1260, N'snf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (639, 1263, N'ttc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (640, 1263, N'ttf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (641, 1264, N'afm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (642, 1264, N'pfa', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (643, 1264, N'pfb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (644, 1264, N'pfm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (645, 1266, N'arc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (646, 1267, N'spl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (647, 1268, N'gca', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (648, 1269, N'ulx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (649, 1270, N'gnumeric', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (650, 1271, N'gramps', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (651, 1272, N'gtar', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (652, 1274, N'hdf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (653, 1275, N'php', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (654, 1276, N'install', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (655, 1277, N'iso', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (656, 1278, N'jardiff', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (657, 1279, N'jnlp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (658, 1281, N'latex', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (659, 1282, N'luac', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (660, 1283, N'lha', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (661, 1283, N'lzh', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (662, 1284, N'run', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (663, 1285, N'mie', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (664, 1286, N'mobi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (665, 1286, N'prc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (666, 1288, N'application', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (667, 1289, N'lnk', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (668, 1290, N'wmd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (669, 1291, N'wmz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (670, 1292, N'xbap', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (671, 1293, N'mdb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (672, 1294, N'obd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (673, 1295, N'crd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (674, 1296, N'clp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (675, 1297, N'exe', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (676, 1298, N'bat', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (677, 1298, N'com', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (678, 1298, N'dll', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (679, 1298, N'exe', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (680, 1298, N'msi', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (681, 1299, N'm13', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (682, 1299, N'm14', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (683, 1299, N'mvb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (684, 1300, N'emf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (685, 1300, N'emz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (686, 1300, N'wmf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (687, 1300, N'wmz', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (688, 1301, N'mny', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (689, 1302, N'pub', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (690, 1303, N'scd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (691, 1304, N'trm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (692, 1305, N'wri', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (693, 1306, N'cdf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (694, 1306, N'nc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (695, 1307, N'pac', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (696, 1308, N'nzb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (697, 1309, N'pl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (698, 1309, N'pm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (699, 1310, N'pdb', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (700, 1310, N'prc', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (701, 1311, N'p12', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (702, 1311, N'pfx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (703, 1312, N'p7b', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (704, 1312, N'spc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (705, 1313, N'p7r', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (706, 1314, N'rar', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (707, 1315, N'rpm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (708, 1316, N'ris', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (709, 1317, N'sea', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (710, 1318, N'sh', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (711, 1319, N'shar', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (712, 1320, N'swf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (713, 1321, N'xap', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (714, 1322, N'sql', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (715, 1323, N'sit', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (716, 1324, N'sitx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (717, 1325, N'srt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (718, 1326, N'sv4cpio', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (719, 1327, N'sv4crc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (720, 1328, N't3', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (721, 1329, N'gam', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (722, 1330, N'tar', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (723, 1331, N'tcl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (724, 1331, N'tk', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (725, 1332, N'tex', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (726, 1333, N'tfm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (727, 1334, N'texi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (728, 1334, N'texinfo', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (729, 1335, N'obj', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (730, 1336, N'ustar', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (731, 1337, N'src', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (732, 1338, N'webapp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (733, 1340, N'crt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (734, 1340, N'der', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (735, 1340, N'pem', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (736, 1341, N'fig', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (737, 1342, N'xlf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (738, 1343, N'xpi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (739, 1344, N'xz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (740, 1345, N'z1', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (741, 1345, N'z2', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (742, 1345, N'z3', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (743, 1345, N'z4', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (744, 1345, N'z5', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (745, 1345, N'z6', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (746, 1345, N'z7', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (747, 1345, N'z8', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (748, 1348, N'xaml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (749, 1351, N'xdf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (750, 1357, N'xenc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (751, 1358, N'xht', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (752, 1358, N'xhtml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (753, 1360, N'rng', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (754, 1360, N'xml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (755, 1360, N'xsd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (756, 1360, N'xsl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (757, 1361, N'dtd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (758, 1365, N'xop', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (759, 1366, N'xpl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (760, 1367, N'xslt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (761, 1368, N'xspf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (762, 1369, N'mxml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (763, 1369, N'xhvml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (764, 1369, N'xvm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (765, 1369, N'xvml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (766, 1370, N'yang', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (767, 1371, N'yin', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (768, 1372, N'zip', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (769, 1376, N'3gpp', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (770, 1379, N'adp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (771, 1388, N'au', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (772, 1388, N'snd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (773, 1443, N'kar', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (774, 1443, N'mid', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (775, 1443, N'midi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (776, 1443, N'rmi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (777, 1445, N'm4a', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (778, 1445, N'mp4a', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (779, 1449, N'm2a', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (780, 1449, N'm3a', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (781, 1449, N'mp2', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (782, 1449, N'mp2a', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (783, 1449, N'mp3', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (784, 1449, N'mpga', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (785, 1452, N'oga', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (786, 1452, N'ogg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (787, 1452, N'spx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (788, 1467, N's3m', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (789, 1468, N'sil', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (790, 1490, N'uva', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (791, 1490, N'uvva', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (792, 1491, N'eol', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (793, 1501, N'dra', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (794, 1502, N'dts', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (795, 1503, N'dtshd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (796, 1507, N'lvp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (797, 1508, N'pya', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (798, 1511, N'ecelp4800', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (799, 1512, N'ecelp7470', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (800, 1513, N'ecelp9600', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (801, 1517, N'rip', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (802, 1524, N'wav', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (803, 1525, N'wav', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (804, 1526, N'weba', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (805, 1527, N'aac', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (806, 1528, N'aif', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (807, 1528, N'aifc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (808, 1528, N'aiff', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (809, 1529, N'caf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (810, 1530, N'flac', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (811, 1531, N'm4a', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (812, 1532, N'mka', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (813, 1533, N'm3u', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (814, 1534, N'wax', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (815, 1535, N'wma', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (816, 1536, N'ra', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (817, 1536, N'ram', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (818, 1537, N'rmp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (819, 1538, N'ra', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (820, 1540, N'wav', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (821, 1541, N'xm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (822, 1542, N'cdx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (823, 1543, N'cif', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (824, 1544, N'cmdf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (825, 1545, N'cml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (826, 1546, N'csml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (827, 1548, N'xyz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (828, 1549, N'otf', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (829, 1550, N'bmp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (830, 1551, N'cgm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (831, 1553, N'g3', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (832, 1554, N'gif', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (833, 1555, N'ief', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (834, 1557, N'jpe', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (835, 1557, N'jpeg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (836, 1557, N'jpg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (837, 1560, N'ktx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (838, 1563, N'png', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (839, 1564, N'btif', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (840, 1567, N'sgi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (841, 1568, N'svg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (842, 1568, N'svgz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (843, 1570, N'tif', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (844, 1570, N'tiff', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (845, 1572, N'psd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (846, 1575, N'uvg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (847, 1575, N'uvi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (848, 1575, N'uvvg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (849, 1575, N'uvvi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (850, 1576, N'djv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (851, 1576, N'djvu', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (852, 1577, N'sub', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (853, 1578, N'dwg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (854, 1579, N'dxf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (855, 1580, N'fbs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (856, 1581, N'fpx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (857, 1582, N'fst', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (858, 1583, N'mmr', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (859, 1584, N'rlc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (860, 1589, N'mdi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (861, 1590, N'wdp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (862, 1591, N'npx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (863, 1599, N'wbmp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (864, 1600, N'xif', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (865, 1602, N'webp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (866, 1603, N'3ds', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (867, 1604, N'ras', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (868, 1605, N'cmx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (869, 1606, N'fh', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (870, 1606, N'fh4', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (871, 1606, N'fh5', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (872, 1606, N'fh7', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (873, 1606, N'fhc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (874, 1607, N'ico', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (875, 1608, N'jng', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (876, 1609, N'sid', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (877, 1610, N'bmp', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (878, 1611, N'pcx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (879, 1612, N'pct', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (880, 1612, N'pic', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (881, 1613, N'pnm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (882, 1614, N'pbm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (883, 1615, N'pgm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (884, 1616, N'ppm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (885, 1617, N'rgb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (886, 1618, N'tga', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (887, 1619, N'xbm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (888, 1621, N'xpm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (889, 1622, N'xwd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (890, 1636, N'eml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (891, 1636, N'mime', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (892, 1643, N'iges', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (893, 1643, N'igs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (894, 1644, N'mesh', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (895, 1644, N'msh', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (896, 1644, N'silo', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (897, 1645, N'dae', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (898, 1646, N'dwf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (899, 1648, N'gdl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (900, 1651, N'gtw', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (901, 1653, N'mts', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (902, 1659, N'vtu', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (903, 1660, N'vrml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (904, 1660, N'wrl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (905, 1661, N'x3db', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (906, 1661, N'x3dbz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (907, 1663, N'x3dv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (908, 1663, N'x3dvz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (909, 1664, N'x3d', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (910, 1664, N'x3dz', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (911, 1681, N'appcache', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (912, 1681, N'manifest', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (913, 1682, N'ics', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (914, 1682, N'ifb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (915, 1685, N'coffee', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (916, 1685, N'litcoffee', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (917, 1686, N'css', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (918, 1687, N'csv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (919, 1696, N'hjson', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (920, 1697, N'htm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (921, 1697, N'html', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (922, 1697, N'shtml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (923, 1698, N'jade', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (924, 1701, N'jsx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (925, 1702, N'less', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (926, 1704, N'mml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (927, 1706, N'n3', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (928, 1709, N'conf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (929, 1709, N'def', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (930, 1709, N'in', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (931, 1709, N'ini', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (932, 1709, N'list', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (933, 1709, N'log', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (934, 1709, N'text', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (935, 1709, N'txt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (936, 1712, N'dsc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (937, 1717, N'rtx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (938, 1718, N'rtf', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (939, 1722, N'sgm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (940, 1722, N'sgml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (941, 1723, N'slim', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (942, 1723, N'slm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (943, 1724, N'styl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (944, 1724, N'stylus', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (945, 1726, N'tsv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (946, 1727, N'man', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (947, 1727, N'me', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (948, 1727, N'ms', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (949, 1727, N'roff', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (950, 1727, N't', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (951, 1727, N'tr', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (952, 1728, N'ttl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (953, 1730, N'uri', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (954, 1730, N'uris', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (955, 1730, N'urls', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (956, 1731, N'vcard', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (957, 1734, N'curl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (958, 1735, N'dcurl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (959, 1736, N'mcurl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (960, 1737, N'scurl', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (961, 1740, N'sub', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (962, 1742, N'fly', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (963, 1743, N'flx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (964, 1744, N'gv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (965, 1745, N'3dml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (966, 1746, N'spot', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (967, 1755, N'jad', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (968, 1759, N'wml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (969, 1760, N'wmls', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (970, 1761, N'vtt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (971, 1762, N'asm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (972, 1762, N's', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (973, 1763, N'c', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (974, 1763, N'cc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (975, 1763, N'cpp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (976, 1763, N'cxx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (977, 1763, N'dic', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (978, 1763, N'h', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (979, 1763, N'hh', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (980, 1764, N'htc', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (981, 1765, N'f', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (982, 1765, N'f77', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (983, 1765, N'f90', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (984, 1765, N'for', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (985, 1767, N'hbs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (986, 1768, N'java', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (987, 1770, N'lua', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (988, 1771, N'markdown', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (989, 1771, N'md', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (990, 1771, N'mkd', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (991, 1772, N'nfo', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (992, 1773, N'opml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (993, 1774, N'p', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (994, 1774, N'pas', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (995, 1775, N'pde', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (996, 1776, N'sass', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (997, 1777, N'scss', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (998, 1778, N'etx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (999, 1779, N'sfv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1000, 1780, N'ymp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1001, 1781, N'uu', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1002, 1782, N'vcs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1003, 1783, N'vcf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1004, 1784, N'xml', 0)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1005, 1786, N'yaml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1006, 1786, N'yml', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1007, 1788, N'3gp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1008, 1788, N'3gpp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1009, 1790, N'3g2', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1010, 1796, N'h261', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1011, 1797, N'h263', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1012, 1800, N'h264', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1013, 1805, N'jpgv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1014, 1807, N'jpgm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1015, 1807, N'jpm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1016, 1808, N'mj2', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1017, 1808, N'mjp2', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1018, 1811, N'ts', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1019, 1812, N'mp4', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1020, 1812, N'mp4v', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1021, 1812, N'mpg4', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1022, 1814, N'm1v', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1023, 1814, N'm2v', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1024, 1814, N'mpe', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1025, 1814, N'mpeg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1026, 1814, N'mpg', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1027, 1818, N'ogv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1028, 1821, N'mov', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1029, 1821, N'qt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1030, 1831, N'uvh', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1031, 1831, N'uvvh', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1032, 1832, N'uvm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1033, 1832, N'uvvm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1034, 1834, N'uvp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1035, 1834, N'uvvp', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1036, 1835, N'uvs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1037, 1835, N'uvvs', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1038, 1836, N'uvv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1039, 1836, N'uvvv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1040, 1840, N'dvb', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1041, 1841, N'fvt', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1042, 1851, N'm4u', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1043, 1851, N'mxu', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1044, 1852, N'pyv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1045, 1862, N'uvu', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1046, 1862, N'uvvu', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1047, 1863, N'viv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1048, 1865, N'webm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1049, 1866, N'f4v', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1050, 1867, N'fli', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1051, 1868, N'flv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1052, 1869, N'm4v', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1053, 1870, N'mk3d', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1054, 1870, N'mks', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1055, 1870, N'mkv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1056, 1871, N'mng', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1057, 1872, N'asf', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1058, 1872, N'asx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1059, 1873, N'vob', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1060, 1874, N'wm', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1061, 1875, N'wmv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1062, 1876, N'wmx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1063, 1877, N'wvx', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1064, 1878, N'avi', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1065, 1879, N'movie', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1066, 1880, N'smv', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1067, 1881, N'ice', 1)
GO
INSERT [dbo].[MimeTypes] ([Id], [MimeId], [Extension], [IsDefault]) VALUES (1068, 1696, N'json', 0)
GO
SET IDENTITY_INSERT [dbo].[MimeTypes] OFF
GO
ALTER TABLE [dbo].[MimeTypes] ADD  CONSTRAINT [DF_MimeExtension_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[FileTypes_MimeTypes]  WITH CHECK ADD  CONSTRAINT [FK_FileTypes_MimeTypes_FileTypes] FOREIGN KEY([FileTypeId])
REFERENCES [dbo].[FileTypes] ([Id])
GO
ALTER TABLE [dbo].[FileTypes_MimeTypes] CHECK CONSTRAINT [FK_FileTypes_MimeTypes_FileTypes]
GO
ALTER TABLE [dbo].[FileTypes_MimeTypes]  WITH CHECK ADD  CONSTRAINT [FK_FileTypes_MimeTypes_MimeTypes] FOREIGN KEY([MimeTypeId])
REFERENCES [dbo].[MimeTypes] ([Id])
GO
ALTER TABLE [dbo].[FileTypes_MimeTypes] CHECK CONSTRAINT [FK_FileTypes_MimeTypes_MimeTypes]
GO
ALTER TABLE [dbo].[MimeTypes]  WITH CHECK ADD  CONSTRAINT [FK_MimeTypes_Mimes] FOREIGN KEY([MimeId])
REFERENCES [dbo].[Mimes] ([Id])
GO
ALTER TABLE [dbo].[MimeTypes] CHECK CONSTRAINT [FK_MimeTypes_Mimes]
GO
ALTER TABLE [dbo].[FileTypeTexts]  WITH CHECK ADD  CONSTRAINT [FK_FileTypeTexts_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[FileTypeTexts] CHECK CONSTRAINT [FK_FileTypeTexts_Languages]
GO
ALTER TABLE [dbo].[FileTypeTexts]  WITH CHECK ADD  CONSTRAINT [FK_FileTypeTexts_FileTypes] FOREIGN KEY([RecordId])
REFERENCES [dbo].[FileTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FileTypeTexts] CHECK CONSTRAINT [FK_FileTypeTexts_FileTypes]
GO

