using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class DTOUsuarios
    {
        [JsonProperty(PropertyName = "usuario", NullValueHandling = NullValueHandling.Ignore)]
        public string? Usuario { get; set; }

        [JsonProperty(PropertyName = "contraseña", NullValueHandling = NullValueHandling.Ignore)]
        public string? Contraseña { get; set; }

        [JsonProperty(PropertyName = "Correo", NullValueHandling = NullValueHandling.Ignore)]
        public string? Correo { get; set; }

        [JsonProperty(PropertyName = "idPerfil", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdPerfil { get; set; }
    }
}
