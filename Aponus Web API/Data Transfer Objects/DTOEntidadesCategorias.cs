using Aponus_Web_API.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOEntidadesCategorias
    {
        [JsonProperty(PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdTipo{ get; set; }

        [JsonProperty(PropertyName = "idCategoria", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdCategoria { get; set; }

        [JsonProperty(PropertyName = "nombreCategoria", NullValueHandling = NullValueHandling.Ignore)]
        public string? NombreCategoria{ get; set; }

    }
}
