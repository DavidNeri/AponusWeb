using Aponus_Web_API.Data_Transfer_objects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class ComprasDetalles
    {
        [Key]
        [ForeignKey("ID_COMPRA")]
        public int IdCompra { get; set; }

        [Key]
        [ForeignKey("ID_INSUMO")]
        public string IdInsumo { get; set; } = string.Empty;

        [Column("CANTIDAD")]
        public int Cantidad { get; set; }       

        public virtual ComponentesDetalle DetallesInsumo { get; set; }  = new ComponentesDetalle();
        public virtual Compras Compra { get; set; } = new  Compras ();

    }
}
