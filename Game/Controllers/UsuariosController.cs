﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Prediccion;

namespace Game.Controllers
{
    public class UsuariosController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                var unUsuario = Usuario.Create(Convert.ToInt32(id), "German Gimenez", "FBK");
                response.Content = new ObjectContent(typeof(Usuario), unUsuario, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                response.Content = new ObjectContent(typeof(string), "Error con el usuario", new JsonMediaTypeFormatter());
                return response;
            }
            return response;
        }

        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                var listaDeUsuarios = new List<Usuario>(2);
                var unUsuario = Usuario.Create(1, "German Gimenez","FBK");
                listaDeUsuarios.Add(unUsuario);
                unUsuario = Usuario.Create(2, "Carlos Talarga", "GGL");
                listaDeUsuarios.Add(unUsuario);
                response.Content = new ObjectContent(typeof(List<Usuario>), listaDeUsuarios, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                response.Content = new ObjectContent(typeof(string), "Error los usuarios", new JsonMediaTypeFormatter());
                return response;
            }
            return response;
        }
    }
}
