using System.ComponentModel.DataAnnotations;

namespace Aponus_Web_API.Models 
{
    public class ComponentesDetalle
    {

        [Key]
        public string IdInsumo { get; set; }   
        public int IdDescripcion { get; set; }
        public decimal? Diametro { get; set; }
        public int? DiametroNominal { get; set; }
        public decimal? Espesor { get; set; }
        public decimal? Longitud { get; set; }
        public decimal? Altura { get; set; }
        public int? Perfil { get; set; }
        public string? Tolerancia { get; set; }
        public decimal? Peso { get; set; }
        public string? Sigla { get; set; }




    }
}
