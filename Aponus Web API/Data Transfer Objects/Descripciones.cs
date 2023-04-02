using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class Descripciones
    {
        [JsonProperty(PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
        public int IdDescripcion { get; set; }
        [JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
        public string? Descripcion { get;set; }

    }
}
