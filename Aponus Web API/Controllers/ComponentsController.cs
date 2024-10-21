using Aponus_Web_API.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class ComponentsController : Controller
    {
        private readonly BS_Components _BsComponents;
        public ComponentsController(BS_Components BsComponents)
        {
            _BsComponents = BsComponents;
        }

        [HttpGet]
        [Route("FetchUnities")]

        public async Task<IActionResult> ObtenerAlmacenamiento()
        {
            try
            {
                return await _BsComponents.ObtenerTipoAlmacenamiento();
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException?.Message ?? e.Message;
                return new JsonResult(Mensaje);
            }
        }

        [HttpGet]
        [Route("GetProperties")]

        public  IActionResult ObtenerPropsComponentes()
        {
            try
            {
                return  _BsComponents.ObtenerPropsComponentes();
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException?.Message ?? e.Message;
                return new JsonResult(Mensaje);
            }
        }

        

        [HttpGet]
        [Route("List/{IdDescripcion?}")]

        public IActionResult ListarComponentes(int? IdDescripcion)
        {
            try
            {
                return _BsComponents.ListarComponentes(IdDescripcion);
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException?.Message ?? e.Message;
                return new JsonResult(Mensaje);
            }
        }
    }
}
