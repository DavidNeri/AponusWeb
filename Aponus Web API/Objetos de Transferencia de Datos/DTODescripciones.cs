using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTODescripciones
    {
        [JsonProperty(PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
        public int IdDescripcion { get; set; } = 0;

        [JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
        public string? Descripcion { get;set; }

    }
}
