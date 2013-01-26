using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Pe.Edu.Upc.NTravel.Data.Model.Entities;
using Pe.Edu.Upc.NTravel.Service.Travel;
using Pe.Edu.Upc.NTravel.Site.Src.ViewModel;

namespace Pe.Edu.Upc.NTravel.Site.Src.Controllers
{
    public class ViajeController : Controller
    {
        private ViajeService viajeService = new ViajeService();
        private LugarService lugarService = new LugarService();

        public ActionResult Index()
        {
            var lugares = lugarService.ListarTodos();
            ViajeViewModel viajeModel = new ViajeViewModel(lugares);
            return View(viajeModel);
        }

        [HttpPost]
        public ActionResult Buscar(Viaje viaje)
        {
            var resultado = viajeService.BuscarDisponibilidad(viaje);
            return PartialView(resultado);
        }
    }
}
