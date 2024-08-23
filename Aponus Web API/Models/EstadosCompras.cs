using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class EstadosCompras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ESTADO_COMPRA")]
        public int IdEstadoCompra { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        public virtual ICollection<Compras> compras { get; set; } = new HashSet<Compras>();

    }
}
