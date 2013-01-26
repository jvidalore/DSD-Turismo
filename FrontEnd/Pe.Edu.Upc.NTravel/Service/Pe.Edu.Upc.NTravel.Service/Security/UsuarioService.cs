using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.Edu.Upc.NTravel.Service.Common;
using Pe.Edu.Upc.NTravel.Data.Context;
using Pe.Edu.Upc.NTravel.Data.Repository;
using Pe.Edu.Upc.NTravel.Data.Model.Entities;
using Pe.Edu.Upc.NTravel.Domain.ServiceContract;
using Pe.Edu.Upc.NTravel.Domain.RepositoryContract;

namespace Pe.Edu.Upc.NTravel.Service.Security
{
    public class UsuarioService : GenericService<Usuario>, IUsuarioService
    {
        public UsuarioService()
        {
            this.Provider = new DBContextProvider();
            this.UserRepository = new UsuarioRepository(this.Provider.Context);


        }

        public IUsuarioRepository UserRepository
        {
            set
            {
                this.genericRepository = value;
            }
            get
            {
                return this.genericRepository as IUsuarioRepository;
            }
        }

        public Usuario Login(string correo, string clave)
        {
            var user = this.UserRepository.FindOne(u => u.Correo.Equals(correo) && u.Clave.Equals(clave));
            return user;
        }
    }
}
