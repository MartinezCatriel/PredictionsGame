using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Prediccion;
using Repository.EntitiesRepository;

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
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                var repoEquipo = new EquipoRepository();
                var equipoMapper = new EquipoMapper();

                response.Content = new ObjectContent(typeof(List<Equipo>), equipos, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                response.Content = new ObjectContent(typeof(string), "Error al obtener los equipos. Error:" + ex.Message + "Stack:" + ex.StackTrace, new JsonMediaTypeFormatter());
                return response;
            }
            var equipos = new List<Equipo>();
            equipos.Add(Equipo.Create(1, "ARG"));
            equipos.Add(Equipo.Create(2, "BRA"));
            equipos.Add(Equipo.Create(3, "URU"));
            response.Content = new ObjectContent(typeof(List<Equipo>), equipos, new JsonMediaTypeFormatter()); // new StringContent("{equipoid:1, equiponombre:argentina}");
            return response;
        }
    }
}
