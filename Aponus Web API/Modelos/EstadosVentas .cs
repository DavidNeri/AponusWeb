using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class EstadosVentas
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ESTADO_VENTA")]
        public int IdEstadoVenta{ get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        public virtual ICollection<Ventas> ventas { get; set; } = new HashSet<Ventas>();
    }
}
