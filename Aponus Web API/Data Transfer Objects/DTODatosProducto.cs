using  Newtonsoft.Json;
namespace Aponus_Web_API.Data_Transfer_objects
{
    public class DTODatosProducto :DTODetallesProducto
    {       

        [JsonProperty(PropertyName = "descripcionProducto",NullValueHandling =NullValueHandling.Ignore)]
        public string? DescripcionProducto { get; set; }


        [JsonProperty(PropertyName = "detallesProducto", NullValueHandling = NullValueHandling.Ignore)]
        public DTODetallesProducto? DetallesProducto { get; set; }

    }
}
