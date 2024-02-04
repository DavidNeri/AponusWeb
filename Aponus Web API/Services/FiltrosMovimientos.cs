using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq.Expressions;

namespace Aponus_Web_API.Services
{
    public class FiltrosMovimientos
    {
        public string? Proveedor{ get; set; }
        public string? Etapa { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }

        public Expression<Func<DTOMovimientosStock, bool>> ConstruirCondicionWhere(FiltrosMovimientos filtros)
        {
            string Propiedad;
            // Parámetro para la expresión lambda
            var EntidadParametro = Expression.Parameter(typeof(DTOMovimientosStock));

            // Lista para almacenar las condiciones
            List<Expression> Condiciones = new List<Expression>();

            // Obtener propiedades no nulas de los filtros
            var PropsNoNulas = typeof(FiltrosMovimientos).GetProperties().Where(Prop => Prop.GetValue(filtros) != null);

            

            foreach (var Prop in PropsNoNulas)
            {
                //Solo para los filtros de Fechas
                if (Prop.PropertyType == typeof(DateTime?) && Prop.GetValue(filtros) is DateTime?)
                {
                    if (Prop.Name.Contains("Desde") && Prop.GetValue(filtros) != null)
                    {

                        var CondicionDesde = Expression.GreaterThanOrEqual(
                            Expression.Property(EntidadParametro, "FechaHora"),
                            Expression.Constant(filtros.Desde, typeof(DateTime?)));

                        Condiciones.Add(CondicionDesde);

                    }
                    else if (Prop.Name.Contains("Hasta") && Prop.GetValue(filtros) != null)
                    {
                        var CondicionHasta= Expression.LessThanOrEqual(
                            Expression.Property(EntidadParametro, "FechaHora"),
                            Expression.Constant(filtros.Hasta, typeof(DateTime?)));

                        Condiciones.Add(CondicionHasta);
                    }
                }


                //Para el "CampoStockDestino", debo Recorrer 'Suministros'
                if (Prop.Name.Equals("Etapa"))
                {

                    Propiedad = "CampoStockDestino";

                    // Obtener la propiedad Suministros de DTOMovimientosStock
                    var PropSuministros = Expression.Property(EntidadParametro, "Suministros");

                    // Crear un parámetro para los elementos dentro de la lista Suministros
                    var ParamSuministros = Expression.Parameter(typeof(DTOSuministrosMovimientosStock));

                    // Acceder a la propiedad CampoStockDestino de los elementos dentro de la lista Suministros
                    var propCampoStockDestino = Expression.Property(ParamSuministros, Propiedad);

                    // Construir la condición para la propiedad CampoStockDestino dentro de la lista Suministros
                    var metodoContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                    var CondicionCampoStockDestino = Expression.Call(propCampoStockDestino,
                        metodoContains,
                        Expression.Constant(filtros.Etapa, typeof(string)));

                    // Crear una expresión Lambda para la condición CampoStockDestino dentro de la lista Suministros

                    var lambdaCampoStockDestino = Expression.Lambda<Func<DTOSuministrosMovimientosStock, bool>>(CondicionCampoStockDestino,
                        ParamSuministros);

                    // Utilizar Any para verificar si al menos un elemento en la lista cumple la condición
                    var CondicionCampoStockDestinoLista = Expression.Call(typeof(Enumerable),   // Tipo que contiene el método estático (Enumerable en este caso)
                        "Any",                                                                  // Nombre del método estático (Any en este caso)
                        new[] { typeof(DTOSuministrosMovimientosStock) },                       // Tipo genérico del método. En este caso, se espera que la secuencia sea de tipo IEnumerable<DTOSuministrosMovimientosStock>.
                        PropSuministros,                                                        // Es la expresión que representa la lista o secuencia que se evaluará.
                        lambdaCampoStockDestino);                                               //Es la expresión lambda que representa la condición que debe cumplir al menos un elemento en la lista.

                    // Agregar la condición a la lista general de condiciones
                    Condiciones.Add(CondicionCampoStockDestinoLista);
                }
                else if (Prop.Name.Equals("Proveedor"))
                {
                    Propiedad = "ProveedorDestino";

                    //Obtener la prop ProveedorDestino de DTOMovimientosSTock
                    var PropProveedor = Expression.Property(EntidadParametro, Propiedad);

                    var PropNombreProveedor = Expression.Property(PropProveedor, "NombreProveedor");

                    // Crear un parámetro para los elementos dentro de la lista Proveedores
                    var paramProveedor = Expression.Parameter(typeof(DTOProveedores));

                    // Acceder a la propiedad NombreProveedor de los elementos dentro de la lista Proveedores
                    var NombreProveedor = Expression.Property(paramProveedor, "NombreProveedor");

                    // Construir la condición para la propiedad NombreProveedor dentro de ProveedorDestino en DTOMovimientosSTock
                    var metodoContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                    var condicionNombreProveedor = Expression.Call(PropNombreProveedor,   // El objeto o expresión sobre el cual se llama el método
                        metodoContains,                                             // El método que se va a llamar (en este caso, el método Contains)
                        Expression.Constant(filtros.Proveedor, typeof(string)));    // El argumento que se pasa al método


                    Condiciones.Add(condicionNombreProveedor);

                }



            }

            // Unir las condiciones con AND
            var CondicionFinal = Condiciones.Any() ? Condiciones.Aggregate(Expression.AndAlso) : Expression.Constant(true);

            var lambda = Expression.Lambda<Func<DTOMovimientosStock, bool>>(CondicionFinal, EntidadParametro);

            return lambda;

        }



    }

    


}
