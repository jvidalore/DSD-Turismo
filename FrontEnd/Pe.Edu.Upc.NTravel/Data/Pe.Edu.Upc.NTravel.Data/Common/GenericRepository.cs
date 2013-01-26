using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using Pe.Edu.Upc.NTravel.Data.Model.Common;
using Pe.Edu.Upc.NTravel.Domain.Common;

namespace Pe.Edu.Upc.NTravel.Data.Common
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
    where T : Entity
    {
        internal DbContext db;
        internal DbSet<T> dbSet;

        public GenericRepository(DbContext dbContext)
        {
            this.db = dbContext;
            this.dbSet = db.Set<T>();
        }

        public void Insert(T entidad)
        {
            this.db.Set<T>().Add(entidad);
        }

        public void Edit(T entidad)
        {
            this.db.Entry(entidad).State = System.Data.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entidad = FindById(id);
            entidad.IsDelete = true;
        }

        public virtual IQueryable<T> ListAll()
        {
            IQueryable<T> query = this.db.Set<T>().Where(c => c.IsDelete == false);
            return query;
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = this.dbSet.Where(c => c.IsDelete == false);
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public T FindById(int id)
        {
            T entity = this.db.Set<T>().FirstOrDefault(c => c.IsDelete == false && c.Id == id);
            return entity;
        }

        public T FindOne(Expression<Func<T, bool>> filter)
        {
            T entity = this.db.Set<T>().Where(c => c.IsDelete == false).Where(filter).SingleOrDefault();
            return entity;
        }
    }
}