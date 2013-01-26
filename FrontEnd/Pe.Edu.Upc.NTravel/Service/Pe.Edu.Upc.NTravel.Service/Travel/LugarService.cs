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
using Pe.Edu.Upc.NTravel.Domain.DTO;
using Pe.Edu.Upc.NTravel.Service.SOAHotel;

namespace Pe.Edu.Upc.NTravel.Service.Travel
{
    public class LugarService : GenericService<Lugar>, ILugarService
    {

        public LugarService()
        {
            this.Provider = new DBContextProvider();
            this.LugarRepository = new LugarRepository(this.Provider.Context);
        }
        public ILugarRepository LugarRepository
        {
            set
            {
                this.genericRepository = value;
            }
            get
            {
                return this.genericRepository as ILugarRepository;
            }
        }


        public List<Lugar> ListarTodos(string descripcion = null)
        {
            var resultado = this.LugarRepository.Find(l => l.Descripcion.Contains(descripcion) || descripcion == null).ToList();

            return resultado;
        }
    }
}
