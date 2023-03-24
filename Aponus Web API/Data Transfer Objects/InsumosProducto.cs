using Newtonsoft.Json;
namespace Aponus_Web_API.Data_Transfer_objects
{
    public class InsumosProducto : Insumos
    {
        [JsonProperty(PropertyName = "pesables", NullValueHandling = NullValueHandling.Ignore)]
        public List<Insumos>? Pesables { get; set; }

        [JsonProperty(PropertyName = "cuantitativos", NullValueHandling = NullValueHandling.Ignore)]
        public List<Insumos>? Cuantitativos { get; set; }

        [JsonProperty(PropertyName = "mensurables", NullValueHandling = NullValueHandling.Ignore)]
        public List<Insumos>? Mensurables { get; set; }
    }


}
