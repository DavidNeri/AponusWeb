using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Categorias = Aponus_Web_API.Acceso_a_Datos.Sistema.Categorias;

namespace Aponus_Web_API.Business
{
    public class BS_Categorias
    {
        private readonly Categorias AdCategorias;
        private readonly ComponentesProductos _ComponentesProductos;

        public BS_Categorias(Categorias _AdCategorias, ComponentesProductos componentesProductos)
        {
            AdCategorias = _AdCategorias;
            _ComponentesProductos = componentesProductos;
        }
        internal async Task<IActionResult> AgregarDescripcion(DTOCategorias NuevaCategoria)
        {
            try
            {
                ProductosDescripcion DescripcionProductoDB = new ProductosDescripcion()
                {
                    DescripcionProducto = Regex.Replace(NuevaCategoria.Descripcion ?? "", @"\s+", " ").Trim().ToUpper(),  //Inserta la Descripcion y obtiene el id
                };

                return await AdCategorias.NuevaDescripcion(DescripcionProductoDB, NuevaCategoria.IdTipo ?? "");    

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
        internal JsonResult AgregarTipo(DTOCategorias NuevaCategoria)
        {
            try
            {
                NuevaCategoria.IdTipo = new CategoriesServices().GenerarIdTipo(NuevaCategoria.DescripcionTipo??"");
                NuevaCategoria.DescripcionTipo = NuevaCategoria.DescripcionTipo?.ToUpper();
                AdCategorias.NuevoTipo(NuevaCategoria);

                return new JsonResult(NuevaCategoria.IdTipo);

            }
            catch (DbUpdateException ex)
            {
                return new JsonResult(ex.InnerException?.Message.ToString());
            }

        }
        internal List<DTODescripciones> ListarDescripciones(string IdTipo)
        {
            return AdCategorias.ListarDescripciones(IdTipo);
        }
        internal IActionResult Actualizar(DTOActualizarCategorias ActualizarCategorias)
        {
            //cambiar los return y agregar "se actuializo bla bla bla , valor anteriores blabla bla , avalor nuevo bla bla bli

            try
            {    //si tengo ID_TIPO anterior + el texto del NUEVO_TIPO actualizo el TIPO, para lo cual
                 //Verifico que exista el TIPO anterior, genero el nuevo ID_TIPO y actualizo 
                if (ActualizarCategorias?.Anterior?.IdTipo != null && ActualizarCategorias?.Nueva?.DescripcionTipo != null && ActualizarCategorias.Nueva.IdTipo==null)
                {
                    ActualizarCategorias.Nueva.IdTipo = new CategoriesServices().GenerarIdTipo(ActualizarCategorias.Nueva.DescripcionTipo);
                    ActualizarCategorias.Nueva.DescripcionTipo = ActualizarCategorias.Nueva.DescripcionTipo.TrimEnd().ToUpper();

                    ProductosTipo? TipoAnteriorExiste =
                    AdCategorias.ObtenerTipo(new ProductosTipo
                    {
                        IdTipo = ActualizarCategorias.Anterior.IdTipo,
                    });

                    if (TipoAnteriorExiste!=null)
                    {
                        try
                        {
                            AdCategorias.ActualizarTipoProd(ActualizarCategorias);
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
                else if (ActualizarCategorias?.Anterior?.IdTipo == null && ActualizarCategorias?.Nueva?.IdTipo==null) 
                {
                    if (ActualizarCategorias?.Nueva?.Descripcion != null && ActualizarCategorias.Anterior?.IdDescripcion != null)
                    {
                        ActualizarCategorias.Nueva.Descripcion = ActualizarCategorias.Nueva.Descripcion.TrimEnd().ToUpper();

                        try
                        {
                            AdCategorias.ActualizarDescripcionProd(ActualizarCategorias);
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
                    else if (ActualizarCategorias?.Nueva?.Descripcion == null)
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
                else if (ActualizarCategorias?.Anterior?.IdTipo != null && ActualizarCategorias.Nueva?.IdTipo != null && (ActualizarCategorias.Anterior.IdTipo != ActualizarCategorias.Nueva.IdTipo) && ActualizarCategorias.Anterior.IdDescripcion == ActualizarCategorias.Nueva.IdDescripcion)
                {                   
                        AdCategorias.ActualizarTipos_Descripciones(ActualizarCategorias);
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
            return await _ComponentesProductos.ListarNombresComponentes() ;
        }        
        internal IActionResult AgregarDescripcionCompoente(string DescripcionComponente)
        {
            try
            {
                return AdCategorias.AgregarDescripcionCompoente(DescripcionComponente);
            }
            catch (DbUpdateException ex)
            {

                if (ex.InnerException!=null)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message,
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
                return AdCategorias.ModificarDescripcionComponente(descripcion);
            }
            catch (DbUpdateException ex)
            {

                if (ex.InnerException != null)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message,
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
        internal IActionResult EliminarTipoProducto(string idTipo)
        {
            return AdCategorias.Productos_Metodos().EliminarTipo(idTipo);
        }
        internal IActionResult EliminarDescripcionProducto(int idDescription)
        {

            return AdCategorias.Productos_Metodos().EliminarDescripcion(idDescription);
        }

       
    }
}
