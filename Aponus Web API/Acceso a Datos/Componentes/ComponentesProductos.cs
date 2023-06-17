using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Aponus_Web_API.Data_Transfer_Objects;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace Aponus_Web_API.Acceso_a_Datos.Componentes
{
    public class ComponentesProductos
    {
        private readonly AponusContext AponusDbContext;
        public ComponentesProductos() { AponusDbContext = new AponusContext(); }
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

        internal JsonResult ObtenerComponentesProducto(DTODetallesProducto Producto)
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
                            _IdComponente =_JoinResult._DetComponentes._Componentes.IdComponente ?? "" ,
                            _Descripcion=_JoinResult._NombreComponentes.Descripcion ??  "",
                            _Diametro=_JoinResult._DetComponentes._DetalleComponentes.Diametro ?? null,
                            _Longitud=_JoinResult._DetComponentes._DetalleComponentes.Longitud ?? null,
                            _Altura=_JoinResult._DetComponentes._DetalleComponentes.Altura ?? null,
                            _Espesor=_JoinResult._DetComponentes._DetalleComponentes.Espesor ?? null,
                            _Perfil=_JoinResult._DetComponentes._DetalleComponentes.Perfil ?? null,
                            _Tolerancia=_JoinResult._DetComponentes._DetalleComponentes.Tolerancia ?? "",
                            _DiametroNominal=_JoinResult._DetComponentes._DetalleComponentes.DiametroNominal ?? null,
                            _Largo = _JoinResult._DetComponentes._Componentes.Longitud ?? null,


                            StockComponente = new NewStocks
                            {
                                IdInsumo = _StockComponentes.IdInsumo,
                                Recibido = _StockComponentes.CantidadRecibido ?? 0,
                                Granallado = _StockComponentes.CantidadGranallado ?? 0,
                                Pintura = _StockComponentes.CantidadPintura ?? 0,
                                Proceso = _StockComponentes.CantidadProceso ?? 0,
                                Moldeado = _StockComponentes.CantidadMoldeado ?? 0,

                                Total = (_StockComponentes.CantidadPintura ?? 0) +
                                        (_StockComponentes.CantidadMoldeado ?? 0) +
                                        (_StockComponentes.CantidadRecibido ?? 0) +
                                        (_StockComponentes.CantidadProceso ?? 0) +
                                        (_StockComponentes.CantidadGranallado ?? 0),

                                PesoReq=(_JoinResult._DetComponentes._Componentes.Peso ?? 0) *Producto.Cantidad ,
                                CantidadReq= (_JoinResult._DetComponentes._Componentes.Cantidad?? 0) * Producto.Cantidad,
                                LongReq= (_JoinResult._DetComponentes._Componentes.Longitud?? 0) * Producto.Cantidad,
                                

                            }
                        })
                    .GroupBy(cp => new
                    { 
                        cp._IdComponente, 
                        cp._Descripcion,
                        cp._Longitud,
                        cp._Perfil,
                        cp._DiametroNominal,
                        cp._Altura,
                        cp._Espesor,
                        cp._Largo,
                        cp._Diametro,
                        cp._Tolerancia })

                    .Select(group => new
                    {
                        IdComponente = group.Key._IdComponente,
                        Descripcion = group.Key._Descripcion, 
                        Perfil = group.Key._Perfil,
                        Longitud = group.Key._Longitud,
                        DiametroNominal=group.Key._DiametroNominal,
                        Altura=group.Key._Altura,
                        Largo=group.Key._Largo,
                        Diametro=group.Key._Diametro,
                        Espesor = group.Key._Espesor,
                        Tolerancia=group.Key._Tolerancia,
                        StockComponente = group.Select(cp => cp.StockComponente).ToList(),

                    })
                    .ToList();





            List<DTOProductoComponente> productos = new List<DTOProductoComponente>();

            foreach (var cp in ComponentesProducto)
            {
                string? IdComponente = cp.IdComponente ?? "";
                string? descripcion = cp.Descripcion ?? "";
                string? diametro = cp.Diametro != null ? string.Format("{0:####}", cp.Diametro) : null;
                string? longitud = cp.Longitud != null ? string.Format("{0:####}", cp.Longitud) : null;
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
                if (tolerancia != "")
                    sb.Append($", Tolerancia:{tolerancia}");
                if (DiametroNominal != "")
                    sb.Append($", DN:{DiametroNominal}mm");

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
                    StockComponente = cp.StockComponente
                };

                productos.Add(productoComponente);
            }

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

                foreach (var item in producto.StockComponente)
                {
                    if (item.Recibido == 0) item.Recibido= null;                   
                    if (item.Granallado== 0) item.Granallado= null;                   
                    if (item.Pintura== 0) item.Pintura= null;                   
                    if (item.Proceso== 0) item.Proceso = null;                   
                    if (item.Moldeado== 0) item.Moldeado= null;                   

                    if (item.Total== 0) item.Total= null;                   

                    if (item.PesoReq== 0) item.PesoReq= null;                   
                    if (item.CantidadReq== 0) item.CantidadReq= null;                   
                    if (item.LongReq== 0) item.LongReq= null;                   
                                    
                }
            }


            return new JsonResult(productos);





        }
    }
}
