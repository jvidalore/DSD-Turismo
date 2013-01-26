using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.Edu.Upc.NTravel.Data.Model.Common;

namespace Pe.Edu.Upc.NTravel.Data.Model.Entities
{
    public class Tours : Entity
    {
        public int IdLugar { get; set; }
        public String Descripción { get; set; }
        public decimal Duracion { get; set; }
        public decimal Costo { get; set; }

        public Lugar Lugar { get; set; }

        public ICollection<Viaje> Viajes { get; set; }
    }
}
