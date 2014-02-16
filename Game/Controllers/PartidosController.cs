using System;
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
            var listaDePartidos = new List<Dictionary<string, string>>();
            var dic = new Dictionary<string, string>();
            dic.Add("Id", "1");
            dic.Add("Equipos", "{Brasil,Croacia");
            dic.Add("Fecha-Hora", "Jueves 12 de Junio 17:00hs");
            dic.Add("Ganador", "Brasil");
            dic.Add("Geolocalizacion", "San Pablo");
            dic.Add("GolesPorEquipo", "{Equipo:1, Goles:0},{Equipo:2, Goles:0}");
            listaDePartidos.Add(dic);
            dic = new Dictionary<string, string>();
            dic.Add("Id", "2");
            dic.Add("Equipos", "{Mexico,Camerun");
            dic.Add("Fecha-Hora", "Viernes 13 de junio 13:00hs");
            dic.Add("Ganador", "Brasil");
            dic.Add("Geolocalizacion", "San Pablo");
            dic.Add("GolesPorEquipo", "{Equipo:1, Goles:0},{Equipo:2, Goles:0}");
            listaDePartidos.Add(dic);
            response.Content = new ObjectContent(typeof(List<Dictionary<string, string>>), listaDePartidos, new JsonMediaTypeFormatter());

            return response;
        }

        public HttpResponseMessage Get(string id)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var dic = new Dictionary<string, string>();
            dic.Add("Id", "1");
            dic.Add("Equipos", "{Brasil,Croacia");
            dic.Add("Fecha-Hora", "17:00");
            dic.Add("Ganador", "Brasil");
            dic.Add("Geolocalizacion", "San Pablo");
            dic.Add("GolesPorEquipo", "{Equipo:1, Goles:0},{Equipo:2, Goles:0}");

            response.Content = new ObjectContent(typeof(Dictionary<string, string>), dic, new JsonMediaTypeFormatter());

            return response;
        }
    }
}
