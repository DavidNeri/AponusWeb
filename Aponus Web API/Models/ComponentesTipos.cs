using System.ComponentModel.DataAnnotations;

namespace Aponus_Web_API.Models
{
    public class ComponentesTipos
    {
        [Key]
        public int IdDescripcionTipo { get; set; }

        public string? DescripcionTipo { get; set; }

        public ICollection<ComponentesDescripcion> ? componentesDescripcions { get; set; } 

    }
}
