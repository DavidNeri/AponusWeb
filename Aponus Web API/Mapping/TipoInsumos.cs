using MessagePack.Formatters;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Aponus_Web_API.Mapping
{
    public class TipoInsumos : EspecificacionesComponentes
    {

        [JsonProperty(PropertyName = "idDescripcion")]
        public int? IdDescripcion { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string? Descripcion { get; set; }

        [JsonProperty(PropertyName = "especificaciones", NullValueHandling =NullValueHandling.Ignore)]
        public List<EspecificacionesComponentes>? Especificaciones { get; set; } = null;


        [JsonProperty(PropertyName = "columnasPesables", NullValueHandling = NullValueHandling.Ignore)]
        public ColumnasInsumosPesables? ColumnasPesables { get; set; } = null;

        [JsonProperty(PropertyName = "columnasCuantitativos", NullValueHandling = NullValueHandling.Ignore)]
        public ColumnasInsumosCuantitativos? ColumnasCuantitativos { get; set; } = null;


        [JsonProperty(PropertyName = "columnasMensurables", NullValueHandling = NullValueHandling.Ignore)]
        public ColumnasInsumosMensurables? ColumnasMensurables { get; set; } = null;

    }
}
