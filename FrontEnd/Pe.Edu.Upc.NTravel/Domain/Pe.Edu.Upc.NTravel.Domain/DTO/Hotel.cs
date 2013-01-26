using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pe.Edu.Upc.NTravel.Domain.DTO
{
    public class Hotel
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Logo { get; set; }
        public int Camas { get; set; }
        public int Categoria { get; set; }
        public decimal Costo { get; set; }
    }
}
