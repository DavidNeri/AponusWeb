﻿using System.Text.RegularExpressions;
using Annytab.Stemmer;
using Aponus_Web_API.Models;

namespace Aponus_Web_API.Support
{
    public class CategoriesServices
    {
        private readonly AponusContext AponusDBContext;
        public CategoriesServices() { AponusDBContext = new AponusContext(); }

        

        public string? GenerarIdTipo(string tipo)
        {
            string IdTipo;
            try
            {
               /* string[] Palabras = new string[60] {"a", "ante", "bajo", "cabe", "con", "contra", "de","desde", "en", "entre", "hasta", "hacia", "para","por", "según", "sin", "so", "sobre", "tras", "/",
                    "p/", "P/", "con", "el", "la", "los", "las", "un","una", "unos", "unas", "y", "o", "pero", "como","si", "no", "más", "menos", "mucho", "poco", "bien","mal", "ser", "estar", "tener", "haber", "hacer",
                    "decir", "ir", "venir", "llevar", "dar", "ver","saber", "poder", "querer", "deber", "amar","\\"};*/


                string textoNormalizado = Regex.Replace(tipo.Trim(), @"\s+", " ").ToUpper();

                var stemmer = new SpanishStemmer();

                var IdTipo_Palabras = textoNormalizado.Split(' ');

                string resultado = String.Join("_",IdTipo_Palabras.Select(Palabra=>stemmer.GetSteamWord(Palabra).ToUpper()));

                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
           

        }

    

    }
}