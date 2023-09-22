using Aponus_Web_API.Data_Transfer_objects;
using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOProductoComponente
    {
        [JsonProperty(PropertyName = "idProducto", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdProducto { get; set; }

        [JsonProperty(PropertyName = "idComponente", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdComponente { get; set; }

        [JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
        public string? Descripcion { get; set; }

        [JsonProperty(PropertyName = "perfil", NullValueHandling = NullValueHandling.Ignore)]
        public int? Perfil { get; set; }

        [JsonProperty(PropertyName = "longitud", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Longitud { get; set; }

        [JsonProperty(PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
        public int? DiametroNominal { get; set; }

        [JsonProperty(PropertyName = "altura", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Altura { get; set; }

        [JsonProperty(PropertyName = "largo", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Largo { get; set; }

        [JsonProperty(PropertyName = "diametro", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Diametro { get; set; }

        [JsonProperty(PropertyName = "espesor", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Espesor { get; set; }

        [JsonProperty(PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
        public string? Tolerancia { get; set; }

        [JsonProperty(PropertyName = "stockComponente", NullValueHandling = NullValueHandling.Ignore)]
        public List<NewStocks>? StockComponente { get; set; }

        [JsonProperty(PropertyName = "stockFormateado", NullValueHandling = NullValueHandling.Ignore)]
        public List<DTOStocks>? StockFormateado { get; set; }


    }
}
