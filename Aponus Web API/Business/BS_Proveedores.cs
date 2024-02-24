using Aponus_Web_API.Acceso_a_Datos.Proveedores;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Business
{
    public class BS_Proveedores
    {
        internal IActionResult Actualizar(DTOProveedores proveedor)
        {
            try
            {
                return new ABM_Proveedores().ActualizarProveedor(proveedor);
            }
            catch (Exception ex)
            {

                return new ContentResult()
                {
                    ContentType = "application/json",
                    StatusCode = 400,
                    Content = !string.IsNullOrEmpty(ex.InnerException.Message) ? "Error:\n" + ex.InnerException.Message : "Error:\n" + ex.Message
                };
            }
        }

        internal IActionResult Eliminar(int idProveedor)
        {
            try
            {
                return new ABM_Proveedores().Eliminar(idProveedor);
            }
            catch (Exception ex)
            {

                return new ContentResult()
                {
                    ContentType = "application/json",
                    StatusCode = 400,
                    Content = !string.IsNullOrEmpty(ex.InnerException.Message) ? "Error:\n" + ex.InnerException.Message : "Error:\n" + ex.Message
                };
            }
            
        }

        internal IActionResult Listar()
        {
            try
            {
                return new ABM_Proveedores().Listar();
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    ContentType = "application/json",
                    StatusCode = 400,
                    Content = !string.IsNullOrEmpty(ex.InnerException.Message) ? "Error:\n" + ex.InnerException.Message : "Error:\n" + ex.Message
                };
            }
        }

        internal IActionResult Nuevo(DTOProveedores proveedor)
        {
			try
			{
				return new ABM_Proveedores().NuevoProveedor(proveedor);
			}
			catch (Exception ex)
			{
                return new ContentResult()
                {
                    ContentType = "application/json",
                    StatusCode = 400,
                    Content = !string.IsNullOrEmpty(ex.InnerException.Message) ? "Error:\n" + ex.InnerException.Message : "Error:\n" + ex.Message
                };

            }
        }
    }
}
