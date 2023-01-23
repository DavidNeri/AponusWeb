using Aponus_Web_API.Mapping;
using Aponus_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Services
{
    public class ObtenerStocks
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerStocks() { AponusDBContext = new AponusContext(); }
        public async  Task<List<TipoInsumos>>Listar() 
        {

            try
            {
                List<TipoInsumos> Stocks = await
           AponusDBContext.ComponentesDescripcions
               .Select(
                x => new TipoInsumos
                {
                    IdDescripcion = x.IdDescripcion,
                    Descripcion = x.Descripcion,
                }
               )
               .ToListAsync();

                List<EspecificacionesComponentes> ComponentesPesables = await AponusDBContext.PesablesDetalles
                    .Join(AponusDBContext.StockPesables,
                    PD=>PD.IdComponente,SP=>SP.IdComponente,
                    (PD,SP)=> new
                    {
                        PD.IdDescripcion,
                        PD.Diametro,
                        PD.Altura,
                        SP.CantidadRecibido,
                        SP.CantidadPintura,
                        SP.CantidadProceso
                    }).Select(x=> new EspecificacionesComponentes
                    { 
                        IdDescripcion=x.IdDescripcion,
                        Altura=x.Altura,    
                        Diametro=x.Diametro,    
                        Pintura=x.CantidadPintura.ToString(),
                        Proceso=x.CantidadProceso.ToString(),
                        Recibido=x.CantidadRecibido.ToString(),
                    }).ToListAsync();

                List<EspecificacionesComponentes> ComponentesCuantitativos = await AponusDBContext.CuantitativosDetalles
                  .Join(AponusDBContext.StockCuantitativos,
                  CD => CD.IdComponente, SC => SC.IdComponente,
                  (CD, SC) => new
                  {
                      CD.IdDescripcion,
                      CD.IdComponente,
                      CD.Diametro,
                      CD.Altura,
                      CD.ToleranciaMaxima,
                      CD.ToleranciaMinima,
                      CD.Perfil,
                      CD.Espesor,                      
                      SC.CantidadRecibido,
                      SC.CantidadGranallado,
                      SC.CantidadPintura,
                      SC.CantidadMoldeado,
                      SC.CantidadProceso
                  }).Select(x => new EspecificacionesComponentes
                  {
                      IdDescripcion = x.IdDescripcion,
                      Idinsumo=x.IdComponente,
                      Diametro = x.Diametro,
                      Altura = x.Altura,
                      ToleranciaMinina = x.ToleranciaMinima,
                      ToleranciaMaxima = x.ToleranciaMaxima,
                      Perfil=x.Perfil,
                      Espesor = x.Espesor,
                      Recibido = x.CantidadRecibido.ToString(),
                      Granallado = x.CantidadGranallado.ToString(),
                      Pintura = x.CantidadPintura.ToString(),
                      Moldeado=x.CantidadMoldeado.ToString(),  
                      Proceso = x.CantidadProceso.ToString(),

                  }).ToListAsync();

                List<EspecificacionesComponentes> ComponentesMensurables = await AponusDBContext.MensurablesDetalles
                  .Join(AponusDBContext.StockMensurables,
                  MD => MD.IdComponente, SM => SM.IdComponente,
                  (MD, SM) => new
                  {
                      MD.IdDescripcion,
                      MD.IdComponente,
                      MD.Largo,                   
                      MD.Espesor,
                      MD.Perfil,
                      SM.CantidadRecibido, 
                      SM.CantidadProceso
                  }).Select(x => new EspecificacionesComponentes
                  {
                      IdDescripcion = x.IdDescripcion,
                      Idinsumo=x.IdComponente,
                      Espesor= x.Espesor,
                      Largo= x.Largo,   
                      Perfil= x.Perfil,
                      Proceso= x.CantidadProceso.ToString(),   
                      Recibido= x.CantidadRecibido.ToString(),
                     

                  }).ToListAsync();

                foreach (TipoInsumos _Insumos in Stocks) 
                {
                    foreach (EspecificacionesComponentes _Pesables in ComponentesPesables)
                    {
                        if (_Pesables.IdDescripcion == _Insumos.IdDescripcion  )
                        {
                            if (_Insumos.Especificaciones == null)
                            {
                                _Insumos.Especificaciones = new List<EspecificacionesComponentes>();
                            }                           

                            _Insumos.Especificaciones.Add(_Pesables);
                        }
                    }

                    foreach (EspecificacionesComponentes _Cuantitativos in ComponentesCuantitativos)
                    {
                        if (_Cuantitativos.IdDescripcion == _Insumos.IdDescripcion)
                        {
                            if (_Insumos.Especificaciones == null)
                            {
                                _Insumos.Especificaciones = new List<EspecificacionesComponentes>();
                            }

                            _Insumos.Especificaciones.Add(_Cuantitativos);
                        }
                    }

                    foreach (EspecificacionesComponentes _Mensurables in ComponentesMensurables)
                    {
                        if (_Mensurables.IdDescripcion == _Insumos.IdDescripcion)
                        {
                            if (_Insumos.Especificaciones == null)
                            {
                                _Insumos.Especificaciones = new List<EspecificacionesComponentes>();
                            }

                            _Insumos.Especificaciones.Add(_Mensurables);
                        }
                    }


                }
                Stocks.OrderBy(x => x.Descripcion)
                    .ThenBy(x=>x.Diametro)
                    .ThenBy(x=>x.ToleranciaMinina)
                    .ThenBy(x => x.ToleranciaMaxima)
                    .ThenBy(x=>x.Perfil)
                    .ThenBy(x=>x.Largo);
                
                return Stocks;
            }
            catch (Exception)
            {

                throw;
            }
            

            //List <InsumosPesables> _InsumosPesables  =
            

           /* List<DetalleCuantitativos> _Insumos_Cuantitativos = await AponusDBContext.CuantitativosDetalles
                .Join(AponusDBContext.StockCuantitativos,
                _CuantitativosDetalle=>_CuantitativosDetalle.IdComponente,
                _StockCuantitativos=>_StockCuantitativos.IdComponente,
                (_CuantitativosDetalle, _StockCuantitativos)=> new 
                { 
                   // _CuantitativosDetalle.IdComponente,
                    _CuantitativosDetalle.IdDescripcion,
                    _CuantitativosDetalle.Diametro,
                    _CuantitativosDetalle.Altura,
                    _CuantitativosDetalle.ToleranciaMinima,
                    _CuantitativosDetalle.ToleranciaMaxima,
                    _CuantitativosDetalle.Perfil,
                    _CuantitativosDetalle.Espesor,
                    _StockCuantitativos.CantidadRecibido,
                    _StockCuantitativos.CantidadGranallado,
                    _StockCuantitativos.CantidadPintura,
                    _StockCuantitativos.CantidadMoldeado,
                    _StockCuantitativos.CantidadProceso
                })
                .Select(x=> new DetalleCuantitativos 
                {
                    IdDescripcion=x.IdDescripcion,
                    Diametro=x.Diametro,
                    Altura=x.Altura,
                    ToleranciaMinina=x.ToleranciaMinima,
                    ToleranciaMaxima=x.ToleranciaMaxima,
                    Perfil=x.Perfil,
                    Espesor=x.Espesor,
                    Recibido=x.CantidadRecibido.ToString(),
                    Granallado=x.CantidadGranallado.ToString(),
                    Pintura=x.CantidadPintura.ToString(),
                    Moldeado=x.CantidadMoldeado.ToString(),
                    Proceso=x.CantidadProceso.ToString()

                }).ToListAsync();

            List<DetalleMensurables> _Insumos_Mensurables= await AponusDBContext.MensurablesDetalles
               .Join(AponusDBContext.StockMensurables,
               _MensurablesDetalle => _MensurablesDetalle.IdComponente,
               _StockMensurables => _StockMensurables.IdComponente,
               (_MensurablesDetalle, _StockMensurables) => new
               {
                   _MensurablesDetalle.IdDescripcion,
                   _MensurablesDetalle.Largo,
                   _MensurablesDetalle.Espesor,
                   _MensurablesDetalle.Perfil,                   
                   _StockMensurables.CantidadRecibido,
                   _StockMensurables.CantidadProceso,
               })
               .Select(x => new DetalleMensurables
               {
                   IdDescripcion = x.IdDescripcion,
                   Largo = x.Largo,
                   Espesor = x.Espesor,
                   Perfil = x.Perfil,
                   Recibido = x.CantidadRecibido.ToString(),
                   Proceso = x.CantidadProceso.ToString()                  

               }).ToListAsync();
           */

          /*  foreach (TipoInsumos tipo in _TipoInsumos)
            {

                foreach (InsumosPesables _insumos_Soportes in _InsumosPesables)
                {
                    if (_insumos_Soportes.IdDescripcion==tipo.IdDescripcion)
                    {
                        tipo.Pesables = new List<InsumosPesables>();
                        tipo.Pesables.AddRange(_InsumosPesables.Where(x => x.IdDescripcion == tipo.IdDescripcion));
                    }
                 

                }

                foreach (Insumos_Cuantitativos _insumos_Cuantitativos in _Insumos_Cuantitativos)
                {
                    if (_insumos_Cuantitativos.IdDescripcion == tipo.IdDescripcion)
                    {
                        tipo.DetalleCuantitativos = new List<Insumos_Cuantitativos>();
                        tipo.DetalleCuantitativos.AddRange(_Insumos_Cuantitativos.Where(x => x.IdDescripcion == tipo.IdDescripcion));
                    }

                }

                foreach (Insumos_Mensurables _insumos_Mensurables in _Insumos_Mensurables)
                {
                    if (_insumos_Mensurables.IdDescripcion == tipo.IdDescripcion)
                    {
                        tipo.DetalleMensurables = new List<Insumos_Mensurables>();
                        tipo.DetalleMensurables.AddRange(_Insumos_Mensurables.Where(x => x.IdDescripcion == tipo.IdDescripcion));
                    }

                }


            }
          */
           

        }
    }
}
