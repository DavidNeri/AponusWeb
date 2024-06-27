using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOVentasDetalles
    {
        public int? IdVenta { get; set; }
        public string IdProducto { get; set; }
        public int Cantidad { get; set; }
        public DatosProducto? datosProducto { get; set; }
    }
}