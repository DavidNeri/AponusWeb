using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Systema
{
    public class SS_Usuarios
    {
        private readonly AD_Usuarios AdUsuarios;

        public SS_Usuarios(AD_Usuarios _usuarios)
        {
            AdUsuarios = _usuarios;
        }

        internal DTOUsuarios? ValidarUsuario(DTOUsuarios Usuario)
        {
            return AdUsuarios.ValidarCredenciales(Usuario);
        }

        public async Task<IActionResult> NuevoUsuario(DTOUsuarios Usuario)
        {
            Modelos.Usuarios _Usuario = new Modelos.Usuarios()
            {
                Usuario = Usuario.Usuario ?? "",
                IdPerfil = Usuario.IdPerfil ?? 0,
                Correo = Usuario.Correo ?? "",
                Contraseña = Usuario.Contraseña ?? "",
            };

            try
            {
                await AdUsuarios.Nuevo(_Usuario);
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 500
                };
            }

        }
    }
}
