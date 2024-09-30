using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOMovimientosStock
    {
        [JsonProperty(PropertyName = "idMovimiento", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdMovimiento { get; set; }

        [JsonProperty(PropertyName = "usuarioCreacion", NullValueHandling = NullValueHandling.Ignore)]
        public string? UsuarioCreacion { get; set; }

        [JsonProperty(PropertyName = "usuarioModificacion", NullValueHandling = NullValueHandling.Ignore)]
        public string? UsuarioModificacion { get; set; }

        [JsonProperty(PropertyName = "fechaHoraCreado", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FechaHoraCreado { get; set; }

        [JsonProperty(PropertyName = "fechaHoraUltimaModificacion", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FechaHoraUltimaModificacion{ get; set; }

        [JsonProperty(PropertyName = "idProveedorOrigen", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdProveedorOrigen { get; set; }

        [JsonProperty(PropertyName = "idProveedorDestino", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdProveedorDestino { get; set; }

        [JsonProperty(PropertyName = "origen", NullValueHandling = NullValueHandling.Ignore)]
        public string? Origen { get; set; }

        [JsonProperty(PropertyName = "destino", NullValueHandling = NullValueHandling.Ignore)]
        public string? Destino { get; set; }

        [JsonProperty(PropertyName = "tipo", NullValueHandling = NullValueHandling.Ignore)]
        public string? Tipo{ get; set; }

        [JsonProperty(PropertyName = "proveedorDestino", NullValueHandling = NullValueHandling.Ignore)]
        public DTOEntidades? Proveedor { get; set; }

        [JsonProperty(PropertyName = "proveedorOrigen", NullValueHandling = NullValueHandling.Ignore)]
        public DTOEntidades? ProveedorOrigen { get; set; }

        [JsonProperty(PropertyName = "suministros", NullValueHandling = NullValueHandling.Ignore)]
        public List<DTOSuministrosMovimientosStock>? Suministros { get; set; }

        [JsonProperty(PropertyName = "infoArchivos", NullValueHandling = NullValueHandling.Ignore)]
        public List<DTODatosArchivosMovimientosStock>? DatosArchivos { get; set; } = new List<DTODatosArchivosMovimientosStock>();

        [JsonProperty(PropertyName = "archivos", NullValueHandling = NullValueHandling.Ignore)]
        public List<IFormFile>? Archivos { get; set; }

        [JsonProperty(PropertyName = "idEstado", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdEstado { get; set; }

        [JsonProperty(PropertyName = "estado", NullValueHandling = NullValueHandling.Ignore)]
        public string? Estado { get; set; }

    }
}
