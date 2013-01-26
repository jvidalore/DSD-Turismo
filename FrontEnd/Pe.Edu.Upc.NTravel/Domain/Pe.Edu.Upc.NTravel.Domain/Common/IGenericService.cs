using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.Edu.Upc.NTravel.Data.Model.Common;

namespace Pe.Edu.Upc.NTravel.Domain.Common
{
    public interface IGenericService<T>:IDisposable
          where T : Entity
    {
        /// <summary>
        /// Saves an entity if it is new, or updates it if it is old.
        /// </summary>
        /// <param name="entity">The entity to save or update.</param>
        void InsertOrEdit(T entity);
        /// <summary>
        /// Delete an entity , logic delete.
        /// </summary>
        /// <param name="id">The id entity to delete.</param>
        void Delete(int id);
    }
}
