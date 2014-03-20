﻿using Prediccion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Repository.EntitiesRepository;
using PartidoPrediccion = Prediccion.Partido;
using Game.RepositoryMap;
namespace Game.Controllers
{
    public class PartidosController : ApiController
    {

        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                var repoPartidos = new PartidoRepository();
                var partidoMapper = new PartidoMap();
                //obtengo todos los partidos de la base de datos
                var listaDePartidos = partidoMapper.MapPartidos(repoPartidos.GetAll());
                var partidosPorFecha = new List<PartidosPorFecha>();
                //los agrupo por fecha a los objetos de modelo
                var listas = listaDePartidos.GroupBy((item) => { return item.Fecha.ToShortDateString(); });

                foreach (var lista in listas)
                {
                    //por cada grupo de partidos por fecha creo un objeto de retorno
                    var partidos = lista.ToList().ConvertAll((item) => { return new Controllers.Partido() { Equipos = item.Equipos, Ganador = item.Ganador, Ponderado = item.Ponderado, Geolocalizacion = item.Geolocalizacion, GolesPorEquipo = item.GolesPorEquipo, Hora = item.Fecha.ToString("MM:ss tt"), Id = item.Id }; });
                    //creo un objeto que contenga la fecha y sus partidos
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
                var repoPartidos = new PartidoRepository();
                var partidosMap = new PartidoMap();
                var unPartido = partidosMap.MapPartido(repoPartidos.GetById(Convert.ToInt32(id)));
                var rtnPartido = new Controllers.Partido() { Equipos = unPartido.Equipos, Ganador = unPartido.Ganador, Ponderado = unPartido.Ponderado, Geolocalizacion = unPartido.Geolocalizacion, GolesPorEquipo = unPartido.GolesPorEquipo, Hora = unPartido.Fecha.ToString("MM:ss tt"), Id = unPartido.Id };
                response.Content = new ObjectContent(typeof(Partido), rtnPartido, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                response.Content = new ObjectContent(typeof(string), ex.Message, new JsonMediaTypeFormatter());
            }
            return response;
        }

        public HttpResponseMessage Post(PartidoEquiposUpload partidoToUpload)
        {
            //actualiza los equipos por partido
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                var repoPartidos = new PartidoRepository();
                var partidosMap = new PartidoMap();
                repoPartidos.UpdateEquiposDelPartido(partidoToUpload.IdPartido, partidoToUpload.Equipos.ToList());
                response.Content = new ObjectContent(typeof(string), "Partido actualizado con exito", new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                response.Content = new ObjectContent(typeof(string), ex.Message, new JsonMediaTypeFormatter());
            }
            return response;
        }

        public HttpResponseMessage Post(PartidoEquipoGolesUpload partidoToUpload)
        {
            //actualiza los goles por equipo del partido
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                var repoPartidos = new PartidoRepository();
                var partidosMap = new PartidoMap();
                repoPartidos.UpdateEquipoGolesByPartidoId(partidoToUpload.idPartido, partidoToUpload.idEquipo, partidoToUpload.goles);

                response.Content = new ObjectContent(typeof(string), "Partido actualizado con exito", new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                response.Content = new ObjectContent(typeof(string), ex.Message, new JsonMediaTypeFormatter());
            }
            return response;
        }

       
    }

    public class PartidoEquiposUpload
    {
        public int IdPartido { get; set; }
        public List<int> Equipos { get; set; }
    }

    public class PartidoEquipoGolesUpload
    {
        public int idPartido { get; set; }
        public int idEquipo { get; set; }
        public int goles { get; set; }
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
