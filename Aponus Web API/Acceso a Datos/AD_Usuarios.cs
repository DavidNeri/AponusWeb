using Aponus_Web_API.Modelos;
using Microsoft.EntityFrameworkCore;
using Npgsql;


namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Usuarios
    {
        private readonly AponusContext AponusDBContext;
        public AD_Usuarios(AponusContext _aponusContext)
        {
            AponusDBContext = _aponusContext;
        }

        public async Task<(int? StatusCode200Ok, Exception? Ex)> Nuevo(Usuarios Usuario, string contraseña)
        {
            Usuario.Rol = AponusDBContext.rolesUsuarios
                .FirstOrDefault(x => x.IdRol == Usuario.IdRol) ?? new RolesUsuarios();

            using var transaccion = await AponusDBContext.Database.BeginTransactionAsync();
            try
            {
                if (Usuario.Rol != null)
                {
                    RolesUsuarios rol = Usuario.Rol;

                    using (var Conexion = new NpgsqlConnection(AponusDBContext.Database.GetConnectionString()))
                    {
                        await Conexion.OpenAsync();
                        var QueryCrearUsuario = new NpgsqlCommand($"CREATE USER {Usuario.Usuario} WITH PASSWORD '{contraseña}';", Conexion);
                        var QueryAsignarRol = new NpgsqlCommand($"GRANT {rol.NombreRol} TO {Usuario.Usuario};", Conexion);
                        QueryCrearUsuario.ExecuteNonQuery();
                        QueryAsignarRol.ExecuteNonQuery();
                    }
                }

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

        public async Task<(int? Resultado, Exception? ex)> ResetearContraseña(Usuarios usuario)
        {
            try
            {
                AponusDBContext.Usuarios.Update(usuario);
                await AponusDBContext.SaveChangesAsync();

                return (StatusCodes.Status200OK, null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }



        public (Usuarios? Usuario, Exception? Error) ObtenerDatosUsuario(Usuarios usuario)
        {
            try
            {

                var _Usuario = AponusDBContext.Usuarios
                    .Include(x => x.Rol)
                    .FirstOrDefault(x => x.Usuario.ToUpper().Equals(usuario.Usuario.ToUpper()) || x.Correo.ToUpper().Equals(usuario.Correo.ToUpper()));

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

        public (List<AsignacionPermisosRoles>? permisosRol, Exception? ex) ListarPermisosRol(string rol)
        {
            try
            {
                return (AponusDBContext.asignacionRoles
                                .Where(x => x.EsquemaTabla == "public" && x.Beneficiario == rol)
                                .Select(x => new AsignacionPermisosRoles()
                                {
                                    NombreTabla = x.NombreTabla,
                                    Atributo = x.Atributo
                                })
                                .ToList(),
                        null);
            }
            catch (Exception ex)
            {
                return (null, ex);

            }
        }

        internal async Task<(List<RolesUsuarios>? Roles, Exception? ex)> ListaRoles()
        {
            try
            {
                return (await AponusDBContext.rolesUsuarios.ToListAsync(), null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }

        }
    }
}
