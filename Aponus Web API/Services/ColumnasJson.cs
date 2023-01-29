using Aponus_Web_API.Mapping;
using Aponus_Web_API.Mapping;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Reflection;

namespace Aponus_Web_API.Services
{
    public class ColumnasJson
    {
        public ColumnasJson()
        {
        }


        public ColumnasInsumosPesables setColumnasPesbles(
            ColumnasInsumosPesables _ColumnasInsumosPesables)
        {
            _ColumnasInsumosPesables.Diametro = "Diámetro (mm)";
            _ColumnasInsumosPesables.Altura = "Altura (mm)";
            return _ColumnasInsumosPesables;
        }
    }

}
    

