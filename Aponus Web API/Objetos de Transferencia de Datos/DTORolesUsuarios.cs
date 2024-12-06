using Aponus_Web_API.Modelos;
using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTORolesUsuarios
    {
        [JsonProperty(PropertyName = "idRol", NullValueHandling = NullValueHandling.Ignore)]
        public int IdRol { get; set; }

        [JsonProperty(PropertyName = "nombreRol", NullValueHandling = NullValueHandling.Ignore)]
        public string NombreRol { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
        public string Descripcion { get; set; } = string.Empty;        
    }
}
