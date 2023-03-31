using  Newtonsoft.Json;
namespace Aponus_Web_API.Data_Transfer_objects
{
    public class DatosProducto :EspecificacionesDatosProducto
    { 
       

        [JsonProperty(PropertyName = "descripcionProducto",NullValueHandling =NullValueHandling.Ignore)]
        public string? DescripcionProducto { get; set; }

        [JsonProperty(PropertyName = "productos", NullValueHandling = NullValueHandling.Ignore)]
        public List<EspecificacionesDatosProducto>? Producto { get; set;}

    }
}
