using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOTiposProductos
    {
        [JsonProperty(PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
        public string IdTipo { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "descripcionTipo", NullValueHandling = NullValueHandling.Ignore)]
        public string DescripcionTipo{ get; set; } = string.Empty;

        public List<DTODescripcionesProductos> DescripcionProductos { get; set; } = new List<DTODescripcionesProductos>();
    }
}
