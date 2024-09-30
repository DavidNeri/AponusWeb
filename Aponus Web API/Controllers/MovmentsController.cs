using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Support;
using Aponus_Web_API.Support.Movimientos;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class MovmentsController : Controller
    {
        [HttpPost]
        [Route("New")]
        public IActionResult NuevoMovimiento ([FromForm]DTOMovimientosStock Actualizacion)
        {
            try
            {
                return new BS_Movimientos().ProcesarDatosMovimiento(Actualizacion);
                
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
        [Route("List")]
        public async Task<IActionResult> Listar(FiltrosMovimientos? Filtros)
        {
            return await new BS_Movimientos().Listar(Filtros);
        }

        [HttpPost]
        [Route("{IdMovimiento}/Delete")]
        public IActionResult EliminarMovimiento(int IdMovimiento)
        {
            if (IdMovimiento == null)
                return new ContentResult()
                {
                    Content = "No se encontró el valor 'ID_MOVIMIENTO'\n No se aplicaron los cambios",
                    ContentType = "Aplication/Json",
                    StatusCode = 400,
                };
            return new BS_Movimientos().Eliminar(IdMovimiento);
        }
        //Update State Movment

        [HttpPost]
        [Route("Files/Delete")]
        public IActionResult EliminarArchivo(DTOMovimientosStock Archivos)
        {
            return new BS_Movimientos.Archivos().Eliminar(Archivos);
        }

        [HttpPost]
        [Route("Files/New")]      

        public async Task<IActionResult> AgregarArchivo([FromForm] DTOMovimientosStock Archivos)
        {
            return await new BS_Movimientos.Archivos().Agregar(Archivos);
        }

        

        [HttpPut]
        [Route("Update")]
        public IActionResult ActualizarProveedor(DTOMovimientosStock Movimiento)
        {
            return new BS_Movimientos().Actualizar(Movimiento);
        }

        [HttpPost]
        [Route("Supplies/Update")]

        public IActionResult ActualizarInsumos(DTOMovimientosStock Movimiento)
        {
            if(Movimiento.IdMovimiento==null)
                return new ContentResult()
                {
                    Content = "No se encontró el valor 'ID_MOVIMIENTO'\n No se aplicaron los cambios",
                    ContentType = "Aplication/Json",
                    StatusCode = 400,
                };
            return new BS_Movimientos().ActualizarSuministros(Movimiento);
        }

        [HttpGet]
        [Route("States/List")]
        public IActionResult ListarEstados()
        {
            return BS_Movimientos.Estados.Listar();
        }

        [HttpPost]
        [Route("States/Save")]

        public async Task<IActionResult> NuevoEstado(DTOEstadosMovimientosStock Estado)
        {
            if (string.IsNullOrEmpty(Estado.Descripcion))
                return new ContentResult()
                {
                    Content = "Ingresar el Estado",
                    ContentType = "Aplication/Json",
                    StatusCode = 400,
                };
            return await BS_Movimientos.Estados.Guardar(Estado);
        }
    }
}
