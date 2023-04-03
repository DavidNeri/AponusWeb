using Aponus_Web_API.Data_Transfer_objects;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class GuardarProducto
    {
        public DatosProducto Producto{ get; set; }

        public List<ComponentesProducto> Componentes { get; set; }

    }
}
