using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class Proveedores
    {
        [Key]
        [Column("ID_PROVEEDOR")]
        public int IdProveedor { get; set; }

        [Column("NOMBRE_CLAVE")]
        public string NombreClave{ get;set; }

        [Column("NOMBRE")]
        public string? Nombre { get; set; }

        [Column("APELLIDO")]
        public string? Apellido { get; set; }

        [Column("PAIS")]
        public string? Pais{ get; set;}

        [Column("CIUDAD")]
        public string? Ciudad{ get; set; }

        [Column("PROVINCIA")]
        public string? Provincia { get; set; }

        [Column("LOCALIDAD")]
        public string? Localidad { get; set;}

        [Column("BARRIO")]
        public string? Barrio { get; set; }

        [Column("CALLE")]
        public string? Calle{ get; set;}

        [Column("ALTURA")]
        public string? Altura{ get; set;}

        [Column("CODIGO_POSTAL")]
        public string? CodigoPostal{ get; set;}

        [Column("TELEFONO_1")]
        public string? Telefono1 { get; set;}

        [Column("TELEFONO_2")]
        public string? Telefono2 { get; set; }

        [Column("TELEFONO_3")]
        public string? Telefono3 { get; set; }

        [Column("EMAIL")]
        public string? Email{ get; set; }

        [Column("ID_FISCAL")]        
        public string IdFiscal { get; set; }

        [Column("FECHA_REGISTRO")]
        public DateTime FechaRegistro{ get; set; }

        [ForeignKey("ID_USUARIO_REGISTRO")]
        public string IdUsuarioRegistro{ get; set; }

        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        public ICollection<Stock_Movimientos> MovimientosOrigen { get; set; }
        public ICollection<Stock_Movimientos> MovimientosDestino { get; set; }

        public Usuarios UsuarioRegistro { get; set; }

    }
}
