using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Prediccion;

namespace Game.Controllers
{
    public class EquiposController : ApiController
    {

        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            var unEquipo = Equipo.Create(1, "Argentina");
            response.Content = new ObjectContent(typeof(Equipo), unEquipo, new JsonMediaTypeFormatter()); // new StringContent("{equipoid:1, equiponombre:argentina}");
            return response;
        }

        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            var equipos = new List<Equipo>();
            equipos.Add(Equipo.Create(1, "ARG"));
            equipos.Add(Equipo.Create(2, "Brasil"));
            equipos.Add(Equipo.Create(3, "Uruguay"));
            response.Content = new ObjectContent(typeof(List<Equipo>), equipos, new JsonMediaTypeFormatter()); // new StringContent("{equipoid:1, equiponombre:argentina}");
            return response;
        }

        public HttpResponseMessage Post()
        {
            throw new NotImplementedException();
        }
    }
}
