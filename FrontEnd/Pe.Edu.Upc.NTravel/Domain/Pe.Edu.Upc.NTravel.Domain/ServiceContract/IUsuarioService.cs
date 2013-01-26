using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.Edu.Upc.NTravel.Domain.Common;
using Pe.Edu.Upc.NTravel.Data.Model.Entities;

namespace Pe.Edu.Upc.NTravel.Domain.ServiceContract
{
    public interface IUsuarioService : IGenericService<Usuario>
    {
        Usuario Login(string userName, string password);
    }
}
