using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOEntidadesTipos
    {
        [JsonProperty(PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdTipo { get; set; }

        [JsonProperty(PropertyName = "nombre", NullValueHandling = NullValueHandling.Ignore)]
        public string? Nombre { get; set; }

    }
}
