using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class EntidadesCategorias
    {
        [Key]
        [Column("ID_CATEGORIA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }

        [Column("NOMBRE_CATEGORIA")]
        public string NombreCategoria { get; set;}

        [Column("ID_ESTADO")]
        public byte IdEstado {  get; set; }
        public virtual ICollection<Entidades> Entidades { get; set; }
        public virtual ICollection<EntidadesTiposCategorias> TiposCategoriasNavigation { get; set; }


    }
}
