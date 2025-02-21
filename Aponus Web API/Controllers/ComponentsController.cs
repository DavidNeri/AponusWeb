using Aponus_Web_API.Negocio;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class ComponentsController : Controller
    {
        private readonly BS_Componentes _BsComponentes;
        public ComponentsController(BS_Componentes BsComponents)
        {
            _BsComponentes = BsComponents;
        }

        [HttpGet]
        [Route("FetchUnities/{IdNombreComponente?}")]
        public async Task<IActionResult> ObtenerAlmacenamientoComponentes(int? IdNombreComponente)
        {
            return await _BsComponentes.MapeoDetalleNombreComponenteDTO(IdNombreComponente);
        }


        [HttpGet] //¿Se usa?
        [Route("GetProperties")]
        public IActionResult ObtenerPropsComponentes()
        {
            try
            {
                return _BsComponentes.ObtenerPropsComponentes();
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException?.Message ?? e.Message;
                return new JsonResult(Mensaje);
            }
        }


        [HttpGet]
        [Route("List/{IdDescripcion?}/{idInsumo?}")]
        [RequiredPermission("COMPONENTES_DETALLE","SELECT")]
        [RequiredPermission("COMPONENTES_DESCRIPCION", "SELECT")]
        public IActionResult ObtenerListarComponentes(int? IdDescripcion, string? idInsumo)
        {
            return _BsComponentes.MapeoComponentesDetalleDTO(IdDescripcion, idInsumo);
        }

        [HttpGet]
        [Route("ListGrid/{IdDescripcion}")]
        [RequiredPermission("COMPONENTES_DETALLE", "SELECT")]
        [RequiredPermission("COMPONENTES_DESCRIPCION", "SELECT")]
        public IActionResult ObtenerListarComponentes(int IdDescripcion)
        {
            return _BsComponentes.MapeoComponentesDetalleGrid(IdDescripcion);
        }

        [HttpPost]
        [Route("Delete/{IdInsumo}")]
        [RequiredPermission("COMPONENTES_DETALLE", "UPDATE")]
        public async Task<IActionResult> EliminarComponente(string IdInsumo)
        {
            return await _BsComponentes.ProcesarDatos(IdInsumo);
        }
    }
}
