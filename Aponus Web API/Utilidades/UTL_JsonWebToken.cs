using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aponus_Web_API.Utilidades
{
    public class UTL_JsonWebToken
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expiracion;
        private readonly AD_Usuarios AdUsuarios;


        public UTL_JsonWebToken(IConfiguration configuration, UTL_Entorno UtlEntorno, AD_Usuarios adUsuarios)
        {
            _secretKey = UtlEntorno.EsDesarollo()
                ? Environment.GetEnvironmentVariable("JWT_SECRET_KEY", EnvironmentVariableTarget.User)
                    ?? throw new InvalidOperationException("JWT_SECRET_KEY no conigurada para Desarrollo")
                : Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
                    ?? throw new InvalidOperationException("JWT_SECRET_KEY no conigurada para Produccion");

            _issuer = configuration["Jwt:Issuer"] ?? throw new ArgumentNullException("Issuer no configurado");
            _audience = configuration["Jwt:Audience"] ?? throw new ArgumentNullException("Audience no configurado");
            _expiracion = int.Parse(configuration["Jwt:ExpirationInHours"] ?? "15");
            AdUsuarios = adUsuarios;
        }

        public string GenerarToken(Usuarios _usuario)
        {
            var (permisos, error) = AdUsuarios.ListarPermisosRol(_usuario.Rol.NombreRol);

            if (error != null)
                return "Error al obtener los privilegios del usuario";

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, _usuario.Usuario.ToString()),
                new (ClaimTypes.Email, _usuario.Correo),
                new ("Rol", _usuario.Rol.NombreRol),
                new ("TokenId",Guid.NewGuid().ToString())
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var Credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: _issuer,
                    audience: _audience,
                    claims: claims,
                    expires: DateTime.Now.AddHours(_expiracion),
                    signingCredentials: Credenciales
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal ValidarToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)),
                ValidateIssuer = true,
                ValidIssuer = _issuer,
                ValidateAudience = true,
                ValidAudience = _audience,
                ValidateLifetime = true,
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch (Exception ex)
            {
                throw new SecurityTokenException("Invalid token.", ex);
            }
        }
    }
}
