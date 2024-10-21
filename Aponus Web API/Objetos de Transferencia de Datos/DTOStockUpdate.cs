using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class DTOStockUpdate
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

        [JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Cantidad { get; set; }

        [JsonProperty(PropertyName = "idJuntaPerfil", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdJuntaPerfil { get; set; }

        [JsonProperty(PropertyName = "idBulon", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdBulon { get; set; }

        [JsonProperty(PropertyName = "usuario", NullValueHandling = NullValueHandling.Ignore)]
        public string?   Usuario { get; set; }

        [JsonProperty(PropertyName = "archivos", NullValueHandling = NullValueHandling.Ignore)]
        public List<IFormFile>? Archivos { get; set; }

        [JsonProperty(PropertyName = "idProveedorOrigen", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdProveedorOrigen { get; set; }

        [JsonProperty(PropertyName = "idEntidad", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdEntidad{ get; set; }

        [JsonProperty(PropertyName = "Suministros", NullValueHandling = NullValueHandling.Ignore)]
        public List <DTOSuministrosMovimientosStock>? Suministros { get; set; }


    }
}
