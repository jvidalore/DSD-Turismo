using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pe.Edu.Upc.NTravel.Domain.DTO
{
    public class Vuelo
    {
        public int Id { get; set; }
        public string Aerolinea { get; set; }
        public int Asientos { get; set; }
        public decimal Costo { get; set; }
        public string Clase { get; set; }
    }
}
