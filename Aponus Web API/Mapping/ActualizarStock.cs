using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class ActualizarStock
    {
        [JsonProperty(PropertyName = "idExistencia", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdExistencia{ get; set; }

        [JsonProperty(PropertyName = "idTipoExistencia", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdTipoExistencia { get; set; }

        [JsonProperty(PropertyName = "origen", NullValueHandling = NullValueHandling.Ignore)]
        public string? Origen { get; set; }

        [JsonProperty(PropertyName = "destino", NullValueHandling = NullValueHandling.Ignore)]
        public string? Destino { get; set; }

        [JsonProperty(PropertyName = "operador", NullValueHandling = NullValueHandling.Ignore)]
        public string? Operador{ get; set; }
      
        [JsonProperty(PropertyName = "valor", NullValueHandling = NullValueHandling.Ignore)]
        public int? Valor{ get;set; }



    }
}
