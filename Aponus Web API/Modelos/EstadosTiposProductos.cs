using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class EstadosTiposProductos
    {
        [Key]
        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = string.Empty;

        public virtual ICollection<ProductosTipo> ProductosTipos{ get; set; } = new List<ProductosTipo>();
    }
}
