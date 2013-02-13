using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace wsRest.Controllers
{
    public class VueloController : ApiController
    {
        private BD_DSDEntities db = new BD_DSDEntities();

        // GET api/Vuelo
        public IEnumerable<Vuelo> GetVueloes()
        {
            var vueloes = db.Vueloes.Include("Aerolinea").Include("Ciudad").Include("Ciudad1");
            return vueloes.AsEnumerable();
        }

        // GET api/Vuelo/5
        public Vuelo GetVuelo(int id)
        {
            Vuelo vuelo = db.Vueloes.Single(v => v.NuVuelo == id);
            if (vuelo == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return vuelo;
        }

        // PUT api/Vuelo/5
        public HttpResponseMessage PutVuelo(int id, Vuelo vuelo)
        {
            if (ModelState.IsValid && id == vuelo.NuVuelo)
            {
                db.Vueloes.Attach(vuelo);
                db.ObjectStateManager.ChangeObjectState(vuelo, EntityState.Modified);

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Vuelo
        public HttpResponseMessage PostVuelo(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                db.Vueloes.AddObject(vuelo);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, vuelo);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = vuelo.NuVuelo }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Vuelo/5
        public HttpResponseMessage DeleteVuelo(int id)
        {
            Vuelo vuelo = db.Vueloes.Single(v => v.NuVuelo == id);
            if (vuelo == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Vueloes.DeleteObject(vuelo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, vuelo);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}