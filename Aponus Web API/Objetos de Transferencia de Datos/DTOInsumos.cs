using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOInsumos : DTOStockFormateado
    {
        [JsonProperty(PropertyName = "idInsumo", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdInsumo { get; set; }

        [JsonProperty(PropertyName = "nombre", NullValueHandling = NullValueHandling.Ignore)]
        public string? Nombre { get; set; }


    }
}

