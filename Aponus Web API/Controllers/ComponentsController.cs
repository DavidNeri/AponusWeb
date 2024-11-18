using Aponus_Web_API.Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class ComponentsController : Controller
    {
        private readonly BS_Componentes _BsComponents;
        public ComponentsController(BS_Componentes BsComponents)
        {
            _BsComponents = BsComponents;
        }

        [HttpGet]
        [Route("FetchUnities/{IdNombreComponente?}")]
        public async Task<IActionResult> ObtenerAlmacenamientoComponentes(int? IdNombreComponente)
        {
            return await _BsComponents.MapeoDetalleNombreComponenteDTO(IdNombreComponente);
        }


        [HttpGet] //¿Se usa?
        [Route("GetProperties")]
        public IActionResult ObtenerPropsComponentes()
        {
            try
            {
                return _BsComponents.ObtenerPropsComponentes();
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException?.Message ?? e.Message;
                return new JsonResult(Mensaje);
            }
        }


        [HttpGet]
        [Route("List/{IdDescripcion?}")]

        public IActionResult ObtenerListarComponentes(int? IdDescripcion)
        {
            return _BsComponents.MapeoComponentesDetalleDTO(IdDescripcion);
        }
    }
}
