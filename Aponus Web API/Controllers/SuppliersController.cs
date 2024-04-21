using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        [HttpPost]
        [Route("Save")]
        public IActionResult Nuevo(DTOProveedores Proveedor)
        {
            return new BS_Proveedores().Guardar(Proveedor);
        }       


        [HttpPost]
        [Route("{IdProveedor}/Delete")]
        public IActionResult Eliminar(int IdProveedor)
        {
            return new BS_Proveedores().Eliminar(IdProveedor);
        }

        [HttpGet]
        [Route("List/{IdProveedor?}")]
        public IActionResult Listar(int? IdProveedor)
        {
            return new BS_Proveedores().Listar(IdProveedor);
        }

    }
}
