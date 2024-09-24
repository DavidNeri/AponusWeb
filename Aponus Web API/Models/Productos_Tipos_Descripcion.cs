using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class Productos_Tipos_Descripcion
    {
        [Column("ID_DESCRIPCION")]
        public int? IdDescripcion { get; set; }

        [Column("ID_TIPO")]
        public string IdTipo { get; set; }        

        public  virtual ProductosTipo IdTipoNavigation { get; set; }
        public virtual ProductosDescripcion IdDescripcionNavigation { get; set; }


    }
}
