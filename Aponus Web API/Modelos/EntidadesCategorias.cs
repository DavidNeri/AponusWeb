using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class EntidadesCategorias
    {
        [Key]
        [Column("ID_CATEGORIA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }

        [Column("NOMBRE_CATEGORIA")]
        public string NombreCategoria { get; set;} = string.Empty;

        [Column("ID_ESTADO")]
        public int IdEstado {  get; set; }
        public virtual ICollection<Entidades> Entidades { get; set; } = new List<Entidades>();
        public virtual ICollection<EntidadesTiposCategorias> TiposCategoriasNavigation { get; set; } = new List<EntidadesTiposCategorias>();


    }
}
