using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Patterns;
using System.ComponentModel;

namespace Aponus_Web_API.Controllers
{
    [ApiController]
    [Route("Aponus/[Controller]")]
    public class EndpointsController : ControllerBase
    {
        private readonly EndpointDataSource _endpointDataSource;

        public EndpointsController(EndpointDataSource endpointDataSource)
        {
            _endpointDataSource = endpointDataSource;   
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<Object>Get()
        {
            var Endpoints = _endpointDataSource.Endpoints;

            var ListaEndPoints = Endpoints.Select(endpoint =>
            {
                var ruta = endpoint as RouteEndpoint;

                if (ruta != null)
                {
                    var MetodosHttp = ruta.Metadata.GetMetadata<HttpMethodMetadata>()?.HttpMethods;

                    return new
                    {
                        Tipo = MetodosHttp != null ? string.Join(", ", MetodosHttp) : "N/A",
                        URL = ruta.RoutePattern.RawText,
                    };
                };
                return null;
            }).Where(e => e != null);
            return ListaEndPoints;  
                
        }

    }
}
