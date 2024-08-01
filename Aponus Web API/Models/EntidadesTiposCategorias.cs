using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class EntidadesTiposCategorias
    {
        [ForeignKey("ID_TIPO")]
        public int idTipoEntidad { get; set; }

        [ForeignKey("ID_CATEGORIA")]
        public int IdCategoriaEntidad{ get; set; }

        public virtual EntidadesTipos TipoEntidad { get; set; } = new EntidadesTipos();
        public virtual EntidadesCategorias CategoriaEntidad { get; set; } = new EntidadesCategorias();

    }
}
