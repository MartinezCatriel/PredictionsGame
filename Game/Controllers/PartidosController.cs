using Prediccion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Game.Controllers
{
    public class PartidosController : ApiController
    {

        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {

                var listaDePartidos = new List<Partido>();
                Partido unPartido;

                var equipos = new List<Equipo>();
                equipos.Add(Equipo.Create(1, "Brasil"));
                equipos.Add(Equipo.Create(2, "Croacia"));
                unPartido = Partido.Create(1, equipos, DateTime.Now, "San Pablo");
                unPartido.SetGolesPorEquipo(1, 0);
                unPartido.SetGolesPorEquipo(2, 0);
                listaDePartidos.Add(unPartido);

                equipos = new List<Equipo>();
                equipos.Add(Equipo.Create(3, "Mexico"));
                equipos.Add(Equipo.Create(4, "Camerun"));
                unPartido = Partido.Create(2, equipos, DateTime.Now.AddDays(1), "Natal");
                unPartido.SetGolesPorEquipo(3, 0);
                unPartido.SetGolesPorEquipo(4, 0);
                listaDePartidos.Add(unPartido);
                response.Content = new ObjectContent(typeof(List<Partido>), listaDePartidos, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                response.Content = new ObjectContent(typeof(string), ex.Message, new JsonMediaTypeFormatter());
            }
            return response;
        }

        public HttpResponseMessage Get(string id)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                Partido unPartido;

                var equipos = new List<Equipo>();
                equipos.Add(Equipo.Create(1, "Brasil"));
                equipos.Add(Equipo.Create(2, "Croacia"));
                unPartido = Partido.Create(1, equipos, DateTime.Now, "San Pablo");
                unPartido.SetGolesPorEquipo(1, 0);
                unPartido.SetGolesPorEquipo(2, 0);
                response.Content = new ObjectContent(typeof(Partido), unPartido, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                response.Content = new ObjectContent(typeof(string), ex.Message, new JsonMediaTypeFormatter());
            }
            return response;
        }

        public HttpResponseMessage Post()
        {

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
