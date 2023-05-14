using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace Aponus_Web_API.Acceso_a_Datos.Componentes
{
    public class ComponentesProductos
    {

        internal static void GuardarComponenteProd(Productos_Componentes componente)
        {
            using (var DbContext = new AponusContext())
            {               
                    var ValidarExistencia = DbContext.Componentes_Productos
                    .FirstOrDefault(c => c.IdProducto == componente.IdProducto &&
                                         c.IdComponente == componente.IdComponente);

                    if (ValidarExistencia != null)
                    {
                        ValidarExistencia.Cantidad = componente.Cantidad;
                        ValidarExistencia.Peso = componente.Peso;
                        ValidarExistencia.Longitud = componente.Longitud;
                        DbContext.SaveChanges();
                    }
                    else
                    {
                        DbContext.Componentes_Productos.Add(componente);
                        DbContext.SaveChanges();
                    }
                
               
            }


        }
    }
}
