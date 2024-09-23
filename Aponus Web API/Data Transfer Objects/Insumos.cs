using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class Insumos : DTOStockFormateado
    {
        [JsonProperty(PropertyName = "idInsumo", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdInsumo { get; set; }

        [JsonProperty(PropertyName = "nombre", NullValueHandling = NullValueHandling.Ignore)]
        public string? Nombre { get; set; }


    }
}

