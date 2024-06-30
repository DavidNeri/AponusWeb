using Aponus_Web_API.Models;
using Aponus_Web_API.Data_Transfer_objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Aponus_Web_API.Support;

namespace Aponus_Web_API.Acceso_a_Datos.Insumos
{
    public class ObtenerInsumos
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerInsumos() { AponusDBContext = new AponusContext(); }
        public List<Data_Transfer_objects.Insumos> ObtenterPesables(string ProductId, int Cantidad)
        {
            List<Data_Transfer_objects.Insumos> LstInsumosPesables = new List<Data_Transfer_objects.Insumos>();
            string? _Descripcion;
            decimal? Total;
            decimal? _Requerido;
            decimal? Faltantes;
            decimal? _Disponibles;

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
                    _Descripcion = queryResult.Descripcion + " " + string.Format("{0:####}", queryResult.Altura) + " mm";
                }


                Total = queryResult.CantidadRecibido + queryResult.CantidadPintura + queryResult.CantidadProceso;
                _Requerido = queryResult.Peso * Cantidad;

                if (true)
                {

                }
                _Disponibles = Total / _Requerido;

                if (Total - _Requerido >= 0)
                {
                    Faltantes = 0;
                }
                else
                {
                    Faltantes = Total - _Requerido;
                }

                LstInsumosPesables.Add(new Data_Transfer_objects.Insumos()
                {
                    Nombre = _Descripcion,
                    Requerido = _Requerido + " Kg",
                    Recibido = queryResult.CantidadRecibido + " Kg",
                    Pintura = queryResult.CantidadPintura + " Kg",
                    Proceso = queryResult.CantidadProceso + " Kg",
                    Total = queryResult.CantidadRecibido + queryResult.CantidadPintura + queryResult.CantidadProceso + "Kg",
                    Faltantes = Faltantes + " Kg",
                    Disponibles = string.Format("{0:0.##}", _Disponibles) + " U"



                });
            }
            return LstInsumosPesables;
        }

        public List<Data_Transfer_objects.Insumos> ObtenterCuantitativos(string ProductId, int Cantidad = 1)
        {
            List<Data_Transfer_objects.Insumos> LstInsumosCuantitativos = new List<Data_Transfer_objects.Insumos>();
            string _Descripcion;
            decimal? Total;
            decimal? _Requerido;
            decimal? Faltantes;
            decimal? _Disponibles;
            string? _Moldeado = null;
            string? Pintura = null;
            string? Recibido = null;
            string? Granallado = null;
            string? Proceso = null;

            var InsumosCuantitativos =
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
                            _CuantitativosDetalle.Tolerancia,

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
                            _ComponenetesCuantitativos_Cuantitativos_Detalle.Tolerancia,
                            _StockCuantitativos.CantidadRecibido,
                            _StockCuantitativos.CantidadPintura,
                            _StockCuantitativos.CantidadProceso,
                            _StockCuantitativos.CantidadGranallado,
                            _StockCuantitativos.CantidadMoldeado
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
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.Tolerancia,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.CantidadRecibido,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.CantidadPintura,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.CantidadProceso,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.CantidadGranallado,
                            Cuantitativos._ComponentesCuantitativos_CuantitativosDetalle_SotckCuantitativos.CantidadMoldeado
                        }).ToList();

            foreach (var queryResult in InsumosCuantitativos)
            {
                if (queryResult.Descripcion.Contains("brida") == true && queryResult.Descripcion != null)
                {
                    _Descripcion = queryResult.Descripcion +
                        " DN " + string.Format("{0:####}", queryResult.Diametro) + ' ' +
                        queryResult.Tolerancia;


                }
                else
                {
                    _Descripcion = queryResult.Descripcion + " Ø" +
                        string.Format("{0:####}", queryResult.Diametro) + " Tolerancia: " +
                        queryResult.Tolerancia;
                }

                if (queryResult.CantidadMoldeado != null)
                {
                    Total = queryResult.CantidadRecibido +
                           queryResult.CantidadGranallado +
                           queryResult.CantidadPintura +
                           queryResult.CantidadProceso + queryResult.CantidadMoldeado;

                    _Disponibles = Total / (queryResult.Cantidad * Cantidad);
                }
                else
                {
                    if (queryResult.CantidadRecibido == null && queryResult.CantidadGranallado == null && queryResult.CantidadPintura == null && queryResult.CantidadMoldeado == null)
                    {

                        Total = queryResult.CantidadProceso;
                        Pintura = null;
                        Recibido = null;
                        Granallado = null;
                        Proceso = null;

                    }
                    else if (queryResult.CantidadRecibido != null && queryResult.CantidadGranallado == null
                        && queryResult.CantidadPintura == null && queryResult.CantidadMoldeado == null && queryResult.CantidadProceso == null)
                    {
                        Total = queryResult.CantidadRecibido;
                        Pintura = null;
                        _Moldeado = null;
                        Granallado = null;
                        Proceso = null;


                    }
                    else
                    {
                        Total = queryResult.CantidadRecibido + queryResult.CantidadGranallado + queryResult.CantidadPintura + queryResult.CantidadProceso;
                        Pintura = queryResult.CantidadPintura.ToString() + " U";
                        Recibido = queryResult.CantidadRecibido.ToString() + " U";
                        Granallado = queryResult.CantidadGranallado.ToString() + " U";
                        _Moldeado = queryResult.CantidadMoldeado + " U";
                        Proceso = queryResult.CantidadProceso + "U";


                    }

                    _Moldeado = null;
                    _Disponibles = Total / (queryResult.Cantidad * Cantidad);
                }


                _Requerido = queryResult.Cantidad * Cantidad;
                if (Total - _Requerido >= 0)
                {
                    Faltantes = 0;
                }
                else
                {
                    Faltantes = Total - _Requerido;
                }



                LstInsumosCuantitativos.Add(new Data_Transfer_objects.Insumos()
                {
                    Nombre = _Descripcion,
                    Requerido = _Requerido.ToString() + " U",
                    Recibido = Recibido,
                    Pintura = Pintura,
                    Proceso = Proceso,
                    Granallado = Granallado,
                    Moldeado = _Moldeado,
                    Total = Total.ToString() + " U",
                    Faltantes = Faltantes.ToString() + " U",
                    Disponibles = _Disponibles.ToString()
                });
            }
            return LstInsumosCuantitativos;
        }

        public List<Data_Transfer_objects.Insumos> ObtenterMensurables(string ProductId, int Cantidad)
        {
            List<Data_Transfer_objects.Insumos> LstInsumosMensurables = new List<Data_Transfer_objects.Insumos>();
            string _Descripcion;
            decimal? Total;
            decimal? Req;
            decimal? Faltantes;
            decimal? _Disponibles;
            string _Requerido;
            string _Proceso;

            var InsumosMensurables =

                AponusDBContext.ComponentesMensurables
                    .Join(AponusDBContext.MensurablesDetalles,
                        _ComponentesMensurables => _ComponentesMensurables.IdComponente,
                        _MensurablesDetalle => _MensurablesDetalle.IdComponente,
                        (_ComponentesMensurables, _MensurablesDetalle) => new
                        {
                            _ComponentesMensurables.IdProducto,
                            LargoRequerido = _ComponentesMensurables.Largo,
                            AlturaCuerpoPerfil = _ComponentesMensurables.Altura,

                            _MensurablesDetalle.IdDescripcion,
                            _MensurablesDetalle.IdComponente,
                            _MensurablesDetalle.Espesor,
                            _MensurablesDetalle.Perfil,
                            LargoUnidad = _MensurablesDetalle.Largo,

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
                            Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.LargoUnidad,
                            Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.Espesor,
                            Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.Perfil,
                            Mensurables._ComponentesMensurables_MensurablesDetalle_SotckMensurables.CantidadRecibido
                        }).ToList();


            if (InsumosMensurables.Count > 0)
            {
                try
                {
                    foreach (var queryResult in InsumosMensurables)
                    {
                        _Requerido = "";
                        _Proceso = "";

                        if (queryResult.Descripcion.Contains("GOMA") == false && queryResult.Descripcion != null)
                        {
                            _Descripcion = queryResult.Descripcion + ' ' + queryResult.Espesor + " mm x " + queryResult.LargoUnidad * queryResult.CantidadRecibido / 1000 + " m - PERFIL " + queryResult.Perfil;
                            _Requerido = "Perfil de " + queryResult.AlturaCuerpoPerfil + " mm x " + Cantidad + " U";
                            _Proceso = queryResult.CantidadRecibido + " U de " + queryResult.LargoUnidad / 1000 + " m/" + string.Format("{0:####}", queryResult.LargoUnidad * queryResult.CantidadRecibido / queryResult.AlturaCuerpoPerfil) + " perfiles de " + queryResult.AlturaCuerpoPerfil / 100 + " cm";
                        }
                        else
                        {
                            _Descripcion = queryResult.Descripcion + " PERFIL " + queryResult.Perfil;
                            if (queryResult.IdProducto.Contains("ABT") == true)
                            {
                                _Requerido = queryResult.LargoRequerido * Cantidad / 1000 + " m/" + Cantidad + " Junta(s) de " + queryResult.LargoRequerido / 1000 + " cm";
                            }
                            else
                            {
                                _Requerido = queryResult.LargoRequerido * Cantidad * 2 / 1000 + "m/" + Cantidad * 2 + " Junta(s) de " + queryResult.LargoRequerido / 100 + " cm";
                            }
                            _Proceso = queryResult.LargoUnidad * queryResult.CantidadRecibido / 1000 + " m/" + queryResult.LargoUnidad * queryResult.CantidadRecibido / queryResult.LargoRequerido + " Junta(s) de " + queryResult.LargoRequerido / 100 + " cm";
                        }

                        Req = queryResult.AlturaCuerpoPerfil * Cantidad / (queryResult.LargoUnidad * queryResult.CantidadRecibido) / 1000;
                        Total = queryResult.LargoUnidad * queryResult.CantidadRecibido / 1000;
                        _Disponibles = Total / (queryResult.LargoRequerido * Cantidad);

                        if (Total - Req >= 0)
                        {
                            Faltantes = 0;
                        }
                        else
                        {
                            Faltantes = Total - Req;
                        }

                        LstInsumosMensurables.Add(new Data_Transfer_objects.Insumos()
                        {
                            Nombre = _Descripcion,
                            Requerido = _Requerido,
                            Proceso = _Proceso,
                            Total = Total + " m",
                            Faltantes = Faltantes + " U",
                            Disponibles = _Disponibles + " U"
                        }); ;
                    }
                    return LstInsumosMensurables;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;

        }


        public List<(string, string, string?)> ObtenerDetalleSuministro(List<string> SuministrosId)
        {

            ///Buscar Detalle Suministros (Componentes)
            ///

            var IdSuministrosTodos = SuministrosId.ToList();

            List<FormatoSuministros> formatoSuminitrosComponentes=AponusDBContext.ComponentesDetalles
                .Join(
                    AponusDBContext.ComponentesDescripcions,
                    Detalles=>Detalles.IdDescripcion,
                    Descripciones=>Descripciones.IdDescripcion,
                    (_Detalles, _Descripciones)=>new
                    {
                        detales=_Detalles,
                        descripciones=_Descripciones,
                    })
                .Where(ComponentesId => IdSuministrosTodos.Contains(ComponentesId.detales.IdInsumo))
                .Select(reg=> new FormatoSuministros()
                {
                    IdSuministro=reg.detales.IdInsumo,
                    Descripcion=reg.descripciones.Descripcion,
                    DiametroNominal=reg.detales.DiametroNominal,
                    Diametro=reg.detales.Diametro,
                    Tolerancia=reg.detales.Tolerancia,
                    Espesor = reg.detales.Espesor,
                    Longitud=reg.detales.Longitud,
                    Altura=reg.detales.Altura,
                    Perfil = reg.detales.Perfil,
                    UnidadAlmacenamiento=reg.detales.IdAlmacenamiento,
                    UnidadFraccionamiento=reg.detales.IdFraccionamiento

                })
                .ToList();

            ///Buscar Detalle Suministros (Productos)
            ///
            List<FormatoSuministros> formatoSuminitrosProductos= AponusDBContext.Productos
               .Join(
                   AponusDBContext.ProductosDescripcions,
                   Detalles => Detalles.IdDescripcion,
                   Descripciones => Descripciones.IdDescripcion,
                   (_Detalles, _Descripciones) => new
                   {
                       detales = _Detalles,
                       descripciones = _Descripciones,
                   })
               .Where(ProductosId => IdSuministrosTodos.Contains(ProductosId.detales.IdProducto))
               .Select(reg => new FormatoSuministros()
               {
                   IdSuministro = reg.detales.IdProducto,
                   Descripcion = reg.descripciones.DescripcionProducto,
                   DiametroNominal = reg.detales.DiametroNominal,
                   Tolerancia = reg.detales.Tolerancia,
                   UnidadAlmacenamiento="Ud",
               })
               .ToList();

            ////
            ///Concatenar Listas
            ///

            List<FormatoSuministros>formatoSuministros = formatoSuminitrosComponentes.Concat(formatoSuminitrosProductos).ToList();


            ///Formatear Nombres
            ///

            List<(string IdSuminitro,
                string NombreFormateado,
                string? Unidad)> SuministrosFormateados=new Nombres().formatearNombres(formatoSuministros);


              

            return SuministrosFormateados;

        }



       



    }
}