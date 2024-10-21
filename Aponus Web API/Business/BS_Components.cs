using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Validation;
using Microsoft.EntityFrameworkCore;
using Aponus_Web_API.Data_Transfer_Objects;

namespace Aponus_Web_API.Business
{
    public class BS_Components
    {
        private readonly ComponentesProductos _componentesProductos;
        private readonly OperacionesComponentes _operacionesComponentes;
        private readonly ObtenerComponentes _obtenerComponentes;

        public BS_Components(ComponentesProductos componentesProductos, OperacionesComponentes operacionesComponentes, ObtenerComponentes obtenerComponentes)
        {
            _componentesProductos = componentesProductos;
            _operacionesComponentes = operacionesComponentes;
            _obtenerComponentes = obtenerComponentes;
        }
        internal JsonResult? DeterminarProp(DTODetallesComponenteProducto? Especificaciones)
        {
            return _obtenerComponentes.ListarProp(
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
                    catch (DbEntityValidationException ex)
                    {
                        string Mensaje = "";

                        foreach (var entityValidationError in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                Mensaje += "Error de validación: Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage + "\n";
                            }
                        }

                        return new ContentResult { Content = Mensaje, StatusCode = 400 };

                    }
                    catch (InvalidOperationException)
                    {
                        return new ContentResult { Content = "Operacion Invalida", ContentType = "text/plan", StatusCode = 400 };
                    }
                    catch (Exception )
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
        internal IActionResult ListarComponentes(int? IdDescripcion)
        {
            return _obtenerComponentes.Listar(IdDescripcion);
        }
        internal JsonResult? ObtenerIdComponente(DTODetallesComponenteProducto? Especificaciones)
        {

            return _obtenerComponentes.ObtenerId(CategorizarPropiedades(Especificaciones).Item2);

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
                       Nombre= item.Name,
                        Tipo = TipoMapeado,

                    });
                }
            }

           
            return new JsonResult(ListaInfoProps);
            
        }
        internal async Task<IActionResult> ObtenerTipoAlmacenamiento( )
        {
            
            return await _operacionesComponentes.ListarTiposAlacenamiento();
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

            return (propiedadesNulas,propiedadesNoNulas);

        }
            
    }
}
