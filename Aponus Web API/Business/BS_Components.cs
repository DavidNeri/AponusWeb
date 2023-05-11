using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq.Expressions;

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
