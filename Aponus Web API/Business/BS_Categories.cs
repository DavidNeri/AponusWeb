using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Acceso_a_Datos.Sistema;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Business
{
    public class BS_Categories
    {
      
        internal IActionResult AgregarDescripcion(DTOCategorias NuevaCategoria)
        {
            NuevaCategoria.Descripcion = NuevaCategoria.Descripcion.ToUpper();
            try
            {
                Categorias categorias = new Categorias();

                //Inserta la Descripcion y obtiene el id
                NuevaCategoria.IdDescripcion = categorias.NuevaDescripcion(NuevaCategoria);

                if (NuevaCategoria.IdDescripcion != 0)
                {
                    try
                    {
                        categorias.VincularCategorias(NuevaCategoria);
                        return new StatusCodeResult(StatusCodes.Status200OK);

                    }
                    catch (DbUpdateException ex)
                    {
                        string Mensaje;
                        if (ex.InnerException != null) Mensaje = ex.InnerException.Message; else Mensaje = ex.Message;

                        return new ContentResult
                        {
                            StatusCode = 500,
                            Content = "Ocurrió un error: " + Mensaje,
                            ContentType = "text/plain"
                        };



                    }
                    catch (Exception ex)
                    {
                        string Mensaje;
                        if (ex.InnerException != null) Mensaje = ex.InnerException.Message; else Mensaje = ex.Message;

                        return new ContentResult
                        {
                            StatusCode = 500,
                            Content = "Ocurrió un error: " + Mensaje,
                            ContentType = "text/plain"
                        };

                    }
                }
                else
                {
                    return new ContentResult
                    {
                        StatusCode = 400,
                        Content = "Error: El campo 'Descripcion' no puede ser nulo ",
                        ContentType = "text/plain"
                    };
                }




            }
            catch (DbUpdateException e)
            {

                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }


        }

        internal JsonResult AgregarTipo(DTOCategorias NuevaCategoria)
        {
            try
            {
                NuevaCategoria.IdTipo = new CategoriesServices().GenerarIdTipo(NuevaCategoria.DescripcionTipo);
                NuevaCategoria.DescripcionTipo = NuevaCategoria.DescripcionTipo.ToUpper();
                new Categorias().NuevoTipo(NuevaCategoria);

                return new JsonResult(NuevaCategoria.IdTipo);

            }
            catch (DbUpdateException ex)
            {
                return new JsonResult(ex.InnerException.Message.ToString());
            }

        }
        internal List<DTODescripciones> ListarDescripciones(string IdTipo)
        {
            return new Categorias().ListarDescripciones(IdTipo);
        }
        internal IActionResult Actualizar(DTOActualizarCategorias ActualizarCategorias)
        {
            Categorias ObjCategorias = new Categorias();
            //cambiar los return y agregar "se actuializo bla bla bla , valor anteriores blabla bla , avalor nuevo bla bla bli

            try
            {    //si tengo ID_TIPO anterior + el texto del NUEVO_TIPO actualizo el TIPO, para lo cual
                 //Verifico que exista el TIPO anterior, genero el nuevo ID_TIPO y actualizo 
                if (ActualizarCategorias.Anterior.IdTipo != null && ActualizarCategorias.Nueva.DescripcionTipo != null && ActualizarCategorias.Nueva.IdTipo==null)
                {
                    ActualizarCategorias.Nueva.IdTipo = new CategoriesServices().GenerarIdTipo(ActualizarCategorias.Nueva.DescripcionTipo);
                    ActualizarCategorias.Nueva.DescripcionTipo = ActualizarCategorias.Nueva.DescripcionTipo.TrimEnd().ToUpper();

                    ProductosTipo? TipoAnteriorExiste =
                    ObjCategorias.ObtenerTipo(new ProductosTipo
                    {
                        IdTipo = ActualizarCategorias.Anterior.IdTipo,
                    });

                    if (TipoAnteriorExiste!=null)
                    {
                        try
                        {
                            ObjCategorias.ActualizarTipoProd(ActualizarCategorias);
                        }
                        catch (DbUpdateException ex)
                        {
                            string Mensaje;
                            if (ex.InnerException != null) Mensaje = ex.InnerException.Message; else Mensaje=ex.Message;

                            return new ContentResult()
                            {
                                StatusCode= 400,
                                Content = "Ocurrio un error " + Mensaje,
                                ContentType = "text/plain"

                            };
                        }


                    }
                    else
                    {
                        return new ContentResult()
                        {
                            StatusCode = 400,
                            Content = "Error: El campo 'Descripcion' no puede estar vacio" ,
                            ContentType = "text/plain"

                        };
                    }

                }
                //Si no hay ID_TIPOS verifico si existe diferencia entre las DECRIPTIONS para actualizarlas
                else if (ActualizarCategorias.Anterior.IdTipo==null&&ActualizarCategorias.Nueva.IdTipo==null) 
                {
                    if (ActualizarCategorias.Nueva.Descripcion!=null && ActualizarCategorias.Anterior.IdDescripcion!=null)
                    {
                        ActualizarCategorias.Nueva.Descripcion = ActualizarCategorias.Nueva.Descripcion.TrimEnd().ToUpper();

                        try
                        {
                            ObjCategorias.ActualizarDescripcionProd(ActualizarCategorias);
                            return new StatusCodeResult(200);
                        }
                        catch (DbUpdateException ex)
                        {
                            string Mensaje;

                            if (ex.InnerException != null) Mensaje = ex.InnerException.Message; else Mensaje=ex.Message ;

                            return new ContentResult()
                            {
                                StatusCode = 500,
                                Content = "Ocurrio un error " + Mensaje,
                                ContentType = "text/plain"

                            };
                        }
                    }
                    else if (ActualizarCategorias.Nueva.Descripcion== null)
                    {

                        return new ContentResult()
                        {
                            StatusCode = 400,
                            Content = "El campo 'Descripcion' no puede estar vacio",
                            ContentType = "text/plain"

                        };

                    }else
                    {
                        return new ContentResult()
                        {
                            StatusCode = 400,
                            Content = "Faltan Datos",
                            ContentType = "text/plain"

                        };
                    }

                } 
                // Axtualizar Descripcion (cambiar el TIPO al que pertenece)
                else if (ActualizarCategorias.Anterior.IdTipo!=null 
                    && ActualizarCategorias.Nueva.IdTipo != null
                    && (ActualizarCategorias.Anterior.IdTipo != ActualizarCategorias.Nueva.IdTipo)
                    && ActualizarCategorias.Anterior.IdDescripcion == ActualizarCategorias.Nueva.IdDescripcion)
                {                   
                        ObjCategorias.ActualizarTipos_Descripciones(ActualizarCategorias);
                        return new StatusCodeResult(200);
                }
                else
                {
                    return new ContentResult()
                    {
                        StatusCode = 400,
                        Content = "Faltan Datos",
                        ContentType = "text/plain"

                    };
                }


             }
             catch (DbUpdateException)
             {
                 return new StatusCodeResult(500);
             }

            return new ContentResult()
            {
                StatusCode = 500,
                Content = "Error Interno, fin de la instruccion",
                ContentType = "text/plain"

            };
        }

        internal async Task<JsonResult> ListarNombresComponentes()
        {
            return await new OperacionesComponentes().ListarNombres() ;
        }

        internal async Task<JsonResult> ObtenerNuevoIdComponente(string ComponentDescription)
        {
            return await new OperacionesComponentes().ObtenerNuevoId(ComponentDescription);
        }

        internal IActionResult AgregarDescripcionCompoente(string DescripcionComponente)
        {
            try
            {
                return new Categorias().AgregarDescripcionCompoente(DescripcionComponente);
            }
            catch (DbUpdateException ex)
            {

                if (ex.InnerException!=null)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException.Message,
                        ContentType = "text/plain",
                        StatusCode = 400,
                    
                    };
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = ex.Message,
                        ContentType = "text/plain",
                        StatusCode = 400,

                    };
                };
            }
        }

        internal IActionResult ModificarDescripcionCompoente(DTODescripcionComponentes descripcion)
        {
            try
            {
                return new Categorias().ModificarDescripcionComponente(descripcion);
            }
            catch (DbUpdateException ex)
            {

                if (ex.InnerException != null)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException.Message,
                        ContentType = "text/plain",
                        StatusCode = 400,

                    };
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = ex.Message,
                        ContentType = "text/plain",
                        StatusCode = 400,

                    };
                };
            }
        }
    }
}
