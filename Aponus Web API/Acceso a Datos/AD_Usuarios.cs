using Aponus_Web_API.Mapping;
using Aponus_Web_API.Modelos;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Usuarios
    {
        private readonly AponusContext AponusDBContext;
        public AD_Usuarios(AponusContext _aponusContext)
        {
            AponusDBContext = _aponusContext;
        }

        internal DTOUsuarios? ValidarCredenciales(DTOUsuarios usuario)
        {
            List<DTOUsuarios>? ListUsuario = new List<DTOUsuarios>();
            DTOUsuarios? Usuario = new DTOUsuarios();


            if (usuario.Usuario != null && usuario.Usuario.Contains("@") == true)
            {
                ListUsuario = AponusDBContext.Usuarios
                   .Where(x => x.Correo == usuario.Usuario && x.Contraseña == usuario.Contraseña)
                   .Select(x => new DTOUsuarios
                   {
                       Usuario = x.Usuario,
                       IdPerfil = x.IdPerfil
                   }).ToList();

                if (ListUsuario.Count() != 0)
                {
                    Usuario.Usuario = ListUsuario[0].Usuario;
                    Usuario.IdPerfil = ListUsuario[0].IdPerfil;
                }

                return Usuario;

            }
            else if (usuario.Usuario != null && usuario.Usuario.Contains("@") == false)
            {

                ListUsuario = AponusDBContext.Usuarios
                   .Where(x => x.Usuario == usuario.Usuario && x.Contraseña == usuario.Contraseña)
                   .Select(x => new DTOUsuarios
                   {
                       Usuario = x.Usuario,
                       Contraseña = x.Contraseña,
                       IdPerfil = x.IdPerfil
                   }).ToList();

                if (ListUsuario.Count() != 0)
                {
                    Usuario.Usuario = ListUsuario[0].Usuario;
                    Usuario.IdPerfil = ListUsuario[0].IdPerfil;
                }

                return Usuario;


            }
            else
            {
                return null;
            }

        }


        public async Task Nuevo(Modelos.Usuarios Usuario)
        {
            Usuario.Perfil = AponusDBContext.perfilesUsuarios.FirstOrDefault(x => x.IdPerfil == Usuario.IdPerfil) ?? new PerfilesUsuarios();

            using (var transaccion = await AponusDBContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await AponusDBContext.Usuarios.AddAsync(Usuario);
                    await AponusDBContext.SaveChangesAsync();
                    await transaccion.CommitAsync();
                }
                catch (Exception)
                {
                    await transaccion.RollbackAsync();
                }
            }

        }
    }
}
