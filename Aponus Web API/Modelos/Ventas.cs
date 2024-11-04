using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class Ventas
    {
        [Key]
        [Column("ID_VENTA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenta { get; set; }

        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }

        [Column("FECHA_HORA")]
        public DateTime FechaHora { get; set; }

        [ForeignKey("ID_USUARIO")]
        public string IdUsuario { get; set; } = "";

        [Column("MONTO_TOTAL")]
        public decimal MontoTotal { get; set; }

        [Column("SALDO_PENDIENTE")]
        public decimal? SaldoPendiente { get; set; }

        [Column("ID_ESTADO_VENTA")]
        public int IdEstadoVenta { get; set; }

        [NotMapped]
        public decimal SaldoCancelado => MontoTotal - (SaldoPendiente ?? 0);

        public virtual Entidades Cliente { get; set; } = new();
        public virtual Usuarios Usuario { get; set; } = new();
        public virtual EstadosVentas Estado { get; set; } = new();

        public virtual ICollection<VentasDetalles> DetallesVenta { get; set; } = new HashSet<VentasDetalles>();
        public virtual ICollection<PagosVentas> Pagos { get; set; } = new HashSet<PagosVentas>();
        public virtual ICollection<CuotasVentas> Cuotas { get; set; } = new HashSet<CuotasVentas>();


    }
}
