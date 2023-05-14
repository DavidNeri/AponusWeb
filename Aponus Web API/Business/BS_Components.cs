using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq.Expressions;
using System.Data.Entity.Validation;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Business
{
    public class BS_Components
    {
        internal JsonResult? DeterminarProp(DTODetalleComponentes? Especificaciones)
        {
            return new ObtenerComponentes().ListarProp(
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
                        ComponentesProductos.GuardarComponenteProd(new Productos_Componentes
                        {
                            IdProducto = Componente.IdProducto,
                            IdComponente = Componente.IdComponente,
                            Cantidad = Componente.Cantidad,
                            Longitud = Componente.Largo,
                            Peso = Componente.Peso,
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

        internal JsonResult? ObtenerIdComponente(DTODetalleComponentes? Especificaciones)
        {
            return new ObtenerComponentes().ObtenerId(CategorizarPropiedades(Especificaciones).Item2);

        }

                
        private (string[], List<(string Nombre, string Valor)>) CategorizarPropiedades(DTODetalleComponentes? Especificaciones)
        {
            var propiedadesNulas = new string[0];
            List<(string Nombre, string Valor)> propiedadesNoNulas = new List<(string, string)>();
            var propiedades = typeof(DTODetalleComponentes).GetProperties();

            foreach (var propiedad in propiedades)
            {
                var valor = propiedad.GetValue(Especificaciones);
                bool propiedadExiste = typeof(Insumos_Detalle).GetProperty(propiedad.Name) != null;
                if (valor == null && propiedad.Name != "idComponente" && propiedadExiste)
                {
                    Array.Resize(ref propiedadesNulas, propiedadesNulas.Length + 1);
                    propiedadesNulas[propiedadesNulas.Length - 1] = propiedad.Name;
                }
                else if (valor != null)
                {
                    string _valor = valor.ToString();
                    propiedadesNoNulas.Add((propiedad.Name, _valor));

                }
            }

            return (propiedadesNulas,propiedadesNoNulas);

        }
            
    }
}
