using System.Text;

namespace Aponus_Web_API.Utilidades
{
    public class UTL_NombresSuministros
    {
        public List<(string, string, string?)> formatearNombres(List<UTL_FormatoSuministros> list)
        {
            List<(string IdSuminitro, string NombreFormateado, string? Unidad)> SuministrosFormateados = new List<(string, string, string?)>();
            foreach (var cp in list)
            {
                string? IdSuministro = cp.IdSuministro ?? "";
                string? descripcion = cp.Descripcion ?? "";
                string? diametro = cp.Diametro != null ? string.Format("{0:####}", cp.Diametro) : null;
                string? longitud = cp.Longitud != null ? string.Format("{0:#,0}", cp.Longitud) : null;
                string? altura = cp.Altura != null ? string.Format("{0:####}", cp.Altura) : null;
                string? espesor = cp.Espesor != null ? string.Format("{0:####}", cp.Espesor) : null;
                string? perfil = cp.Perfil != null ? string.Format("{0:####}", cp.Perfil) : null;
                string? tolerancia = cp.Tolerancia ?? "";
                string? DiametroNominal = cp.DiametroNominal.ToString() ?? "";
                string? Unidad;

                if (cp.UnidadFraccionamiento == null) Unidad = cp.UnidadAlmacenamiento;
                else Unidad = cp.UnidadAlmacenamiento;

                StringBuilder sb = new StringBuilder();
                sb.Append($"{descripcion}");
                if (diametro != "-" && diametro != null || !string.IsNullOrEmpty(diametro?.Trim()))
                    sb.Append($", Diametro:{diametro}mm");
                if (longitud != "-" && longitud != null || !string.IsNullOrEmpty(longitud?.Trim()))
                    sb.Append($", Longitud:{longitud}mm");
                if (altura != "-" && altura != null || !string.IsNullOrEmpty(altura?.Trim()))
                    sb.Append($", Altura:{altura}mm");
                if (espesor != "-" && espesor != null || !string.IsNullOrEmpty(espesor?.Trim()))
                    sb.Append($", Espesor:{espesor}mm");
                if (perfil != "-" && perfil != null || !string.IsNullOrEmpty(perfil?.Trim()))
                    sb.Append($", Perfil:{perfil}");
                if (tolerancia != "-" && !string.IsNullOrEmpty(tolerancia?.Trim()))
                    sb.Append($", Tolerancia:{tolerancia}");
                if (DiametroNominal != "-" && !string.IsNullOrEmpty(DiametroNominal?.Trim()))
                    sb.Append($", DN:{DiametroNominal}mm");

                SuministrosFormateados.Add(new()
                {
                    IdSuminitro = IdSuministro,
                    NombreFormateado = sb.ToString(),
                    Unidad = Unidad
                });
            }

            return SuministrosFormateados;
        }

    }
}





