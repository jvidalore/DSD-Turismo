using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Common;
using Pe.Edu.Upc.NTravel.Data.Common;

namespace Pe.Edu.Upc.NTravel.Data.Context
{
    public class DBContextProvider : IDBContextProvider
    {
        public DbContext Context { get; set; }
        public DbTransaction Transaction { get; set; }

        public DBContextProvider()
        {
            if (Context == null)
            {
                Context = new GenericDBContext();
            }
        }

        public void Save()
        {
            Context.SaveChanges();

            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public bool LazyLoadingEnabled
        {
            get { return Context.Configuration.LazyLoadingEnabled; }
            set { Context.Configuration.LazyLoadingEnabled = value; }
        }

        public bool ProxyCreationEnabled
        {
            get { return Context.Configuration.ProxyCreationEnabled; }
            set { Context.Configuration.ProxyCreationEnabled = value; }
        }

        public string ConnectionString
        {
            get { return Context.Database.Connection.ConnectionString; }
            set { Context.Database.Connection.ConnectionString = value; }
        }

        private bool Disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    if (Transaction != null)
                    {
                        Transaction.Dispose();
                    }

                    if (Context != null)
                    {
                        Context.Dispose();
                    }
                    Context = null;
                    Transaction = null;
                }
            }
            this.Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
