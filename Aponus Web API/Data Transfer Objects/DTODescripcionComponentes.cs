using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTODescripcionComponentes
    {
        [JsonProperty(PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
        public int IdDescripcion { get; set; }

        [JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
        public string Descripcion { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "idAlmacenamiento", NullValueHandling = NullValueHandling.Ignore)]
        public string IdAlmacenamiento { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "idFraccionamiento", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdFraccionamiento { get; set; }
    }
}
