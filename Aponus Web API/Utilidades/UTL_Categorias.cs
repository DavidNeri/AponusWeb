using Annytab.Stemmer;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Utilidades
{
    public class UTL_Categorias
    {
        public string? GenerarIdTipoProducto(string tipo)
        {
            try
            {
                string textoNormalizado = Regex.Replace(tipo.Trim(), @"\s+", " ").ToUpper();
                var stemmer = new SpanishStemmer();
                var IdTipo_Palabras = textoNormalizado.Split(' ');
                string resultado = String.Join("_", IdTipo_Palabras.Select(Palabra => stemmer.GetSteamWord(Palabra).ToUpper()));

                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
