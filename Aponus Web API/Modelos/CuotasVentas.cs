using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class CuotasVentas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CUOTA")]
        public int IdCuota { get; set; }

        [ForeignKey("ID_VENTA")]
        public int IdVenta { get; set; }

        [Column("NUMERO_CUOTA")]
        public int NumeroCuota { get; set; }

        [Column("MONTO")]
        public decimal Monto { get; set; }

        [Column("FECHA_VENCIMIENTO")]
        public DateTime FechaVencimiento { get; set; }

        [ForeignKey("ID_ESTADO_CUOTA")]
        public int IdEstadoCuota { get; set; }

        [Column("FECHA_PAGO")]
        public DateTime? FechaPago { get; set; }

        public virtual Ventas Venta { get; set; } = new Ventas();

        public virtual EstadosCuotasVentas EstadoCuota { get; set; } = new EstadosCuotasVentas();

    }
}
