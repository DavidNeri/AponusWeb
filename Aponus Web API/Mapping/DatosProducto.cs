using  Newtonsoft.Json;
namespace Aponus_Web_API.Mapping
{
    public class DatosProducto 
    { 
       

        [JsonProperty(PropertyName = "descripcion")]
        public string? Descripcion { get; set; } 

        [JsonProperty(PropertyName = "especifiaciones")]
        public List<EspecificacionesDatosProducto>? Especificaciones { get; set;}
    }
}
