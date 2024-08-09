using Aponus_Web_API.Acceso_a_Datos.Entidades;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Data.Entity;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Business
{
    public static class BS_Entidades
    {
        internal static IActionResult Eliminar(int idProveedor)
        {
            try
            {
                return new ABM_Entidades().Eliminar(idProveedor);
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

        internal static IActionResult Listar(int IdTipo, int IdCategoria, int IdEntidad )
        {
            try
            {
                IQueryable<Entidades> QueryEntidades = new ABM_Entidades().Listar();

                if (IdEntidad != 0)
                    QueryEntidades = QueryEntidades.Where(x => x.IdEntidad == IdEntidad);
                if (IdTipo != 0)
                    QueryEntidades = QueryEntidades.Where(x => x.IdTipo == IdTipo);
                if (IdCategoria != 0)
                    QueryEntidades = QueryEntidades.Where(x => x.IdCategoria == IdCategoria);

                List<DTOEntidades> Listado =  QueryEntidades
                    .Select(x=>new DTOEntidades()
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
                        IdCategoria = x.IdCategoria
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

        internal static IActionResult Guardar(DTOEntidades Entidad)
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
                    DateTime FechaRegistro = Fechas.ObtenerFechaHora();
                    Entidad.NombreClave = !string.IsNullOrEmpty(Entidad.NombreClave) ?
                                    Regex.Replace(Entidad.NombreClave, @"\s+", " ").Trim().ToUpper() :
                                    Regex.Replace(Entidad.Apellido ?? "", @"\s+", " ").Trim().ToUpper() + " " +
                                    Regex.Replace(Entidad.Nombre ?? "", @"\s+", " ").Trim().ToUpper();

                    foreach ( PropertyInfo prop in Entidad.GetType().GetProperties())
                    {
                        if (prop.PropertyType == typeof(string) && !prop.Name.ToLower().Equals("idfiscal"))
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

                    return new ABM_Entidades().GuardarEntidad(Entidad);
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

        internal static class Tipos
        {
            internal static IActionResult Eliminar(int id)
            {
                try
                {
                    return new ABM_Entidades().EliminarTipo(id);
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

            internal static async Task<IActionResult> Guardar(DTOEntidadesTipos tipoEntidad)
            {
                try
                {
                    await new ABM_Entidades().GuardarTipo(tipoEntidad);
                    return new StatusCodeResult(200);
                }
                catch (Exception ex)
                {
                    string Mensaje = ex.InnerException?.Message ?? ex.Message;
                    return new ContentResult()
                    {
                        Content = Mensaje,
                        ContentType = "application/json",
                        StatusCode = 400
                    };

                }

            }

            internal static async Task<IActionResult> Listar()
            {
                List<EntidadesTipos>? EntidadesList = new List<EntidadesTipos>();
                List<DTOEntidadesTipos> DTOEntidades = new List<DTOEntidadesTipos>();

                IActionResult Tipos = await new ABM_Entidades().ListarTipos();

                if (Tipos is JsonResult JsonTiposEntidades)
                {
                    EntidadesList = JsonTiposEntidades.Value as List<EntidadesTipos>;

                }

                foreach (EntidadesTipos entidad in EntidadesList)
                {
                    DTOEntidades.Add(new DTOEntidadesTipos()
                    {
                        IdTipo = entidad.IdTipo,
                        Nombre = entidad.NombreTipo
                    });
                }

                return new JsonResult(DTOEntidades);

            }


        }

        internal static class Categorias
        {
            internal static IActionResult Eliminar(int idCategoria)
            {
                try
                {
                    return new ABM_Entidades().EliminarCategoria(idCategoria);
                }
                catch (Exception ex)
                {

                    return new ContentResult()
                    {
                        Content= ex.InnerException?.Message ??  ex.Message,
                        ContentType = "application/json",
                        StatusCode = 400
                         
                    };
                }
            }

            internal static async Task<IActionResult> Guardar(DTOEntidadesCategorias nuevaCategoria)
            {
                nuevaCategoria.NombreCategoria = !string.IsNullOrEmpty(nuevaCategoria.NombreCategoria) ?  Regex.Replace(nuevaCategoria.NombreCategoria, @"\s+", " ").Trim().ToUpper() : "";
                try
                {
                    _= await new ABM_Entidades().GuardarCategoria(nuevaCategoria);
                    return new StatusCodeResult(20);
                }
                catch (Exception ex)
                {

                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        ContentType="application/json",
                        StatusCode=400
                    };
                }
            }

            internal static async Task<IActionResult> Listar(int? idTipo)
            {
                List<EntidadesCategorias>? ListaCategorias = new List<EntidadesCategorias>();
                List<DTOEntidadesCategorias> DTOCategorias = new List<DTOEntidadesCategorias>();

                IActionResult Categorias = await new ABM_Entidades().ListarCategorias(idTipo);

                if (Categorias is JsonResult JsonCategorias)
                {
                    ListaCategorias = JsonCategorias.Value as List<EntidadesCategorias>;
                }

                foreach (EntidadesCategorias categoria in ListaCategorias)
                {
                    DTOCategorias.Add(new DTOEntidadesCategorias()
                    {
                        IdCategoria = categoria.IdCategoria,
                        NombreCategoria = categoria.NombreCategoria,
                    });
                }
                return new JsonResult(DTOCategorias);


            }
        }


    }
           
        

       
    
}
