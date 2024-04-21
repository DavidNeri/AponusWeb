using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Acceso_a_Datos.Insumos;
using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Aponus_Web_API.Business
{
    public class BS_Supplies
    {

        internal async Task<JsonResult> ObtenerNuevoIdComponente(string ComponentDescription)
        {
            return await new OperacionesComponentes().ObtenerNuevoId(ComponentDescription);
        }
        internal IActionResult GuardarInsumoProducto(DTOComponente componente)
        {
            try
            {

                if (componente.idComponente != null && componente.IdDescripcion != null)
                {
                    new OperacionesComponentes().GuardarComponente(new ComponentesDetalle()
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
                if (ex.InnerException.Message != null)
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

        internal int? ObtenerTablaInsumo(Insumos Insumo)
        {

            try
            {
                return new TablaInsumo().ObtenerTabla(Insumo);
            }
            catch (Exception)
            {

                return null;
            }
            


        }

        internal IActionResult ListarNombresFormateados()
        {
            List<TipoInsumos>? InsumosAgrupados = new List<TipoInsumos>();
            List<FormatoSuministros> InsumosDesagrupados = new List<FormatoSuministros>();

            IActionResult InusmosActionResult = new Stocks().Listar();

            if (InusmosActionResult is JsonResult InsumosJsonResult)
            {
                InsumosAgrupados = InsumosJsonResult.Value as List<TipoInsumos>;
            }


            foreach (TipoInsumos insumo in InsumosAgrupados)
            {

                foreach (DTOComponenteFormateado item in insumo.especificacionesFormato)
                {
                    InsumosDesagrupados.Add(new FormatoSuministros()
                    {
                        IdSuministro = item.idComponente,
                        Descripcion = insumo.Descripcion,
                        Altura = !string.IsNullOrEmpty(item.Altura) && !item.Altura.Contains("-") ? Convert.ToDecimal(item.Altura.Replace("mm","")) : null,
                        Diametro = !string.IsNullOrEmpty(item.Altura) && !item.Altura.Contains("-") ? Convert.ToDecimal(item.Altura.Replace("mm", "")) : null,
                        DiametroNominal = !string.IsNullOrEmpty(item.DiametroNominal) && !item.DiametroNominal.Contains("-") ? Convert.ToInt32(item.DiametroNominal.Replace("mm", "")) : null,
                        Espesor = !string.IsNullOrEmpty(item.Espesor) && !item.Espesor.Contains("-") ? Convert.ToDecimal(item.Espesor.Replace("mm", "")) : null,
                        Longitud = !string.IsNullOrEmpty(item.Longitud) && !item.Longitud.Contains("-") ? Convert.ToDecimal(item.Longitud.Replace("mm", "")) : null,
                        Perfil = !string.IsNullOrEmpty(item.Perfil) && !item.Perfil.Contains("-") ? Convert.ToInt32(item.Perfil) : null,
                        Tolerancia = item.Tolerancia.Equals("-") ? "" : item.Tolerancia,
                        UnidadAlmacenamiento= !string.IsNullOrEmpty(item.idAlmacenamiento) ? item.idAlmacenamiento : null,
                        UnidadFraccionamiento = !string.IsNullOrEmpty(item.idFraccionamiento) ? item.idFraccionamiento : null,
                    });
                }
            };

            List<(string IdSuministro, string Nombre, string? Unidad)> ListaInusumos = new Nombres().formatearNombres(InsumosDesagrupados);
            ListaInusumos = ListaInusumos.OrderBy(x=>x.Nombre).ToList();    

            List<Dictionary<string, string>> InsumosFormateados = ListaInusumos
                .Select(item=> new Dictionary<string, string>()
                {
                    { "idInsumo", item.IdSuministro},
                    { "nombre", item.Nombre}
                })
                .ToList();

            return new JsonResult(InsumosFormateados); 

        }
    }
}
