using MessagePack.Formatters;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Aponus_Web_API.Mapping
{
    public class TipoInsumos
    {

        [JsonProperty(PropertyName = "idDescripcion")]
        public int IdDescripcion { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string? Descripcion { get; set; }


        [JsonProperty(PropertyName = "detalleSoportes", NullValueHandling =NullValueHandling.Ignore)]
        public List<Insumos_Soportes>? DetalleSoportes { get; set; } = null;

        [JsonProperty(PropertyName = "detalleCuantitativos", NullValueHandling = NullValueHandling.Ignore)]
        public List<Insumos_Cuantitativos>? DetalleCuantitativos { get; set; }  =null ;

        [JsonProperty(PropertyName = "detalleMensurables", NullValueHandling = NullValueHandling.Ignore)]
        public List<Insumos_Mensurables>? DetalleMensurables { get; set; } = null;


    }
}
