using MessagePack.Formatters;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class TipoInsumos : DTOComponente
    {

        [JsonProperty(PropertyName = "idDescripcion")]
        public int? IdDescripcion { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string? Descripcion { get; set; }

        [JsonProperty(PropertyName = "especificaciones", NullValueHandling = NullValueHandling.Ignore)]
        public List<DTOComponente>? Especificaciones { get; set; } = null;

        [JsonProperty(PropertyName = "columnas", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Columnas { get; set; }

    }
}
