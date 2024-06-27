using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class CategoriasClientes
    {
        [Key]
        [Column("ID_CATEGORIA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }

        [Column("NOMBRE")]
        public string NombreCategoria { get; set;}

        [Column("ID_ESTADO")]
        public byte IdEstado {  get; set; }

        public virtual ICollection<Clientes_Proveedores> Clientes { get; set; }



    }
}
