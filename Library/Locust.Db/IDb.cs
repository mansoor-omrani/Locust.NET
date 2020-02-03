using System.Data.Common;

public interface IDb
    {
        DbConnection GetConnection();
        bool PersistConnection { get; set; }
        bool AutoNullEmptyStrings { get; set; }
    }
