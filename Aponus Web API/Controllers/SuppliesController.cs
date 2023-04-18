using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_objects;
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

        [HttpGet]
        [Route("List/{idDescription}")]

        public async Task<List<EspecificacionesComponentes>>? Listar(int? idDescription)
        {
            return await new BS_Components().ListarComponentes(idDescription);

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
