using Newtonsoft.Json;
namespace Aponus_Web_API.Mapping
{
    public class InsumosProducto : Insumos
    {
        [JsonProperty(PropertyName = "pesables")]
        public List<Insumos>? Pesables { get; set; }

        [JsonProperty(PropertyName = "cuantitativos")]
        public List<Insumos>? Cuantitativos { get; set; }

        [JsonProperty(PropertyName = "mensurables")]
        public List<Insumos>? Mensurables { get; set; }
    }
    

}
