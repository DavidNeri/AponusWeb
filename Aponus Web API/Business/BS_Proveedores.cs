using Aponus_Web_API.Acceso_a_Datos.Proveedores;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Business
{
    public class BS_Proveedores
    {
      

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

        internal IActionResult Listar(int? IdProveedor)
        {
            try
            {
                if (IdProveedor == null)
                    return new ABM_Proveedores().Listar();
                else
                    return new ABM_Proveedores().Listar(IdProveedor);

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

        internal IActionResult Guardar(DTOProveedores Proveedor)
        {
			try
			{
                if (Proveedor.Nombre == null && Proveedor.Apellido == null && Proveedor.NombreClave == null)
                {
                    return new ContentResult()
                    {
                        Content = "Completar Nombre, Apellido y/o Razon Social",
                        ContentType = "application/json",
                        StatusCode = 400,
                    };
                    
                }
                else
                {
                    return new ABM_Proveedores().Guardar(Proveedor);
                }

                
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
