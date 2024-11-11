using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOEstadosCompras
    {
        public int IdEstadoCompra { get; set; }
        public string Descripcion { get; set; } = string.Empty;

    }
}