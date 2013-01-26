using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Pe.Edu.Upc.NTravel.Data.Model.Entities;
using Pe.Edu.Upc.NTravel.Service.Security;

namespace Pe.Edu.Upc.NTravel.Site.Src.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioService userService = new UsuarioService();
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LogOn(string correo, string clave)
        {
            var user = this.userService.Login(correo, clave);

            return Json(user);
        }
    }
}
