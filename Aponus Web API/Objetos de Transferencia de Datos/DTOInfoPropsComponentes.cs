using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOInfoPropsComponentes
    {
        [JsonProperty(PropertyName = "nombre", NullValueHandling = NullValueHandling.Ignore)]
        public string? Nombre { get; set; }

        [JsonProperty(PropertyName = "tipo", NullValueHandling = NullValueHandling.Ignore)]
        public string? Tipo { get; set; }

    }
}
