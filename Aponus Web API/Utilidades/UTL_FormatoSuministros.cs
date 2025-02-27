﻿namespace Aponus_Web_API.Utilidades
{
    public class UTL_FormatoSuministros
    {
        public string IdSuministro { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public int? DiametroNominal { get; set; }
        public decimal? Diametro { get; set; }
        public string? Tolerancia { get; set; }
        public decimal? Espesor { get; set; }
        public decimal? Longitud { get; set; }
        public decimal? Altura { get; set; }
        public int? Perfil { get; set; }
        public decimal? Valor { get; set; }
        public string? Granallado { get; set; }
        public string? Recibido { get; set; }
        public string? Pintura{ get; set; }
        public string? Proceso{ get; set; }
        public string? Moldeado{ get; set; }
        public string? Pendiente { get; set; }


        public string? UnidadAlmacenamiento { get; set; }
        public string? UnidadFraccionamiento { get; set; }



    }
}
