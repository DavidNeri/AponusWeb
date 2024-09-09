using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[controller]")]
    [ApiController]
    public class Test : Controller
    {
        [HttpGet]
        [Route("Test")]

        public ActionResult Prueba()
        {
            return new ContentResult()
            {
                Content = "Metodo de Prueba de Aponus Web API",  
                StatusCode = 200,
                ContentType="application/json"
            };
        }
    }
}
