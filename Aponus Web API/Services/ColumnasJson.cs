using Aponus_Web_API.Mapping;
using Aponus_Web_API.Mapping;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.OpenApi.Extensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Aponus_Web_API.Services
{
    public class ColumnasJson
    {
        public ColumnasJson()
        {
        }

        public  object setColumnas(
        ColumnasInsumosPesables? _CIP = null,
        ColumnasInsumosCuantitativos? _CIC = null,
        ColumnasInsumosMensurables? _CIM = null)
        
        {
                

            if (_CIP != null)
            {
                 var Columnas = _CIP;
                  return Columnas;
            }
            else if (_CIC != null)
            {
                 var Columnas = _CIC;

                return Columnas;
            }
            else if (_CIM!=null)
            {
                var Columnas = _CIM;
                return Columnas;
            }
            else
            {
                var Columnas = new { };
                return  Columnas;
            }


          
          
        }
    }

}
    

