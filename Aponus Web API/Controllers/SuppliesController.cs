using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{

    [Route("Aponus/[Controller]")]
    [ApiController]
    public class SuppliesController : Controller
    {
        [HttpPost]
        [Route("GetTableID")]
        public int? ObtenerTabla(Data_Transfer_objects.Insumos Insumo)
        {
            try
            {
                return new BS_TablasInsumos().ObtenerTablaInsumo(Insumo);
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        [HttpPost]
        [Route("ListProp")]

        public JsonResult? Listar(DTOComponente Especificaciones)
        {
            return  new BS_Components().DeterminarProp(Especificaciones);

        }

        [HttpPost]
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
