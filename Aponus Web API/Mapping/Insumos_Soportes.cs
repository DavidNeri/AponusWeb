using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class Insumos_Soportes
    {
       // [JsonProperty(PropertyName = "idComponente")]
        //public string? IdComponente { get; set; }

        [JsonProperty(PropertyName ="idDescripcion"), JsonIgnore]
        public int? IdDescripcion { get; set; }

        [JsonProperty(PropertyName ="diametro")]
        public decimal? Diametro { get; set; }

        [JsonProperty(PropertyName ="altura")]
        public decimal? Altura { get; set; }

        [JsonProperty(PropertyName = "recibido")]
        public decimal? Recibido { get; set; }

        [JsonProperty(PropertyName = "pintura")]
        public decimal? Pintura { get; set; }

        [JsonProperty(PropertyName = "proceso")]
        public decimal? Proceso { get; set; }

    }

}
