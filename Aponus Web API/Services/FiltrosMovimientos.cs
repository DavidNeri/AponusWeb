using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq.Expressions;

namespace Aponus_Web_API.Services
{
    public class FiltrosMovimientos
    {
        public string? IdUsuario { get; set; }
        public string? Proveedor{ get; set; }
        public string? Etapa { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }

        public Expression<Func<DTOMovimientosStock, bool>> ConstruirCondicionWhere(FiltrosMovimientos filtros)
        {
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

                //Para el resto de los filtros 
                string Propiedad;

                if (Prop.Name.Equals("Etapa"))
                {

                    Propiedad = "CampoStockDestino";
                }
                else if (Prop.Name.Equals("Proveedor")) Propiedad = "ProveedorDestino";
                else Propiedad = Prop.Name;

                if (!string.IsNullOrEmpty(Prop.GetValue(filtros)?.ToString()))
                {
                    var Condicion = Expression.Call(
                        Expression.Property(EntidadParametro, Propiedad),
                        typeof(string).GetMethod("Contains"),
                        Expression.Constant(Prop.GetValue(filtros), typeof(string)));

                    Condiciones.Add(Condicion);
                }
                
            }

            // Unir las condiciones con AND
            var CondicionFinal = Condiciones.Any() ? Condiciones.Aggregate(Expression.AndAlso) : Expression.Constant(true);

            var lambda = Expression.Lambda<Func<DTOMovimientosStock, bool>>(CondicionFinal, EntidadParametro);

            return lambda;

        }



    }

    


}
