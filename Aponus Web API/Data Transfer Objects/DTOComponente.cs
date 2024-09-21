using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class DTOComponente : DTOStocks
    {
        [JsonProperty(PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdDescripcion { get; set; }

        [JsonProperty(PropertyName = "idComponente" , NullValueHandling = NullValueHandling.Ignore)]
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
        public decimal? Diametro { get; set; }

        [JsonProperty(PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
        public int? DiametroNominal { get; set; }

        [JsonProperty(PropertyName = "Altura" , NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Altura { get; set; }
       
        [JsonProperty(PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
        public string? Tolerancia{ get; set; }

        [JsonProperty(PropertyName = "longitud", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Longitud { get; set; }

        [JsonProperty(PropertyName = "idFraccionamiento", NullValueHandling = NullValueHandling.Ignore)]
        public string? idFraccionamiento { get; set; }

        [JsonProperty(PropertyName = "idAlmacenamiento", NullValueHandling = NullValueHandling.Ignore)]
        public string? idAlmacenamiento{ get; set; }

        [JsonProperty(PropertyName = "peso", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Peso { get; set; }



    }
}
