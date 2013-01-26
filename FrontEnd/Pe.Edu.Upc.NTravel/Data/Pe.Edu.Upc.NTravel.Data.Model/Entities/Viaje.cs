using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.Edu.Upc.NTravel.Data.Model.Common;

namespace Pe.Edu.Upc.NTravel.Data.Model.Entities
{
    public class Viaje : Entity
    {
        public int IdLugarOrigen { get; set; }
        public int IdLugarDestino { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Partida { get; set; }
        public DateTime Regreso { get; set; }
        public int Adultos { get; set; }
        public int Ninios { get; set; }
        public int Habitaciones { get; set; }

        public Lugar Origen { get; set; }
        public Lugar Destino { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<Tours> Tours { get; set; }
    }
}
