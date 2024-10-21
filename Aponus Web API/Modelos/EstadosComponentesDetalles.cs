using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class EstadosComponentesDetalles
    {
        [Key]
        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = string.Empty;
        
        public virtual ICollection<ComponentesDetalle> ComponentesDetalle { get; set; } = new List<ComponentesDetalle>();
    }
}
