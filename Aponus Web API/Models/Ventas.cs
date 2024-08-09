using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class Ventas
    {
        [Key]
        [Column("ID_VENTA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenta{ get; set; }

        [Column("ID_CLIENTE")]
        public int IdCliente{ get; set; }

        [Column("FECHA_HORA")]
        public DateTime FechaHora { get; set; }

        [ForeignKey("ID_USUARIO")]
        public string IdUsuario { get; set; }

        [Column("ID_ESTADO_VENTA")]
        public int IdEstadoVenta{ get; set; }

        [Column("SALDO_TOTAL")]
        public decimal SaldoTotal { get; set; }

        [Column("SALDO_CANCELADO")]
        public decimal? SaldoCancelado { get; set; }

        [NotMapped]
        public decimal SaldoPendiente => SaldoTotal - (SaldoCancelado ?? 0);

        public virtual Entidades Cliente { get; set; }
        
        public Usuarios Usuario = new();
        public virtual ICollection<VentasDetalles> DetallesVenta{ get; set; } = new HashSet<VentasDetalles>();
        public virtual ICollection<PagosVentas> Pagos { get; set; } = new HashSet<PagosVentas>();
        public virtual ICollection<CuotasVentas> Cuotas { get; set; } = new HashSet<CuotasVentas>();
        public virtual EstadosVentas Estado { get; set; } = new();


    }
}
