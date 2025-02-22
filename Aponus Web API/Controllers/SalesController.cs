using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]

    public class SalesController : Controller
    {
        private readonly BS_Ventas BsVentas;
        public SalesController(BS_Ventas bsVentas)
        {
            BsVentas = bsVentas;
        }

        [HttpGet]
        [Route("List")]
        [RequiredPermission("VENTAS", "SELECT")]
        [RequiredPermission("ESTADOS_VENTAS", "SELECT")]
        [RequiredPermission("VENTAS_DETALLES", "SELECT")]
        [RequiredPermission("CUOTAS_VENTAS", "SELECT")]
        [RequiredPermission("PAGOS_VENTAS", "SELECT")]
        [RequiredPermission("ARCHIVOS_VENTAS", "SELECT")]        
        public IActionResult List(UTL_FiltrosComprasVentas? Filtros)
        {
            return BsVentas.Filtrar(Filtros);

        }

        [HttpPost]
        [Route("Quotation")]
        public IActionResult GenerarCuotas(UTL_ParametrosCuotas Parametros)
        {
            try
            {
                ICollection<DTOCuotasVentas> ListadoCuotas = BS_Ventas.CalcularCuotas(Parametros);
                return new JsonResult(ListadoCuotas);

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

        [HttpGet]
        [Route("Products/List")]
        [RequiredPermission("PRODUCTOS", "SELECT")]
        [RequiredPermission("PRODUCTOS_DESCRIPCION", "SELECT")]
        public async Task<IActionResult> ListarProductosVentas()
        {
            return await BsVentas.ListarProductos();
        }

        [HttpPost]
        [Route("States/Save")]
        [RequiredPermission("ESTADOS_VENTAS", "INSERT")]
        [RequiredPermission("ESTADOS_VENTAS", "UPDATE")]
        public async Task<IActionResult> GuardarEstadoVenta(DTOEstadosVentas Estados)
        {
            return await BsVentas.EstadosVentas().ValidarDatos(Estados);
        }

        [HttpPost]
        [Route("States/{Id}/Delete")]
        [RequiredPermission("ESTADOS_VENTAS", "UPDATE")]
        public IActionResult EliminarEstadoVenta(int Id)
        {
            return BsVentas.EstadosVentas().Eliminar(Id);
        }

        [HttpPost]
        [Route("Save")]
        [RequiredPermission("VENTAS", "INSERT")]
        [RequiredPermission("PRODUCTOS", "UPDATE")]
        public async Task<IActionResult> Guardar(DTOVentas Venta)
        {

            if (Venta.MontoTotal.Equals(0))
                return new ContentResult()
                {
                    Content = "El valor de la venta no puede ser 0.00",
                    ContentType = "Application/Json",
                    StatusCode = 400
                };
            else
            {
                try
                {
                    return await BsVentas.ProcesarDatosVenta(Venta);
                }
                catch (Exception ex)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        ContentType = "applcation/json",
                        StatusCode = 400
                    };
                }

            }
        }

        [HttpPost]
        [Route("Bills/new")]
        //[RequiredPermission("PAGOS_VENTAS", "INSERT")]
        //[RequiredPermission("PAGOS_VENTAS", "UPDATE")]
        public async Task<IActionResult> RegistrarPago(DTOPagosVentas Pago)
        {
            try
            {
                return await BsVentas.MapeoDTOPagosVenta(Pago);
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "applcation/json",
                    StatusCode = 400
                };
            }
        }

        [HttpPost]
        [Route("Files/Upload")]
        public async Task<IActionResult> SubirArchivosVenta([FromForm] DTOVentas Venta)
        {
            return await BsVentas.ProcesarArchivos(Venta);

        }

    }
}
