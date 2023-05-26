using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Aponus_Web_API.Acceso_a_Datos.Componentes
{
    public class ObtenerComponentes
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerComponentes() { AponusDBContext = new AponusContext(); }
        internal JsonResult? ListarProp(string[] propiedadesNulas, List<(string Nombre, string Valor)> propiedadesNoNulas)
        {
           
            var dbContext = AponusDBContext;
            var query = GenerarWhereAND(propiedadesNoNulas);
            

            JsonResult? jsonResult= null;
            int i = 0;

            do
            {
                var propertyType = typeof(ComponentesDetalle).GetProperty(propiedadesNulas[i]).PropertyType;

                // Crear la expresión lambda para la propiedad a seleccionar
                var parameter = Expression.Parameter(typeof(ComponentesDetalle), "x");
                var property = Expression.Property(parameter, propiedadesNulas[i]);
                Expression<Func<ComponentesDetalle, object>> lambda = null;

                // Agregar comprobación para manejar valores nulos
                var defaultValue = propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null;
                var propertyOrDefault = Expression.Coalesce(property, Expression.Constant(defaultValue, propertyType));

                lambda = Expression.Lambda<Func<ComponentesDetalle, object>>(
                          Expression.Convert(propertyOrDefault, typeof(object)),
                          parameter);

                var resultados = query.Select(lambda).Distinct().ToArray();

                var Valores = resultados.Where(x => x != null && !string.IsNullOrEmpty(x.ToString()));

                if (Valores.Count()>0)                    
                {
                    var Columna = AponusDBContext.Set<ComponentesDetalle>()
                        .Select(e => typeof(ComponentesDetalle).GetProperty(propiedadesNulas[i]))
                        .First()
                        .Name;

                    var ResultadosTotales = new { Valores , Columna };
                    jsonResult = new JsonResult(ResultadosTotales);
                }      

                i++;
            } while (jsonResult == null && i < propiedadesNulas.Length);


            if (jsonResult==null)
            {
                jsonResult = new JsonResult(null);
            }

            return jsonResult;

        }

        internal JsonResult? ObtenerId(List<(string Nombre, string Valor)> propiedadesNoNulas)
        {
            var query = GenerarWhereAND(propiedadesNoNulas);
            var Insumo = query.Select(x => x.IdInsumo).ToList();
            JsonResult jsonResult= null;

            if(Insumo.Count()>1)
            {
                jsonResult= new JsonResult("Los valores no corresponden a un elemento unico");
            }else
            {
                jsonResult= new JsonResult(Insumo);
            }

            return jsonResult;
        }

        private IQueryable<ComponentesDetalle> GenerarWhereAND(List<(string Nombre, string Valor)> propiedadesNoNulas)
        {
            var dbContext = AponusDBContext;
            var query = dbContext.ComponentesDetalles.AsQueryable().Where(x => true);

            foreach ((string Nombre, string Valor) propiedad in propiedadesNoNulas)
            {
                // Obtener el valor de la propiedad
                var valor = propiedad.Valor;
                int valorNumeroEntero;
                decimal numeroDecimal;

                // Si la propiedad tiene un valor, agregarla al Where
                if (valor != null)
                {
                    var nombre = propiedad.Nombre;
                    var propertyType = typeof(ComponentesDetalle).GetProperty(nombre)?.PropertyType;

                    if (int.TryParse(valor, out valorNumeroEntero))
                    {
                        var parameter = Expression.Parameter(typeof(ComponentesDetalle), "x");
                        var property = Expression.Property(parameter, nombre);

                        try
                        {
                            var constant = Expression.Constant(valorNumeroEntero, typeof(int?));
                            var equals = Expression.Equal(property, constant);
                            var lambda = Expression.Lambda<Func<ComponentesDetalle, bool>>(equals, parameter);
                            query = query.Where(lambda);

                        }
                        catch (InvalidOperationException)
                        {
                            var constant = Expression.Constant(valorNumeroEntero, typeof(int));
                            var equals = Expression.Equal(property, constant);
                            var lambda = Expression.Lambda<Func<ComponentesDetalle, bool>>(equals, parameter);
                            query = query.Where(lambda);
                        }

                    }
                    else if (decimal.TryParse(valor, out numeroDecimal))
                    {
                        var parameter = Expression.Parameter(typeof(ComponentesDetalle), "x");
                        var property = Expression.Property(parameter, nombre);
                        var constant = Expression.Constant(numeroDecimal, typeof(decimal?));
                        var equals = Expression.Equal(property, constant);
                        var lambda = Expression.Lambda<Func<ComponentesDetalle, bool>>(equals, parameter);
                        query = query.Where(lambda);
                    }
                    else
                    {
                        var typedValue = Convert.ChangeType(valor, propertyType);
                        var parameter = Expression.Parameter(typeof(ComponentesDetalle), "x");
                        var property = Expression.Property(parameter, nombre);


                        // Agregar la condición al Where
                        if (property != null)
                        {
                            var value = Expression.Constant(typedValue);
                            var equals = Expression.Equal(property, value);
                            var lambda = Expression.Lambda<Func<ComponentesDetalle, bool>>(equals, parameter);

                            // Agregar la condición al Where
                            query = query.Where(lambda);
                        }
                    }

                    
                }
            }
            return query;
        }
    }
}

