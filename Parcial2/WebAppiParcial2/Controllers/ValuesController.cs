using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppiParcial2.Models;

namespace WebAppiParcial2.Controllers
{
    //[Route("")]
    public class ValuesController : ApiController
    {
        public IHttpActionResult Post([FromBody] ClaseRequest request )
        {
            ResponseGeneral responseGeneral = new ResponseGeneral(Logica.LogicaPrincipal.Instancia.Alta(ClaseRequest.Conversor(request)));

            if (responseGeneral.Respuesta)
            {
                ClaseResponse objResponse = new ClaseResponse(responseGeneral.id);
                return Content(HttpStatusCode.Created, objResponse);
            }
            return Content(HttpStatusCode.BadRequest, responseGeneral.Detalle);
        }
    }
}
