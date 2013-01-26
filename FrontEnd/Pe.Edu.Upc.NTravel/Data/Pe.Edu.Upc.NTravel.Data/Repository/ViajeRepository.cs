using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.Edu.Upc.NTravel.Data.Common;
using Pe.Edu.Upc.NTravel.Domain.RepositoryContract;
using Pe.Edu.Upc.NTravel.Data.Model.Entities;
using System.Data.Entity;

namespace Pe.Edu.Upc.NTravel.Data.Repository
{
    public class ViajeRepository : GenericRepository<Viaje>, IViajeRepository
    {
        public ViajeRepository(DbContext context)
            : base(context)
        { }
    }
}
