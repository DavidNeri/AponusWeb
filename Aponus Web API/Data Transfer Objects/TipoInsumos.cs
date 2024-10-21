using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Support;
using MessagePack.Formatters;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class TipoInsumos : DTODetallesComponenteProducto
    {

        [JsonProperty(PropertyName = "idDescripcion")]
        public int? IdDescripcion { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string? Descripcion { get; set; }

        [JsonProperty(PropertyName = "especificaciones", NullValueHandling = NullValueHandling.Ignore)]
        public List<DTODetallesComponenteProducto>? Especificaciones { get; set; } = null;


        [JsonProperty(PropertyName = "especificacionesFormato", NullValueHandling = NullValueHandling.Ignore)]
        public List<DTOComponenteFormateado>? especificacionesFormato { get; set; } = null;

        [JsonProperty(PropertyName = "columnas", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Columnas { get; set; }

        [JsonProperty(PropertyName = "columnasProp", NullValueHandling = NullValueHandling.Ignore)]
        public ColumnasJson? ColumnasProp { get; set; }

    }
}
