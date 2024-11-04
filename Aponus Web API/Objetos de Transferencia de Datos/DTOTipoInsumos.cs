using Aponus_Web_API.Utilidades;
using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOTipoInsumos : DTODetallesComponenteProducto
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
        public UTL_Productos? ColumnasProp { get; set; }

    }
}
