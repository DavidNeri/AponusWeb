using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Controllers
{

    [Route("Aponus/[Controller]")]
    [ApiController]
    public class SuppliesController : Controller
    {
     
        [HttpGet]
        [Route("new-id/{sypplyName}/")]
        public async Task<JsonResult> GenerarIdInsumo(string? sypplyName)
        {
            try
            {
                return await new BS_Supplies().ObtenerNuevoIdComponente(sypplyName);
            }
            catch (Exception e)
            {

                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
        }

       [HttpGet]
        [Route("ListFormatted")]
        public IActionResult ListarInsumosFormateados()
        {

            return new BS_Supplies().ListarNombresFormateados();

        }
      
        [HttpPost]
        [Route("Create-or-Update")]

        public IActionResult ObtenerPropsComponentes(DTOComponente InsumoProducto)
        {
            try
            {
                return new BS_Supplies().GuardarInsumoProducto(InsumoProducto);
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
        }

        [HttpPost]


        [Route("ListProp")]

        public JsonResult? Listar(DTOComponente Especificaciones)
        {
            return  new BS_Components().DeterminarProp(Especificaciones);

        }

        [HttpGet]
        [Route("GetId")]

        public JsonResult? ObtenerId(DTOComponente Especificaciones)
        {
            return new BS_Components().ObtenerIdComponente(Especificaciones);

        }

        [HttpPost]
        [Route("SaveProductComponents")]

        public IActionResult? GuardarComponentesProducto(List<DTOComponentesProducto> ComponentesProd)
        {
            return new BS_Components().GuardarComponentesProducto(ComponentesProd);

        }

    }
}
