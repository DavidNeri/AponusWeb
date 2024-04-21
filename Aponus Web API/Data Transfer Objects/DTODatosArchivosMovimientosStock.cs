using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTODatosArchivosMovimientosStock
    {
        [JsonProperty(PropertyName = "idMovimiento", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdMovimiento { get; set; }

        [JsonProperty(PropertyName = "nombreArchivo", NullValueHandling = NullValueHandling.Ignore)]
        public string? NombreArchivo { get; set; }

        [JsonProperty(PropertyName = "path", NullValueHandling = NullValueHandling.Ignore)]
        public string? Path { get; set; }

        [JsonProperty(PropertyName = "mimeType", NullValueHandling = NullValueHandling.Ignore)]
        public string? MimeType { get; set; }

        [JsonProperty(PropertyName = "Extension", NullValueHandling = NullValueHandling.Ignore)]
        public string? Extension { get; set; }

        [JsonProperty(PropertyName = "datosArchivo", NullValueHandling = NullValueHandling.Ignore)]
        public byte[]? DatosArchivo { get; set; }
    }
}
