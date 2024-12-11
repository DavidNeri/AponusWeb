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

        [ForeignKey("ID_CUOTA")]
        public int? IdCuota { get; set; }        

        [ForeignKey("ID_MEDIO_PAGO")]
        public int IdMedioPago { get; set; }

        [Column("MONTO")]
        public decimal Monto { get; set; }

        [Column("FECHA")]
        public DateTime? Fecha { get; set; }

        [ForeignKey("ID_ENTIDAD_PAGO")]
        public int IdEntidadPago { get; set; }   

        public virtual MediosPago MedioPago { get; set; } = new();
        public virtual Ventas Venta { get; set; } = new();
        public virtual EntidadesPago EntidadPago { get; set; } = new();
        public virtual CuotasVentas? Cuota { get; set; }


    }
}
