using  Newtonsoft.Json;
namespace Aponus_Web_API.Mapping
{
    public class DatosProducto :EspecificacionesDatosProducto
    { 
       

        [JsonProperty(PropertyName = "descripcionProducto")]
        public string? DescripcionProducto { get; set; } 

        [JsonProperty(PropertyName = "productos")]
        public List<EspecificacionesDatosProducto>? Producto { get; set;}

    }
}
