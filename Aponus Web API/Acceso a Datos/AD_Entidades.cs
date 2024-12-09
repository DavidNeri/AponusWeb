using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Entidades
    {
        private readonly AponusContext AponusDBContext;
        public AD_Entidades(AponusContext _aponusDBContext)
        {
            AponusDBContext = _aponusDBContext;
        }
        public IActionResult GuardarEntidad(DTOEntidades Entidad)
        {

            try
            {
                if (Entidad.IdEntidad != null)
                {
                    var Existente = AponusDBContext.Entidades.FirstOrDefault(x => x.IdEntidad == Entidad.IdEntidad);

                    if (Existente != null)
                    {

                        Existente.NombreClave       = Entidad.NombreClave ?? Existente.NombreClave;
                        Existente.Pais              = Entidad.Pais ?? Existente.Pais;
                        Existente.Localidad         = Entidad.Localidad ?? Existente.Localidad;
                        Existente.Calle             = Entidad.Calle ?? Existente.Calle;
                        Existente.Altura            = Entidad.Altura ?? Existente.Altura;
                        Existente.CodigoPostal      = Entidad.CodigoPostal ?? Existente.CodigoPostal;
                        Existente.Telefono1         = Entidad.Telefono1 ?? Existente.Telefono1;
                        Existente.Telefono2         = Entidad.Telefono2 ?? Existente.Telefono2;
                        Existente.Telefono3         = Entidad.Telefono3 ?? Existente.Telefono3;
                        Existente.Email             = Entidad.Email ?? Existente.Email;
                        Existente.IdFiscal          = Entidad.IdFiscal ?? Existente.IdFiscal;
                        Existente.Ciudad            = Entidad.Ciudad ?? Existente.Ciudad;
                        Existente.Provincia         = Entidad.Provincia ?? Existente.Provincia;
                        Existente.Apellido          = Entidad.Apellido ?? Existente.Apellido;
                        Existente.Nombre            = Entidad.Nombre ?? Existente.Nombre;
                        Existente.IdUsuarioRegistro = Entidad.IdUsuarioRegistro ?? Existente.IdUsuarioRegistro;
                        Existente.Barrio            = Entidad.Barrio ?? Existente.Barrio;
                        Existente.IdCategoria       = Entidad.IdCategoria;
                        Existente.IdTipo            = Entidad.IdTipo;
                        Existente.IdEstado          = 1;                       

                        if (Entidad.IdTipo != Existente.IdTipo || Entidad.IdCategoria != Existente.IdCategoria)
                        {
                            Existente.CategoriaEntidad = AponusDBContext.CategoriasEntidades.First(x => x.IdCategoria == Entidad.IdCategoria);
                            Existente.TipoEntidad      = AponusDBContext.TiposEntidades.First(x => x.IdTipo == Entidad.IdTipo);
                        }

                        AponusDBContext.Entidades.Update(Existente);
                        AponusDBContext.SaveChanges();
                    }

                    return new StatusCodeResult(200);
                }
                else
                {
                    Entidades NuevaEntidad = new()
                    {
                        NombreClave       = Entidad.Nombre                              ?? "",
                        Nombre            = !string.IsNullOrEmpty(Entidad.Nombre)       ? Entidad.Nombre.Trim().ToUpper().Replace(" ", "")       : null,
                        Apellido          = !string.IsNullOrEmpty(Entidad.Apellido)     ? Entidad.Apellido.Trim().ToUpper().Replace(" ", "")     : null,
                        Pais              = !string.IsNullOrEmpty(Entidad.Pais)         ? Entidad.Pais.Trim().ToUpper().Replace(" ", "")         : null,
                        Ciudad            = !string.IsNullOrEmpty(Entidad.Ciudad)       ? Entidad.Ciudad.Trim().ToUpper().Replace(" ", "")       : null,
                        Provincia         = !string.IsNullOrEmpty(Entidad.Provincia)    ? Entidad.Provincia.Trim().ToUpper().Replace(" ", "")    : null,
                        Localidad         = !string.IsNullOrEmpty(Entidad.Localidad)    ? Entidad.Localidad.Trim().ToUpper().Replace(" ", "")    : null,
                        Calle             = !string.IsNullOrEmpty(Entidad.Calle)        ? Entidad.Calle.Trim().ToUpper().Replace(" ", "")        : null,
                        Altura            = !string.IsNullOrEmpty(Entidad.Altura)       ? Entidad.Altura.Trim().ToUpper().Replace(" ", "")       : null,
                        CodigoPostal      = !string.IsNullOrEmpty(Entidad.CodigoPostal) ? Entidad.CodigoPostal.Trim().ToUpper().Replace(" ", "") : null,
                        Telefono1         = !string.IsNullOrEmpty(Entidad.Telefono1)    ? Entidad.Telefono1.Trim().ToUpper().Replace(" ", "")    : null,
                        Telefono2         = !string.IsNullOrEmpty(Entidad.Telefono2)    ? Entidad.Telefono2.Trim().ToUpper().Replace(" ", "")    : null,
                        Telefono3         = !string.IsNullOrEmpty(Entidad.Telefono3)    ? Entidad.Telefono3.Trim().ToUpper().Replace(" ", "")    : null,
                        Email             = !string.IsNullOrEmpty(Entidad.Email)        ? Entidad.Email.Trim().ToUpper().Replace(" ", "")        : null,
                        IdFiscal          = Entidad.IdFiscal.Trim().ToUpper().Replace(" ", "").Replace("-", "").Replace("_", ""),
                        FechaRegistro     = Entidad.FechaRegistro ?? UTL_Fechas.ObtenerFechaHora(),
                        IdUsuarioRegistro = Entidad.IdUsuarioRegistro ?? "",
                        IdTipo            = Entidad.IdTipo,
                        IdCategoria       = Entidad.IdCategoria,
                        CategoriaEntidad  = AponusDBContext.CategoriasEntidades.FirstOrDefault(x => x.IdCategoria == Entidad.IdCategoria) ?? new EntidadesCategorias(),
                        TipoEntidad       = AponusDBContext.TiposEntidades.FirstOrDefault(x => x.IdTipo == Entidad.IdTipo) ?? new EntidadesTipos(),
                        UsuarioRegistro   = AponusDBContext.Usuarios.FirstOrDefault(x => x.Usuario == Entidad.IdUsuarioRegistro) ?? new Usuarios(),
                        IdEstado          = 1,

                    };

                    AponusDBContext.Entidades.Add(NuevaEntidad);
                    AponusDBContext.SaveChanges();
                    return new StatusCodeResult(200);
                }
            }
            catch (Exception ex)
            {
                ContentResult excepcion = new()
                {
                    ContentType = "application/json",
                    StatusCode = 400,
                };

                excepcion.Content = !string.IsNullOrEmpty(ex.InnerException?.Message) ? "Error:\n" + ex.InnerException.Message : "Error:\n" + ex.Message;

                return excepcion;
            }

        }
        internal async Task<(int? Resultado, Exception? Error)> DeshabilitarEntidad(Entidades Entidad)
        {
            using var transaccion = await AponusDBContext.Database.BeginTransactionAsync();
            try
            {
                AponusDBContext.Entidades.Update(Entidad);
                await AponusDBContext.SaveChangesAsync();
                await transaccion.CommitAsync();

                return (StatusCodes.Status200OK, null);

            }
            catch (Exception ex)
            {
                await transaccion.RollbackAsync();
                return (null, ex);
            }
        }
        internal IQueryable<Entidades> ListarEntidades()
        {
            IQueryable<Entidades> QueryListado = AponusDBContext.Entidades
                .Where(x => x.IdEstado != 0)
                .Include(x=>x.TipoEntidad)
                .Include(x=>x.CategoriaEntidad);

            return QueryListado;

        }
        internal async Task<(List<EntidadesTipos>? LstTiposEntidades, Exception? ex)> ListarTiposEntidades()
        {
            try
            {
                return
                (
                    await AponusDBContext.TiposEntidades
                        .Where(x => x.IdEstado != 0)
                        .ToListAsync(),
                        null
                );
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }
        internal async Task<(int?, Exception? ex)> GuardarTipoEntidad(EntidadesTipos NuevoTipo)
        {
            using var transaccion = await AponusDBContext.Database.BeginTransactionAsync();
            try
            {
                if (NuevoTipo.IdTipo != 0)
                {
                    EntidadesTipos? ExisteId = AponusDBContext.TiposEntidades                       
                        .FirstOrDefault(x => x.IdTipo == NuevoTipo.IdTipo);

                    if (ExisteId?.IdTipo != null && ExisteId?.IdTipo != 0 && !string.IsNullOrEmpty(NuevoTipo.NombreTipo))
                    {
                        ExisteId!.NombreTipo = NuevoTipo.NombreTipo;
                        ExisteId.IdEstado = 1;

                        AponusDBContext.TiposEntidades.Update(ExisteId);
                        await AponusDBContext.SaveChangesAsync();
                        await transaccion.CommitAsync();

                        return (StatusCodes.Status200OK, null);
                    }

                    return (null, new Exception("error al actualizar, no se encontro el Tipo"));
                }
                else
                {
                    await AponusDBContext.TiposEntidades.AddAsync(NuevoTipo);
                    await AponusDBContext.SaveChangesAsync();
                    await transaccion.CommitAsync();

                    return (StatusCodes.Status200OK, null);
                }
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }
        internal async Task<(List<EntidadesCategorias>? LstCategoriasEntidades, Exception? Ex)> ListarCategorias(int? idTipo)
        {
            try
            {
                IQueryable<EntidadesCategorias> QueryCategorias = AponusDBContext.CategoriasEntidades
                    .Where(x => x.IdEstado == 1);


                if (idTipo != null)
                {
                    var IdCategorias = await AponusDBContext.EntidadeTiposCategorias
                        .Where(x => x.idTipoEntidad == idTipo)
                        .Select(x => x.IdCategoriaEntidad)
                        .ToListAsync();

                    QueryCategorias = QueryCategorias.Where(x => IdCategorias.ToList().Equals(x.IdCategoria));
                }

                List<EntidadesCategorias> LstCategoriasEntidades = await QueryCategorias.ToListAsync();

                return (LstCategoriasEntidades, null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }


        }
        internal async Task<(int? Resultado, Exception? Ex)> GuardarCategoria(EntidadesCategorias nuevaCategoria, int? IdTipo)
        {
            bool rollback;
            using var transaccion = await AponusDBContext.Database.BeginTransactionAsync();

            try
            {
                var CategoriaExistente = await AponusDBContext.CategoriasEntidades.FirstOrDefaultAsync(x => x.NombreCategoria.Equals(nuevaCategoria.NombreCategoria) && x.IdEstado != 0);

                if (CategoriaExistente == null)
                {
                    await AponusDBContext.CategoriasEntidades.AddAsync(nuevaCategoria);
                    await AponusDBContext.SaveChangesAsync();

                    EntidadesCategorias? Cat = await AponusDBContext.CategoriasEntidades.FirstOrDefaultAsync(x => x.NombreCategoria == nuevaCategoria.NombreCategoria && x.IdEstado != 0);
                    EntidadesTipos? Tipo = await AponusDBContext.TiposEntidades.FirstOrDefaultAsync(x => x.IdTipo == IdTipo && x.IdEstado != 0);
                    nuevaCategoria.IdCategoria = Cat?.IdCategoria ?? 0;

                    rollback = await VincularTiposCategorias(Tipo, Cat);

                    if (!rollback)
                    {
                        await transaccion.CommitAsync();
                        return (StatusCodes.Status200OK, null);
                    }
                    else
                    {
                        await transaccion.RollbackAsync();
                        return (null, new Exception("No se aplicaron los cambios"));

                    }
                }
                else if (nuevaCategoria.IdCategoria != 0)
                {

                    CategoriaExistente = await AponusDBContext.CategoriasEntidades.FirstOrDefaultAsync(x => x.IdCategoria.Equals(nuevaCategoria.IdCategoria) && x.IdEstado != 0);

                    if (CategoriaExistente != null)
                        CategoriaExistente.NombreCategoria = nuevaCategoria.NombreCategoria ?? "";

                    await AponusDBContext.SaveChangesAsync();
                    await transaccion.CommitAsync();
                }

                return (StatusCodes.Status200OK, null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }
        internal async Task<bool> VincularTiposCategorias(EntidadesTipos? Tipo, EntidadesCategorias? Cat)
        {
            try
            {
                if (Tipo != null && Cat != null)
                {
                    EntidadesTiposCategorias vinculo = new EntidadesTiposCategorias()
                    {
                        idTipoEntidad = (int)Tipo.IdTipo,
                        IdCategoriaEntidad = (int)Cat.IdCategoria,
                        TipoEntidad = Tipo,
                        CategoriaEntidad = Cat

                    };

                    await AponusDBContext.EntidadeTiposCategorias.AddAsync(vinculo);
                    await AponusDBContext.SaveChangesAsync();
                    return false;
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        internal async Task<(int? Status, Exception? ex)> CambiarEstadoCategoria(EntidadesCategorias Categoria)
        {
            try
            {
                AponusDBContext.CategoriasEntidades.Update(Categoria);
                await AponusDBContext.SaveChangesAsync();

                return (StatusCodes.Status200OK, null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }

        }
        internal async Task<(int? Resultado, Exception? ex)> DesactivarTipoyRelaciones(EntidadesTipos TipoEntidad)
        {
            using var transaccion = await AponusDBContext.Database.BeginTransactionAsync();
            try
            {
                var Entidades = await AponusDBContext.Entidades
                    .Where(x => x.IdTipo == TipoEntidad.IdTipo)
                    .ToListAsync() ?? new List<Entidades>();

                Entidades.ForEach(x => x.IdEstado = 0);

                AponusDBContext.Entidades.UpdateRange(Entidades);
                AponusDBContext.TiposEntidades.Update(TipoEntidad);

                await AponusDBContext.SaveChangesAsync();
                await transaccion.CommitAsync();

                return (StatusCodes.Status200OK, null);
            }
            catch (Exception ex)
            {
                await transaccion.RollbackAsync();
                return (null, ex);
            }
        }

        //internal async Task<(List<EntidadesPago>? Listado, Exception? ex)> ListarEntidadesPago()
        //{
        //    return (await AponusDBContext.entidadespago
        //        .Select(x => new EntidadesPago()
        //        {
        //            Descripcion = x.Descripcion,
        //            Emisor = x.Emisor,
        //            IdEntidad = x.IdEntidad,
        //            Tipo = x.Tipo
        //        }).ToListAsync(), 
    }

}
