using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Pe.Edu.Upc.NTravel.Data.Model.Entities;

namespace Pe.Edu.Upc.NTravel.Site.Src.ViewModel
{
    public class ViajeViewModel
    {
        public SelectList Lugares { get; set; }

        public ViajeViewModel(List<Lugar> lugares)
        {
            this.Lugares = new SelectList(lugares, "Id", "Descripcion");
        }
    }
}
