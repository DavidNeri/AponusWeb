using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Acceso_a_Datos.Ventas
{
    public class Ventas
    {
        private readonly AponusContext AponusDBContext;
        public Ventas() { AponusDBContext = new AponusContext(); }

        public async Task<int> Guardar(Models.Ventas Venta)
        {
            await AponusDBContext.ventas.AddAsync(Venta);
            int Resultado = await AponusDBContext.SaveChangesAsync();

           return Resultado;


        }
    }
}
