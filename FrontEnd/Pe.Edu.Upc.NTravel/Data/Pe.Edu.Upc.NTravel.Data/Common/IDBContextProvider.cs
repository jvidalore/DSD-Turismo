using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Pe.Edu.Upc.NTravel.Data.Common
{
    public interface IDBContextProvider : IDisposable
    {
        DbContext Context { get; set; }
        void Save();
        bool LazyLoadingEnabled { get; set; }
        bool ProxyCreationEnabled { get; set; }
        string ConnectionString { get; set; }
    }
}
