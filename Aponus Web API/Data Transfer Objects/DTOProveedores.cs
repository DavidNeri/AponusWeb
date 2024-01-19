using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOProveedores
    {
        public int IdProveedor { get; set; }
        public string? NombreProveedor { get; set; }
        public string? Pais { get; set; }
        public string? Localidad { get; set; }
        public string? Calle { get; set; }
        public string? Altura { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Telefono1 { get; set; }
        public string? Telefono2 { get; set; }
        public string? Telefono3 { get; set; }
        public string? Email { get; set; }
        public string? IdFiscal { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool Estado { get; set; }
    }
}
