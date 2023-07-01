namespace Aponus_Web_API.Models
{
    public class Productos_Tipos_Descripcion
    {
        public int? IdDescripcion { get; set; }
        public string IdTipo { get; set; }

        //Navigation Properties

        public  ProductosTipo IdTipoNavigation { get; set; }
        public ProductosDescripcion DescripcionNavigation { get; set; }


    }
}
