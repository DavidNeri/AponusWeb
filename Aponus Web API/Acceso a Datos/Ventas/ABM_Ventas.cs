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
            return AponusDBContext.ventas
                .Where(Estado=>Estado.IdEstadoVenta != 0)
                .Include(x=>x.DetallesVenta)
                .Include(x=>x.Cuotas)
                .Include(x=>x.Pagos)
                .Include(Cli=>Cli.Cliente)
                .AsQueryable();
        }

        internal async Task GuardarEstado(EstadosVentas nuevoEstado)
        {
            //if (nuevoEstado.IdEstadoVenta)
            //{

            //}
            //var Existe = AponusDBContext.estadosVentas.FirstOrDefault(x => x.Descripcion.Equals(nuevoEstado.Descripcion));

            


        }
    }
}
