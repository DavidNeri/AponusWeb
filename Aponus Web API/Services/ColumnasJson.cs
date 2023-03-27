using Aponus_Web_API.Mapping;
using Aponus_Web_API.Mapping;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.OpenApi.Extensions;
using NuGet.Protocol;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Aponus_Web_API.Data_Transfer_objects;

namespace Aponus_Web_API.Services
{
    public class ColumnasJson
    {
        public ColumnasJson()
        {
        }

        public  string[] setColumnas(
        
        ColumnasInsumosPesables? _CIP = null,
        ColumnasInsumosCuantitativos? _CIC = null,
        ColumnasInsumosMensurables? _CIM = null, 
        EspecificacionesComponentes? especificaciones = null
        )
        
        {
            
                if (_CIP != null && especificaciones != null)
                {                    
                 
                if (especificaciones.Diametro == null) { _CIP.Diametro = null;};
                if (especificaciones.Altura == null) { _CIP.Altura = null;};
                if (especificaciones.Recibido == null) { _CIP.Recibido = null;};
                if (especificaciones.Pintura == null) { _CIP.Pintura = null;};
                if (especificaciones.Proceso == null) { _CIP.Proceso = null;};
                
                var Columnas = _CIP;

                string[] _Columnas = new string[] {
                   
                    _CIP.Diametro,
                    _CIP.Altura,                 
                    _CIP.Recibido,
                    _CIP.Pintura,
                    _CIP.Proceso
                };

                List<string> Col = _Columnas.ToList<string>();
                Col.RemoveAll(p => string.IsNullOrEmpty(p));
                _Columnas = Col.ToArray();

                return _Columnas;
                }
                else if (_CIC != null && especificaciones!=null)
                {
                
                if (especificaciones.Espesor == null) { _CIC.Espesor = null; };
                if (especificaciones.Perfil == null) { _CIC.Perfil = null; };
                if (especificaciones.Diametro == null) { _CIC.Diametro = null; };
                if (especificaciones.Altura == null) { _CIC.Altura = null; };
                if (especificaciones.Tolerancia== null) { _CIC.Tolerancia= null; };
                if (especificaciones.Requerido == null) { _CIC.Requerido = null; };
                if (especificaciones.Recibido == null) { _CIC.Recibido = null; };
                if (especificaciones.Granallado == null) { _CIC.Granallado = null; };
                if (especificaciones.Pintura == null) { _CIC.Pintura = null; };
                if (especificaciones.Proceso == null) { _CIC.Proceso = null; };
                if (especificaciones.Moldeado == null) { _CIC.Moldeado = null; };

                var Columnas = _CIC;

                string[] _Columnas = new string[] {
                    _CIC.Espesor,
                    _CIC.Perfil,
                    _CIC.Diametro,
                    _CIC.Altura,
                    _CIC.Tolerancia,
                    _CIC.Requerido,
                    _CIC.Recibido,
                    _CIC.Granallado,
                    _CIC.Pintura,
                    _CIC.Proceso,
                    _CIC.Moldeado
                };

                List<string> Col = _Columnas.ToList<string>();
                Col.RemoveAll(p => string.IsNullOrEmpty(p));
                _Columnas = Col.ToArray();

                return _Columnas;

                }
                else if (_CIM != null && especificaciones != null)
                {
                   
                  if (especificaciones.Largo == null) { _CIM.Largo=null; };
                  if (especificaciones.Ancho== null) { _CIM.Ancho=null; };
                  if (especificaciones.Perfil== null) { _CIM.Perfil=null; };
                  if (especificaciones.Proceso == null) { _CIM.Proceso = null; };

                var Columnas = _CIM;
                string[] _Columnas = new string[] {
                    _CIM.Largo,
                    _CIM.Ancho,
                    _CIM.Perfil,
                    _CIM.Proceso                   
                };

                List<string> Col = _Columnas.ToList<string>();
                Col.RemoveAll(p => string.IsNullOrEmpty(p));
                _Columnas = Col.ToArray();


                return _Columnas;
                }
            else
            {
                string[] _Columnas = new string[0];
                return _Columnas;
            }

           
          
          
        }
    }

}
    

