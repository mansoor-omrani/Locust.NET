declare @mimes nvarchar(max)
declare @mimetypes nvarchar(max)

set @mimes = '[' + stuff(
					(
						select
							',[' + cast(m.Id as varchar(10)) + ',"' +isnull(m.Source, '') + '","' + isnull(m.Value, '')  + '",' + case when m.Compressible = 1 then 'true' else 'false' end + ',"' + isnull(m.Charset, '') + '","' + isnull(m.Extensions, '') + '"]' as ' '
						from Mimes m order by m.Id for xml path('')
					), 1, 1, '') + ']'

set @mimetypes = '[' + stuff(
					(
						select
							',[' + cast(mt.MimeId as varchar(10)) + ',"' + isnull(mt.Extension, '') + '",' + case when mt.IsDefault = 1 then 'true' else 'false' end + ']' as ' '
						from MimeTypes mt order by mt.Extension for xml path('')
					), 1, 1, '') + ']'

