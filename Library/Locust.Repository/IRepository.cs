using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Repository
{
    public interface IRepository
    {
        bool AutoSave { get; set; }
    }
    public interface IRepository<T, PK>: IRepository, ISyncRepository<T, PK>, IAsyncRepository<T, PK>
    {
    }
}
