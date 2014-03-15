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
    public class PrediccionesController : ApiController
    {

        /*public HttpResponseMessage Get(int equipo)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {
                var listaDePrediccionesPorEquipo = new List<UsuarioPrediccion>(2);
                var golesPorEquipos = new Dictionary<int, int>(2) { { 1, 1 }, { 2, 0 } };
                var unaPrediccion = UsuarioPrediccion.Create(1, 1, golesPorEquipos);
                listaDePrediccionesPorEquipo.Add(unaPrediccion);

                golesPorEquipos = new Dictionary<int, int>(2) { { 3, 1 }, { 1, 0 } };
                unaPrediccion = UsuarioPrediccion.Create(2, 1, golesPorEquipos);
                listaDePrediccionesPorEquipo.Add(unaPrediccion);

                response.Content = new ObjectContent(typeof(List<UsuarioPrediccion>), listaDePrediccionesPorEquipo, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {

                response.Content = new ObjectContent(typeof(string), string.Format("Error. Msg:{0} Stack:{1}", ex.Message, ex.StackTrace), new JsonMediaTypeFormatter());
            }
            return response;
        }*/

        public HttpResponseMessage Get(int user)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {
                var listaDePrediccionesPorUsuario = new List<UsuarioPrediccion>(2);
                var golesPorEquipos = new Dictionary<int, int>(2) { { 1, 1 }, { 2, 0 } };
                var unaPrediccion = UsuarioPrediccion.Create(1, 1, golesPorEquipos);
                listaDePrediccionesPorUsuario.Add(unaPrediccion);

                golesPorEquipos = new Dictionary<int, int>(2) { { 3, 1 }, { 1, 0 } };
                unaPrediccion = UsuarioPrediccion.Create(1, 2, golesPorEquipos);
                listaDePrediccionesPorUsuario.Add(unaPrediccion);

                response.Content = new ObjectContent(typeof(List<UsuarioPrediccion>), listaDePrediccionesPorUsuario, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {

                response.Content = new ObjectContent(typeof(string), string.Format("Error. Msg:{0} Stack:{1}", ex.Message, ex.StackTrace), new JsonMediaTypeFormatter());
            }
            return response;
        }

        public HttpResponseMessage Post(int partido, int equipo, int goles)
        {
            if (partido < 0)
            {

            }
            if (equipo < 0)
            {

            }
            if (goles < 0)
            {

            }

            

            return new HttpResponseMessage();
        }
    }
}
