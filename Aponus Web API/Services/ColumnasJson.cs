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
        public string? Diametro { get; set; } = "Diametro";

        [JsonProperty(PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
        public string? DiametroNominal { get; set; } = "DN";


        [JsonProperty(PropertyName = "altura", NullValueHandling = NullValueHandling.Ignore)]
        public string? Altura { get; set; } = "Altura";

        [JsonProperty(PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
        public string? Tolerancia { get; set; } = "Tolerancia";

        [JsonProperty(PropertyName = "longitud", NullValueHandling = NullValueHandling.Ignore)]
        public string? Longitud { get; set; } = "Longitud";


        [JsonProperty(PropertyName = "recibido", NullValueHandling = NullValueHandling.Ignore)]
        public string? Recibido { get; set; } = "Cant. Recibida";

        [JsonProperty(PropertyName = "pintura", NullValueHandling = NullValueHandling.Ignore)]
        public string? Pintura { get; set; } = "Cant. Pintura";

        [JsonProperty(PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
        public string? Proceso { get; set; } = "Cant. Proceso";    

        [JsonProperty(PropertyName = "requerido", NullValueHandling = NullValueHandling.Ignore)]
        public string? Requerido { get; set; } = "Cant. Requerida";


        [JsonProperty(PropertyName = "granallado", NullValueHandling = NullValueHandling.Ignore)]
        public string? Granallado { get; set; } = "Cant. Granallado";
      

        [JsonProperty(PropertyName = "moldeado", NullValueHandling = NullValueHandling.Ignore)]
        public string? Moldeado { get; set; } = "Cant. Moldeada";
    

       
  

       

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


        public string[] NewSetColumnas(List<DTOComponente> Especificaciones)
        {
            List<string> columnasList = new List<string>();

            if (Especificaciones.All(x => x.Largo != null)) columnasList.Add(Largo);
            if (Especificaciones.All(x => x.Ancho != null)) columnasList.Add(Ancho);
            if (Especificaciones.All(x => x.Espesor != null)) columnasList.Add(Espesor);
            if (Especificaciones.All(x => x.Perfil != null)) columnasList.Add(Perfil);
            if (Especificaciones.All(x => x.Diametro != null)) columnasList.Add(Diametro);
            if (Especificaciones.All(x => x.DiametroNominal != null)) columnasList.Add(DiametroNominal);
            if (Especificaciones.All(x => x.Altura != null)) columnasList.Add(Altura);
            if (Especificaciones.All(x => x.Tolerancia != null)) columnasList.Add(Tolerancia);
            if (Especificaciones.All(x => x.Longitud != null)) columnasList.Add(Longitud);
            if (Especificaciones.All(x => x.Recibido != null)) columnasList.Add(Recibido);
            if (Especificaciones.All(x => x.Pintura != null)) columnasList.Add(Pintura);
            if (Especificaciones.All(x => x.Proceso != null)) columnasList.Add(Proceso);
            if (Especificaciones.All(x => x.Requerido != null)) columnasList.Add(Requerido);
            if (Especificaciones.All(x => x.Granallado != null)) columnasList.Add(Granallado);
            if (Especificaciones.All(x => x.Moldeado != null)) columnasList.Add(Moldeado);


            string[] columnas = columnasList.ToArray();

            return columnas;
        }

    }

}
    

