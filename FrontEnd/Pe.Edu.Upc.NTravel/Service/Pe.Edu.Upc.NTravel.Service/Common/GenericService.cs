using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.Edu.Upc.NTravel.Domain.Common;
using Pe.Edu.Upc.NTravel.Data.Model.Common;
using Pe.Edu.Upc.NTravel.Data.Common;

namespace Pe.Edu.Upc.NTravel.Service.Common
{
    public abstract class GenericService<T> : IGenericService<T>
        where T : Entity
    {
        protected IGenericRepository<T> genericRepository;
        public IDBContextProvider Provider { get; set; }

        public void InsertOrEdit(T entity)
        {
            using (Provider)
            {
                if (entity.Id == 0)
                {
                    genericRepository.Insert(entity);
                }
                else
                {
                    genericRepository.Edit(entity);
                }
                Provider.Save();
            }

        }

        public void Delete(int id)
        {
            using (Provider)
            {
                genericRepository.Delete(id);
                Provider.Save();
            }
        }

        private bool Disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    if (Provider != null)
                    {
                        Provider.Dispose();
                    }
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
