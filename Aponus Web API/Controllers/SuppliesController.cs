using Aponus_Web_API.Business;
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
    }
}
