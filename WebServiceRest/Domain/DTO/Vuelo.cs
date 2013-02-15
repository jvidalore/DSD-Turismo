using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.DTO
{
    public class Vuelo
    {
        public int NuVuelo { get; set; }
        public string CoAerolinea { get; set; }
        public string CoCiudadOri { get; set; }
        public string CoCiudadDes { get; set; }
        public decimal SsCosto { get; set; }
        public DateTime FeSalida { get; set; }
        public DateTime FeRetorno { get; set; }
        public DateTime HrSalida { get; set; }
        public DateTime HrRetorno { get; set; }
        public int QtDisponible { get; set; }

        #region "No Campos"
        public string NoRazonSocialAerolina { get; set; }
        public string NoCiudadDescripcionOri { get; set; }
        public string NoCiudadDescripcionDes { get; set; }
        #endregion

    }
}
