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
        private readonly BS_Supplies BsSupplies;
        private readonly BS_Components BsComponents;  

        public SuppliesController(BS_Supplies bsSupplies, BS_Components bsComponents)
        {
            BsSupplies = bsSupplies;
            BsComponents = bsComponents;
        }

        [HttpGet]
        [Route("new-id/{sypplyName}/")]
        public async Task<JsonResult> GenerarIdInsumo(string? sypplyName)
        {
            try
            {
                return await BsSupplies.ObtenerNuevoIdComponente(sypplyName);
            }
            catch (Exception e)
            {
                string Mensaje = e.InnerException?.Message ?? e.Message;
                return new JsonResult(Mensaje);
            }
        }

       [HttpGet]
        [Route("ListFormatted")]
        public IActionResult ListarInsumosFormateados()
        {

            return BsSupplies.ListarNombresFormateados();

        }
      
        [HttpPost]
        [Route("Create-or-Update")]

        public IActionResult ObtenerPropsComponentes(DTODetallesComponenteProducto InsumoProducto)
        {
            try
            {
                return BsSupplies.GuardarInsumoProducto(InsumoProducto);
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
        }

        [HttpPost]


        [Route("ListProp")]

        public JsonResult? Listar(DTODetallesComponenteProducto Especificaciones)
        {
            return BsComponents.DeterminarProp(Especificaciones);

        }

        [HttpGet]
        [Route("GetId")]

        public JsonResult? ObtenerId(DTODetallesComponenteProducto Especificaciones)
        {
            return BsComponents.ObtenerIdComponente(Especificaciones);

        }

        [HttpPost]
        [Route("SaveProductComponents")]

        public IActionResult? GuardarComponentesProducto(List<DTOComponentesProducto> ComponentesProd)
        {
            return BsComponents.GuardarComponentesProducto(ComponentesProd);

        }

    }
}
