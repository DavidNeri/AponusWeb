using Aponus_Web_API.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.System
{
    public class SS_Usuarios
    {
        internal DTOUsuarios? ValidarUsuario(DTOUsuarios Usuario )
        {
            return new Acceso_a_Datos.Usuarios.Usuarios().ValidarCredenciales(Usuario);

        }

        public static async Task<IActionResult> NuevoUsuario(DTOUsuarios Usuario)
        {

            Models.Usuarios _Usuario = new Models.Usuarios()
            {
                Usuario = Usuario.Usuario ?? "",
                IdPerfil = Usuario.IdPerfil ?? 0,
                correo = Usuario.Correo ?? "",
                Contraseña = Usuario.Contraseña ?? "",
            };

            try
            {
                await new Acceso_a_Datos.Usuarios.Usuarios().Nuevo(_Usuario);
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {

                return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,   
                    ContentType="application/json",
                    StatusCode=500
                };
            }
             
        }
    }
}
