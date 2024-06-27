using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class TiposClientes
    {
        [Key]
        [Column("ID_TIPO")]
        public int IdTipo { get; set; }
        
        [Column("NOMBRE")]
        public string NombreTipo { get; set; }

        [Column("ID_ESTADO")]
        public byte IdEstado { get; set; }

        public virtual ICollection<Clientes_Proveedores> Clientes { get; set; }



    }
}
