using Newtonsoft.Json;
namespace Aponus_Web_API.Mapping
{
    public class InsumosProducto
    {
        [JsonProperty(PropertyName = "pesables")]
        public List<InsumosPesables>? Pesables { get; set; }


    }


}
