using Aponus_Web_API.Mapping;
using Aponus_Web_API.Mapping;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.OpenApi.Extensions;
using NuGet.Protocol;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Aponus_Web_API.Data_Transfer_objects;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Aponus_Web_API.Data_Transfer_Objects;
using AponusWebAPI.Migrations;

namespace Aponus_Web_API.Services
{
    public class ColumnasJson
    {
        public ColumnasJson()
        {
        }

        [JsonProperty(PropertyName = "largo", NullValueHandling = NullValueHandling.Ignore)]
        public string? Largo { get; set; } = "Largo";

        [JsonProperty(PropertyName = "ancho", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ancho { get; set; } = "Ancho";

        [JsonProperty(PropertyName = "espesor", NullValueHandling = NullValueHandling.Ignore)]
        public string? Espesor { get; set; } = "Espesor";

        [JsonProperty(PropertyName = "perfil", NullValueHandling = NullValueHandling.Ignore)]
        public string? Perfil { get; set; } = "Perfil";

        [JsonProperty(PropertyName = "diametro", NullValueHandling = NullValueHandling.Ignore)]
        public string? Diametro { get; set; } = "Diámetro";

        [JsonProperty(PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
        public string? DiametroNominal { get; set; } = "DN";

        [JsonProperty(PropertyName = "peso", NullValueHandling = NullValueHandling.Ignore)]
        public string? Peso { get; set; } = "Peso";

        [JsonProperty(PropertyName = "altura", NullValueHandling = NullValueHandling.Ignore)]
        public string? Altura { get; set; } = "Altura";

        [JsonProperty(PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
        public string? Tolerancia { get; set; } = "Tolerancia";

        [JsonProperty(PropertyName = "longitud", NullValueHandling = NullValueHandling.Ignore)]
        public string? Longitud { get; set; } = "Longitud";

        [JsonProperty(PropertyName = "recibido", NullValueHandling = NullValueHandling.Ignore)]
        public string? Recibido { get; set; } = "Recibidos";

        [JsonProperty(PropertyName = "pintura", NullValueHandling = NullValueHandling.Ignore)]
        public string? Pintura { get; set; } = "En Pintura";

        [JsonProperty(PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
        public string? Proceso { get; set; } = "En Proceso";

        [JsonProperty(PropertyName = "granallado", NullValueHandling = NullValueHandling.Ignore)]
        public string? Granallado { get; set; } = "En Granallado";

        [JsonProperty(PropertyName = "moldeado", NullValueHandling = NullValueHandling.Ignore)]
        public string? Moldeado { get; set; } = "Moldeados";

        [JsonProperty(PropertyName = "requerido", NullValueHandling = NullValueHandling.Ignore)]
        public string? Requerido { get; set; } = "Requeridos";

        [JsonProperty(PropertyName = "disponibles", NullValueHandling = NullValueHandling.Ignore)]
        public string? Disponibles { get; set; } = "Disponibles";

        [JsonProperty(PropertyName = "faltantes", NullValueHandling = NullValueHandling.Ignore)]
        public string? Faltantes { get; set; } = "Faltantes";

        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public string? Total { get; set; } = "Total";


       

        public  string[] setColumnas(
        
        ColumnasInsumosPesables? _CIP = null,
        ColumnasInsumosCuantitativos? _CIC = null,
        ColumnasInsumosMensurables? _CIM = null, 
        DTOComponente? especificaciones = null
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


        public string[] NewSetColumnas(List<DTOComponente> Especificaciones = null, List<DTOComponenteFormateado> Especificacionesformato = null)
        {
            List<string> columnasList = new List<string>();

            if (Especificaciones!=null)
            {
                if (Especificacionesformato.Any(x => x.Largo != null)) columnasList.Add(Largo);
                if (Especificacionesformato.Any(x => x.Ancho != null)) columnasList.Add(Ancho);
                if (Especificacionesformato.Any(x => x.Longitud != null)) columnasList.Add(Longitud);
                if (Especificacionesformato.Any(x => x.Espesor != null)) columnasList.Add(Espesor);
                if (Especificacionesformato.Any(x => x.Altura != null)) columnasList.Add(Altura);
                if (Especificacionesformato.Any(x => x.Diametro != null)) columnasList.Add(Diametro);
                if (Especificacionesformato.Any(x => x.DiametroNominal != null)) columnasList.Add(DiametroNominal);
                if (Especificacionesformato.Any(x => x.Tolerancia != null)) columnasList.Add(Tolerancia);
                if (Especificacionesformato.Any(x => x.Peso != null)) columnasList.Add(Peso);
                if (Especificacionesformato.Any(x => x.Perfil != null)) columnasList.Add(Perfil);
                if (Especificacionesformato.Any(x => x.Recibido != null)) columnasList.Add(Recibido);
                if (Especificacionesformato.Any(x => x.Granallado != null)) columnasList.Add(Granallado);
                if (Especificacionesformato.Any(x => x.Pintura != null)) columnasList.Add(Pintura);
                if (Especificacionesformato.Any(x => x.Proceso != null)) columnasList.Add(Proceso);
                if (Especificacionesformato.Any(x => x.Moldeado != null)) columnasList.Add(Moldeado);
                if (Especificacionesformato.Any(x => x.Requerido != null)) columnasList.Add(Requerido);
                if (Especificacionesformato.Any(x => x.Disponibles != null)) columnasList.Add(Disponibles);
                if (Especificacionesformato.Any(x => x.Faltantes != null)) columnasList.Add(Faltantes);
                if (Especificacionesformato.Any(x => x.Total != null)) columnasList.Add(Total);

                string[] columnas = columnasList.ToArray();
                return columnas;
            }
            else if (Especificacionesformato!=null)
            {  
                if (Especificacionesformato.Any(x => x.Largo != null)) columnasList.Add(Largo);
                if (Especificacionesformato.Any(x => x.Ancho != null)) columnasList.Add(Ancho);
                if (Especificacionesformato.Any(x => x.Longitud != null)) columnasList.Add(Longitud);
                if (Especificacionesformato.Any(x => x.Espesor != null)) columnasList.Add(Espesor);
                if (Especificacionesformato.Any(x => x.Altura != null)) columnasList.Add(Altura);
                if (Especificacionesformato.Any(x => x.Diametro != null)) columnasList.Add(Diametro);
                if (Especificacionesformato.Any(x => x.DiametroNominal != null)) columnasList.Add(DiametroNominal);
                if (Especificacionesformato.Any(x => x.Tolerancia != null)) columnasList.Add(Tolerancia);
                if (Especificacionesformato.Any(x => x.Peso != null)) columnasList.Add(Peso);
                if (Especificacionesformato.Any(x => x.Perfil != null)) columnasList.Add(Perfil);              
                if (Especificacionesformato.Any(x => x.Recibido != null)) columnasList.Add(Recibido);
                if (Especificacionesformato.Any(x => x.Granallado != null)) columnasList.Add(Granallado);
                if (Especificacionesformato.Any(x => x.Pintura != null)) columnasList.Add(Pintura);
                if (Especificacionesformato.Any(x => x.Proceso != null)) columnasList.Add(Proceso);
                if (Especificacionesformato.Any(x => x.Moldeado != null)) columnasList.Add(Moldeado);
                if (Especificacionesformato.Any(x => x.Requerido != null)) columnasList.Add(Requerido);
                if (Especificacionesformato.Any(x => x.Disponibles != null)) columnasList.Add(Disponibles);
                if (Especificacionesformato.Any(x => x.Faltantes != null)) columnasList.Add(Faltantes);
                if (Especificacionesformato.Any(x => x.Total != null)) columnasList.Add(Total);

                string[] columnas = columnasList.ToArray();
                return columnas;

            }
            else
            {
                return columnasList.ToArray();
            }            

            
        }


       

    }

}
    

