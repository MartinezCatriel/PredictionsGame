using Game.RepositoryMap;
using Repository.EntitiesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Game.Controllers
{
    public class NewPartidoController : ApiController
    {
        public HttpResponseMessage Post(NewPartido newPartido)
        {
            //actualiza los goles por equipo del partido
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                if (newPartido == null)
                {
                    throw new Exception("Debe enviar informacion válida");
                }
                var dic = new Dictionary<int, int>(newPartido.equipogoles.Count);
                foreach (var eg in newPartido.equipogoles)
                {
                    dic.Add(eg.IdEquipo, eg.Goles);
                }
                var repoPartidos = new PartidoRepository();
                var partidoMap = new PartidoMap();
                var partidomapped = partidoMap.MapPartido(
                    repoPartidos.Insert(Convert.ToDateTime(newPartido.Fecha)
                    , newPartido.geo
                    , newPartido.ponderado
                    , dic));
                var controllerPartido = new Controllers.Partido() { Equipos = partidomapped.Equipos, Ganador = partidomapped.Ganador, Ponderado = partidomapped.Ponderado, Geolocalizacion = partidomapped.Geolocalizacion, GolesPorEquipo = partidomapped.GolesPorEquipo, Hora = partidomapped.Fecha.ToString("MM:ss tt"), Id = partidomapped.Id };
                response.Content = new ObjectContent(typeof(Partido), controllerPartido, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                response.Content = new ObjectContent(typeof(string), ex.Message, new JsonMediaTypeFormatter());
            }
            return response;
        }
    }

    public class NewPartido
    {

        public string Fecha { get; set; }
        public string geo { get; set; }
        public int ponderado { get; set; }
        public List<EquipoGoles> equipogoles { get; set; }
    }
}
