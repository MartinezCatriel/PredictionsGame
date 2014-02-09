using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Game.Controllers
{
    public class EquiposController : ApiController
    {

        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            
            response.Content = new StringContent("{equipoid:1, equiponombre:argentina}");

            return response;
        }
    }
}
