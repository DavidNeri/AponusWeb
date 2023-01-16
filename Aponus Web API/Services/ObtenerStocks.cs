using Aponus_Web_API.Mapping;
using Aponus_Web_API.Models;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aponus_Web_API.Services
{
    public class ObtenerStocks
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerStocks() { AponusDBContext = new AponusContext(); }
        public async  Task<List<TipoInsumos>>Listar() 
        {
            List<TipoInsumos> _Insumos = await AponusDBContext.ComponentesDescripcions
               .Select(x => new TipoInsumos
               {
                   IdDescripcion = x.IdDescripcion,
                   Descripcion = x.Descripcion
               }).ToListAsync();

            List <Insumos_Soportes> _Insumos_Soportes  =  await
            AponusDBContext.PesablesDetalles
               .Join(AponusDBContext.StockPesables,
               _PesablesDetalle => _PesablesDetalle.IdComponente,
               _StockPesables => _StockPesables.IdComponente,
               (_PesablesDetalle, _StockPesables) => new
               {
                  // _PesablesDetalle.IdComponente,
                   _PesablesDetalle.IdDescripcion,
                   _PesablesDetalle.Diametro,
                   _PesablesDetalle.Altura,
                   _StockPesables.CantidadRecibido,
                   _StockPesables.CantidadPintura,
                   _StockPesables.CantidadProceso
               })
               .Select(
                x=> new Insumos_Soportes { 
                    IdDescripcion=x.IdDescripcion,                    
                    Diametro=x.Diametro,
                    Altura=x.Altura,
                    Recibido=x.CantidadRecibido,
                    Pintura=x.CantidadPintura,
                    Proceso=x.CantidadProceso

                }
               ).ToListAsync();

            List<Insumos_Cuantitativos> _Insumos_Cuantitativos = await AponusDBContext.CuantitativosDetalles
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
                .Select(x=> new Insumos_Cuantitativos 
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

            List<Insumos_Mensurables> _Insumos_Mensurables= await AponusDBContext.MensurablesDetalles
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
               .Select(x => new Insumos_Mensurables
               {
                   IdDescripcion = x.IdDescripcion,
                   Largo = x.Largo,
                   Espesor = x.Espesor,
                   Perfil = x.Perfil,
                   Recibido = x.CantidadRecibido,
                   Proceso = x.CantidadProceso                

               }).ToListAsync();


            foreach (TipoInsumos tipo in _Insumos)
            {

                foreach (Insumos_Soportes _insumos_Soportes in _Insumos_Soportes)
                {
                    if (_insumos_Soportes.IdDescripcion==tipo.IdDescripcion)
                    {
                        tipo.DetalleSoportes = new List<Insumos_Soportes>();
                        tipo.DetalleSoportes.AddRange(_Insumos_Soportes.Where(x => x.IdDescripcion == tipo.IdDescripcion));
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

            return _Insumos;

        }
    }
}
