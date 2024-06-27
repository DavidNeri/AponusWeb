using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class Usuarios
    {
        public string Usuario { get; set; }
        public  string Contraseña { get; set; }
        public string correo { get; set; }
        public int IdPerfil { get; set; }

        public virtual ICollection<Clientes_Proveedores> IdUsuarioRegistroNavigation { get; set; } = new HashSet<Clientes_Proveedores>();
        public virtual ICollection<Compras> Compras { get; set; } = new HashSet<Compras>();
        public virtual ICollection<Ventas> Ventas { get; set; } = new HashSet<Ventas>();
    }
}