using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOEstadosCompras
    {
        [JsonProperty(PropertyName = "idEstadoCompra", NullValueHandling = NullValueHandling.Ignore)]

        public int IdEstadoCompra { get; set; }
        
        [JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
        public string Descripcion { get; set; } = string.Empty;

    }
}