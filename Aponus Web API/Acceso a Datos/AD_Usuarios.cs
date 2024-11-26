using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Usuarios
    {
        private readonly AponusContext AponusDBContext;
        public AD_Usuarios(AponusContext _aponusContext)
        {
            AponusDBContext = _aponusContext;
        }

        public async Task<(int? StatusCode200Ok, Exception? Ex)> Nuevo(Usuarios Usuario)
        {
            Usuario.Perfil = AponusDBContext.perfilesUsuarios
                .FirstOrDefault(x => x.IdPerfil == Usuario.IdPerfil) ?? new PerfilesUsuarios();

            using (var transaccion = await AponusDBContext.Database.BeginTransactionAsync())
                try
                {
                    await AponusDBContext.Usuarios.AddAsync(Usuario);
                    await AponusDBContext.SaveChangesAsync();
                    await transaccion.CommitAsync();
                    return (StatusCodes.Status200OK, null);
                }
                catch (Exception ex)
                {
                    await transaccion.RollbackAsync();
                    return (null, ex);
                }
        }


        public async Task<(Usuarios? Usuario, Exception? Error)> ObtenerDatosUsuario(string Usuario)
        {
            try
            {
                var _Usuario = await AponusDBContext.Usuarios
                    .FirstOrDefaultAsync(x=> x.Usuario.ToUpper().Equals(Usuario) || x.Correo.ToUpper().Equals(Usuario));

                if (_Usuario != null)
                {
                    return (_Usuario, null);
                }
                else
                {
                    return (null, new Exception("Usuario Inexistente"));
                }
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }
    }
}
