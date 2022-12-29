using Aponus_Web_API.Mapping;
using Aponus_Web_API.Models;

namespace Aponus_Web_API.Services
{
    public class ObtenerInsumos
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerInsumos() { AponusDBContext = new AponusContext(); }
        public List<InsumosPesables> ObtenterPesables(string ProductId)
        {
            List<InsumosPesables> LstInsumosPesables = new List<InsumosPesables>();
            string _Descripcion;

            var InsumosPesables = 

                AponusDBContext.ComponentesPesables
                    .Join(AponusDBContext.PesablesDetalles,
                        _ComponentesPesables => _ComponentesPesables.IdComponente,
                        _PesablesDetalle => _PesablesDetalle.IdComponente,
                        (_ComponentesPesables, _PesablesDetalle) => new
                        {
                            _ComponentesPesables.IdProducto,
                            _ComponentesPesables.Peso,
                            _PesablesDetalle.IdDescripcion,
                            _PesablesDetalle.IdComponente,
                            _PesablesDetalle.Diametro,
                            _PesablesDetalle.Altura
                        })
                    .Join(AponusDBContext.StockPesables,
                        _ComponentesPesables_PesablesDetalle => _ComponentesPesables_PesablesDetalle.IdComponente,
                        _StockPesables => _StockPesables.IdComponente,
                        (_ComponenetesPesables_Pesables_Detalle, _StockPesables) => new
                        {
                            _ComponenetesPesables_Pesables_Detalle.IdProducto,
                            _ComponenetesPesables_Pesables_Detalle.IdComponente,
                            _ComponenetesPesables_Pesables_Detalle.IdDescripcion,
                            _ComponenetesPesables_Pesables_Detalle.Peso,
                            _ComponenetesPesables_Pesables_Detalle.Altura,
                            _StockPesables.CantidadRecibido,
                            _StockPesables.CantidadPintura,
                            _StockPesables.CantidadProceso
                        })
                    .Join(AponusDBContext.ComponentesDescripcions,
                    _ComponentesPesables_PesablesDetalle_SotckPesables => _ComponentesPesables_PesablesDetalle_SotckPesables.IdDescripcion,
                    _ComponentesDescripcion => _ComponentesDescripcion.IdDescripcion,
                    (_ComponentesPesables_PesablesDetalle_SotckPesables, _ComponentesDescripcion) => new
                    {
                        _ComponentesPesables_PesablesDetalle_SotckPesables,
                        _ComponentesDescripcion
                    })

                    .Where(x => x._ComponentesPesables_PesablesDetalle_SotckPesables.IdProducto == ProductId)
                    .Select(
                        Pesables => new
                        {
                            Pesables._ComponentesPesables_PesablesDetalle_SotckPesables.IdProducto,
                            Pesables._ComponentesDescripcion.Descripcion,
                            Pesables._ComponentesPesables_PesablesDetalle_SotckPesables.Altura,
                            Pesables._ComponentesPesables_PesablesDetalle_SotckPesables.Peso,
                            Pesables._ComponentesPesables_PesablesDetalle_SotckPesables.CantidadRecibido,
                            Pesables._ComponentesPesables_PesablesDetalle_SotckPesables.CantidadPintura,
                            Pesables._ComponentesPesables_PesablesDetalle_SotckPesables.CantidadProceso
                        }).ToList();


            foreach (var queryResult in InsumosPesables)
            {

                if (queryResult.Descripcion != "BULON" && queryResult.Descripcion != null)
                {
                    _Descripcion = queryResult.Descripcion.ToString();
                }
                else
                {
                    _Descripcion = queryResult.Descripcion + " " + String.Format("{0:####}", queryResult.Altura) + " mm";
                }

                LstInsumosPesables.Add(new InsumosPesables()
                {
                    NombreInsumo = _Descripcion,
                    PesoRequerido = queryResult.Peso + " Kg",
                    CantidadRecibida = queryResult.CantidadRecibido + " Kg",
                    CantidadPintura = queryResult.CantidadPintura + " Kg",
                    CantidadProceso = queryResult.CantidadProceso + " Kg"
                });
            }
            return LstInsumosPesables;
        }
    }
}