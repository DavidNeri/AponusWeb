using Newtonsoft.Json;
namespace Aponus_Web_API.Mapping
{
    public class InsumosProducto
    {
        [JsonProperty(PropertyName = "pesables")]
        public List<InsumosPesables>? Pesables { get; set; }

        [JsonProperty(PropertyName = "cuantitativos")]
        public List<InsumosCuantitativos>? Cuantitativos { get; set; }

        [JsonProperty(PropertyName = "mensurables")]
        public List<InsumosMensurables>? Mensurables { get; set; }
    }
    

}
