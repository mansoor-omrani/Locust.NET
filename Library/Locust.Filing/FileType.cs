using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Filing
{
    public class FileType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CodeName { get; set; }
        public string Extensions { get; set; }
    }
    public class FileTypeText
    {
        public int LanguageId { get; set; }
        public int RecordId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class MimeType
    {
        public short Id { get; set; }
        public short MimeId { get; set; }
        public string Extension { get; set; }
        public bool IsDefault { get; set; }
    }
    public class Mime
    {
        public short Id { get; set; }
        public string Value { get; set; }
        public string Source { get; set; }
        public string Charset { get; set; }
        public bool Compressible { get; set; }
        public string Extensions { get; set; }
    }
    public class FileTypeMimeType
    {
        public int FileTypeId { get; set; }
        public short MimeTypeId { get; set; }
    }
}
