using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace Aponus_Web_API.Models
{
    public class Productos_Componentes
    {
        
        public string IdProducto { get; set; }
        public string IdComponente {get; set;}
        public int? Cantidad { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Longitud { get; set; }


    }
}
