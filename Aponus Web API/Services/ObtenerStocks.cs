using Aponus_Web_API.Models;

namespace Aponus_Web_API.Services
{
    public class ObtenerStocks
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerStocks() { AponusDBContext = new AponusContext(); }
        /*public async  Listar()
        {
            AponusDBContext.StockCuantitativos.Find()
        }*/
    }
}
