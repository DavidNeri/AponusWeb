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
        ColumnasInsumosMensurables? _CIM = null, EspecificacionesComponentes? especificaciones = null
        )
        
        {
            
                if (_CIP != null && especificaciones != null)
                {                    
                 var Columnas = _CIP;
                if (especificaciones.Diametro == null) { _CIP.Diametro = null;};
                if (especificaciones.Altura == null) { _CIP.Altura = null;};
                if (especificaciones.Recibido == null) { _CIP.Recibido = null;};
                if (especificaciones.Pintura == null) { _CIP.Pintura = null;};
                if (especificaciones.Proceso == null) { _CIP.Proceso = null;};
                    return Columnas;
                }
                else if (_CIC != null && especificaciones!=null)
                {
                var Columnas = _CIC;
                if (especificaciones.Espesor == null) { _CIC.Espesor = null; };
                if (especificaciones.Perfil == null) { _CIC.Perfil = null; };
                if (especificaciones.Diametro == null) { _CIC.Diametro = null; };
                if (especificaciones.Altura == null) { _CIC.Altura = null; };
                if (especificaciones.ToleranciaMinina == null) { _CIC.ToleranciaMinina = null; };
                if (especificaciones.ToleranciaMaxima == null) { _CIC.ToleranciaMaxima = null; };
                if (especificaciones.Requerido == null) { _CIC.Requerido = null; };
                if (especificaciones.Recibido == null) { _CIC.Recibido = null; };
                if (especificaciones.Granallado == null) { _CIC.Granallado = null; };
                if (especificaciones.Pintura == null) { _CIC.Pintura = null; };
                if (especificaciones.Proceso == null) { _CIC.Poceso = null; };
                if (especificaciones.Moldeado == null) { _CIC.Moldeado = null; };


                    return Columnas;
                }
                else if (_CIM != null && especificaciones != null)
                {
                    var Columnas = _CIM;
                  if (especificaciones.Largo == null) { _CIM.Largo=null; };
                  if (especificaciones.Ancho== null) { _CIM.Ancho=null; };
                  if (especificaciones.Perfil== null) { _CIM.Perfil=null; };
                  if (especificaciones.Proceso == null) { _CIM.Proceso = null; };
                
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
    

