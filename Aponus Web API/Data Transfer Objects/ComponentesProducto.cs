using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class ComponentesProducto
    {
        public string? IdComponente { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Largo { get; set; }

    }
}
