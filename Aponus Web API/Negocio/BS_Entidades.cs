using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Negocio
{
    public class BS_Entidades
    {
        private readonly AD_Entidades AdEntidades;

        public BS_Entidades(AD_Entidades adEntidades)
        {
            AdEntidades = adEntidades;
        }
        public Tipos TiposEntidades()
        {
            return new Tipos(AdEntidades);
        }

        public Categorias CategoriasEntidades()
        {
            return new Categorias(AdEntidades);
        }

        internal async Task<IActionResult> ValidarEntidad(int idEntidad)
        {
            IQueryable<Entidades> LstEntidades = AdEntidades.ListarEntidades();
            Entidades? Entidad = LstEntidades.FirstOrDefault(x => x.IdEntidad == idEntidad);

            if (Entidad == null)
            {
                return new ContentResult()
                {
                    ContentType = "application/json",
                    StatusCode = 400,
                    Content = "No se encontró la Entidad"
                };
            }
            else
            {
                var (Status, error) = await AdEntidades.DeshabilitarEntidad(Entidad);
                if (error != null) return new ContentResult()
                {
                    ContentType = "application/json",
                    StatusCode = 400,
                    Content = error.InnerException?.Message ?? error.Message
                };

                return new StatusCodeResult((int)Status!);
            }
        }

        internal IActionResult MapeoEntidadesDTO(int IdTipo, int IdCategoria, int IdEntidad)
        {
            try
            {
                IQueryable<Modelos.Entidades> QueryEntidades = AdEntidades.ListarEntidades();

                if (IdEntidad != 0)
                    QueryEntidades = QueryEntidades.Where(x => x.IdEntidad == IdEntidad);
                if (IdTipo != 0)
                    QueryEntidades = QueryEntidades.Where(x => x.IdTipo == IdTipo);
                if (IdCategoria != 0)
                    QueryEntidades = QueryEntidades.Where(x => x.IdCategoria == IdCategoria);

                List<DTOEntidades> Listado = QueryEntidades
                    .Select(x => new DTOEntidades()
                    {
                        IdEntidad = x.IdEntidad,
                        NombreClave = x.NombreClave,
                        Nombre = x.Nombre,
                        Apellido = x.Apellido,
                        Pais = x.Pais,
                        Ciudad = x.Ciudad,
                        Provincia = x.Provincia,
                        Localidad = x.Localidad,
                        Calle = x.Calle,
                        Altura = x.Altura,
                        CodigoPostal = x.CodigoPostal,
                        Barrio = x.Barrio,
                        Telefono1 = x.Telefono1,
                        Telefono2 = x.Telefono2,
                        Telefono3 = x.Telefono3,
                        Email = x.Email,
                        IdFiscal = x.IdFiscal,
                        FechaRegistro = x.FechaRegistro,
                        IdUsuarioRegistro = x.IdUsuarioRegistro,
                        IdTipo = x.IdTipo,
                        IdCategoria = x.IdCategoria,
                        Tipo = new DTOEntidadesTipos { IdTipo = x.TipoEntidad.IdTipo , Nombre = x.TipoEntidad.NombreTipo},
                        Categoria = new DTOEntidadesCategorias {IdCategoria = x.CategoriaEntidad.IdCategoria, NombreCategoria = x.CategoriaEntidad.NombreCategoria }                      

                        
                    })
                    .ToList();
                return new JsonResult(Listado);





            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    ContentType = "application/json",
                    StatusCode = 400,
                    Content = !string.IsNullOrEmpty(ex.InnerException?.Message) ? "Error:\n" + ex.InnerException.Message : "Error:\n" + ex.Message
                };
            }
        }

        internal IActionResult ValidaryNormalizarDatos(DTOEntidades Entidad)
        {
            try
            {
                if (Entidad.Nombre == null && Entidad.Apellido == null && Entidad.NombreClave == null)
                {
                    return new ContentResult()
                    {
                        Content = "Completar Nombre, Apellido y/o Razón Social",
                        ContentType = "application/json",
                        StatusCode = 400,
                    };
                }
                else
                {
                    DateTime FechaRegistro = UTL_Fechas.ObtenerFechaHora();
                    Entidad.NombreClave = !string.IsNullOrEmpty(Entidad.NombreClave) ?
                                    Regex.Replace(Entidad.NombreClave, @"\s+", " ").Trim().ToUpper() :
                                    Regex.Replace(Entidad.Apellido ?? "", @"\s+", " ").Trim().ToUpper() + " " +
                                    Regex.Replace(Entidad.Nombre ?? "", @"\s+", " ").Trim().ToUpper();

                    foreach (PropertyInfo prop in Entidad.GetType().GetProperties())
                    {
                        if (prop.PropertyType == typeof(string) && !prop.Name.ToLower().Equals("idfiscal") && !prop.Name.ToLower().Equals("idusuarioregistro"))
                        {
                            string? valor = (string?)prop.GetValue(Entidad);
                            string ValorNormalizado = Regex.Replace(valor ?? "", @"\s+ ", " ").Trim().ToUpper();
                            prop.SetValue(Entidad, ValorNormalizado);
                        }
                        else if (prop.Name.ToLower().Equals("idfiscal"))
                        {
                            string? valor = (string?)prop.GetValue(Entidad);
                            string ValorNormalizado = Regex.Replace(valor ?? "", "-", "");
                            prop.SetValue(Entidad, ValorNormalizado);
                        }
                    }

                    return AdEntidades.GuardarEntidad(Entidad);
                }


            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    ContentType = "application/json",
                    StatusCode = 400,
                    Content = !string.IsNullOrEmpty(ex.InnerException?.Message) ? "Error:\n" + ex.InnerException.Message : "Error:\n" + ex.Message
                };
            }
        }

        //internal async IActionResult MapeoEntidadesPagoDTO()
        //{
        //    return null;

        //    var (Listado, ex) = await AdEntidades.ListarEntidadesPago();

        //    if (ex != null) return new ContentResult()
        //    {
        //        Content = ex.InnerException?.Message ?? ex?.Message,
        //        ContentType = "application/json",
        //        StatusCode = 400,
        //    };
        //}

        public class Tipos
        {
            private readonly AD_Entidades AdEntidades;

            public Tipos(AD_Entidades adEntidades)
            {
                AdEntidades = adEntidades;
            }

            internal async Task<IActionResult> ValidarTipoEntidad(int id)
            {
                try
                {
                    var (LstTipos, ex) = await AdEntidades.ListarTiposEntidades();
                    if (ex != null) return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        ContentType = "application/json",
                        StatusCode = 400
                    };
                    EntidadesTipos? TipoEntidad = LstTipos!.FirstOrDefault(x => x.IdTipo == id);
                    if (TipoEntidad != null)
                    {
                        TipoEntidad.IdEstado = 0;

                        var (Resultado, _ex) = await AdEntidades.DesactivarTipoyRelaciones(TipoEntidad);
                        if (_ex != null) return new ContentResult()
                        {
                            Content = _ex.InnerException?.Message ?? _ex.Message,
                            ContentType = "application/json",
                            StatusCode = 400
                        };

                        return new StatusCodeResult((int)Resultado!);
                    }
                    else
                    {
                        return new ContentResult()
                        {
                            Content = "No se encontró el Tipo",
                            ContentType = "application/json",
                            StatusCode = 400
                        };
                    }
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

            internal async Task<IActionResult> MapeoDTOTipoEntidadDB(DTOEntidadesTipos tipoEntidad)
            {
                EntidadesTipos NuevoTipo = new()
                {
                    NombreTipo = !string.IsNullOrEmpty(tipoEntidad.Nombre) ? Regex.Replace(tipoEntidad.Nombre, @"\s+", " ").Trim().ToUpper() : string.Empty,
                    IdTipo = tipoEntidad.IdTipo ?? 0
                };

                var (Resultado, ex) = await AdEntidades.GuardarTipoEntidad(NuevoTipo);

                if (ex != null) return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 400
                };

                return new StatusCodeResult((int)Resultado!);

            }

            internal async Task<IActionResult> MapeoTiposEntidadesDTO()
            {
                List<DTOEntidadesTipos> DTOEntidades = new();

                var (LstTipos, ex) = await AdEntidades.ListarTiposEntidades();

                if (ex != null)
                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex?.Message,
                        ContentType = "application/json",
                        StatusCode = 400,
                    };

                LstTipos!.ForEach(X => DTOEntidades.Add(new DTOEntidadesTipos()
                {
                    IdTipo = X.IdTipo,
                    Nombre = X.NombreTipo
                }));

                return new JsonResult(DTOEntidades);
            }
        }

        public class Categorias
        {
            private readonly AD_Entidades AdEntidades;
            public Categorias(AD_Entidades adEntidades)
            {
                AdEntidades = adEntidades;
            }
            internal async Task<IActionResult> ValidarCategoria(int idCategoria)
            {

                var (LstEntidades, ex) = await AdEntidades.ListarCategorias(null);
                if (ex != null) return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex?.Message,
                    ContentType = "application/json",
                    StatusCode = 400,
                };

                EntidadesCategorias? CategoriaEntidad = LstEntidades!.FirstOrDefault(x => x.IdCategoria == idCategoria);

                if (CategoriaEntidad != null)
                {
                    CategoriaEntidad.IdEstado = 0;
                    var (resultado, _ex) = await AdEntidades.CambiarEstadoCategoria(CategoriaEntidad);

                    if (_ex != null) return new ContentResult()
                    {
                        Content = _ex.InnerException?.Message ?? _ex?.Message,
                        ContentType = "application/json",
                        StatusCode = 400,
                    };

                    return new StatusCodeResult((int)resultado!);
                }

                return new ContentResult()
                {
                    Content = "No se encontróla Categoría",
                    ContentType = "application/json",
                    StatusCode = 400,
                };


            }
            internal async Task<IActionResult> MapeoNuevaCategoriaDB(DTOEntidadesCategorias nuevaCategoria)
            {

                EntidadesCategorias entidadesCategorias = new EntidadesCategorias()
                {
                    IdCategoria = nuevaCategoria.IdCategoria ?? 0,
                    NombreCategoria = !string.IsNullOrEmpty(nuevaCategoria.NombreCategoria) ? Regex.Replace(nuevaCategoria.NombreCategoria, @"\s+", " ").Trim().ToUpper() : "",

                };

                var (Resultado, ex) = await AdEntidades.GuardarCategoria(entidadesCategorias, nuevaCategoria.IdTipo);
                if (ex != null) return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 400
                };

                return new StatusCodeResult((int)Resultado!);

            }
            internal async Task<IActionResult> MapeoEntidadesCategoriasDTO(int? idTipo)
            {
                List<EntidadesCategorias>? ListaCategorias = new List<EntidadesCategorias>();
                List<DTOEntidadesCategorias> DTOCategorias = new List<DTOEntidadesCategorias>();

                var (LstCategorias, ex) = await AdEntidades.ListarCategorias(idTipo);

                if (ex != null) return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 400
                };

                LstCategorias!.ForEach(c => DTOCategorias.Add(new DTOEntidadesCategorias()
                {
                    IdTipo = idTipo,
                    IdCategoria = c.IdCategoria,
                    NombreCategoria = c.NombreCategoria,
                }));

                return new JsonResult(DTOCategorias);


            }
        }


    }





}
