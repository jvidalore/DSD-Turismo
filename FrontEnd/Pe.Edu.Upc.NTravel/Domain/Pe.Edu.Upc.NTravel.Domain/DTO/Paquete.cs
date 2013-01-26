using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.Edu.Upc.NTravel.Data.Model.Entities;

namespace Pe.Edu.Upc.NTravel.Domain.DTO
{
    public class Paquete
    {
        public List<Hotel> Hoteles { get; set; }
        public List<Vuelo> Vuelos { get; set; }
        public List<Tours> Tours { get; set; }
    }
}
