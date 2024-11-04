using Newtonsoft.Json;

namespace Aponus_Web_API.Utilidades
{
    public class UTL_ParametrosCuotas
    {

        [JsonProperty(PropertyName = "cantidadCuotas", NullValueHandling = NullValueHandling.Ignore)]
        public int CantidadCuotas { get; set; }

        [JsonProperty(PropertyName = "montoVenta", NullValueHandling = NullValueHandling.Ignore)]
        public decimal MontoVenta { get; set; }

        [JsonProperty(PropertyName = "interes", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Interes { get; set; } = 0;

    }
}
