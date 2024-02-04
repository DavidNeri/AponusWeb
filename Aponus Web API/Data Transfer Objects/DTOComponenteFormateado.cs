using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Services;
using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOComponenteFormateado : DTOStocks
    {
        [JsonProperty(Order = 1, PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdDescripcion { get; set; }

        [JsonProperty(Order = 2, PropertyName = "IdComponente", NullValueHandling = NullValueHandling.Ignore)]
        public string? idComponente { get; set; }

        [JsonProperty(Order = 3, PropertyName = "largo", NullValueHandling = NullValueHandling.Ignore)]
        public string? Largo { get; set; }

        [JsonProperty(Order = 4, PropertyName = "ancho", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ancho { get; set; }

        [JsonProperty(Order = 5, PropertyName = "longitud", NullValueHandling = NullValueHandling.Ignore)]
        public string? Longitud { get; set; }

        [JsonProperty(Order = 6, PropertyName = "espesor", NullValueHandling = NullValueHandling.Ignore)]
        public string? Espesor { get; set; }

        [JsonProperty(Order = 7, PropertyName = "Altura", NullValueHandling = NullValueHandling.Ignore)]
        public string? Altura { get; set; }

        [JsonProperty(Order = 8, PropertyName = "diametro", NullValueHandling = NullValueHandling.Ignore)]
        public string? Diametro { get; set; }

        [JsonProperty(Order = 9, PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
        public int? DiametroNominal { get; set; }

        [JsonProperty(Order = 10, PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
        public string? Tolerancia { get; set; }

        [JsonProperty(Order = 11, PropertyName = "peso", NullValueHandling = NullValueHandling.Ignore)]
        public string? Peso { get; set; }

        [JsonProperty(Order = 12, PropertyName = "perfil", NullValueHandling = NullValueHandling.Ignore)]
        public int? Perfil { get; set; }

        [JsonProperty(Order = 13, PropertyName = "idFraccionamiento", NullValueHandling = NullValueHandling.Ignore)]
        public string? idFraccionamiento { get; set; }

        [JsonProperty(Order = 14, PropertyName = "idAlmacenamiento", NullValueHandling = NullValueHandling.Ignore)]
        public string? idAlmacenamiento { get; set; }

       

    }
}
