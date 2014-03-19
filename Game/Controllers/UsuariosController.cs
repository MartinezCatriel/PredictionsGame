﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Prediccion;
using Repository.EntitiesRepository;
using Game.RepositoryMapper;

namespace Game.Controllers
{
    public class UsuariosController : ApiController
    {
        public HttpResponseMessage Get(int id)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {

                var repoUsu = new UsuarioRepository();
                var usuMapper = new UsuarioMapper();
                var usuRTN = usuMapper.MapperUsuario(repoUsu.GetById(id));
                response.Content = new ObjectContent(typeof(Usuario), usuRTN, new JsonMediaTypeFormatter());
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
                /*var listaDeUsuarios = new List<Usuario>(2);
                var unUsuario = Usuario.Create(1, "FBK", "a@a", "$#%G#%#/#(#IFQF$FFWEF");
                listaDeUsuarios.Add(unUsuario);
                unUsuario = Usuario.Create(2, "GGL", "a@a", "$#%G#%#/#(#IFQF$FFWEF");
                listaDeUsuarios.Add(unUsuario);*/
                var repoUsu = new UsuarioRepository();
                var usuMapper = new UsuarioMapper();
                var listaDeUsuarios = usuMapper.MapperUsuarios(repoUsu.GetAll());
                response.Content = new ObjectContent(typeof(List<Usuario>), listaDeUsuarios, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                response.Content = new ObjectContent(typeof(string), "Error los usuarios", new JsonMediaTypeFormatter());
                return response;
            }
            return response;
        }

        public HttpResponseMessage Post(NewUsuario newU)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {
                var repoUsu = new UsuarioRepository();
                var usuMapper = new UsuarioMapper();
                var usufromrepo = repoUsu.Insert("email", "FBK", newU.token);
                var usuRTN = usuMapper.MapperUsuario(usufromrepo);
                response.Content = new ObjectContent(typeof(Usuario), usuRTN, new JsonMediaTypeFormatter());
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
    }

    public class NewUsuario
    {
        public string token { get; set; }
    }
}
