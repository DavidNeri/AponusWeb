using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BS_Categorias BsCategorias;
        public CategoriesController(BS_Categorias _BsCategorias)
        {
            BsCategorias = _BsCategorias;
        }

        [HttpGet]
        [Route("Products/Types/List")]
        public async Task<JsonResult> ListarTiposProductos()
        {
            return await BsCategorias.MapearTiposProductosDTO();
        }

        [HttpGet]
        [Route("Products/Descriptions/List/{idTipo}")]
        public async Task<IActionResult> ListarDescripcionesProductos(string IdTipo)
        {
            return await BsCategorias.MapearDescripcionesProductosDTO(IdTipo);
        }


        [HttpPost]
        [Route("Products/Types/New")]
        public JsonResult AgregarTipoProducto(DTOCategorias NuevaCategoria)
        {
            try
            {
                return BsCategorias.NormalizarNombreTipoProducto(NuevaCategoria);

            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost]
        [Route("Products/Types/{TypeId}/Delete/")]
        public async Task<IActionResult> EliminarTipoProducto(string IdTipo)
        {
            try
            {
                return await BsCategorias.RegistrarCambioEstadoTipoProducto(IdTipo);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }


        [HttpPost]
        [Route("Products/Descriptions/New")]
        public async Task<IActionResult> NuevaDescripcionProducto(DTOCategorias NuevaCategoria)
        {
            try
            {
                return await BsCategorias.NormalizarDescripcionProducto(NuevaCategoria);
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }
        }

        [HttpPost]
        [Route("Products/Descriptions/{IdDescription}/Delete/")]
        public async Task<IActionResult> EliminarDescripcionProducto(int IdDescription)
        {
            return await BsCategorias.RegistrarCambioEstadoDescripcionProducto(IdDescription);
        }

        [HttpPost]
        [Route("Products/Type-or-Description/Update")]
        public IActionResult Actualizar_Tipo_Descripcion_Producto(DTOActualizarCategorias ActualizarCategorias)
        {
            try
            {
                return BsCategorias.ValidarOperacionActualizacion(ActualizarCategorias);
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException?.Message ?? e.Message;
                return new JsonResult(Mensaje);
            }
        }

        [HttpGet]
        [Route("Supplies/Descriptions/List")]
        public IActionResult ListarNombreComponentes()
        {
            return BsCategorias.MapearNombresComponentesDTO();
        }

        [HttpPost]
        [Route("Supplies/Descriptions/Save")]
        public async Task<IActionResult> GuardarDescripcionComponente(DTODescripcionComponentes Componente)
        {
            return await BsCategorias.MapeoComponenteBD(Componente);
        }

    }
}
