using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.Edu.Upc.NTravel.Data.Model.Common;

namespace Pe.Edu.Upc.NTravel.Data.Model.Entities
{
    public class Usuario : Entity
    {
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DefaultAction { get; set; }
    }
}
