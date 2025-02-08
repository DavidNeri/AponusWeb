using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades.ReportResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;

namespace Aponus_Web_API.Negocio
{
    public class BS_Componentes
    {
        private readonly AD_Componentes _componentesProductos;

        public BS_Componentes(AD_Componentes componentesProductos)
        {
            _componentesProductos = componentesProductos;
        }
        internal JsonResult? DeterminarProp(DTODetallesComponenteProducto? Especificaciones)
        {
            return _componentesProductos.ListarProp(
                CategorizarPropiedades(Especificaciones).Item1,
                CategorizarPropiedades(Especificaciones).Item2);

        }
        internal IActionResult GuardarComponentesProducto(List<DTOComponentesProducto> ComponentesProd)
        {
            bool ChkIdProd = ComponentesProd.All(x => x.IdProducto != null);

            if (ChkIdProd)
            {
                foreach (DTOComponentesProducto Componente in ComponentesProd)
                {
                    try
                    {
                        _componentesProductos.GuardarComponenteProd(new Productos_Componentes
                        {
                            IdProducto = Componente?.IdProducto ?? "",
                            IdComponente = Componente?.IdComponente ?? "",
                            Cantidad = Componente?.Cantidad,
                            Longitud = Componente?.Largo,
                            Peso = Componente?.Peso,
                        });

                    }
                    catch (DbUpdateException)
                    {
                        return new ContentResult { Content = "Error al actualizar la Base de Datos", ContentType = "text/plan", StatusCode = 400 };
                    }                    
                    catch (InvalidOperationException)
                    {
                        return new ContentResult { Content = "Operacion Invalida", ContentType = "text/plan", StatusCode = 400 };
                    }
                    catch (Exception)
                    {
                        return new ContentResult { Content = "Objeto Inexistente", ContentType = "text/plan", StatusCode = 400 };
                    }


                }
            }
            else
            {
                return new ContentResult { Content = "Faltan Datos", ContentType = "text/plan", StatusCode = 400 };
            }

            return new StatusCodeResult(200);

        }
        internal IActionResult MapeoComponentesDetalleDTO(int? IdDescripcion, string? idInsumo)
        {
            var (Listado, Ex) = _componentesProductos.ListarDetalleComponentes(IdDescripcion, idInsumo);

            if (Ex != null) return new ContentResult()
            {
                Content = Ex.InnerException?.Message ?? Ex.Message,
                ContentType = "application/json",
                StatusCode = 500
            };
            List<DTODetallesComponenteProducto> ComponentesDetalle = new();

            Listado!.ForEach(x => ComponentesDetalle.Add(new DTODetallesComponenteProducto()
            {
                IdInsumo = x.IdInsumo,
                IdDescripcion = x.IdDescripcion,
                Altura = x.Altura,
                Espesor = x.Espesor,
                Diametro = x.Diametro,
                DiametroNominal = x.DiametroNominal,
                Longitud = x.Longitud,
                Perfil = x.Perfil,
                Tolerancia = x.Tolerancia,
                Peso = x.Peso,
                idFraccionamiento = x.IdFraccionamiento,
                idAlmacenamiento = x.IdAlmacenamiento,

            }));

            return new JsonResult(Listado);
        }
        internal JsonResult? ObtenerIdComponente(DTODetallesComponenteProducto? Especificaciones)
        {

            return _componentesProductos.ObtenerId(CategorizarPropiedades(Especificaciones).Item2);

        }
        internal IActionResult ObtenerPropsComponentes()
        {
            string? TipoMapeado;

            ComponentesDetalle intancia = new ComponentesDetalle();
            var Tipo = intancia.GetType();
            var propiedades = Tipo.GetProperties();

            List<DTOInfoPropsComponentes> ListaInfoProps = new List<DTOInfoPropsComponentes>();

            var MapeoTipos = new Dictionary<Type, string>
            {
            { typeof(int), "int" },
            { typeof(string), "string" },
            { typeof(decimal), "decimal" },
            { typeof(int?), "int" },
            { typeof(decimal?), "decimal" },

            };
            foreach (var item in propiedades)
            {


                if (MapeoTipos.TryGetValue(item.PropertyType, out TipoMapeado) && !item.Name.Contains("IdInsumo"))
                {
                    ListaInfoProps.Add(new DTOInfoPropsComponentes()
                    {
                        Nombre = item.Name,
                        Tipo = TipoMapeado,

                    });
                }
            }


            return new JsonResult(ListaInfoProps);

        }
        internal async Task<IActionResult> MapeoDetalleNombreComponenteDTO(int? IdDescripcionComponente)
        {
            var (Listado, error) = await _componentesProductos.ListarTiposAlacenamiento(IdDescripcionComponente);
            if (error != null) return new ContentResult()
            {
                Content = error.InnerException?.Message ?? error.Message,
                ContentType = "application/json",
                StatusCode = 400
            };

            List<DTODescripcionComponentes> ListadoDetallesNombresComponentes = new List<DTODescripcionComponentes>();
            Listado!.ForEach(x => ListadoDetallesNombresComponentes.Add(new DTODescripcionComponentes()
            {
                IdDescripcion = x.IdDescripcion,
                NombreDescripcion = x.Descripcion ?? "",
                IdAlmacenamiento = x.IdAlmacenamiento,
                IdFraccionamiento = x.IdFraccionamiento
            }));

            return new JsonResult(ListadoDetallesNombresComponentes);

        }
        private (string[], List<(string Nombre, string Valor)>) CategorizarPropiedades(DTODetallesComponenteProducto? Especificaciones)
        {
            var propiedadesNulas = new string[0];
            List<(string Nombre, string Valor)> propiedadesNoNulas = new List<(string, string)>();
            var propiedades = typeof(DTODetallesComponenteProducto).GetProperties();

            foreach (var propiedad in propiedades)
            {
                var valor = propiedad.GetValue(Especificaciones);
                bool propiedadExiste = typeof(ComponentesDetalle).GetProperty(propiedad.Name) != null;
                if (valor == null && propiedad.Name != "idComponente" && propiedadExiste)
                {
                    Array.Resize(ref propiedadesNulas, propiedadesNulas.Length + 1);
                    propiedadesNulas[propiedadesNulas.Length - 1] = propiedad.Name;
                }
                else if (valor != null)
                {
                    string _valor = valor.ToString() ?? "";
                    propiedadesNoNulas.Add((propiedad.Name, _valor));

                }
            }

            return (propiedadesNulas, propiedadesNoNulas);

        }

        internal async Task<IActionResult> ProcesarDatos(string idInsumo)
        {
            var Error = await _componentesProductos.DeshabilitarComponente(idInsumo);

            if (Error != null)
                return new ContentResult()
                {
                    Content = Error.InnerException?.Message,
                    ContentType = "application/json",
                    StatusCode=400
                };

            return new StatusCodeResult(200);

        }

        internal IActionResult MapeoComponentesDetalleGrid(int idDescripcion)
        {
            var (Listado, Ex) = _componentesProductos.ListarDetalleComponentes(idDescripcion, null);

            if (Ex != null) return new ContentResult()
            {
                Content = Ex.InnerException?.Message ?? Ex.Message,
                ContentType = "application/json",
                StatusCode = 500
            };

            IReportResult Reporte = new();

            var Propiedades = Listado!.FirstOrDefault()?.GetType().GetProperties();


            var Columnas = Propiedades!.Where(prop => Listado!.All(x =>
            {
                var valor = prop.GetValue(x);
                var nombre = prop.Name;
                return 
                (valor != null || nombre.Contains("IdFraccionamiento"))
                && valor?.ToString() != "" 
                && valor?.ToString() != "-"
                && !nombre.Contains("IdEstado")
                && !nombre.Contains("IdDescripcion")
                && !nombre.Contains("ComprasNavigation");
            }))
                .Select(prop => prop.Name)
                .ToList();

            Listado!.ForEach(x =>
            {
                Reporte.rowList.Add(new RowList()
                {
                    idInsmo = x.IdInsumo,
                    cellList = x.GetType().GetProperties()
                    .Where(y => Columnas.Contains(y.Name))
                    .Select(h => new CelList()
                    {
                        header = h.Name,
                        value= h.GetValue(x)?.ToString() ?? "",
                        type = ObtenerTipoValor(h.PropertyType)

                    }).ToList(),                     
                });                
            });

            Reporte.rowList.ForEach(reporte =>
            {
                reporte.cellList.Add(new CelList()
                {
                    header = "Acciones",
                    type = "button",
                    value = reporte.idInsmo
                });
            });


            return new JsonResult(Reporte);
        }

        public string ObtenerTipoValor(Type Tipo)
        {
            Type? UnderlyingType = Nullable.GetUnderlyingType(Tipo) ?? Tipo;

            return
                UnderlyingType == typeof(string) ? "string" :
                UnderlyingType == typeof(int)
                    || UnderlyingType == typeof(decimal)
                    || UnderlyingType == typeof(double)
                    || UnderlyingType == typeof(float) ? "number" 
                    : "string";
                    

        }
    }
}
