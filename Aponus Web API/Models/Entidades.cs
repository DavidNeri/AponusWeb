using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class Entidades
    {
        [Key]
        [Column("ID_ENTIDAD")]
        public int IdEntidad { get; set; }

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

        [ForeignKey("ID_CATEGORIA")]
        public int IdCategoria{ get; set; }

        [ForeignKey("ID_TIPO")]
        public int IdTipo{ get; set; }

        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        public virtual ICollection<Stock_Movimientos> MovimientosOrigen { get; set; } = new HashSet<Stock_Movimientos>();
        public virtual ICollection<Stock_Movimientos> MovimientosDestino { get; set; } = new HashSet<Stock_Movimientos>();       
        public virtual ICollection<Compras> compras { get; set; } = new HashSet<Compras>(); 
        public virtual ICollection<Ventas> ventas{ get; set; } = new HashSet<Ventas>();
        public virtual Usuarios UsuarioRegistro { get; set; }
        public virtual EntidadesCategorias CategoriaEntidad { get; set; }
        public virtual EntidadesTipos TipoEntidad { get; set; }

    }
}
