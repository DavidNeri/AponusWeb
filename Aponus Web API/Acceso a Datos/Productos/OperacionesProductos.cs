using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Validation;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Acceso_a_Datos.Productos
{
    
    public class OperacionesProductos
    {
        private readonly AponusContext AponusDBContext;
        public OperacionesProductos() { AponusDBContext = new AponusContext(); }
        internal void EliminarComponententesCuantitativos(DatosProducto producto, List<DTOComponentesProducto> componentes)
        {
            throw new NotImplementedException();
        }

        internal void EliminarComponententesMensurables(DatosProducto producto, List<DTOComponentesProducto> componentes)
        {
            throw new NotImplementedException();
        }

        internal void EliminarComponententesPesables(DatosProducto producto, List<DTOComponentesProducto> componentes)
        {
            throw new NotImplementedException();
        }

        internal void EliminarProducto(DatosProducto producto)
        {
            throw new NotImplementedException();
        }

        internal void GuardarComponententesCuantitativos(DTOComponentesProducto componente)
        {
            AponusDBContext.ComponentesCuantitativos
                   .Add(new ComponentesCuantitativo
                   {
                       IdProducto = componente.IdProducto,
                       IdComponente = componente.IdComponente,
                       Cantidad = (int)componente.Cantidad

                   });

            AponusDBContext.SaveChanges();
                      
        }

        internal void GuardarComponententesMensurables(DTOComponentesProducto componente)
        {
            AponusDBContext.ComponentesMensurables
                .Add(new ComponentesMensurable
                {
                    IdProducto = componente.IdProducto,
                    IdComponente = componente.IdComponente,
                    Largo = componente.Largo,

                });
            AponusDBContext.SaveChanges(); 
        }

        internal void GuardarComponententesPesables(DTOComponentesProducto componente)
        {

            AponusDBContext.ComponentesPesables
                   .Add(new ComponentesPesable
                   {
                       IdProducto = componente.IdProducto,
                       IdComponente = componente.IdComponente,
                       Cantidad = componente.Cantidad,
                       Peso = componente.Peso
                   });
            AponusDBContext.SaveChanges();

        }

        internal void GuardarProducto(DTOProducto producto)
        {
            var existingProducto = AponusDBContext.Productos.FirstOrDefault(p => p.IdProducto == producto.Producto.IdProducto);


            if (existingProducto != null)
            {
                existingProducto.IdDescripcion = (int)producto.Producto.IdDescripcion;
                existingProducto.IdTipo = producto.Producto.IdTipo;
                existingProducto.DiametroNominal = producto.Producto.DiametroNominal;
                existingProducto.Cantidad = Convert.ToInt32(producto.Producto.Cantidad);
                existingProducto.PrecioLista = producto.Producto.PrecioLista;
                existingProducto.Tolerancia = producto.Producto.Tolerancia;
            }
            else
            {
                AponusDBContext.Productos
            .Add(new Producto
            {
                IdProducto = producto.Producto.IdProducto,
                IdDescripcion = (int)producto.Producto.IdDescripcion,
                IdTipo = producto.Producto.IdTipo,
                DiametroNominal = producto.Producto.DiametroNominal,
                Cantidad = Convert.ToInt32(producto.Producto.Cantidad),
                PrecioLista = producto.Producto.PrecioLista,
                Tolerancia = producto.Producto.Tolerancia
            });
            }
           

            AponusDBContext.SaveChanges();
        }

        public string GenerarIdProd(DTOProducto Producto)
        {
            string IdProducto;

            try
            {
                string Tolerancia = Producto.Producto.Tolerancia.Replace("-", "_").Replace("/","_");
                IdProducto = Producto.Producto.IdTipo + "_" +
                    Producto.Producto.IdDescripcion + "_" +
                    Producto.Producto.DiametroNominal + "_" + Tolerancia;
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

            if (ChkIdProd)
            {
                foreach (DTOComponentesProducto Componente in Componentes)
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

        internal void ActualizarComponente(DTOProducto producto)
        {
        }

        internal void Actualizar(PropertyInfo prop, DTODetallesProducto detallesProducto, Producto? ProductUpdateDetails)
        {            

            PropertyInfo? PropertyProductUpdate = ProductUpdateDetails.GetType().GetProperty(prop.Name);


            if (PropertyProductUpdate != null)
            {
                var CurrenValue = prop.GetValue(detallesProducto);

                PropertyProductUpdate.SetValue(ProductUpdateDetails, CurrenValue);

               
            }  

        }

        internal void ModifyProductDetails(Producto ProductUpdate)
        {
            AponusDBContext.Entry(ProductUpdate).State = EntityState.Modified;

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
    }
}
