using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class EstadosTiposProductos
    {
        [Key]
        [Column("ID_ESTADO")]
        public byte IdEstado { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        public virtual ICollection<ProductosTipo> ProductosTipos{ get; set; }
    }
}
