using System.Data.Common;

namespace Locust.Db
{
    public interface IDb
    {
        DbConnection GetConnection();
        bool PersistConnection { get; set; }
        bool AutoNullEmptyStrings { get; set; }
    }
}
