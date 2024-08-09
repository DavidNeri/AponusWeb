using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support.Ventas;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]

    //Se agregó 'Default Value' =1 en ID_ESTADO tablas MEDIOS_PAGO y ESTADOS_VENTAS  --> MNodificar en DBContexdt
    public class SalesController : Controller
    {
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List(FiltrosVentas? Filtros)
        {
            return await BS_Ventas.Filtrar(Filtros);

        }
        //

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Guardar (DTOVentas Venta)
        {
            if(Venta.Monto.Equals(0))
                return new ContentResult()
                {
                    Content="El valor de la venta no puede ser 0.00",
                    ContentType="Application/Json",
                    StatusCode = 400
                };
            else
            {
                
                return await BS_Ventas.ProcesarDatosVenta(Venta);
            }


        }

        //Traer 'Calcular Cuotas' 
        //Agregar Estados Ventas
        //Agregar TIPO y  CATEGORIA de ENTIDADES , en 'Entidades'



    }
}
