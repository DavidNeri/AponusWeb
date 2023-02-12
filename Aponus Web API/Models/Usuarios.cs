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
    }
}