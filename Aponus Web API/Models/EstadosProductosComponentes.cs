using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class EstadosProductosComponentes
    {
        [Key]
        [Column("ID_ESTADO")]        
        public int IdEstado { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion{ get; set;}

        public ICollection<Productos_Componentes> ProductosComponentes { get; set; }

    }
}
