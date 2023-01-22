using MessagePack.Formatters;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Aponus_Web_API.Mapping
{
    public class TipoInsumos
    {

        [JsonProperty(PropertyName = "idDescripcion")]
        public int? IdDescripcion { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string? Descripcion { get; set; }

        [JsonProperty(PropertyName = "pesables", NullValueHandling =NullValueHandling.Ignore)]
        public List<DetallePesables>? Pesables { get; set; } = null;

        [JsonProperty(PropertyName = "cuantitativos", NullValueHandling = NullValueHandling.Ignore)]
        public List<DetalleCuantitativos>? Cuantitativos { get; set; }  =null ;

        [JsonProperty(PropertyName = "mensurables", NullValueHandling = NullValueHandling.Ignore)]
        public List<DetalleMensurables>? Mensurables { get; set; } = null;

        
    }
}
