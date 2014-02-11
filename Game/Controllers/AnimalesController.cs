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
    public class AnimalesController : ApiController
    {

        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            var animales = new List<Animal>();
            animales.Add(AnimalCreator.GetAnimalInstanceByType(TipoAnimal.Leon, 1, "leon choton"));
            animales.Add(AnimalCreator.GetAnimalInstanceByType(TipoAnimal.Leon, 2, "pulpo paul"));
            response.Content = new ObjectContent(typeof(List<Animal>), animales, new JsonMediaTypeFormatter()); // new StringContent("{equipoid:1, equiponombre:argentina}");
            return response;
        }
    }
}
