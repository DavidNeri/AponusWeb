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
    }
}
