using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Negocio
{
    public class BS_Suministros
    {
        private readonly AD_Componentes Componentes;
        private readonly AD_Stocks stocks;

        public BS_Suministros(AD_Componentes componentes, AD_Stocks _stocks)
        {
            Componentes = componentes;
            stocks = _stocks;
        }
        internal JsonResult ObtenerNuevoIdComponente(string ComponentDescription)
        {
            return Componentes.ObtenerNuevoId(ComponentDescription);
        }
        internal IActionResult MapeoDTOtoDB(DTODetallesComponenteProducto componente)
        {
            var (resultado, error) = Componentes.GuardarComponente(new ComponentesDetalle()
            {
                IdInsumo = componente.idComponente ?? "",
                Diametro = componente.Diametro,
                Altura = componente.Altura,
                IdDescripcion = componente.IdDescripcion ?? 0,
                DiametroNominal = componente.DiametroNominal,
                Espesor = componente.Espesor,
                IdAlmacenamiento = componente.idAlmacenamiento,
                IdFraccionamiento = componente.idFraccionamiento,
                Longitud = componente.Longitud,
                Perfil = componente.Perfil,
                Peso = componente.Peso,
                Tolerancia = componente.Tolerancia,
                IdEstado = 1
            });

            if (error != null) return new ContentResult()
            {
                Content = error.InnerException?.Message ?? error.Message,
                ContentType = "text/plan",
                StatusCode = 400
            };

            return new StatusCodeResult((int)resultado!);

        }
        internal IActionResult ListarNombresFormateados()
        {
            List<DTOTipoInsumos>? InsumosAgrupados = new List<DTOTipoInsumos>();
            List<UTL_FormatoSuministros> InsumosDesagrupados = new List<UTL_FormatoSuministros>();

            IActionResult InusmosActionResult = stocks.ListarInsumosProducto();

            if (InusmosActionResult is JsonResult InsumosJsonResult)
            {
                InsumosAgrupados = InsumosJsonResult.Value as List<DTOTipoInsumos>;
            }

            foreach (DTOTipoInsumos insumo in InsumosAgrupados ?? Enumerable.Empty<DTOTipoInsumos>())
            {
                foreach (DTOComponenteFormateado item in insumo.especificacionesFormato ?? Enumerable.Empty<DTOComponenteFormateado>())
                {
                    InsumosDesagrupados.Add(new UTL_FormatoSuministros()
                    {
                        IdSuministro = item.idComponente ?? string.Empty,
                        Descripcion = insumo.Descripcion,
                        Altura = !string.IsNullOrEmpty(item.Altura) && item.Altura != "-" ? Convert.ToDecimal(item.Altura.Replace("mm", "")) : null,
                        Diametro = !string.IsNullOrEmpty(item.Diametro) && item.Diametro != "-" ? Convert.ToDecimal(item.Diametro?.Replace("mm", "")) : null,
                        DiametroNominal = !string.IsNullOrEmpty(item.DiametroNominal) && item.DiametroNominal != "-" ? Convert.ToInt32(item.DiametroNominal.Replace("mm", "")) : null,
                        Espesor = !string.IsNullOrEmpty(item.Espesor) && item.Espesor != "-" ? Convert.ToDecimal(item.Espesor.Replace("mm", "")) : null,
                        Longitud = !string.IsNullOrEmpty(item.Longitud) && item.Longitud != "-" ? Convert.ToDecimal(item.Longitud.Replace("mm", "")) : null,
                        Perfil = !string.IsNullOrEmpty(item.Perfil) && item.Perfil != "-" ? Convert.ToInt32(item.Perfil) : null,
                        Tolerancia = (item.Tolerancia?.Equals('-') ?? false) ? "" : item.Tolerancia,
                        UnidadAlmacenamiento = !string.IsNullOrEmpty(item.idAlmacenamiento) ? item.idAlmacenamiento : null,
                        UnidadFraccionamiento = !string.IsNullOrEmpty(item.idFraccionamiento) ? item.idFraccionamiento : null,
                        Granallado = item.Granallado,
                        Pintura = item.Pintura,
                        Moldeado = item.Moldeado,
                        Pendiente = item.Pendiente,
                        Proceso = item.Proceso,
                        Recibido = item.Recibido,


                    });
                }
            };

            List<(string IdSuministro, string Nombre, string? Unidad)> ListaInusumos = new UTL_NombresSuministros().formatearNombres(InsumosDesagrupados);
            ListaInusumos = ListaInusumos.OrderBy(x => x.Nombre).ToList();

            List<Dictionary<string, string>> InsumosFormateados = ListaInusumos
                .Select(item =>
                {
                    var id = item.IdSuministro;
                    return new Dictionary<string, string>
                    {
                        { "idInsumo", id },
                        { "nombre", item.Nombre },
                        { "granallado", InsumosDesagrupados.First(x=>x.IdSuministro==id).Granallado  ?? "0.00"},
                        { "recibido", InsumosDesagrupados.First(x=>x.IdSuministro==id).Recibido  ?? "0.00"},
                        { "pintura", InsumosDesagrupados.First(x=>x.IdSuministro==id).Pintura  ?? "0.00"},
                        { "proceso", InsumosDesagrupados.First(x=>x.IdSuministro==id).Proceso  ?? "0.00"},
                        { "moldeado", InsumosDesagrupados.First(x=>x.IdSuministro==id).Moldeado  ?? "0.00"},
                        { "pendiente", InsumosDesagrupados.First(x=>x.IdSuministro==id).Pendiente  ?? "0.00"},
                    };

                })
                .ToList();

            return new JsonResult(InsumosFormateados);

        }
    }
}

