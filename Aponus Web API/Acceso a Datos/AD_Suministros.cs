using Aponus_Web_API.Modelos;
using Aponus_Web_API.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Suministros
    {
        private readonly AponusContext AponusDBContext;
        public AD_Suministros(AponusContext _aponusDBContext)
        {
            AponusDBContext = _aponusDBContext;
        }
        public List<(string, string, string?)> ObtenerDetalles(List<string> SuministrosId)
        {
            ///Buscar Detalle Suministros (Componentes)            

            var IdSuministrosTodos = SuministrosId.ToList();

            List<UTL_FormatoSuministros> formatoSuminitrosComponentes = AponusDBContext.ComponentesDetalles
                .Join(
                    AponusDBContext.ComponentesDescripcions,
                    Detalles => Detalles.IdDescripcion,
                    Descripciones => Descripciones.IdDescripcion,
                    (_Detalles, _Descripciones) => new
                    {
                        detales = _Detalles,
                        descripciones = _Descripciones,
                    })
                .Where(ComponentesId => IdSuministrosTodos.Contains(ComponentesId.detales.IdInsumo))
                .Select(reg => new UTL_FormatoSuministros()
                {
                    IdSuministro = reg.detales.IdInsumo,
                    Descripcion = reg.descripciones.Descripcion,
                    DiametroNominal = reg.detales.DiametroNominal,
                    Diametro = reg.detales.Diametro,
                    Tolerancia = reg.detales.Tolerancia,
                    Espesor = reg.detales.Espesor,
                    Longitud = reg.detales.Longitud,
                    Altura = reg.detales.Altura,
                    Perfil = reg.detales.Perfil,
                    UnidadAlmacenamiento = reg.detales.IdAlmacenamiento,
                    UnidadFraccionamiento = reg.detales.IdFraccionamiento

                })
                .ToList();


            ///Buscar Detalle Suministros (StockInsumos)            
            List<UTL_FormatoSuministros> formatoSuminitrosProductos = AponusDBContext.Productos
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
               .Select(reg => new UTL_FormatoSuministros()
               {
                   IdSuministro = reg.detales.IdProducto,
                   Descripcion = reg.descripciones.DescripcionProducto,
                   DiametroNominal = reg.detales.DiametroNominal,
                   Tolerancia = reg.detales.Tolerancia,
                   UnidadAlmacenamiento = "Ud",
               })
               .ToList();

            ////
            ///Concatenar Listas
            ///

            List<UTL_FormatoSuministros> formatoSuministros = formatoSuminitrosComponentes.Concat(formatoSuminitrosProductos).ToList();


            ///Formatear Nombres
            ///

            List<(string IdSuminitro,
                string NombreFormateado,
                string? Unidad)> SuministrosFormateados = new UTL_NombresSuministros().formatearNombres(formatoSuministros);

            return SuministrosFormateados;

        }
    }
}