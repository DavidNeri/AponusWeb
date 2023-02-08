using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class EspecificacionesComponentes : Stocks
    {
        [JsonProperty(PropertyName = "idDescripcion"), JsonIgnore]
        public int? IdDescripcion { get; set; }

        [JsonProperty(PropertyName = "IdComponente" , NullValueHandling = NullValueHandling.Ignore)]
        public string? idComponente { get; set; }

        [JsonProperty(PropertyName = "largo" , NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Largo { get; set; }

        [JsonProperty(PropertyName = "ancho", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Ancho { get; set; }

        [JsonProperty(PropertyName = "espesor" , NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Espesor { get; set; }

        [JsonProperty(PropertyName = "perfil" , NullValueHandling = NullValueHandling.Ignore)]
        public int? Perfil { get; set; }

        [JsonProperty(PropertyName = "diametro" , NullValueHandling = NullValueHandling.Ignore)]
        public int? Diametro { get; set; }

        [JsonProperty(PropertyName = "Altura" , NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Altura { get; set; }

        [JsonProperty(PropertyName = "toleranciaMinima" , NullValueHandling = NullValueHandling.Ignore)]
        public int? ToleranciaMinina { get; set; }

        [JsonProperty(PropertyName = "toleranciaMaxima" , NullValueHandling = NullValueHandling.Ignore)]
        public int? ToleranciaMaxima { get; set; }



    }
}
