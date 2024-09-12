using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class EntidadesTipos
    {
        [Key]
        [Column("ID_TIPO")]
        public int IdTipo { get; set; }
        
        [Column("NOMBRE")]
        public string NombreTipo { get; set; }

        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        public virtual ICollection<Entidades> Entidades { get; set; }
        public virtual ICollection<EntidadesTiposCategorias> TiposCategoriasNavigation { get; set; }




    }
}
