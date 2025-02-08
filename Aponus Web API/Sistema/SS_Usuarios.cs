using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Aponus_Web_API.Systema
{
    public class SS_Usuarios
    {
        private readonly AD_Usuarios AdUsuarios;
        private readonly UTL_JsonWebToken JsonWebToken;

        public SS_Usuarios(AD_Usuarios _usuarios, UTL_JsonWebToken _JsonWebToken)
        {
            AdUsuarios = _usuarios;
            JsonWebToken = _JsonWebToken;
        }

        internal async Task<IActionResult> MapeoRolesDTO()
        {
            var (Roles, ex) = await AdUsuarios.ListaRoles();

            if (ex != null) return new ContentResult()
            {
                Content = ex.InnerException?.Message ?? ex.Message,
                ContentType = "application/json",
                StatusCode = 400
            };

            List<DTORolesUsuarios> dTORolesUsuarios = new();

            Roles!.ForEach(x => dTORolesUsuarios.Add(new DTORolesUsuarios()
            {
                Descripcion = x.Descripcion,
                NombreRol = x.NombreRol,
                IdRol = x.IdRol
            }));

            return new JsonResult(dTORolesUsuarios);
        }

        internal async Task<IActionResult> ValidarUsuario(DTOUsuarios _usuario)
        {
            Usuarios _Usuario = new Usuarios()
            {
                Usuario = _usuario.Usuario ?? "",
                Correo = _usuario.Correo ?? "",
            };

            var (Usuario, ex) = AdUsuarios.ObtenerDatosUsuario(_Usuario);

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

            string Token = JsonWebToken.GenerarToken(Usuario!);
            return new JsonResult(Token);

        }


        public async Task<IActionResult> ProcesarDatos(DTOUsuarios Usuario)
        {
            var (HasContraseña, Sal) = UTL_Contraseñas.HashContraseña(Usuario.Contraseña ?? "");

            Usuarios _Usuario = new Usuarios()
            {
                Usuario = Usuario.Usuario ?? "",
                IdRol = Usuario.idRol ?? 0,
                Correo = Usuario.Correo ?? "",
                HashContraseña = HasContraseña,
                Sal = Sal
            };
            var (UsuarioExistente, _) = AdUsuarios.ObtenerDatosUsuario(_Usuario);

            if (UsuarioExistente != null)
            {
                if (string.Equals(Usuario.Usuario ?? "", UsuarioExistente.Usuario, StringComparison.OrdinalIgnoreCase))
                {
                    return new ContentResult()
                    {
                        Content = "Usuario existente",
                        ContentType = "application/json",
                        StatusCode = 400
                    };
                }
                else if (string.Equals(Usuario.Correo ?? "", UsuarioExistente.Correo, StringComparison.OrdinalIgnoreCase))
                {
                    return new ContentResult()
                    {
                        Content = "Direcccion de correo asociada a otro usuario",
                        ContentType = "application/json",
                        StatusCode = 400
                    };
                }
            }

            var (StatusCode200OK, ex) = await AdUsuarios.Nuevo(_Usuario, Usuario.Contraseña ?? "");

            if (ex != null) return new ContentResult()
            {
                Content = ex.InnerException?.Message ?? ex.Message,
                ContentType = "application/json",
                StatusCode = 400
            };

            return new StatusCodeResult((int)StatusCode200OK!);
        }

        internal async Task<IActionResult> GenerarContraseña(string usuario)
        {
            Usuarios _Usuario = new Usuarios { Usuario = usuario, Correo = usuario };

            var (Usuario, ex) = AdUsuarios.ObtenerDatosUsuario(_Usuario);

            if (ex != null) return new ContentResult()
            {
                Content = ex.InnerException?.Message ?? ex.Message,
                ContentType = "application/json",
                StatusCode = 400
            };

            string contraseña = GenerarContraseña();

            var (HasContraseña, Sal) = UTL_Contraseñas.HashContraseña(contraseña);
            Usuario!.HashContraseña = HasContraseña;
            Usuario.Sal = Sal;



            var (resultado, error) = await AdUsuarios.ResetearContraseña(Usuario!);

            if (error != null) return new ContentResult()
            {
                Content = error.InnerException?.Message ?? error.Message,
                ContentType = "application/json",
                StatusCode = 400
            };

            var (mensaje, errocontraseña) = Enviar_Correo(Usuario.Correo, Usuario.Usuario, contraseña);

            if (errocontraseña != null) return new ContentResult()
            {
                Content = errocontraseña.InnerException?.Message ?? errocontraseña.Message,
                ContentType = "application/json",
                StatusCode = 400
            };

            return new JsonResult(mensaje);


        }


        private string GenerarContraseña()
        {
            const string Caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder Contraseña = new StringBuilder();
            Random Aleatorio = new Random();

            for (int i = 0; i < 6; i++)
            {
                Contraseña.Append(Caracteres[Aleatorio.Next(Caracteres.Length)]);
            }

            return Contraseña.ToString();
        }

        private (string? Mensaje, Exception?) Enviar_Correo(string Correo, string Usuario, string Contraseña)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var _client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential("davidcneri@gmail.com", "pqix uhbp goye yddw"),

                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                _client.SendAsync(new MailMessage(
                    "davidcneri@gmail.com",
                    Correo,
                    "Sistema APONUS - Mensaje Automatico de recuperacion de contraseña",
                    $"Usuario: {Usuario} \n Contraseña: {Contraseña}"),
                    null);


                return ($"La contraseña se envio por correo a {Correo}", null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }

        }


    }
}
