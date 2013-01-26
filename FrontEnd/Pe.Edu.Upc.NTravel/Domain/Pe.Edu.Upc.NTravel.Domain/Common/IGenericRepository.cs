using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Pe.Edu.Upc.NTravel.Data.Model.Common;
namespace Pe.Edu.Upc.NTravel.Domain.Common
{
    /// <summary>
    /// Repository contract: for persisting an entity.
    /// </summary>
    public interface IGenericRepository<T>
        where T : Entity
    {
        /// <summary>
        /// Saves an entity.
        /// </summary>
        /// <param name="obj">The entity to save.</param>
        void Insert(T entidad);
        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="obj">The entity to update.</param>
        void Edit(T entidad);

        void Delete(int id);
        IQueryable<T> ListAll();
        IQueryable<T> Find(Expression<Func<T, bool>> filter = null);
        /// <summary>
        /// Gets the entity with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the entity to return.</param>
        /// <returns>The entity with the specified ID.</returns>
        T FindById(int id);
        T FindOne(Expression<Func<T, bool>> filter);
    }
}
