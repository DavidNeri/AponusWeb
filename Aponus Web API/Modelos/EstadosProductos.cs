using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class EstadosProductos
    {
        [Key]
        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = string.Empty;

        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
