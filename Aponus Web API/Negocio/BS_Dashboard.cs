using Aponus_Web_API.Modelos;
using Aponus_Web_API.Utilidades.ReportResult;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Negocio
{
    public class BS_Dashboard
    {
        private readonly BS_Ventas BsVentas;
        private readonly BS_Stocks BsStocks;
        private readonly BS_Productos BsProductos;
        private readonly BS_Componentes BsComponentes;

        public BS_Dashboard(BS_Ventas _BsVentas, BS_Stocks _BsStocks, BS_Productos _BSProductos, BS_Componentes _BsComponentes)
        {
            BsVentas = _BsVentas;
            BsStocks = _BsStocks;
            BsProductos = _BSProductos;
            BsComponentes = _BsComponentes;
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
                    idInsmo = insumo.IdInsumo ?? "",
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
                    value = row.idInsmo,
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
                    cantidad = y.Cantidad,
                    tolerancia = y.Tolerancia,
                    precioLista = y.PrecioLista,
                    diametroNominal = y.DiametroNominal,
                    tipo = y.IdTipoNavigation.DescripcionTipo,
                    descripcion = y.IdDescripcionNavigation.DescripcionProducto
                }).ToList();

            return new JsonResult(Productos);

        }

        internal async Task<IActionResult> ProcesarVentasPendientesTablero()
        {
            List<Ventas> VentasPendientes = await BsVentas.ObtenerVentasPendientesEntrega();
            
            var Ventas = VentasPendientes.Select(x => new
            {
                cliente = !string.IsNullOrEmpty(x.Cliente.NombreClave) ? x.Cliente.NombreClave : $"{x.Cliente.Apellido}, {x.Cliente.Nombre}",
                fecha = x.FechaHora,
                usuario = x.Usuario.Usuario,
                montoTotal = x.MontoTotal,
                saldoPendiente = x.SaldoPendiente,
                estado = x.Estado.Descripcion

            }).ToList();

            return new JsonResult(Ventas);

        }
    }
}
