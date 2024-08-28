using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Z.EntityFramework.Plus;

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

        internal void EliminarEstado(EstadosVentas EstadoVenta)
        {
            var Estado = AponusDBContext.estadosVentas.Find(typeof(EstadosVentas), EstadoVenta.IdEstadoVenta);
            
            if (Estado != null)
            {
                Estado.IdEstado = 0;
                AponusDBContext.SaveChanges();

            }
        }

        internal async Task<IActionResult> GuardarEstado(DTOEstadosVentas NuevoEstado)
        {
            if (NuevoEstado.IdEstadoVenta != null)
            {
                EstadosVentas? Estado = await AponusDBContext.estadosVentas.FirstOrDefaultAsync(x => x.IdEstadoVenta == NuevoEstado.IdEstado && x.IdEstado!=0);
                if (Estado != null)
                {
                    Estado.Descripcion = NuevoEstado.Descripcion ?? Estado.Descripcion;
                    Estado.IdEstado = NuevoEstado.IdEstado ?? Estado.IdEstado;
                    await AponusDBContext.SaveChangesAsync();
                    
                }
                else
                {
                    await AponusDBContext.estadosVentas.AddAsync(new EstadosVentas()
                    {
                        Descripcion = NuevoEstado.Descripcion
                    });
                }
                return new StatusCodeResult(200);
            }
            else
            {
                var Existe = AponusDBContext.estadosVentas.FirstOrDefault(x => x.Descripcion.Equals(NuevoEstado.Descripcion) && x.IdEstado!=0);
                if (Existe != null)
                    return new ContentResult()
                    {
                        Content = "Nombre de Estado Existente. No se aplicarion los cambios",
                        ContentType = "application/json",
                        StatusCode = 400
                    };
                else
                {
                    await AponusDBContext.estadosVentas.AddAsync(new EstadosVentas()
                    {
                        Descripcion = NuevoEstado.Descripcion
                    });
                    return new StatusCodeResult(200);
                }
            }
        }
    }
}
