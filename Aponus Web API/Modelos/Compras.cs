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

        //[ForeignKey("ID_PROVEEDOR")]
        public int IdProveedor { get; set; }

        [Column("FECHA_HORA")]
        public DateTime FechaHora { get; set; }

        [ForeignKey("ID_USUARIO")]
        public string IdUsuario { get; set; } = string.Empty;

        [Column("ID_ESTADO_COMPRA")]
        public int IdEstadoCompra { get; set; }

        [Column("SALDO_TOTAL")]
        public decimal SaldoTotal { get; set; }

        [Column("SALDO_CANCELADO")]
        public decimal? SaldoCancelado { get; set; }

        [NotMapped]
        public decimal SaldoPendiente => SaldoTotal - (SaldoCancelado ?? 0); 
        public virtual Usuarios Usuario { get; set; }  = new();
        public virtual EstadosCompras Estado { get; set; } = new();
        public virtual Entidades Proveedor { get; set; } = new ();
        public virtual ICollection<ComprasDetalles> DetallesCompra {  get; set; } = new HashSet<ComprasDetalles>();
        public virtual ICollection<PagosCompras> Pagos { get; set; } = new HashSet<PagosCompras>(); 
    }
}
