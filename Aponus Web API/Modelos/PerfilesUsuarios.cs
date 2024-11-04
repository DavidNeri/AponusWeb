using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class PerfilesUsuarios
    {
        [Key]
        [Column("ID_PERFIL")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerfil { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        public virtual ICollection<Usuarios> UsuariosNavigation { get; set; } = new HashSet<Usuarios>();
    }
}
