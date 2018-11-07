select
	', new Mime { Id = ' + cast(m.Id as varchar(10)) + ', Source = "' +isnull(m.Source, '') + '", Value = "' + isnull(m.Value, '')  + '" , Compressible = ' + case when m.Compressible = 1 then 'true' else 'false' end + ', CharSet = "' + isnull(m.Charset, '') + '", Extensions = "' + isnull(m.Extensions, '') + '" }' as ' '
from Mimes m order by m.Id

select
	', new MimeType { Id = ' + cast(mt.Id as varchar(10)) + ', MimeId = ' + cast(mt.MimeId as varchar(10)) + ', Extension = "' + isnull(mt.Extension, '') + '", IsDefault = ' + case when mt.IsDefault = 1 then 'true' else 'false' end + ' }'  as ' '
from MimeTypes mt order by mt.Extension

select '{"' + mt.Extension + '", "' + m.Value + '"},'
from MimeTypes mt inner join Mimes m on mt.MimeId = m.Id where mt.IsDefault = 1

