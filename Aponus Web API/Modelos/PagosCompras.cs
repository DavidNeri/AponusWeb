using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class PagosCompras
    {
        [Key, Column("ID_PAGO", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPago { get; set; }

        [ForeignKey("ID_COMPRA")]
        public int IdCompra { get; set; }      

        [ForeignKey("ID_MEDIO_PAGO")]
        public int IdMedioPago{ get; set; }

        [Column("CANTIDAD_CUOTAS")]
        public int? CantidadCuotas { get; set; }

        [Column("CANTIDAD_CUOTAS_CANCELADAS")]
        public int? CantidadCuotasCanceladas { get; set; }

        [Column("SUBTOTAL")]
        public decimal Subtotal { get; set; }

        [Column("TOTAL")]
        public decimal Total { get; set; }

        [Column("SUBTOTAL_CANCELADO")]
        public decimal? SubtotalCancelado { get; set; }

        [NotMapped]
        public decimal SubtotalPendiente => Subtotal - (SubtotalCancelado ?? 0);

        [NotMapped]
        public decimal CantidadCuotasPendientes => (CantidadCuotas ?? 0)- (CantidadCuotasCanceladas ?? 0);
        public virtual MediosPago MedioPago { get; set; } = new();        
        public virtual Compras Compra { get; set; } = new();


    }
}
