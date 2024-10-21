using Aponus_Web_API.Models;
using Microsoft.EntityFrameworkCore;
using Aponus_Web_API.Support;

namespace Aponus_Web_API.Acceso_a_Datos.Insumos
{
    public class ObtenerInsumos
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerInsumos(AponusContext _aponusDBContext)
        {
            AponusDBContext = _aponusDBContext;
        }
        public List<(string, string, string?)> ObtenerDetalleSuministro(List<string> SuministrosId)
        {
            ///Buscar Detalle Suministros (Componentes)            

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


            ///Buscar Detalle Suministros (StockInsumos)            
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