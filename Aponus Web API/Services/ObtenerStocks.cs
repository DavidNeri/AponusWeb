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

                List<DetallePesables> pesables = await AponusDBContext.PesablesDetalles
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
                    }).Select(x=> new DetallePesables { 
                        IdDescripcion=x.IdDescripcion,
                        Altura=x.Altura,    
                        Diametro=x.Diametro,    
                        Pintura=x.CantidadPintura,
                        Proceso=x.CantidadProceso,
                        Recibido=x.CantidadRecibido,
                    }).ToListAsync();

                List<DetalleCuantitativos> cuantitativos = await AponusDBContext.CuantitativosDetalles
                  .Join(AponusDBContext.StockCuantitativos,
                  CD => CD.IdComponente, SC => SC.IdComponente,
                  (CD, SC) => new
                  {
                      CD.IdDescripcion,
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
                  }).Select(x => new DetalleCuantitativos
                  {
                      IdDescripcion = x.IdDescripcion,
                      Diametro = x.Diametro,
                      Altura = x.Altura,
                      ToleranciaMimina = x.ToleranciaMinima,
                      ToleranciaMaxima = x.ToleranciaMaxima,
                      Perfil=x.Perfil,
                      Espesor = x.Espesor,
                      Recibido = x.CantidadRecibido,
                      Granallado = x.CantidadGranallado,
                      Pintura = x.CantidadPintura,
                      Moldeado=x.CantidadMoldeado,  
                      Proceso = x.CantidadProceso,

                  }).ToListAsync();

                List<DetalleMensurables> Mensurables = await AponusDBContext.MensurablesDetalles
                  .Join(AponusDBContext.StockCuantitativos,
                  MD => MD.IdComponente, SM => SM.IdComponente,
                  (MD, SM) => new
                  {
                      MD.IdDescripcion,
                      MD.Largo,                   
                      MD.Espesor,
                      MD.Perfil,
                      SM.CantidadRecibido, 
                      SM.CantidadProceso
                  }).Select(x => new DetalleMensurables
                  {
                      IdDescripcion = x.IdDescripcion,
                      Espesor= x.Espesor,
                      Largo= x.Largo,   
                      Perfil= x.Perfil,
                      Proceso= x.CantidadProceso,   
                      Recibido= x.CantidadRecibido,
                     

                  }).ToListAsync();

                foreach (TipoInsumos _Insumos in Stocks) 
                {
                    foreach (DetallePesables _Pesables in pesables)
                    {
                        if (_Pesables.IdDescripcion == _Insumos.IdDescripcion  )
                        {
                            if (_Insumos.Pesables == null)
                            {
                                _Insumos.Pesables = new List<DetallePesables>();
                            }                           

                            _Insumos.Pesables.Add(_Pesables);
                        }
                    }

                    foreach (DetalleCuantitativos _Cuantitativos in cuantitativos)
                    {
                        if (_Cuantitativos.IdDescripcion == _Insumos.IdDescripcion)
                        {
                            if (_Insumos.Cuantitativos == null)
                            {
                                _Insumos.Cuantitativos = new List<DetalleCuantitativos>();
                            }

                            _Insumos.Cuantitativos.Add(_Cuantitativos);
                        }
                    }

                    foreach (DetalleMensurables _Mensurables in Mensurables)
                    {
                        if (_Mensurables.IdDescripcion == _Insumos.IdDescripcion)
                        {
                            if (_Insumos.Mensurables == null)
                            {
                                _Insumos.Mensurables = new List<DetalleMensurables>();
                            }

                            _Insumos.Mensurables.Add(_Mensurables);
                        }
                    }


                }
                
                return Stocks;
            }
            catch (Exception)
            {

                throw;
            }
            

            //List <InsumosPesables> _InsumosPesables  =
            

            List<DetalleCuantitativos> _Insumos_Cuantitativos = await AponusDBContext.CuantitativosDetalles
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
                    ToleranciaMimina=x.ToleranciaMinima,
                    ToleranciaMaxima=x.ToleranciaMaxima,
                    Perfil=x.Perfil,
                    Espesor=x.Espesor,
                    Recibido=x.CantidadRecibido,
                    Granallado=x.CantidadGranallado,
                    Pintura=x.CantidadPintura,
                    Moldeado=x.CantidadMoldeado,
                    Proceso=x.CantidadProceso

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
                   Recibido = x.CantidadRecibido,
                   Proceso = x.CantidadProceso                

               }).ToListAsync();


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
