using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Services;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Acceso_a_Datos.Componentes
{
    public class ObtenerComponentes
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerComponentes() { AponusDBContext = new AponusContext(); }
        internal async Task<List<EspecificacionesComponentes>>? ListarComponentes(int? IdDescripcion)
        {
            try
            {
                List<EspecificacionesComponentes> Componentes;



               Componentes = await AponusDBContext.PesablesDetalles                
                   .Where(x => x.IdDescripcion == IdDescripcion)
                   .Select(x => new EspecificacionesComponentes
                   {
                       Altura = x.Altura,
                       Diametro = x.Diametro
                  
                   }).ToListAsync();

                if (Componentes.Count==0)
                {
                    Componentes = await AponusDBContext.CuantitativosDetalles

                 .Where(x => x.IdDescripcion == IdDescripcion)
                 .Select(x => new EspecificacionesComponentes
                 {
                     Diametro = x.Diametro,
                     Altura = x.Altura,
                     Tolerancia = x.Tolerancia,
                     Perfil = x.Perfil,
                     Espesor = x.Espesor
                 }).ToListAsync();
                }
                if (Componentes.Count == 0)
                {
                    Componentes = await AponusDBContext.MensurablesDetalles
                                    .Where(x => x.IdDescripcion == IdDescripcion)
                                    .Select(x => new EspecificacionesComponentes
                                    {
                                        Perfil = x.Perfil                                        


                                    }).ToListAsync();
                }



                return Componentes;



            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}

