using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
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
        [RequiredPermission("PRODUCTOS_TIPOS", "SELECT")]
        public JsonResult ListarTiposProductos()
        {
            return BsCategorias.MapearTiposProductosDTO();
        }

        [HttpGet]
        [Route("Products/Descriptions/List/{idTipo}")]
        //[RequiredPermission("PRODUCTOS_DESCRIPCION","SELECT")]
        public IActionResult ListarDescripcionesProductos(string IdTipo)
        {
            return BsCategorias.MapearDescripcionesProductosDTO(IdTipo);
        }


        [HttpPost]
        [Route("Products/Types/New")]
        [RequiredPermission("PRODUCTOS_TIPOS", "INSERT")]
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
        [Route("Products/Types/{IdTipo}/Delete")]
        //[RequiredPermission("PRODUCTOS_TIPOS", "UPDATE")]
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
        [RequiredPermission("PRODUCTOS_DESCRIPCION", "UPDATE")]
        [RequiredPermission("PRODUCTOS_TIPOS_DESCRIPCION", "UPDATE")]
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
        [Route("Products/Descriptions/{IdDescription}/Delete")]
        //[RequiredPermission("PRODUCTOS", "UPDATE")]
        //[RequiredPermission("PRODUCTOS_DESCRIPCION", "UPDATE")]
        public async Task<IActionResult> EliminarDescripcionProducto(int IdDescription)
        {
            return await BsCategorias.RegistrarCambioEstadoDescripcionProducto(IdDescription);
        }

        [HttpPost]
        [Route("Products/Type-or-Description/Update")]
        [RequiredPermission("PRODUCTOS_TIPOS", "UPDATE")]
        [RequiredPermission("PRODUCTOS_DESCRIPCION", "UPDATE")]
        [RequiredPermission("PRODUCTOS_TIPOS_DESCRIPCION", "UPDATE")]
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
        [RequiredPermission("COMPONENTES_DESCRIPCION", "SELECT")]
        public IActionResult ListarNombreComponentes()
        {
            return BsCategorias.MapearNombresComponentesDTO();
        }

        [HttpPost]
        [Route("Supplies/Descriptions/Save")]
        [RequiredPermission("COMPONENTES_DESCRIPCION", "INSERT")]
        [RequiredPermission("COMPONENTES_DESCRIPCION", "UPDATE")]
        public async Task<IActionResult> GuardarDescripcionComponente(DTODescripcionComponentes Componente)
        {
            return await BsCategorias.MapeoComponenteBD(Componente);
        }

        [HttpPost]
        [Route("Supplies/Descriptions/{idDescripcion}/Delete")]
        [RequiredPermission("COMPONENTES_DESCRIPCION", "UPDATE")]
        public async Task<IActionResult> EliminarDescripcionComponente(int idDescripcion)
        {
            return await BsCategorias.RegistrarCambioEstadoDescripcionComponente(idDescripcion);
        }

    }
}
