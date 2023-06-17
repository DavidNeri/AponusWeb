using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class ActualizacionStock
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "idExistencia", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdExistencia { get; set; }       

        [JsonProperty(PropertyName = "idTipoExistencia", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdTipoExistencia { get; set; }

        [JsonProperty(PropertyName = "origen", NullValueHandling = NullValueHandling.Ignore)]
        public string? Origen { get; set; }

        [JsonProperty(PropertyName = "destino", NullValueHandling = NullValueHandling.Ignore)]
        public string? Destino { get; set; }

        [JsonProperty(PropertyName = "operador", NullValueHandling = NullValueHandling.Ignore)]
        public string? Operador { get; set; }

        [JsonProperty(PropertyName = "valor", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Valor { get; set; }

        [JsonProperty(PropertyName = "idJuntaPerfil", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdJuntaPerfil { get; set; }

        [JsonProperty(PropertyName = "idBulon", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdBulon { get; set; }


    }
}
