using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Fractions;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Acceso_a_Datos.Componentes
{
    public class ComponentesProductos
    {
        private readonly AponusContext AponusDbContext;
        public ComponentesProductos() { AponusDbContext = new AponusContext(); }
        internal void GuardarComponenteProd(Productos_Componentes componente)
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

        internal void Eliminar(DTOComponentesProducto componente)
        {
            throw new NotImplementedException();
        }

        internal List<DTOComponentesProducto> ObtenerComponentes(string idProducto)=>
        
            AponusDbContext.Componentes_Productos
            .Where(x=>x.IdProducto==idProducto)
            .Select(x=>new DTOComponentesProducto()
            {
                IdProducto=x.IdProducto,
                IdComponente= x.IdComponente,
                Cantidad= x.Cantidad,
                Peso= x.Peso,
                Largo=x.Longitud
            }).ToList();

        internal JsonResult ObtenerComponentesFormateados(DTODetallesProducto Producto)
        {

            
            var ComponentesProducto = AponusDbContext.Componentes_Productos
                    .Where(x => x.IdProducto == Producto.IdProducto)
                    .Join(AponusDbContext.ComponentesDetalles,
                        _Componentes => _Componentes.IdComponente,
                        _DetalleComponentes => _DetalleComponentes.IdInsumo,
                        (_Componentes, _DetalleComponentes) => new
                        {
                            _Componentes,
                            _DetalleComponentes
                        })

                    .Join(AponusDbContext.ComponentesDescripcions,
                        _DetComponentes => _DetComponentes._DetalleComponentes.IdDescripcion,
                        _NombreComponentes => _NombreComponentes.IdDescripcion,
                        (_DetComponentes, _NombreComponentes) => new
                        {
                            _DetComponentes,
                            _NombreComponentes
                        })
                    .Join(AponusDbContext.stockInsumos,
                        _JoinResult => _JoinResult._DetComponentes._DetalleComponentes.IdInsumo,
                        _StockComponentes => _StockComponentes.IdInsumo,
                        (_JoinResult, _StockComponentes) => new
                        {
                            _IdProducto = _JoinResult._DetComponentes._Componentes.IdProducto,
                            _IdComponente = _JoinResult._DetComponentes._Componentes.IdComponente ?? "",
                            _Descripcion = _JoinResult._NombreComponentes.Descripcion ?? "",
                            _Diametro = _JoinResult._DetComponentes._DetalleComponentes.Diametro ?? null,
                            _Longitud = _JoinResult._DetComponentes._DetalleComponentes.Longitud ?? null,
                            _Altura = _JoinResult._DetComponentes._DetalleComponentes.Altura ?? null,
                            _Espesor = _JoinResult._DetComponentes._DetalleComponentes.Espesor ?? null,
                            _Perfil = _JoinResult._DetComponentes._DetalleComponentes.Perfil ?? null,
                            _Tolerancia = _JoinResult._DetComponentes._DetalleComponentes.Tolerancia ?? "",
                            _DiametroNominal = _JoinResult._DetComponentes._DetalleComponentes.DiametroNominal ?? null,
                            _Largo = _JoinResult._DetComponentes._Componentes.Longitud ?? null,


                            StockComponente = new DTOStocks
                            {
                                IdInsumo = _StockComponentes.IdInsumo,
                                Recibido = _StockComponentes.Recibido != null ? _StockComponentes.Recibido.ToString(): "Sin Stock",
                                Granallado = _StockComponentes.Granallado != null ? _StockComponentes.Granallado.ToString() : "Sin Stock",
                                Pintura = _StockComponentes.Pintura != null ? _StockComponentes.Pintura.ToString() : "Sin Stock",
                                Proceso = _StockComponentes.Proceso != null ? _StockComponentes.Proceso.ToString() : "Sin Stock",
                                Moldeado = _StockComponentes.Moldeado != null ? _StockComponentes.Moldeado.ToString() : "Sin Stock",

                                Total = ((_StockComponentes.Pintura ?? 0) +
                                        (_StockComponentes.Moldeado ?? 0) +
                                        (_StockComponentes.Recibido ?? 0) + 
                                        (_StockComponentes.Proceso ?? 0) +
                                        (_StockComponentes.Granallado ?? 0)).ToString(),

                                Requerido = ((_JoinResult._DetComponentes._Componentes.Cantidad ?? 0) * Producto.Cantidad).ToString(),
                                // PesoReq=(_JoinResult._DetComponentes._Componentes.PesoComponente ?? 0) *Producto.CantidadRequerida Eliminar??,
                                // CantidadReq = (_JoinResult._DetComponentes._Componentes.CantidadRequerida ?? 0) * Producto.CantidadRequerida,
                                // LongReq = (_JoinResult._DetComponentes._Componentes.LongitudInsumo ?? 0) * Producto.CantidadRequerida,*/


                            }
                        })
                    .GroupBy(cp => new
                    {
                        cp._IdComponente,
                        cp._IdProducto,
                        cp._Descripcion,
                        cp._Longitud,
                        cp._Perfil,
                        cp._DiametroNominal,
                        cp._Altura,
                        cp._Espesor,
                        cp._Largo,
                        cp._Diametro,
                        cp._Tolerancia
                    })

                    .Select(group => new
                    {
                        idProducto = group.Key._IdProducto,
                        IdComponente = group.Key._IdComponente,
                        Descripcion = group.Key._Descripcion,
                        Perfil = group.Key._Perfil,
                        Longitud = group.Key._Longitud,
                        DiametroNominal = group.Key._DiametroNominal,
                        Altura = group.Key._Altura,
                        Largo = group.Key._Largo,
                        Diametro = group.Key._Diametro,
                        Espesor = group.Key._Espesor,
                        Tolerancia = group.Key._Tolerancia,
                        StockComponente = group.Select(cp => cp.StockComponente).ToList(),

                    })
                    .ToList();



            List<string> AllComponentesIds = ComponentesProducto.Select(cp => cp.IdComponente).ToList();

            List<DTOComponente> PropiedadesComponentes = AponusDbContext.ComponentesDetalles
                .Where(x=>AllComponentesIds.Contains(x.IdInsumo))
                .Select(x => new DTOComponente()
                {                    
                    idComponente = x.IdInsumo,
                    idAlmacenamiento = x.IdAlmacenamiento,
                    idFraccionamiento = x.IdFraccionamiento,
                    Altura= x.Altura,
                    Diametro= x.Diametro,
                    Espesor= x.Espesor,
                    Longitud=x.Longitud,
                    Perfil= x.Perfil,
                    Tolerancia= x.Tolerancia,
                    DiametroNominal= x.DiametroNominal,
                    
                    Peso = x.Peso,
                    
                })
                .ToList();  

            List<DTOProductoComponente> productos = new List<DTOProductoComponente>();

            foreach (var cp in ComponentesProducto)
            {
                    string? IdComponente = cp.IdComponente ?? "";
                    string? descripcion = cp.Descripcion ?? "";
                    string? diametro = cp.Diametro != null ? string.Format("{0:####}", cp.Diametro) : null;
                    string? longitud = cp.Longitud != null ? string.Format("{0:#,0}", cp.Longitud) : null;
                    string? altura = cp.Altura != null ? string.Format("{0:####}", cp.Altura) : null;
                    string? espesor = cp.Espesor != null ? string.Format("{0:####}", cp.Espesor) : null;
                    string? perfil = cp.Perfil != null ? string.Format("{0:####}", cp.Perfil) : null;
                    string? tolerancia = cp.Tolerancia ?? "";
                    string? DiametroNominal = cp.DiametroNominal.ToString() ?? "";
                    string? largo = cp.Largo != null ? string.Format("{0:####}", cp.Largo) : null;


                

                StringBuilder sb = new StringBuilder();
                sb.Append($"{descripcion}");
                if (diametro != null)
                    sb.Append($", Diametro:{diametro}mm");
                if (longitud != null)
                    sb.Append($", Longitud:{longitud}mm");
                if (altura != null)
                    sb.Append($", Altura:{altura}mm");
                if (espesor != null)
                    sb.Append($", Espesor:{espesor}mm");
                if (perfil != null)
                    sb.Append($", Perfil:{perfil}");
                if (tolerancia != null && tolerancia!="")
                    sb.Append($", Tolerancia:{tolerancia}");
                if (DiametroNominal != null && DiametroNominal != "")
                    sb.Append($", DN:{DiametroNominal}mm");

                foreach (var componente in cp.StockComponente)
                {
                    componente.NombreInsumo = descripcion;
                }


                DTOProductoComponente productoComponente = new DTOProductoComponente
                {
                    IdComponente = cp.IdComponente,                    
                    Descripcion = sb.ToString(),
                    Perfil = cp.Perfil,
                    Longitud = cp.Longitud,
                    DiametroNominal = cp.DiametroNominal,
                    Altura = cp.Altura,
                    Largo = cp.Largo,
                    Diametro = cp.Diametro,
                    Espesor = cp.Espesor,
                    Tolerancia = cp.Tolerancia,
                    StockFormateado = cp.StockComponente
                };

                productos.Add(productoComponente);
            }

            //var ComponentesProdIds = ComponentesProducto.Select(x => x.IdComponente).ToList();

            //PropertyInfo[] propsSTock = new DTOStocks().GetType().GetProperties();
           

                      

            foreach (var producto in productos)
            {
                
                producto.Perfil = null;
                producto.Longitud = null;
                producto.DiametroNominal = null;
                producto.Altura = null;
                producto.Largo = null;
                producto.Diametro = null;
                producto.Espesor = null;
                producto.Tolerancia = null;
                

                string? SiglaAlmacenamiento = PropiedadesComponentes
                    .Where(x => x.idComponente.Contains(producto.IdComponente))
                    .Select(x => x.idAlmacenamiento)
                    .FirstOrDefault();

                string? SiglaFraccionamiento = PropiedadesComponentes
                .Where(x => x.idComponente.Contains(producto.IdComponente))
                .Select(x => x.idFraccionamiento)
                .FirstOrDefault();

                //Dictionary<string, bool> propiedadesModificadas = new Dictionary<string, bool>();


                foreach (var item in producto.StockFormateado)
                {
                    var  TipoPropiedadStock = item.GetType();
                     PropertyInfo[] PropiedadesStock = TipoPropiedadStock.GetProperties();                    
                    

                    foreach (var propiedad in PropiedadesStock)
                    {
                        

                        if (propiedad.GetValue(item) !=null
                            && !propiedad.Name.Contains("IdInsumo")
                            && !propiedad.Name.Contains("NombreInsumo")
                            && propiedad.GetValue(item).ToString() != "Sin Stock")
                        {
                            if (SiglaFraccionamiento != null )
                            {
                                if (propiedad.Name.Contains("Requerido"))
                                {
                                    DTOComponente? Componente = PropiedadesComponentes.FirstOrDefault(x => x.idComponente == item.IdInsumo);
                                    
                                    string? CantidadRequerida = (string?)item.GetType().GetProperty(propiedad.Name)?.GetValue(item);
                                    if (CantidadRequerida == "") CantidadRequerida = "0";

                                    //Si el componente no tiene diametro, ni espesor, ni altura, ni DN, es decir si es una junta
                                    if (Componente.Diametro == null && Componente.Perfil != null && Componente.Espesor == null && Componente.Altura == null && Componente.DiametroNominal == null && !Regex.IsMatch(CantidadRequerida, "[a-zA-Z]"))
                                    {
                                        //var LargoRequerido= item.
                                      

                                        var TotalInsumosStock = Decimal.Parse(item.Total, CultureInfo.InvariantCulture);
                                        var LongitudInsumo = Componente.Longitud;
                                        var _CantidadRequerida = Decimal.Parse(CantidadRequerida, CultureInfo.InvariantCulture);
                                        var LongitudNecesaria = _CantidadRequerida * Producto.Cantidad;
                                        var InsumosNecesarios = LongitudNecesaria / LongitudInsumo;
                                        var UnidadAlternativa = (Fraction)InsumosNecesarios;

                                        item.GetType().GetProperty(propiedad.Name)?
                                         .SetValue(item, item.GetType().GetProperty(propiedad.Name)?.GetValue(item)
                                         + SiglaFraccionamiento + " - " + UnidadAlternativa +" "+ SiglaAlmacenamiento);

                                    }
                                    else if (!Regex.IsMatch(CantidadRequerida, "[a-zA-Z]"))
                                    {
                                        decimal? PesoComponente = Componente.Peso;
                                     
                                        if (PesoComponente == null) PesoComponente = 0;

                                        var UnidadAlternativa = ((Decimal.Parse(CantidadRequerida, CultureInfo.InvariantCulture) * PesoComponente) * Producto.Cantidad);
                                        
                                        UnidadAlternativa = Math.Round((decimal)UnidadAlternativa,1);

                                        if (UnidadAlternativa > 0)
                                        {
                                            item.GetType().GetProperty(propiedad.Name)?
                                            .SetValue(item, item.GetType().GetProperty(propiedad.Name)?.GetValue(item)
                                            + " " + SiglaFraccionamiento + " - " + UnidadAlternativa + " " + SiglaAlmacenamiento);
                                        }
                                        else
                                        {
                                            item.GetType().GetProperty(propiedad.Name)?
                                            .SetValue(item, item.GetType().GetProperty(propiedad.Name)?.GetValue(item)
                                            + " " + SiglaFraccionamiento);
                                        }

                                    }
                                }
                                else
                                {
                                    item.GetType().GetProperty(propiedad.Name)?
                                  .SetValue(item, item.GetType().GetProperty(propiedad.Name)?.GetValue(item)
                                  + " " + SiglaAlmacenamiento);
                                }
                            }
                            else
                            {
                                item.GetType().GetProperty(propiedad.Name)?
                                  .SetValue(item, item.GetType().GetProperty(propiedad.Name)?.GetValue(item)
                                  + " " + SiglaAlmacenamiento);
                            }                           
                         
                            
                        }
                        
                    }


                }
            }

            string ? IdProd = ComponentesProducto.Select(x => x.idProducto).FirstOrDefault();
            
            var result = new
            {
                idProducto = IdProd,
                Componentes = productos
            };

            return new JsonResult(result);





        }
    }
}
