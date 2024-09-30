using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;


namespace Aponus_Web_API.Acceso_a_Datos.Productos
{
    
    public class Productos
    {
        private readonly AponusContext AponusDBContext;
        public Productos() { AponusDBContext = new AponusContext(); }
      

       

       

     

        internal void GuardarProducto(DTODetallesProducto producto)
        {
            //AGregar Nuevo Producto 
            AponusDBContext.Productos.Add(new Producto
            {
                IdProducto = producto.IdProducto,
                IdDescripcion = (int)producto.IdDescripcion,
                IdTipo = producto.IdTipo,
                DiametroNominal = producto.DiametroNominal,
                Cantidad = Convert.ToInt32(producto.Cantidad),
                PrecioLista = producto.PrecioLista,
                Tolerancia = producto.Tolerancia
            });
            
            // ProcesarDatos los cambios en la base de datos
            AponusDBContext.SaveChanges();
        }

        public string GenerarIdProd(DTODetallesProducto Producto)
        {
            string IdProducto;

            try
            {
                string Tolerancia = Producto.Tolerancia.Replace("-", "_").Replace("/","_");
                IdProducto = Producto.IdTipo + "_" +
                    Producto.IdDescripcion + "_" +
                    Producto.DiametroNominal + "_" + Tolerancia;
            }
            catch (Exception)
            {

                return null;
            }

            return IdProducto;
        }

        internal void GuardarComponentes(List<DTOComponentesProducto> Componentes)
        {
            bool ChkIdProd = Componentes.All(x => x.IdProducto != null);
            ComponentesProductos GuardarComponente = new ();


            if (ChkIdProd)
            {
                foreach (DTOComponentesProducto Componente in Componentes)
                {
                    try
                    {
                        GuardarComponente.GuardarComponenteProd(new Productos_Componentes
                                                                    {
                                                                        IdProducto = Componente.IdProducto,
                                                                        IdComponente = Componente.IdComponente,
                                                                        Cantidad = Componente.Cantidad,
                                                                        Longitud = Componente.Largo,
                                                                        Peso = Componente.Peso,
                                                                    });

                    }
                    catch (Exception)
                    {
                    }
                }
                AponusDBContext.SaveChanges();
            }          

        }


        public Producto? BuscarProducto(string Id_Producto)
        {
            return AponusDBContext.Productos
                .Where(x => x.IdProducto == Id_Producto)
                .Select(x=>new Producto()
                {
                    IdProducto=x.IdProducto,
                    IdDescripcion=x.IdDescripcion,
                    IdTipo=x.IdTipo,
                    DiametroNominal = x.DiametroNominal,
                    Tolerancia = x.Tolerancia,
                    Cantidad = x.Cantidad,
                    PrecioFinal=x.PrecioFinal,
                    PrecioLista=x.PrecioLista,
                    PorcentajeGanancia=x.PorcentajeGanancia,
                    
                }).SingleOrDefault();
        }

       

      

        internal void ModifyProductDetails(Producto ProductUpdate)
        {
            AponusDBContext.Entry(ProductUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            AponusDBContext.SaveChanges();
        }


        internal string? ObtenerValor(string prop, string IdProducto) {

            var Valor = AponusDBContext.Productos
                .Where(x=>x.IdProducto==IdProducto)
                .Select(x => x.GetType().GetProperty(prop).GetValue(x))
                .FirstOrDefault();

            if (Valor!=null)
            {
                return Valor.ToString();

            }
            else
            {
                return null;
            }

        }

        internal void DeleteAllProductComponents(string IdProducto)
        {
            var DeleteComponents = AponusDBContext.Componentes_Productos
                .Where(x =>x.IdProducto==IdProducto).ToArray();

            if (DeleteComponents != null)
            {
                AponusDBContext.Componentes_Productos.RemoveRange(DeleteComponents);
                AponusDBContext.SaveChanges() ;
            }
            

        }
      
        internal void AgregarComponente(Productos_Componentes NewComponent)
        {   
            AponusDBContext.Componentes_Productos.Add(NewComponent);
            AponusDBContext.SaveChanges();
            
        }

        internal void ModifyProductComponents(List<Productos_Componentes> ProducComponentsUpdate)
        {

            AponusDBContext.Componentes_Productos.UpdateRange(ProducComponentsUpdate);

            AponusDBContext.SaveChanges();
        }

        internal void ActualizarIdProd(string idAnterior, string nuevoId)
        {
            AponusDBContext.Productos
                .Where(x => x.IdProducto == idAnterior)
                .UpdateFromQuery(x => new Producto { IdProducto = nuevoId });

            AponusDBContext.SaveChanges();
        }
    }
}
