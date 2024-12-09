using Aponus_Web_API.Modelos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOComprasDetalles
    {
        [JsonProperty(PropertyName = "idCompra", NullValueHandling = NullValueHandling.Ignore)]
        public int IdCompra { get; set; }

        [JsonProperty(PropertyName = "idInsumo", NullValueHandling = NullValueHandling.Ignore)]
        public string IdInsumo { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
        public int Cantidad { get; set; }
    }
}