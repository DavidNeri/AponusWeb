using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Utilidades;
using Aponus_Web_API.Utilidades.ReportResult;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace Aponus_Web_API.Negocio
{
    public class BS_Dashboard
    {
        private readonly BS_Ventas BsVentas;
        private readonly BS_Stocks BsStocks;
        private readonly BS_Productos BsProductos;
        private readonly BS_Componentes BsComponentes;
        private readonly AD_Ventas ADVentas;

        public BS_Dashboard(BS_Ventas _BsVentas, BS_Stocks _BsStocks, BS_Productos _BSProductos, BS_Componentes _BsComponentes, AD_Ventas _AdVentas)
        {
            BsVentas = _BsVentas;
            BsStocks = _BsStocks;
            BsProductos = _BSProductos;
            BsComponentes = _BsComponentes;
            ADVentas = _AdVentas;
        }

        internal async Task<IActionResult> ProcesarInsumosFaltantesTablero(int idDescripcion)
        {
            var InsumosFaltantes = await BsStocks.ObentenerInsumosFaltantes(idDescripcion);
            IReportResult InsumosRowList = new();
            
            var PropidadesInsumos = InsumosFaltantes.FirstOrDefault()?.GetType().GetProperties();
            
            var Columnas = PropidadesInsumos?.Where(p => InsumosFaltantes.All(x =>
            {
                var valor = p.GetValue(x);
                var nombre = p.Name;
                return
                    valor != null
                    && !nombre.Contains("IdFraccionamiento")
                    && !nombre.Contains("IdAlmacenamiento")
                    && !nombre.Contains("IdEstado")
                    && !nombre.Contains("IdDescripcion")
                    && !nombre.Contains("Navigation");

            }))
            .Select(p => p.Name)
            .ToList();

            InsumosFaltantes.ForEach(insumo =>
            {
                InsumosRowList.rowList.Add(new RowList()
                {
                    idInsumo = insumo.IdInsumo ?? "",
                    cellList = insumo.GetType().GetProperties()
                    .Where(y => Columnas == null || Columnas.Contains(y.Name))
                    .Select(p => new CelList()
                    {
                        header = p.Name,
                        type = BsComponentes.ObtenerTipoValor(p.PropertyType),
                        value = p.GetValue(insumo)?.ToString() ?? ""
                    }).ToList()

                });
            });

            InsumosRowList.rowList.ForEach(row =>
            {
                row.cellList.Add(new CelList()
                {
                    type = "button",
                    value = row.idInsumo,
                    header = "Acciones"
                });
            });
            
            return new JsonResult(InsumosRowList);
        }

        internal IActionResult ProcesarProductosFaltantesTablero()
        {
            var ProductosFaltantes = BsProductos.ObtenerProductosFaltantes();
            var Productos = ProductosFaltantes
                .Where(x => x.Cantidad <= 100)
                .Select(y => new
                {
                    id= y.IdProducto,
                    cantidad = y.Cantidad,
                    tolerancia = y.Tolerancia,
                    precioLista = y.PrecioLista,
                    diametroNominal = y.DiametroNominal,
                    tipo = y.IdTipoNavigation.DescripcionTipo,
                    descripcion = y.IdDescripcionNavigation.DescripcionProducto
                }).ToList();

            return new JsonResult(Productos);

        }

        internal IActionResult ProcesarVentasMensuales()
        {
            IQueryable<Ventas> QueryVentas = ADVentas.ListarVentas();
            List<Ventas> ListaVentas = QueryVentas.ToList();
            //IReportResult reportResult = new();

            var Agrupadas = ListaVentas
                .GroupBy(x=> new
                {
                    Mes = x.FechaHora.ToString("MMMM"),
                    x.FechaHora.Month,
                    x.FechaHora.Year,

                })
                .OrderBy(x => x.Key.Year)
                .ThenBy(x => x.Key.Month)
                .Select(x=>new
                {
                    x.Key.Mes,
                    Año = x.Key.Year,
                    montoTotal= x.Sum(y=>y.MontoTotal),
                    cantidad = x.Count()

                })
                .ToList();

            List<(string mes , string cantidad)> ListadoCatidadVentas = new();
         
             foreach (var item in Agrupadas)
                {
                    ListadoCatidadVentas.Add((
                        mes: $"{item.Mes} {item.Año}",
                        cantidad: item.cantidad.ToString()
                    ));
                }

            var resultado = ListadoCatidadVentas.Select(x => new
            {
                Month = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.mes),
                Ventas = x.cantidad
            }).ToList();


            //foreach (var x in Agrupadas)
            //{
            //    reportResult.rowList.Add(new RowList()
            //    {
            //        cellList = x.GetType().GetProperties().Select(p => new CelList()
            //        {
            //            header = p.Name,
            //            type = BsComponentes.ObtenerTipoValor(p.PropertyType),
            //            value = p.GetValue(x)?.ToString() ?? ""
            //        }).ToList()
            //    });
            //}



            return new JsonResult(resultado);
        }

        internal async Task<IActionResult> ProcesarVentasPendientesTablero()
        {
            List<Ventas> VentasPendientes = await BsVentas.ObtenerVentasPendientesEntrega();
            
            var Ventas = VentasPendientes.Select(x => new
            {
                id =  x.IdVenta,
                cliente = !string.IsNullOrEmpty(x.Cliente.NombreClave) ? x.Cliente.NombreClave : $"{x.Cliente.Apellido}, {x.Cliente.Nombre}",
                fecha = x.FechaHora,
                usuario = x.IdUsuario,
                montoTotal = x.MontoTotal,
                saldoPendiente = x.SaldoPendiente,
                estado = x.Estado.Descripcion

            }).ToList();

            return new JsonResult(Ventas);

        }
    }
}
