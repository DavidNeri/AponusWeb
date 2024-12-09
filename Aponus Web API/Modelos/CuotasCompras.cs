using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class CuotasCompras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CUOTA")]
        public int IdCuota { get; set; }

        [ForeignKey("ID_COMPRA")]
        public int IdCompra { get; set; }

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

        public virtual Compras CompraNavigation { get; set; } = new Compras();
        public virtual EstadosCuotasCompras EstadoCuotaCompra { get; set; } = new EstadosCuotasCompras();
        public virtual ICollection<PagosCuotasCompras> pagosCuotasCompras { get; set; } = new HashSet<PagosCuotasCompras>();

    }
}