using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class VentasDetalles
    {
        [Key]
        [ForeignKey("ID_VENTA")]
        public int IdVenta { get; set; }

        [Key]
        [ForeignKey("ID_PRODUCTO")]
        public string IdProducto { get; set; } = "";

        [Column("PRECIO")]
        public decimal Precio { get; set; }

        [Column("CANTIDAD")]
        public int Cantidad { get; set; }

        [Column("ENTREGADOS")]
        public int? Entregados { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = new();

        public virtual Ventas Venta { get; set; } = new();


    }
}
