using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace wsRest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{qtSeleccionada}/{fechaPartida}/{fechaRegreso}/{lugarOrigen}/{lugarDestino}",
                defaults: new { id = RouteParameter.Optional,
                                qtSeleccionada = RouteParameter.Optional,            
                                fechaPartida = RouteParameter.Optional,
                                fechaRegreso = RouteParameter.Optional,
                                lugarOrigen = RouteParameter.Optional,
                                lugarDestino = RouteParameter.Optional
                }
            );

        }
    }
}
