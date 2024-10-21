using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class Productos_Tipos_Descripcion
    {
        [Column("ID_DESCRIPCION")]
        public int? IdDescripcion { get; set; }

        [Column("ID_TIPO")]
        public string IdTipo { get; set; } = string.Empty; 
        public  virtual ProductosTipo IdTipoNavigation { get; set; } = new ProductosTipo();
        public virtual ProductosDescripcion IdDescripcionNavigation { get; set; } = new ProductosDescripcion();


    }
}
