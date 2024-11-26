using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aponus_Web_API.Systema
{
    public class SS_Usuarios
    {
        private readonly AD_Usuarios AdUsuarios;
        private readonly UTL_Entorno UtlEntorno;

        public SS_Usuarios(AD_Usuarios _usuarios, UTL_Entorno _UtlEntorno)
        {
            AdUsuarios = _usuarios;
            UtlEntorno = _UtlEntorno;
        }

        internal async Task<IActionResult>ValidarUsuario(DTOUsuarios _usuario)
        {
            var (Usuario, ex) = await AdUsuarios.ObtenerDatosUsuario(_usuario.Usuario ?? "");

            if (ex != null) return new ContentResult()
            {
                Content = ex.InnerException?.Message ?? ex.Message,
                ContentType = "application/json",
                StatusCode = 400
            };

            bool esValido = UTL_Contraseñas.VerificarContraseña(_usuario.Contraseña ?? "", Usuario?.HashContraseña ?? "", Usuario?.Sal ?? "");

            if (!esValido)
                return new ContentResult()
                {
                    Content = "Contraseña Incorrecta",
                    ContentType = "application/json",
                    StatusCode = 400
                };

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, Usuario!.Usuario.ToString()),
                new (ClaimTypes.Email, Usuario!.Correo),
                new ("Rol", Usuario!.IdPerfil.ToString()),
            };

            var SecretKey = UtlEntorno.EsDesarollo() ? Environment.GetEnvironmentVariable("JWT_SECRET_KEY", EnvironmentVariableTarget.User) :
                Environment.GetEnvironmentVariable("JWT_SECRET_KEY");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey!));
            var Credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: "https://aponusweb.onrender.com/",
                    audience: "tu-dominio.com",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: Credenciales
                );

            return new JsonResult(new JwtSecurityTokenHandler().WriteToken(token));

        }

        public async Task<IActionResult> ProcesarDatos(DTOUsuarios Usuario)
        {
            var (HasContraseña, Sal) = UTL_Contraseñas.HashContraseña(Usuario.Contraseña ?? "");

            Usuarios _Usuario = new Usuarios()
            {
                Usuario = Usuario.Usuario ?? "",
                IdPerfil = Usuario.IdPerfil ?? 0,
                Correo = Usuario.Correo ?? "",
                HashContraseña = HasContraseña,
                Sal = Sal
            };
            
            var(StatusCode200OK, ex) = await AdUsuarios.Nuevo(_Usuario);           
            
            if(ex != null)return new ContentResult()
            {
                Content = ex.InnerException?.Message ?? ex.Message,
                ContentType = "application/json",
                StatusCode = 400
            };
            
            return new StatusCodeResult((int)StatusCode200OK!);
        }
    }
}
