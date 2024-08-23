using Aponus_Web_API.Mapping;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Aponus_Web_API.Acceso_a_Datos.Validaciones
{
    public class Login
    {
        private readonly AponusContext AponusDBContext;
        public Login() { AponusDBContext = new AponusContext(); }

        internal DTOUsuarios? Validar(DTOUsuarios usuario)
        {
            List<DTOUsuarios>? ListUsuario = new List<DTOUsuarios>();
            DTOUsuarios? Usuario = new DTOUsuarios();


            if (usuario.Usuario.Contains("@")==true)
            {
                ListUsuario = AponusDBContext.Usuarios
                   .Where(x => x.correo == usuario.Usuario && x.Contraseña == usuario.Contraseña)
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
            else if(usuario.Usuario.Contains("@") == false) 
            {

                ListUsuario = AponusDBContext.Usuarios
                   .Where(x => x.Usuario == usuario.Usuario && x.Contraseña == usuario.Contraseña)
                   .Select(x => new DTOUsuarios
                   {
                       Usuario = x.Usuario,
                       Contraseña = x.Contraseña,
                       IdPerfil = x.IdPerfil
                   }).ToList();
              
                if (ListUsuario.Count()!=0)
                {
                    Usuario.Usuario = ListUsuario[0].Usuario;
                    Usuario.IdPerfil = ListUsuario[0].IdPerfil;
                }
                               
                return Usuario;
                

            }else
            {
                return null;
            }

        }
    }
}
