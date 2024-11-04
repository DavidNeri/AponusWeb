using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class Compras
    {
        [Key]
        [Column("ID_COMPRA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCompra { get; set; }

        [Column("ID_PROVEEDOR")]
        public int IdProveedor { get; set; }

        [Column("FECHA_HORA")]
        public DateTime FechaHora { get; set; }

        [ForeignKey("ID_USUARIO")]
        public string IdUsuario { get; set; } = string.Empty;

        [Column("MONTO_TOTAL")]
        public decimal MontoTotal { get; set; }

        [Column("SALDO_PENDIENTE")]
        public decimal? SaldoPendiente { get; set; }

        [Column("ID_ESTADO_COMPRA")]
        public int IdEstadoCompra { get; set; }

        [NotMapped]
        public decimal SaldoCancelado => MontoTotal - (SaldoPendiente ?? 0);

        public virtual Entidades IdProveedorNavigation { get; set; } = new();
        public virtual Usuarios Usuario { get; set; } = new();
        public virtual EstadosCompras Estado { get; set; } = new();
        public virtual ICollection<ComprasDetalles> DetallesCompra { get; set; } = new HashSet<ComprasDetalles>();
        public virtual ICollection<PagosCompras> Pagos { get; set; } = new HashSet<PagosCompras>();
        public virtual ICollection<CuotasCompras> CuotasCompra { get; set; } = new HashSet<CuotasCompras>();
    }
}
