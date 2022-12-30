using Aponus_Web_API.Mapping;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Aponus_Web_API.Services
{
    public class ObtenerInsumos
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerInsumos() { AponusDBContext = new AponusContext(); }
        public  List<Insumos> ObtenterPesables(string ProductId,int Cantidad)
        {
            List<Insumos> LstInsumosPesables = new List<Insumos>();
            string? _Descripcion;

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
                
                LstInsumosPesables.Add(new Insumos()
                {
                    Nombre = _Descripcion,
                    Requerido = queryResult.Peso * Cantidad + " Kg",
                    Recibido = queryResult.CantidadRecibido + " Kg",
                    Pintura = queryResult.CantidadPintura + " Kg",
                    Proceso = queryResult.CantidadProceso + " Kg",
                    Total= queryResult.CantidadRecibido + queryResult.CantidadPintura+queryResult.CantidadProceso + "Kg"


                });
            }
            return LstInsumosPesables;
        }

        public  List <Insumos> ObtenterCuantitativos(string ProductId, int Cantidad)
        {
            List<Insumos> LstInsumosCuantitativos= new List<Insumos>();
            string _Descripcion;

            var InsumosCuantitativos= 

                AponusDBContext.ComponentesCuantitativos
                    .Join(AponusDBContext.CuantitativosDetalles,
                        _ComponentesCuantitativos => _ComponentesCuantitativos.IdComponente,
                        _CuantitativosDetalle => _CuantitativosDetalle.IdComponente,
                        (_ComponentesCuantitativos, _CuantitativosDetalle) => new
                        {
                            _ComponentesCuantitativos.IdProducto,
                            _ComponentesCuantitativos.Cantidad,
                            _CuantitativosDetalle.IdDescripcion,
                            _CuantitativosDetalle.IdComponente,
                            _CuantitativosDetalle.Diametro,
                            _CuantitativosDetalle.Altura,
                            _CuantitativosDetalle.ToleranciaMinima,
                            _CuantitativosDetalle.ToleranciaMaxima,

                        })
                    .Join(AponusDBContext.StockCuantitativos,
                        _ComponentesCuantitativos_CuantitativosDetalle => _ComponentesCuantitativos_CuantitativosDetalle.IdComponente,
                        _StockCuantitativos => _StockCuantitativos.IdComponente,
                        (_ComponenetesCuantitativos_Cuantitativos_Detalle, _StockCuantitativos) => new
                        {
                            _ComponenetesCuantitativos_Cuantitativos_Detalle.IdProducto,
                            _ComponenetesCuantitativos_Cuantitativos_Detalle.IdComponente,
                            _ComponenetesCuantitativos_Cuantitativos_Detalle.IdDescripcion,
                            _ComponenetesCuantitativos_Cuantitativos_Detalle.Cantidad,
                            _ComponenetesCuantitativos_Cuantitativos_Detalle.Diametro,
                            _ComponenetesCuantitativos_Cuantitativos_Detalle.Altura,
                            _ComponenetesCuantitativos_Cuantitativos_Detalle.ToleranciaMinima,
                            _ComponenetesCuantitativos_Cuantitativos_Detalle.ToleranciaMaxima,
                            _StockCuantitativos.CantidadRecibido,
                            _StockCuantitativos.CantidadPintura,
                            _StockCuantitativos.CantidadProceso,
                            _StockCuantitativos.CantidadGranallado
                        })
                    .Join(AponusDBContext.ComponentesDescripcions,
                    _ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos => _ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.IdDescripcion,
                    _ComponentesDescripcion => _ComponentesDescripcion.IdDescripcion,
                    (_ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos, _ComponentesDescripcion) => new
                    {
                        _ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos,
                        _ComponentesDescripcion
                    })

                    .Where(x => x._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.IdProducto == ProductId)
                    .Select(
                        Cuantitativos => new
                        {
                            Cuantitativos._ComponentesDescripcion.Descripcion,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.Cantidad,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.Diametro,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.Altura,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.ToleranciaMinima,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.ToleranciaMaxima,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.CantidadRecibido,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.CantidadPintura,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.CantidadProceso,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.CantidadGranallado,
                        }).ToList();

            foreach (var queryResult in InsumosCuantitativos)
            {
                if (queryResult.Descripcion.Contains("brida")==true && queryResult.Descripcion!=null)
                {
                    _Descripcion = queryResult.Descripcion +
                        " DN " +  String.Format("{0:####}", queryResult.Diametro) +' '+
                        queryResult.ToleranciaMinima +
                        '-' + queryResult.ToleranciaMaxima;

                    
                }
                else
                {
                    _Descripcion = queryResult.Descripcion + " Ø" +
                        String.Format("{0:####}", queryResult.Diametro) +" Tolerancia: "+
                        queryResult.ToleranciaMinima + '-' +
                        queryResult.ToleranciaMaxima;
                }
          

                LstInsumosCuantitativos.Add(new Insumos()
                {
                    Nombre = _Descripcion,                    
                    Requerido= queryResult.Cantidad *Cantidad+ " U",
                    Recibido = queryResult.CantidadRecibido + " U", 
                    Pintura = queryResult.CantidadPintura + " U", 
                    Proceso = queryResult.CantidadProceso + " U",
                    Granallado = queryResult.CantidadGranallado+ " U",
                    Total = queryResult.CantidadRecibido+
                            queryResult.CantidadGranallado+
                            queryResult.CantidadPintura+
                            queryResult.CantidadProceso + " U"
                });
            }
            return  LstInsumosCuantitativos;
        }

        public List<Insumos> ObtenterMensurables(string ProductId, int Cantidad)
        {
            List<Insumos> LstInsumosMensurables = new List<Insumos>();
            string _Descripcion;
            string LargoRequerido;
            string AlturaCuerpoPerfil;
            string LargoStock;
            string AnchoStock;

            var InsumosMensurables =

                AponusDBContext.ComponentesMensurables
                    .Join(AponusDBContext.MensurablesDetalles,
                        _ComponentesMensurables => _ComponentesMensurables.IdComponente,
                        _MensurablesDetalle => _MensurablesDetalle.IdComponente,
                        (_ComponentesMensurables, _MensurablesDetalle) => new
                        {
                            _ComponentesMensurables.IdProducto,
                            LargoRequerido =_ComponentesMensurables.Largo,
                            AlturaCuerpoPerfil =_ComponentesMensurables.Altura,                      

                            _MensurablesDetalle.IdDescripcion,
                            _MensurablesDetalle.IdComponente,                           
                           // AnchoStock =_MensurablesDetalle.Ancho,
                            _MensurablesDetalle.Espesor,
                            _MensurablesDetalle.Perfil,
                            LargoUnidad=_MensurablesDetalle.Largo,
                            

                        })
                    .Join(AponusDBContext.StockMensurables,
                        _ComponentesMensurables_MensurablesDetalle => _ComponentesMensurables_MensurablesDetalle.IdComponente,
                        _StockMensurables => _StockMensurables.IdComponente,
                        (_ComponenetesMensurables_Mensurables_Detalle, _StockMensurables) => new
                        {
                            _ComponenetesMensurables_Mensurables_Detalle.IdProducto,
                            _ComponenetesMensurables_Mensurables_Detalle.IdComponente,
                            _ComponenetesMensurables_Mensurables_Detalle.IdDescripcion,
                            _ComponenetesMensurables_Mensurables_Detalle.AlturaCuerpoPerfil,
                            _ComponenetesMensurables_Mensurables_Detalle.LargoRequerido,
                            //_ComponenetesMensurables_Mensurables_Detalle.LargoStock,
                            //_StockMensurables.AnchoStock,
                            //LargoStock = _MensurablesDetalle.Largo,
                            _ComponenetesMensurables_Mensurables_Detalle.Espesor,
                            _ComponenetesMensurables_Mensurables_Detalle.Perfil,
                            _ComponenetesMensurables_Mensurables_Detalle.LargoUnidad,
                            _StockMensurables.CantidadRecibido
                           
                        })
                    .Join(AponusDBContext.ComponentesDescripcions,
                    _ComponentesMensurables_MensurablesDetalle_SotckMensurables => _ComponentesMensurables_MensurablesDetalle_SotckMensurables.IdDescripcion,
                    _ComponentesDescripcion => _ComponentesDescripcion.IdDescripcion,
                    (_ComponentesMensurables_MensurablesDetalle_SotckMensurables, _ComponentesDescripcion) => new
                    {
                        _ComponentesMensurables_MensurablesDetalle_SotckMensurables,
                        _ComponentesDescripcion
                    })

                    .Where(x => x._ComponentesMensurables_MensurablesDetalle_SotckMensurables.IdProducto == ProductId)
                    .Select(
                        Mensurables => new
                        {
                            Mensurables._ComponentesDescripcion.Descripcion,
                            Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.IdProducto,
                            Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.IdComponente,
                            Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.AlturaCuerpoPerfil,
                            Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.LargoRequerido,
                            //Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.LargoStock,
                            Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.LargoUnidad,
                           // Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.AnchoStock,
                            Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.Espesor,
                            Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.Perfil,
                            Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.CantidadRecibido
                        }).ToList();
            string _Requerido;
            string _Proceso;


            try
            {
                foreach (var queryResult in InsumosMensurables)
                {
                    _Requerido = "";
                    _Proceso = "";

                    if (queryResult.Descripcion.Contains("GOMA") == false && queryResult.Descripcion != null)
                    {
                        _Descripcion = queryResult.Descripcion + ' ' + queryResult.Espesor + " mm x " + (queryResult.LargoUnidad*queryResult.CantidadRecibido) / 1000 + " m - PERFIL " + queryResult.Perfil;
                        _Requerido = "Perfil de " + queryResult.AlturaCuerpoPerfil + " mm x " + Cantidad + " U";
                        _Proceso = queryResult.CantidadRecibido +" U de " + queryResult.LargoUnidad/1000 + " m/" + String.Format("{0:####}", (queryResult.LargoUnidad*queryResult.CantidadRecibido)/ queryResult.AlturaCuerpoPerfil) + " perfiles de " + (queryResult.AlturaCuerpoPerfil / 100) + " cm";
                    }
                    else
                    {
                        _Descripcion = queryResult.Descripcion + "PERFIL " + queryResult.Perfil;
                        if (queryResult.IdProducto.Contains("ABT") == true)
                        {
                            _Requerido = ((queryResult.LargoRequerido * Cantidad) / 1000) + " m/" + Cantidad + " Junta(s) de " + (queryResult.LargoRequerido / 1000) + " cm";
                        }
                        else
                        {
                            _Requerido = ((queryResult.LargoRequerido * Cantidad * 2) / 1000) + "m/" + (Cantidad * 2) + " Junta(s) de " + (queryResult.LargoRequerido / 100) + " cm";
                        }
                        _Proceso = ((queryResult.LargoUnidad*queryResult.CantidadRecibido) / 1000) + " m/" + ((queryResult.LargoUnidad * queryResult.CantidadRecibido) / queryResult.LargoRequerido) + " Junta(s) de " + (queryResult.LargoRequerido / 100) + " cm";
                    }


                    LstInsumosMensurables.Add(new Insumos()
                    {
                        Nombre = _Descripcion,
                        Requerido = _Requerido,
                        Proceso = _Proceso,
                        Total = (queryResult.LargoUnidad * queryResult.CantidadRecibido) / 1000 + " m"

                    });
                }
                return LstInsumosMensurables;
            }
            catch (Exception e)
            {

                return new List<Insumos>();
            }
            
        }


    }
}