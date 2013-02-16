using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.DTO;
using BusinessLogic;
namespace wsRest.Controllers
{
    public class VueloController : ApiController
    {
        // private readonly Vuelo repositorio = new Vuelo();
        List<Domain.DTO.Vuelo> oVuelo = null;
        
        // GET api/vuelo
        public IEnumerable<Domain.DTO.Vuelo> GetVuelos()
        {
            oVuelo = BLVuelo.CargarVueloAll();
            return oVuelo;
        }

        // GET api/vuelo/0/20130104/20130104/000070/000070
        public IEnumerable<Domain.DTO.Vuelo> GetVuelos(string FechaPartida, string FechaRegreso, string LugarOrigen, string LugarDestino)
        {
            oVuelo = BLVuelo.CargarVueloFind(FechaPartida,FechaRegreso,LugarOrigen,LugarDestino);
            return oVuelo;
        }

        // GET api/vuelo/94
        public IEnumerable<Domain.DTO.Vuelo> GetVuelos(int id)
        {
            oVuelo = BLVuelo.CargarVueloOne(id);
            return oVuelo;
        }

        // POST api/vuelo
        public HttpResponseMessage PostVuelo(int id, int QtSeleccionada)
        {
            bool result = BLVuelo.ActualizarVuelo(id, QtSeleccionada);
            if (result == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/vuelo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/vuelo/5
        public void Delete(int id)
        {
        }
    }
}
