using Aponus_Web_API.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOEntidadesTipos
    {
        [JsonProperty(PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdTipo { get; set; }

        [JsonProperty(PropertyName = "nombre", NullValueHandling = NullValueHandling.Ignore)]
        public string? Nombre{ get; set; }
        
    }
}
