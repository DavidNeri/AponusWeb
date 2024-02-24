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
        [Route("New")]
        public IActionResult Nuevo([FromForm] DTOProveedores Proveedor)
        {
            return new BS_Proveedores().Nuevo(Proveedor);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Actualizar(DTOProveedores Proveedor)
        {
            return new BS_Proveedores().Actualizar(Proveedor);
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public IActionResult Actualizar(int IdProveedor)
        {
            return new BS_Proveedores().Eliminar(IdProveedor);
        }

        [HttpGet]
        [Route("List")]
        public IActionResult Listar()
        {
            return new BS_Proveedores().Listar();
        }

    }
}
