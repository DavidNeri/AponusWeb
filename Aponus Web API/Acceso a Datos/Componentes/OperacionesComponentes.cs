using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Acceso_a_Datos.Componentes
{
    public class OperacionesComponentes
    {
        private readonly AponusContext AponusDbContex;

        public OperacionesComponentes(){ AponusDbContex = new AponusContext(); }
        internal async Task<IActionResult> ListarTiposAlacenamiento()
        {
            List <DTODetalleComponentes> Unidades= await  AponusDbContex.ComponentesDetalles
                .Select(x=>new DTODetalleComponentes()
                {
                    IdInsumo=x.IdInsumo,
                    idFraccionamiento=(x.IdFraccionamiento.ToLower()=="ud" || x.IdFraccionamiento.ToLower().Contains("unidad")) ? "Unidades" 
                                       : (x.IdFraccionamiento.ToLower() == "kg" || x.IdFraccionamiento.ToLower().Contains("kilo")) ? "Kgs"
                                       :  x.IdFraccionamiento,

                    idAlmacenamiento= (x.IdAlmacenamiento.ToLower() == "kg" || x.IdAlmacenamiento.ToLower().Contains("kilo")) ? "Kgs"
                                        : (x.IdAlmacenamiento.ToLower() == "ud" || x.IdAlmacenamiento.ToLower().Contains("unidad")) ? "Unidades" 
                                        : x.IdAlmacenamiento,


                }).ToListAsync();

            return new JsonResult(Unidades);
        }
    }
}
