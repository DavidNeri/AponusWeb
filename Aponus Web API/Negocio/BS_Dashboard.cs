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

        internal async Task<IActionResult> ProcesarDatosTablero()
        {
            List<Ventas> VentasPendientes = await BsVentas.ObtenerVentasPendientesEntrega();
            List<IReportResult> Insumos = new();
            var InsumosFaltantes = await BsStocks.ObentenerInsumosFaltantes();
            var ProductosFaltantes = BsProductos.ObtenerProductosFaltantes();
            var InsumosAgrupados = InsumosFaltantes.GroupBy(x => x.Nombre).ToList();

            var Ventas = VentasPendientes.Select(x => new
            {
                cliente = !string.IsNullOrEmpty(x.Cliente.NombreClave) ? x.Cliente.NombreClave : $"{x.Cliente.Apellido}, {x.Cliente.Nombre}",
                fecha = x.FechaHora,
                usuario = x.Usuario,
                montoTotal = x.MontoTotal,
                saldoPendiente = x.SaldoPendiente,
                estado = x.Estado.Descripcion

            }).ToList();

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


            foreach (var insumo in InsumosAgrupados)
            {
                IReportResult GrupoInsumosRowList = new();

                var GrupoInsumos = InsumosFaltantes.Where(x => x.Nombre == insumo.Key).ToList();
                var PropidadesGrupoInsumos = GrupoInsumos.FirstOrDefault()?.GetType().GetProperties();

                var Columnas = PropidadesGrupoInsumos?.Where(p => GrupoInsumos.All(x =>
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



                GrupoInsumos.ForEach(insumo =>
                {
                    GrupoInsumosRowList.rowList.Add(new RowList()
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

                GrupoInsumosRowList.rowList.ForEach(row =>
                {
                    row.cellList.Add(new CelList()
                    {
                        type = "button",
                        value = row.idInsmo,
                        header = "Acciones"
                    });
                });

                Insumos.Add(GrupoInsumosRowList);
            }

            return new JsonResult(new
            {
                Ventas,
                Insumos,
                Productos,
            });

        }
    }
}
