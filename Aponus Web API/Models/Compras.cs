using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
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
        public string IdUsuario { get; set; }

        [Column("ID_ESTADO_COMPRA")]
        public int IdEstadoCompra { get; set; }

        [Column("SALDO_TOTAL")]
        public decimal SaldoTotal { get; set; }

        [Column("SALDO_CANCELADO")]
        public decimal? SaldoCancelado { get; set; }

        [NotMapped]
        public decimal SaldoPendiente => SaldoTotal - (SaldoCancelado ?? 0);       

        public Entidades Proveedor = new();

        public Usuarios Usuario = new();

        public virtual ICollection<ComprasDetalles> DetallesCompra {  get; set; } = new HashSet<ComprasDetalles>();
        public virtual ICollection<PagosCompras> Pagos { get; set; } = new HashSet<PagosCompras>();

        public virtual EstadosCompras Estado { get; set; } = new();



    }
}
