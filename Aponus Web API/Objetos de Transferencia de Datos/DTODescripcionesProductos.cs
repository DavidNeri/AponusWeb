using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTODescripcionesProductos
    {

        [JsonProperty(Order = 1, PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
        public int IdDescripcion { get; set; }

        [JsonProperty(Order = 2, PropertyName = "nombreDescripcion", NullValueHandling = NullValueHandling.Ignore)]
        public string NombreDescripcion { get; set; } = string.Empty;

        [JsonProperty(Order = 3, PropertyName = "productos", NullValueHandling = NullValueHandling.Ignore)]
        public List<DTOStockProductos> Productos { get; set; } = new List<DTOStockProductos>();

        [JsonProperty(Order = 100, PropertyName = "columnas", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Columnas { get; set; }
    }
}