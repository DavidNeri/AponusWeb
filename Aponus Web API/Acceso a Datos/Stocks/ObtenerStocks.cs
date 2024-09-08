using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Linq;

namespace Aponus_Web_API.Acceso_a_Datos.Stocks
{
    public class ObtenerStocks
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerStocks() { AponusDBContext = new AponusContext(); }  
        public async Task<JsonResult> ListarDiametros(int? IdDescripcion)
        {

            var Diametros = await AponusDBContext.CuantitativosDetalles
                   .Where(x => x.IdDescripcion == IdDescripcion)
                   .OrderBy(x => x.Diametro)
                   .Select(x => x.Diametro + " mm")
                   .Distinct()
                   .ToListAsync();

            return new JsonResult(Diametros);

        }


    }
}
