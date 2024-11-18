using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Controllers
{

    [Route("Aponus/[Controller]")]
    [ApiController]
    public class SuppliesController : Controller
    {
        private readonly BS_Suministros BsSupplies;
        private readonly BS_Componentes BsComponents;

        public SuppliesController(BS_Suministros bsSupplies, BS_Componentes bsComponents)
        {
            BsSupplies = bsSupplies;
            BsComponents = bsComponents;
        }

        [HttpGet]
        [Route("new-id/{sypplyName}/")]
        public JsonResult GenerarIdInsumo(string? sypplyName)
        {
            try
            {
                return BsSupplies.ObtenerNuevoIdComponente(sypplyName);
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

        public async Task<IActionResult> GuardarInsumoProducto(DTODetallesComponenteProducto InsumoProducto)
        {            
            return await BsSupplies.MapeoDTOtoDB(InsumoProducto);           
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
