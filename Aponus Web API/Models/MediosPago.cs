using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class MediosPago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_MEDIO_PAGO")]
        public int IdMedioPago { get; set; }

        [Column("CODIGO_MPAGO")]
        public string? CodigoMPago { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        [Column("ID_ESTADO")]
        public int IdEstado{ get; set; }
        public virtual ICollection<PagosCompras> PagosComprasNavigation { get; set; } = new HashSet<PagosCompras>();
        public virtual ICollection<PagosVentas> PagosVentasNavigation { get; set; } = new HashSet<PagosVentas>();


    }
}
    