using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class ComponentsController : Controller
    {
        [HttpGet]
        [Route("FetchUnities")]

        public async Task<IActionResult> ObtenerAlmacenamiento()
        {
            try
            {
                return await new BS_Components().ObtenerTipoAlmacenamiento();
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
        }
    }
}
