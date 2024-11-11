using Aponus_Web_API.Modelos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOComprasDetalles
    {    
        public int IdCompra { get; set; }       
        public string IdInsumo { get; set; } = string.Empty;
        public int Cantidad { get; set; }
    }
}