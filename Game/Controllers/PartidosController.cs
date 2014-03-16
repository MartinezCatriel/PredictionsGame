using Prediccion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using PartidoPrediccion = Prediccion.Partido;
namespace Game.Controllers
{
    public class PartidosController : ApiController
    {

        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                var partidosPorFecha = new List<PartidosPorFecha>();

                var listaDePartidos = new List<PartidoPrediccion>();




                PartidoPrediccion unPartido;
                var equipos = new List<Equipo>();
                equipos.Add(Equipo.Create(1, "BRA"));
                equipos.Add(Equipo.Create(2, "CRO"));
                unPartido = PartidoPrediccion.Create(1, equipos, Convert.ToDateTime("2014-06-12 17:00"), "San Pablo", 80);
                unPartido.SetGolesPorEquipo(1, 0);
                unPartido.SetGolesPorEquipo(2, 0);
                listaDePartidos.Add(unPartido);

                equipos = new List<Equipo>();
                equipos.Add(Equipo.Create(3, "MEX"));
                equipos.Add(Equipo.Create(4, "CAM"));
                unPartido = PartidoPrediccion.Create(2, equipos, Convert.ToDateTime("2014-06-13 13:00"), "Natal", 80);
                unPartido.SetGolesPorEquipo(3, 0);
                unPartido.SetGolesPorEquipo(4, 0);
                listaDePartidos.Add(unPartido);

                equipos = new List<Equipo>();
                equipos.Add(Equipo.Create(1, "BRA"));
                equipos.Add(Equipo.Create(3, "MEX"));
                unPartido = PartidoPrediccion.Create(2, equipos, Convert.ToDateTime("2014-06-17 16:00"), "Fortaleza", 80);
                unPartido.SetGolesPorEquipo(1, 0);
                unPartido.SetGolesPorEquipo(3, 0);
                listaDePartidos.Add(unPartido);

                equipos = new List<Equipo>();
                equipos.Add(Equipo.Create(4, "CAM"));
                equipos.Add(Equipo.Create(2, "CRO"));
                unPartido = PartidoPrediccion.Create(2, equipos, Convert.ToDateTime("2014-06-18 15:00"), "Manaos", 80);
                unPartido.SetGolesPorEquipo(4, 0);
                unPartido.SetGolesPorEquipo(2, 0);
                listaDePartidos.Add(unPartido);

                equipos = new List<Equipo>();
                equipos.Add(Equipo.Create(4, "CAM"));
                equipos.Add(Equipo.Create(1, "BRA"));
                unPartido = PartidoPrediccion.Create(2, equipos, Convert.ToDateTime("2014-06-23 17:00"), "Brasilia", 80);
                unPartido.SetGolesPorEquipo(4, 0);
                unPartido.SetGolesPorEquipo(1, 0);
                listaDePartidos.Add(unPartido);

                equipos = new List<Equipo>();
                equipos.Add(Equipo.Create(2, "CRO"));
                equipos.Add(Equipo.Create(3, "MEX"));
                unPartido = PartidoPrediccion.Create(2, equipos, Convert.ToDateTime("2014-06-23 17:00"), "Recife", 80);
                unPartido.SetGolesPorEquipo(2, 0);
                unPartido.SetGolesPorEquipo(3, 0);
                listaDePartidos.Add(unPartido);


                var listas = listaDePartidos.GroupBy((item) => { return item.Fecha.ToShortDateString(); });
                foreach (var lista in listas)
                {
                    var partidos = lista.ToList().ConvertAll((item) => { return new Controllers.Partido() { Equipos = item.Equipos, Ganador = item.Ganador, Ponderado = item.Ponderado, Geolocalizacion = item.Geolocalizacion, GolesPorEquipo = item.GolesPorEquipo, Hora = item.Fecha.ToString("MM:ss tt"), Id = item.Id }; });
                    var ppf = new PartidosPorFecha() { Fecha = lista.Key, Partidos = partidos };
                    partidosPorFecha.Add(ppf);
                }

                response.Content = new ObjectContent(typeof(List<PartidosPorFecha>), partidosPorFecha, new JsonMediaTypeFormatter());
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
                Prediccion.Partido unPartido;

                var equipos = new List<Equipo>();
                equipos.Add(Equipo.Create(1, "Brasil"));
                equipos.Add(Equipo.Create(2, "Croacia"));
                unPartido = Prediccion.Partido.Create(1, equipos, DateTime.Now, "San Pablo", 80);
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

        public HttpResponseMessage Post(int idPartido, int idEquipo, int goles)
        {
            //actualiza los goles por equipo del partido


            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Post(int idPartido, List<int> idEquipos)
        {
            //actualiza los equipos por partido


            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }

    public class PartidosPorFecha
    {
        public string Fecha { get; set; }
        public List<Game.Controllers.Partido> Partidos { get; set; }
    }

    public class Partido
    {
        public string Hora { get; set; }
        public int Id { get; set; }
        public Equipo Ganador { get; set; }
        public string Geolocalizacion { get; set; }
        public int Ponderado { get; set; }
        public Dictionary<int, int> GolesPorEquipo { get; set; }
        public List<Equipo> Equipos { get; set; }

    }
}
