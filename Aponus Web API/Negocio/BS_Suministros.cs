using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        internal IActionResult GuardarInsumoProducto(DTODetallesComponenteProducto componente)
        {
            try
            {

                if (componente.idComponente != null && componente.IdDescripcion != null)
                {
                    Componentes.GuardarComponente(new ComponentesDetalle()
                    {
                        IdInsumo = componente.idComponente,
                        Diametro = componente.Diametro,
                        Altura = componente.Altura,
                        IdDescripcion = (int)componente.IdDescripcion,
                        DiametroNominal = componente.DiametroNominal,
                        Espesor = componente.Espesor,
                        IdAlmacenamiento = componente.idAlmacenamiento,
                        IdFraccionamiento = componente.idFraccionamiento,
                        Longitud = componente.Longitud,
                        Perfil = componente.Perfil,
                        Peso = componente.Peso,
                        Tolerancia = componente.Tolerancia,
                        IdEstado = 1,
                        IdEstadoNavigation = new EstadosComponentesDetalles { IdEstado = 1 }


                    });
                    return new StatusCodeResult(200);
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = "El Codigo de Insumo y la Descripcion no pueden ser nulos",
                        ContentType = "text/plan",
                        StatusCode = 400

                    };
                }
            }
            catch (DbUpdateException ex)
            {
                string Mensaje;
                if (ex.InnerException?.Message != null)
                    Mensaje = ex.InnerException.Message;
                else Mensaje = ex.Message;


                return new ContentResult()
                {
                    Content = Mensaje,
                    ContentType = "text/plan",
                    StatusCode = 500,
                };

            }

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
                        Altura = !string.IsNullOrEmpty(item.Altura) && !item.Altura.Contains('-') ? Convert.ToDecimal(item.Altura.Replace("mm", "")) : null,
                        Diametro = !string.IsNullOrEmpty(item.Altura) && !item.Altura.Contains('-') ? Convert.ToDecimal(item.Altura.Replace("mm", "")) : null,
                        DiametroNominal = !string.IsNullOrEmpty(item.DiametroNominal) && !item.DiametroNominal.Contains('-') ? Convert.ToInt32(item.DiametroNominal.Replace("mm", "")) : null,
                        Espesor = !string.IsNullOrEmpty(item.Espesor) && !item.Espesor.Contains('-') ? Convert.ToDecimal(item.Espesor.Replace("mm", "")) : null,
                        Longitud = !string.IsNullOrEmpty(item.Longitud) && !item.Longitud.Contains('-') ? Convert.ToDecimal(item.Longitud.Replace("mm", "")) : null,
                        Perfil = !string.IsNullOrEmpty(item.Perfil) && !item.Perfil.Contains('-') ? Convert.ToInt32(item.Perfil) : null,
                        Tolerancia = (item.Tolerancia?.Equals('-') ?? false) ? "" : item.Tolerancia,
                        UnidadAlmacenamiento = !string.IsNullOrEmpty(item.idAlmacenamiento) ? item.idAlmacenamiento : null,
                        UnidadFraccionamiento = !string.IsNullOrEmpty(item.idFraccionamiento) ? item.idFraccionamiento : null,
                    });
                }
            };

            List<(string IdSuministro, string Nombre, string? Unidad)> ListaInusumos = new UTL_NombresSuministros().formatearNombres(InsumosDesagrupados);
            ListaInusumos = ListaInusumos.OrderBy(x => x.Nombre).ToList();

            List<Dictionary<string, string>> InsumosFormateados = ListaInusumos
                .Select(item => new Dictionary<string, string>()
                {
                    { "idInsumo", item.IdSuministro},
                    { "nombre", item.Nombre}
                })
                .ToList();

            return new JsonResult(InsumosFormateados);

        }
    }
}
