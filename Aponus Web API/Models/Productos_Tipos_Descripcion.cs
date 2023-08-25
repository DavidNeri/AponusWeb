using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class Productos_Tipos_Descripcion
    {
        [Column("ID_DESCRIPCION")]
        public int? IdDescripcion { get; set; }

        [Column("ID_DTIPO")]
        public string IdTipo { get; set; }

        //Navigation Properties

        //public  ProductosTipo IdTipoNavigation { get; set; }
        //public ProductosDescripcion IdDescripcionNavigation { get; set; }


    }
}
