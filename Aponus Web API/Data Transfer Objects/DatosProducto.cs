using  Newtonsoft.Json;
namespace Aponus_Web_API.Data_Transfer_objects
{
    public class DatosProducto :EspecificacionesDatosProducto
    { 
       

        [JsonProperty(PropertyName = "descripcionProducto")]
        public string? DescripcionProducto { get; set; } 

        [JsonProperty(PropertyName = "productos")]
        public List<EspecificacionesDatosProducto>? Producto { get; set;}

    }
}
