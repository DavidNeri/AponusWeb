using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOEstadosVentas
    {
        [JsonProperty(PropertyName = "idEstadoVenta", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdEstadoVenta { get; set; }

        [JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
        public string? Descripcion { get; set; }

        [JsonProperty(PropertyName = "idEstado", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdEstado { get; set; }
    }
}
