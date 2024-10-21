using Newtonsoft.Json;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;

namespace Aponus_Web_API.Utilidades
{
    public class UTL_Productos
    {
        public UTL_Productos()
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

        [JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
        public string? Cantidad { get; private set; } = "Cantidad";

        [JsonProperty(PropertyName = "precioLista", NullValueHandling = NullValueHandling.Ignore)]
        public string? PrecioLista { get; private set; } = "Precio de Lista";

        [JsonProperty(PropertyName = "precioFinal", NullValueHandling = NullValueHandling.Ignore)]
        public string? PrecioFinal { get; private set; } = "Precio Final";

        [JsonProperty(PropertyName = "porcentajeGanancia", NullValueHandling = NullValueHandling.Ignore)]
        public string? PorcentajeGanancia { get; private set; } = "Porcentaje de Ganancia";

        public string[] ObtenerColumnas(List<DTOStockProductos>? StockProductos, List<DTOComponenteFormateado>? Especificacionesformato)
        {
            List<string> columnasList = new();

            if (StockProductos != null)
            {
                if (StockProductos.Any(x => x.DiametroNominal    != null && x.DiametroNominal     != "-"))            columnasList.Add(DiametroNominal      ?? "");
                if (StockProductos.Any(x => x.Tolerancia         != null && x.Tolerancia          != "-"))            columnasList.Add(Tolerancia           ?? "");
                if (StockProductos.Any(x => x.Cantidad           != null && x.Cantidad            != "-"))            columnasList.Add(Cantidad             ?? "");
                if (StockProductos.Any(x => x.PrecioLista        != null && x.PrecioLista         != "-"))            columnasList.Add(PrecioLista          ?? "");
                if (StockProductos.Any(x => x.PrecioFinal        != null && x.PrecioFinal         != "-"))            columnasList.Add(PrecioFinal          ?? "");
                if (StockProductos.Any(x => x.PorcentajeGanancia != null && x.PorcentajeGanancia  != "-"))            columnasList.Add(PorcentajeGanancia   ?? "");

                string[] columnas = columnasList.ToArray();

                return columnas;
            }
            else if (Especificacionesformato!=null)
            {  
                if (Especificacionesformato.Any(x => x.Largo           !=            null && !x.Largo          .Contains('-')))            columnasList.Add(Largo           ?? "");
                if (Especificacionesformato.Any(x => x.Ancho           !=            null && !x.Ancho          .Contains('-')))            columnasList.Add(Ancho           ?? "");
                if (Especificacionesformato.Any(x => x.Longitud        !=            null && !x.Longitud       .Contains('-')))            columnasList.Add(Longitud        ?? "");
                if (Especificacionesformato.Any(x => x.Espesor         !=            null && !x.Espesor        .Contains('-')))            columnasList.Add(Espesor         ?? "");
                if (Especificacionesformato.Any(x => x.Altura          !=            null && !x.Altura         .Contains('-')))            columnasList.Add(Altura          ?? "");
                if (Especificacionesformato.Any(x => x.Diametro        !=            null && !x.Diametro       .Contains('-')))            columnasList.Add(Diametro        ?? "");
                if (Especificacionesformato.Any(x => x.DiametroNominal !=            null && !x.DiametroNominal.Contains('-')))            columnasList.Add(DiametroNominal ?? "");
                if (Especificacionesformato.Any(x => x.Tolerancia      !=            null && !x.Tolerancia     .Contains('-')))            columnasList.Add(Tolerancia      ?? "");
                if (Especificacionesformato.Any(x => x.Peso            !=            null && !x.Peso           .Contains('-')))            columnasList.Add(Peso            ?? "");
                if (Especificacionesformato.Any(x => x.Perfil          !=            null && !x.Perfil         .Contains('-')))            columnasList.Add(Perfil          ?? "");              
                if (Especificacionesformato.Any(x => x.Recibido        !=            null && !x.Recibido       .Contains('-')))            columnasList.Add(Recibido        ?? "");
                if (Especificacionesformato.Any(x => x.Granallado      !=            null && !x.Granallado     .Contains('-')))            columnasList.Add(Granallado      ?? "");
                if (Especificacionesformato.Any(x => x.Pintura         !=            null && !x.Pintura        .Contains('-')))            columnasList.Add(Pintura         ?? "");
                if (Especificacionesformato.Any(x => x.Proceso         !=            null && !x.Proceso        .Contains('-')))            columnasList.Add(Proceso         ?? "");
                if (Especificacionesformato.Any(x => x.Moldeado        !=            null && !x.Moldeado       .Contains('-')))            columnasList.Add(Moldeado        ?? "");
                if (Especificacionesformato.Any(x => x.Requerido       !=            null && !x.Requerido      .Contains('-')))            columnasList.Add(Requerido       ?? "");
                if (Especificacionesformato.Any(x => x.Disponibles     !=            null && !x.Disponibles    .Contains('-')))            columnasList.Add(Disponibles     ?? "");
                if (Especificacionesformato.Any(x => x.Faltantes       !=            null && !x.Faltantes      .Contains('-')))            columnasList.Add(Faltantes       ?? "");
                if (Especificacionesformato.Any(x => x.Total           !=            null && !x.Total          .Contains('-')))            columnasList.Add(Total           ?? "");

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
    

