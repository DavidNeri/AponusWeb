using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class ComponentesProducto
    {
        public string? IdComponente { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Largo { get; set; }

    }
}
