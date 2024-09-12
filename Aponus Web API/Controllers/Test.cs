using Aponus_Web_API.Models;
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
            try
            {
                EstadosProductos InsertPrueba = new EstadosProductos()
                {
                    Descripcion = "Creado",
                    

                };

                AponusContext context = new AponusContext();
                context.EstadosProducto.Add(InsertPrueba);
                context.SaveChanges();


                return new ContentResult()
                {
                    Content = "Metodo de Prueba de Aponus Web API",
                    StatusCode = 200,
                    ContentType = "application/json"
                };

            }
            catch (Exception ex )
            {

                return new ContentResult()
                {
                    Content = ex.Message,
                    ContentType = "application/json",
                    StatusCode=400
                    
                };
            }
           

            
           


        }
    }
}
