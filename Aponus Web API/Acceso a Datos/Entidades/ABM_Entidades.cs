using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Z.EntityFramework.Plus;
using static Aponus_Web_API.Business.BS_Entidades;

namespace Aponus_Web_API.Acceso_a_Datos.Entidades
{
    public class ABM_Entidades
    {
        private readonly AponusContext AponusDBContext;
        public ABM_Entidades() { AponusDBContext = new AponusContext(); }

        public IActionResult GuardarEntidad(DTOEntidades Entidad)
        {     
            
            try
            {
                if (Entidad.IdEntidad != null)
                {
                    var Existente = AponusDBContext.Entidades.FirstOrDefault(x => x.IdEntidad == Entidad.IdEntidad && x.IdEstado != 0 );                   

                    if (Existente != null)
                    {

                        Existente.NombreClave = Entidad.NombreClave ?? Existente.NombreClave;
                        Existente.Pais = Entidad.Pais ?? Existente.Pais;
                        Existente.Localidad = Entidad.Localidad ?? Existente.Localidad;
                        Existente.Calle = Entidad.Calle ?? Existente.Calle;
                        Existente.Altura = Entidad.Altura ?? Existente.Altura;
                        Existente.CodigoPostal = Entidad.CodigoPostal ?? Existente.CodigoPostal;
                        Existente.Telefono1 = Entidad.Telefono1 ?? Existente.Telefono1;
                        Existente.Telefono2 = Entidad.Telefono2 ?? Existente.Telefono2;
                        Existente.Telefono3 = Entidad.Telefono3 ?? Existente.Telefono3;
                        Existente.Email = Entidad.Email ?? Existente.Email;
                        Existente.IdFiscal = Entidad.IdFiscal ?? Existente.IdFiscal;
                        Existente.Ciudad = Entidad.Ciudad ?? Existente.Ciudad;
                        Existente.Provincia = Entidad.Provincia ?? Existente.Provincia;
                        Existente.Apellido = Entidad.Apellido ?? Existente.Apellido;
                        Existente.Nombre = Entidad.Nombre ?? Existente.Nombre;
                        Existente.IdUsuarioRegistro = Entidad.IdUsuarioRegistro ?? Existente.IdUsuarioRegistro;
                        Existente.Barrio = Entidad.Barrio ?? Existente.Barrio;
                        Existente.IdCategoria = Entidad.IdCategoria;
                        Existente.IdTipo = Entidad.IdTipo;

                        AponusDBContext.Entidades.Update(Existente);
                        AponusDBContext.SaveChanges();
                    }                   

                    return new StatusCodeResult(200);

                }
                else
                {
                    Models.Entidades NuevaEntidad = new Models.Entidades()
                    {
                        NombreClave = Entidad.Nombre ?? "",
                        Nombre = !string.IsNullOrEmpty(Entidad.Nombre) ? Entidad.Nombre.Trim().ToUpper().Replace(" ", "") : null,
                        Apellido = !string.IsNullOrEmpty(Entidad.Apellido) ? Entidad.Apellido.Trim().ToUpper().Replace(" ", "") : null,
                        Pais = !string.IsNullOrEmpty(Entidad.Pais) ? Entidad.Pais.Trim().ToUpper().Replace(" ", "") : null,
                        Ciudad = !string.IsNullOrEmpty(Entidad.Ciudad) ? Entidad.Ciudad.Trim().ToUpper().Replace(" ", "") : null,
                        Provincia = !string.IsNullOrEmpty(Entidad.Provincia) ? Entidad.Provincia.Trim().ToUpper().Replace(" ", "") : null,
                        Localidad = !string.IsNullOrEmpty(Entidad.Localidad) ? Entidad.Localidad.Trim().ToUpper().Replace(" ", "") : null,
                        Calle = !string.IsNullOrEmpty(Entidad.Calle) ? Entidad.Calle.Trim().ToUpper().Replace(" ", "") : null,
                        Altura = !string.IsNullOrEmpty(Entidad.Altura) ? Entidad.Altura.Trim().ToUpper().Replace(" ", "") : null,
                        CodigoPostal = !string.IsNullOrEmpty(Entidad.CodigoPostal) ? Entidad.CodigoPostal.Trim().ToUpper().Replace(" ", "") : null,
                        Telefono1 = !string.IsNullOrEmpty(Entidad.Telefono1) ? Entidad.Telefono1.Trim().ToUpper().Replace(" ", "") : null,
                        Telefono2 = !string.IsNullOrEmpty(Entidad.Telefono2) ? Entidad.Telefono2.Trim().ToUpper().Replace(" ", "") : null,
                        Telefono3 = !string.IsNullOrEmpty(Entidad.Telefono3) ? Entidad.Telefono3.Trim().ToUpper().Replace(" ", "") : null,
                        Email = !string.IsNullOrEmpty(Entidad.Email) ? Entidad.Email.Trim().ToUpper().Replace(" ", "") : null,
                        IdFiscal = Entidad.IdFiscal.Trim().ToUpper().Replace(" ", "").Replace("-", "").Replace("_", ""),
                        FechaRegistro = Entidad.FechaRegistro ?? Fechas.ObtenerFechaHora(),
                        IdUsuarioRegistro = Entidad.IdUsuarioRegistro ?? "",
                        IdTipo = Entidad.IdTipo,
                        IdCategoria = Entidad.IdCategoria

                    };

                    AponusDBContext.Entidades.Add(NuevaEntidad);
                    AponusDBContext.SaveChanges();
                    return new StatusCodeResult(200);
                }


            }
            catch (Exception ex)
            {
                ContentResult excepcion = new ContentResult()
                {
                    ContentType= "application/json",
                    StatusCode= 400,
                };

                excepcion.Content = !string.IsNullOrEmpty(ex.InnerException?.Message) ? "Error:\n"+ex.InnerException.Message : "Error:\n"+ex.Message;

                return excepcion;   
            }

        }        

        internal IActionResult Eliminar(int IdEntidad)
        {
            try
            {
                Models.Entidades? Entidad = AponusDBContext.Entidades.Find(IdEntidad);

                if (Entidad != null)
                {
                    Entidad.IdEstado= 0;
                    AponusDBContext.Entidades.Update(Entidad);
                    AponusDBContext.SaveChanges();

                    return new StatusCodeResult(200);

                }else
                {
                    return new ContentResult()
                    {
                        ContentType = "application/json",
                        StatusCode = 400,
                        Content ="No se encontró la entida"
                    };

                }
            }
            catch (DbUpdateException ex)
            {
                ContentResult excepcion = new ContentResult()
                {
                    ContentType = "application/json",
                    StatusCode = 400,
                };

                excepcion.Content = !string.IsNullOrEmpty(ex.InnerException?.Message) ? "Error:\n" + ex.InnerException.Message : "Error:\n" + ex.Message;

                return excepcion;
            }
            


        }

        internal IQueryable<Aponus_Web_API.Models.Entidades> Listar()
        {
            IQueryable<Aponus_Web_API.Models.Entidades> QueryListado = AponusDBContext.Entidades.Where(x => x.IdEstado != 0);
            
            return QueryListado;
           
        }


        internal async Task<IActionResult> ListarTipos()
        {
            try
            {
                var Entidades = await AponusDBContext.TiposEntidades.Where(x=>x.IdEstado!=0).ToListAsync();

                return new JsonResult(Entidades);   
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        internal async Task<IActionResult?> GuardarTipo(DTOEntidadesTipos NuevotipoEntidad)
        {
            NuevotipoEntidad.Nombre = !string.IsNullOrEmpty(NuevotipoEntidad.Nombre) ? Regex.Replace(NuevotipoEntidad.Nombre, @"\s+", " ").Trim().ToUpper() : null;
      

            using (var transaccion = await AponusDBContext.Database.BeginTransactionAsync())
            {
                try
                {

                    if (NuevotipoEntidad.IdTipo != null)
                    {
                        EntidadesTipos? ExisteId = AponusDBContext.TiposEntidades.FirstOrDefault(x => x.IdTipo == NuevotipoEntidad.IdTipo & x.IdEstado!=0);

                        if ( ExisteId?.IdTipo != null && !string.IsNullOrEmpty(NuevotipoEntidad.Nombre))
                        {
                            ExisteId.NombreTipo = NuevotipoEntidad.Nombre;
                            AponusDBContext.TiposEntidades.Update(ExisteId);
                            
                            AponusDBContext.SaveChanges();
                            transaccion.Commit();
                            return new StatusCodeResult(200);

                        }
                    }
                    else
                    {
                        EntidadesTipos? ExisteNombre = AponusDBContext.TiposEntidades.FirstOrDefault(x => x.NombreTipo == NuevotipoEntidad.Nombre && x.IdEstado!=0);

                        if (string.IsNullOrEmpty(ExisteNombre?.NombreTipo) && !string.IsNullOrEmpty(NuevotipoEntidad.Nombre))
                        {
                            _ = AponusDBContext.TiposEntidades.AddAsync(new EntidadesTipos()
                            {
                                NombreTipo = NuevotipoEntidad.Nombre
                            }); ;

                           
                            await AponusDBContext.SaveChangesAsync();
                            await transaccion.CommitAsync();
                            return new StatusCodeResult(200);
                        }
                        else
                        {
                            return new ContentResult()
                            {
                                Content = "El Tipo ya existe",
                                ContentType = "application/json",
                                StatusCode = 400

                            };
                        }
                       
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    string Mensaje = ex.InnerException?.Message ?? ex.Message; 

                    return new ContentResult()
                    {
                        ContentType = "application/json",
                        StatusCode = 400,
                        Content = Mensaje
                    };
                }
            }
        }

        internal async Task<IActionResult> ListarCategorias(int? idTipo)
        {
            try
            {
                IEnumerable<EntidadesCategorias> QueryCategorias = await AponusDBContext.CategoriasEntidades.Where(x => x.IdEstado == 1).ToListAsync();

                if (idTipo.HasValue)
                {
                    ICollection<EntidadesTiposCategorias>? Tipo = await AponusDBContext.EntidadeTiposCategorias
                        .Where(x => x.idTipoEntidad == idTipo)
                        .ToListAsync();

                    var TipoCategorias = Tipo.Select(x => x.IdCategoriaEntidad).ToList();

                    QueryCategorias = QueryCategorias.Where(x => TipoCategorias.Contains(x.IdCategoria));
                }

                var ListaCategorias = QueryCategorias.Select(x => new EntidadesCategorias()
                {
                    IdCategoria = x.IdCategoria,
                    NombreCategoria = x.NombreCategoria,
                })
                .ToList();

                return new JsonResult(ListaCategorias);
            }
            catch (Exception ex)
            {

                return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 400

                };
            }
            

        }
            
            
        
        internal async Task<IActionResult> GuardarCategoria(DTOEntidadesCategorias nuevaCategoria)
        {
            bool rollback;
            using (var transaccion = await AponusDBContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var CategoriaExistente = await AponusDBContext.CategoriasEntidades.FirstOrDefaultAsync(x => x.NombreCategoria.Equals(nuevaCategoria.NombreCategoria) && x.IdEstado!=0);

                    if (CategoriaExistente == null)
                    {
                        await AponusDBContext.CategoriasEntidades.AddAsync(new EntidadesCategorias()
                        {
                            NombreCategoria = nuevaCategoria.NombreCategoria ?? "",
                        });

                        await AponusDBContext.SaveChangesAsync();

                        EntidadesCategorias? Cat = await AponusDBContext.CategoriasEntidades.FirstOrDefaultAsync(x => x.NombreCategoria == nuevaCategoria.NombreCategoria && x.IdEstado != 0);
                        EntidadesTipos? Tipo = await AponusDBContext.TiposEntidades.FirstOrDefaultAsync(x => x.IdTipo == nuevaCategoria.IdTipo && x.IdEstado != 0);
                        nuevaCategoria.IdCategoria = Cat?.IdCategoria;

                        rollback = await VincularTiposCategorias(Tipo, Cat);


                        if (!rollback)
                        {
                            await transaccion.CommitAsync();
                            return new StatusCodeResult(200);
                        }
                        else
                        {
                            await transaccion.RollbackAsync();
                            return new ContentResult()
                            {
                                Content = "Error interno, no se aplicaron lo cambios",
                                ContentType = "application/json",
                                StatusCode = 400,
                            };
                        }
                    }
                    else
                    {
                        CategoriaExistente.NombreCategoria = nuevaCategoria.NombreCategoria ?? "";
                        var ValidarVinculo = await AponusDBContext.EntidadeTiposCategorias.FindAsync(nuevaCategoria.IdTipo ?? 0, CategoriaExistente.IdCategoria);
                        AponusDBContext.CategoriasEntidades.Update(CategoriaExistente);
                        
                        if (ValidarVinculo== null)
                        {
                            await AponusDBContext.EntidadeTiposCategorias.AddAsync(new EntidadesTiposCategorias()
                            {
                                idTipoEntidad = nuevaCategoria.IdTipo ?? 0,
                                IdCategoriaEntidad = CategoriaExistente.IdCategoria,
                            });
                        }
                        
                        await AponusDBContext.SaveChangesAsync();
                        await transaccion.CommitAsync();
                        return new StatusCodeResult(200);
                    }

                }
                catch (Exception ex)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        ContentType = "application/json",
                        StatusCode = 400,
                    };
                }
            }
        }


        internal async Task<bool> VincularTiposCategorias(EntidadesTipos? Tipo,EntidadesCategorias? Cat )
        {
            try
            {
                if (Tipo != null && Cat!= null)
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

        internal IActionResult EliminarCategoria(int idCategoria)
        {
            EntidadesCategorias? Categoria = AponusDBContext.CategoriasEntidades.FirstOrDefault(x => x.IdCategoria == idCategoria);

            if (Categoria != null)
            {
                Categoria.IdEstado = 0;

                try
                {
                    AponusDBContext.CategoriasEntidades.Update(Categoria);
                    AponusDBContext.SaveChanges();
                    return new StatusCodeResult(200);
                }
                catch (Exception ex)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        StatusCode = 400,
                        ContentType = "application/json"                    
                    };
                }               

            }else
            {
                return new ContentResult()
                {
                    Content = "Error: No se encontro la Categoría", 
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }

        }

        internal IActionResult EliminarTipo(int id)
        {
            EntidadesTipos? Tipo = AponusDBContext.TiposEntidades.FirstOrDefault(x => x.IdTipo == id);
            var EntidadesTipoCategorias = AponusDBContext.EntidadeTiposCategorias.Where(x=>x.idTipoEntidad==id).ToList();

            using (var transaccion = AponusDBContext.Database.BeginTransaction())
            {



            }

            if (EntidadesTipoCategorias != null)
            {

            }

            if (Tipo != null)
            {
                Tipo.IdEstado = 0;

                try
                {
                    AponusDBContext.TiposEntidades.Update(Tipo);
                    AponusDBContext.SaveChanges();
                    return new StatusCodeResult(200);

                }
                catch (Exception ex)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        StatusCode = 400,
                        ContentType = "application/json"
                    };
                }
            }
            else
            {
                return new ContentResult()
                {
                    Content = "Error: No se encontro la Categoría",
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }
        }
    }
    
}
    