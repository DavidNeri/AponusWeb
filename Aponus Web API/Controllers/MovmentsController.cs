using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class MovmentsController : Controller
    {
        private readonly BS_Movimientos BsMovimientos;
        public MovmentsController(BS_Movimientos bsMovimientos)
        {
            BsMovimientos = bsMovimientos;
        }

        [HttpPost]
        [Route("New")]
        [RequiredPermission("STOCK_INSUMOS", "UPDATE")]
        [RequiredPermission("STOCK_MOVIMIENTOS", "INSERT")]
        [RequiredPermission("SUMINISTROS_MOVIMIENTOS_STOCK", "INSERT")]
        [RequiredPermission("SUMINISTROS_MOVIMIENTOS_STOCK", "UPDATE")]
        [RequiredPermission("ARCHIVOS_STOCK", "INSERT")]
        public IActionResult NuevoMovimiento([FromForm] DTOMovimientosStock Movimiento)
        {
            try
            {
                return BsMovimientos.ProcesarDatosMovimiento(Movimiento);

            }
            catch (Exception)
            {
                return new ContentResult()
                {
                    Content = $"Error interno, no se aplicaron los cambios",
                    ContentType = "Aplication/Json",
                    StatusCode = 500,
                };
            }
        }


        [HttpGet]
        [Route("List/")]
        //[RequiredPermission("STOCK_MOVIMIENTOS", "SELECT")]
        //[RequiredPermission("ARCHIVOS_STOCK", "SELECT")]
        //[RequiredPermission("ESTADOS_MOVIMIENTOS_STOCK", "SELECT")]
        //[RequiredPermission("COMPONENTES_DESCRIPCION", "SELECT")]
        //[RequiredPermission("COMPONENTES_DETALLE", "SELECT")]
        //[RequiredPermission("ENTIDADES", "SELECT")]
        //[RequiredPermission("SUMINISTROS_MOVIMIENTOS_STOCK", "SELECT")]
        public async Task<IActionResult> Listar(UTL_FiltrosMovimientos? Filtros)
        {
            return await BsMovimientos.Listar(Filtros);
        }

        [HttpPost]
        [Route("{IdMovimiento}/Delete")]
        [RequiredPermission("STOCK_MOVIMIENTOS", "UPDATE")]
        public IActionResult EliminarMovimiento(int IdMovimiento)
        {
            return BsMovimientos.Eliminar(IdMovimiento);
        }
        //Update State Movment

        [HttpPost]
        [Route("Files/Delete")]
        [RequiredPermission("ARCHIVOS_STOCK", "UPDATE")]
        [RequiredPermission("STOCK_MOVIMIENTOS", "UPDATE")]
        public IActionResult EliminarArchivo(DTOMovimientosStock Archivos)
        {
            return BsMovimientos.ArchivosMovimientos().Eliminar(Archivos);
        }

        [HttpPost]
        [Route("Files/New")]
        [RequiredPermission("ARCHIVOS_STOCK", "INSERT")]
        [RequiredPermission("STOCK_MOVIMIENTOS", "UPDATE")]
        public async Task<IActionResult> AgregarArchivo([FromForm] DTOMovimientosStock Archivos)
        {
            return await BsMovimientos.ArchivosMovimientos().Agregar(Archivos);
        }

        [HttpPost]
        [Route("Update")]
        [RequiredPermission("STOCK_MOVIMIENTOS", "UPDATE")]
        public IActionResult ActualizarDatosMovimiento(DTOMovimientosStock Movimiento)
        {
            return BsMovimientos.Actualizar(Movimiento);
        }

        [HttpPost]
        [Route("Supplies/Update")]
        [RequiredPermission("SUMINISTROS_MOVIMIENTOS_STOCK", "INSERT")]
        [RequiredPermission("SUMINISTROS_MOVIMIENTOS_STOCK", "UPDATE")]
        [RequiredPermission("STOCK_MOVIMIENTOS", "UPDATE")]
        public IActionResult ActualizarInsumos(DTOMovimientosStock Movimiento)
        {
            if (Movimiento.IdMovimiento == null)
                return new ContentResult()
                {
                    Content = "No se encontró el valor 'ID_MOVIMIENTO'\n No se aplicaron los cambios",
                    ContentType = "Aplication/Json",
                    StatusCode = 400,
                };
            return BsMovimientos.ActualizarSuministros(Movimiento);
        }

        [HttpGet]
        [Route("States/List")]
        [RequiredPermission("ESTADOS_MOVIMIENTOS_STOCK", "SELECT")]
        public IActionResult ListarEstados()
        {
            return BsMovimientos.EstadosMovimientos().Listar();
        }

        [HttpPost]
        [Route("States/Save")]
        [RequiredPermission("ESTADOS_MOVIMIENTOS_STOCK", "INSERT")]
        [RequiredPermission("ESTADOS_MOVIMIENTOS_STOCK", "UPDATE")]
        public async Task<IActionResult> NuevoEstado(DTOEstadosMovimientosStock Estado)
        {
            if (string.IsNullOrEmpty(Estado.Descripcion))
                return new ContentResult()
                {
                    Content = "Ingresar el Estado",
                    ContentType = "Aplication/Json",
                    StatusCode = 400,
                };
            return await BsMovimientos.EstadosMovimientos().Guardar(Estado);
        }
    }
}
