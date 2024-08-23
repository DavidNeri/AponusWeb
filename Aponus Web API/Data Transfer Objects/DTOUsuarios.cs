using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static NuGet.Client.ManagedCodeConventions;

namespace Aponus_Web_API.Mapping
{
    public class DTOUsuarios
    {
        [JsonProperty(PropertyName ="usuario", NullValueHandling =NullValueHandling.Ignore)]
        public string? Usuario { get; set; }

        [JsonProperty(PropertyName = "contraseña", NullValueHandling = NullValueHandling.Ignore)]
        public string? Contraseña{ get; set; }

        [JsonProperty(PropertyName = "idPerfil", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdPerfil { get; set; }
    }
}
