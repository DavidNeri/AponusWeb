using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class PagosVentas
    {

        [Key, Column("ID_PAGO", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPago { get; set; }

        [ForeignKey("ID_VENTA")]
        public int IdVenta { get; set; }

        [ForeignKey("ID_MEDIO_PAGO")]
        public int IdMedioPago { get; set; }

        [Column("MONTO")]
        public decimal Monto { get; set; }

        [Column("FECHA")]
        public DateTime? Fecha { get; set; }
        public virtual MediosPago MedioPago { get; set; } = new();
        public virtual Ventas Venta { get; set; } = new();
    }
}
