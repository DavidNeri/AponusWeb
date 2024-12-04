using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class RolesUsuarios
    {
        public int IdRol { get; set; }
        public string NombreRol{ get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public virtual ICollection<Usuarios> RolesUsuariosNavigation { get; set; } = new HashSet<Usuarios>();
    }
}
