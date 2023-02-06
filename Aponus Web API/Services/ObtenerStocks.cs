using Aponus_Web_API.Mapping;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Linq;

namespace Aponus_Web_API.Services
{
    public class ObtenerStocks
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerStocks() { AponusDBContext = new AponusContext(); }

        public async Task<List<TipoInsumos>> ListarTipoInsumos()
        {
            List<TipoInsumos> TipoInsumos = await
          AponusDBContext.ComponentesDescripcions
              .Select(
               x => new TipoInsumos
               {
                   IdDescripcion = x.IdDescripcion,
                   Descripcion = x.Descripcion,
               }
              )
              .ToListAsync();
            return TipoInsumos;

        }


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
                  })
                        
                  
                  .Select(x => new EspecificacionesComponentes
                  {
                      IdDescripcion = x.IdDescripcion,
                      idComponente=x.IdComponente,
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
                      MD.Ancho,
                      MD.Espesor,
                      MD.Perfil,
                      SM.CantidadRecibido, 
                      SM.CantidadProceso
                  }).Select(x => new EspecificacionesComponentes
                  {
                      IdDescripcion = x.IdDescripcion,
                      idComponente=x.IdComponente,
                      Espesor= x.Espesor,
                      Largo=  Decimal.Round((decimal)(x.Largo/1000),2,MidpointRounding.AwayFromZero),
                      Ancho= x.Ancho,
                      Perfil= x.Perfil,
                      Proceso= x.CantidadProceso.ToString()
                     

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
                            EspecificacionesComponentes especificaciones =
                                ComponentesPesables.Where(especificaciones => especificaciones.IdDescripcion
                                == _Pesables.IdDescripcion).Select(x => new EspecificacionesComponentes
                                {
                                    IdDescripcion = x.IdDescripcion,
                                    Moldeado = x.Moldeado,
                                    Proceso = x.Proceso,
                                    Pintura = x.Pintura,
                                    Altura = x.Altura,
                                    Ancho = x.Ancho,
                                    Diametro = x.Diametro,
                                    Espesor = x.Espesor,
                                    Faltantes = x.Faltantes,
                                    Granallado = x.Granallado,
                                    idComponente = x.idComponente,
                                    Largo = x.Largo,
                                    Perfil = x.Perfil,
                                    Recibido = x.Recibido,
                                    Requerido = x.Requerido,
                                    ToleranciaMaxima = x.ToleranciaMaxima,
                                    ToleranciaMinina = x.ToleranciaMinina,
                                    Total = x.Total
                                }).First();

                            _Insumos.Columnas = new ColumnasJson().setColumnas(new ColumnasInsumosPesables(),null,null,especificaciones);

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

                            EspecificacionesComponentes especificaciones =
                                ComponentesCuantitativos.Where(especificaciones => especificaciones.IdDescripcion
                                == _Cuantitativos.IdDescripcion).Select(x => new EspecificacionesComponentes
                                {
                                    IdDescripcion = x.IdDescripcion,
                                    Moldeado = x.Moldeado,
                                    Proceso = x.Proceso,
                                    Pintura = x.Pintura,
                                    Altura = x.Altura,
                                    Ancho = x.Ancho,
                                    Diametro = x.Diametro,
                                    Espesor = x.Espesor,
                                    Faltantes = x.Faltantes,
                                    Granallado = x.Granallado,
                                    idComponente = x.idComponente,
                                    Largo = x.Largo,
                                    Perfil = x.Perfil,
                                    Recibido = x.Recibido,
                                    Requerido = x.Requerido,
                                    ToleranciaMaxima = x.ToleranciaMaxima,
                                    ToleranciaMinina = x.ToleranciaMinina,
                                    Total = x.Total
                                }).First();

                            _Insumos.Columnas = new ColumnasJson().setColumnas(
                                null, new ColumnasInsumosCuantitativos(), null, especificaciones);


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

                            EspecificacionesComponentes especificaciones = ComponentesMensurables
                                .Where(x => x.IdDescripcion==_Mensurables.IdDescripcion)
                                .Select(x => new EspecificacionesComponentes 
                                {
                                    IdDescripcion = x.IdDescripcion,
                                    Moldeado = x.Moldeado,
                                    Proceso = x.Proceso,
                                    Pintura = x.Pintura,
                                    Altura = x.Altura,
                                    Ancho = x.Ancho,
                                    Diametro = x.Diametro,
                                    Espesor = x.Espesor,
                                    Faltantes = x.Faltantes,
                                    Granallado = x.Granallado,
                                    idComponente = x.idComponente,
                                    Largo = x.Largo,
                                    Perfil = x.Perfil,
                                    Recibido = x.Recibido,
                                    Requerido = x.Requerido,
                                    ToleranciaMaxima = x.ToleranciaMaxima,
                                    ToleranciaMinina = x.ToleranciaMinina,
                                    Total = x.Total

                                }).First(); 
                    
                            _Insumos.Columnas = new ColumnasJson().setColumnas(null,null, new ColumnasInsumosMensurables(),especificaciones);
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

        }

        public async Task<List<TipoInsumos>> Listar(int? IdDescripcion, int? DN)
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
               .Where(x=>x.IdDescripcion==IdDescripcion)
               .ToListAsync();

                
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
                  })

                  .Where(x=>x.Diametro==DN && x.IdDescripcion== IdDescripcion)
                  .Select(x => new EspecificacionesComponentes
                  {
                      IdDescripcion = x.IdDescripcion,
                      idComponente = x.IdComponente,
                      Diametro = x.Diametro,
                      Altura = x.Altura,
                      ToleranciaMinina = x.ToleranciaMinima,
                      ToleranciaMaxima = x.ToleranciaMaxima,
                      Perfil = x.Perfil,
                      Espesor = x.Espesor,
                      Recibido = x.CantidadRecibido.ToString(),
                      Granallado = x.CantidadGranallado.ToString(),
                      Pintura = x.CantidadPintura.ToString(),
                      Moldeado = x.CantidadMoldeado.ToString(),
                      Proceso = x.CantidadProceso.ToString(),

                  }).ToListAsync();
          

                foreach (TipoInsumos _Insumos in Stocks)
                {
                  

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
                        //_Insumos.Columnas.Add()
                    }



                }

                Stocks.OrderBy(x => x.Descripcion);
                    

                return Stocks;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<TipoInsumos>> Listar(int? IdDescripcion)
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
                  })

                  .Where(x => x.IdDescripcion == IdDescripcion)
                  .Select(x => new EspecificacionesComponentes
                  {
                      IdDescripcion = x.IdDescripcion,
                      idComponente = x.IdComponente,
                      Diametro = x.Diametro,
                      Altura = x.Altura,
                      ToleranciaMinina = x.ToleranciaMinima,
                      ToleranciaMaxima = x.ToleranciaMaxima,
                      Perfil = x.Perfil,
                      Espesor = x.Espesor,
                      Recibido = x.CantidadRecibido.ToString(),
                      Granallado = x.CantidadGranallado.ToString(),
                      Pintura = x.CantidadPintura.ToString(),
                      Moldeado = x.CantidadMoldeado.ToString(),
                      Proceso = x.CantidadProceso.ToString(),

                  }).ToListAsync();


                foreach (TipoInsumos _Insumos in Stocks)
                {


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



                }

                Stocks.OrderBy(x => x.Descripcion)
                    .ThenBy(x => x.Diametro)
                    .ThenBy(x => x.ToleranciaMinina)
                    .ThenBy(x => x.ToleranciaMaxima)
                    .ThenBy(x => x.Perfil)
                    .ThenBy(x => x.Largo);

                return Stocks;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<JsonResult> ListarDiametros(int? IdDescripcion)
        {

           var Diametros = await AponusDBContext.CuantitativosDetalles 
                  .Where(x=>x.IdDescripcion==IdDescripcion)
                  .OrderBy(x => x.Diametro)
                  .Distinct()
                  .Select(x => x.Diametro +" mm")
                  .ToListAsync();

                return new JsonResult(Diametros);

        }


    }
}
