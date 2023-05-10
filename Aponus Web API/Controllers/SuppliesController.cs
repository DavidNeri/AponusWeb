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

        public JsonResult? Listar(EspecificacionesComponentes Especificaciones)
        {
            return  new BS_Components().DeterminarProp(Especificaciones);

        }

       

       /* [HttpGet]
        [Route("List/{idDescription}")]

        public async Task<List<TipoInsumos>> Listar(int? idDescription)
        {
            return await new BS_Stocks().Listar(idDescription);

        }

        */


    }
}
