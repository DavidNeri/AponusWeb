using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Aponus_Web_API.Acceso_a_Datos.Ventas
{
    public class ABM_Ventas
    {
        private readonly AponusContext AponusDBContext;
        public ABM_Ventas() { AponusDBContext = new AponusContext(); }

        public async Task<int> Guardar(Models.Ventas Venta)
        {
            await AponusDBContext.ventas.AddAsync(Venta);
            int Resultado = await AponusDBContext.SaveChangesAsync();

           return Resultado;


        }

        public IQueryable<Models.Ventas> ListarVentas()
        {
            return AponusDBContext.ventas.AsQueryable().Include(x => x.DetallesVenta).Include(x => x.Usuario);
        }
    }
}
