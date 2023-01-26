using Aponus_Web_API.Mapping;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Business
{
    public class BS_Stocks
    {
        internal  async Task<List<TipoInsumos>>Listar()
        {
            return   await new ObtenerStocks().Listar();
        }

        internal async Task<List<TipoInsumos>> Listar(int? idDescripcion, int? dn)
        {
            return await new ObtenerStocks().Listar(idDescripcion,dn);
        }

        internal async Task<List<TipoInsumos>> Listar(int? idDescripcion)
        {
            return await new ObtenerStocks().Listar(idDescripcion);
        }

        internal async Task<JsonResult> ListarDiametros(int? idDescripcion)
        {
            return await new ObtenerStocks().ListarDiametros(idDescripcion);
        }

        internal async Task<List<TipoInsumos>> ListarTipoInsumos()
        {
            return await new ObtenerStocks().ListarTipoInsumos();
        }
    }
}
