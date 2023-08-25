using Aponus_Web_API.Data_Transfer_objects;
using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOProducto
    {
        [JsonProperty(PropertyName = "producto", NullValueHandling = NullValueHandling.Ignore)]
        public DatosProducto Producto{ get; set; }

        [JsonProperty(PropertyName = "componentesProducto", NullValueHandling = NullValueHandling.Ignore)]
        public List<DTOComponentesProducto> Componentes { get; set; }

    }
}
