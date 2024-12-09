using Aponus_Web_API.Modelos;
using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOEntidadesPago
    {
        public int IdEntidad { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Emisor { get; set; } = string.Empty;

    }
}
