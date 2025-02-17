using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Negocio
{
    public class BS_Categorias
    {
        private readonly AD_Categorias AdCategorias;
        private readonly AD_Componentes _ComponentesProductos;

        public BS_Categorias(AD_Categorias _AdCategorias, AD_Componentes componentesProductos)
        {
            AdCategorias = _AdCategorias;
            _ComponentesProductos = componentesProductos;
        }
        internal async Task<IActionResult> NormalizarDescripcionProducto(DTOCategorias NuevaCategoria)
        {

            ProductosDescripcion DescripcionProductoDB = new ProductosDescripcion()
            {
                DescripcionProducto = Regex.Replace(NuevaCategoria.Descripcion ?? "", @"\s+", " ").Trim().ToUpper(),  //Inserta la NombreDescripcion y obtiene el id
            };

            var (StatusCode, Error) = await AdCategorias.AgregarDescripcionProducto(DescripcionProductoDB, NuevaCategoria.IdTipo ?? "");

            if (Error != null)
                return new ContentResult()
                {
                    Content = Error.InnerException?.Message ?? Error.Message,
                    ContentType = "application/json",
                    StatusCode = 500
                };

            return new StatusCodeResult((int)StatusCode!);


        }
        internal JsonResult NormalizarNombreTipoProducto(DTOCategorias NuevaCategoria)
        {
            try
            {
                NuevaCategoria.IdTipo = new UTL_Categorias().GenerarIdTipoProducto(NuevaCategoria.DescripcionTipo ?? "");
                NuevaCategoria.DescripcionTipo = NuevaCategoria.DescripcionTipo?.ToUpper();
                AdCategorias.AgregarTipoProducto(NuevaCategoria);

                return new JsonResult(NuevaCategoria.IdTipo);

            }
            catch (DbUpdateException ex)
            {
                return new JsonResult(ex.InnerException?.Message.ToString());
            }

        }
        internal IActionResult MapearDescripcionesProductosDTO(string IdTipo)
        {
            var (resultado, error) = AdCategorias.ListarDescripcionesProductos(IdTipo);

            if (error != null)
                return new ContentResult()
                {
                    Content = error.InnerException?.Message ?? error.Message,
                    ContentType = "ApplicationBuilder/json",
                    StatusCode = 500,
                };

            List<DTODescripcionesProductos> ListadoDescripciones = new();

            resultado!
                .ForEach(descripcion => ListadoDescripciones.Add(new DTODescripcionesProductos()
                {
                    IdDescripcion = descripcion.IdDescripcion,
                    NombreDescripcion = descripcion.DescripcionProducto ?? ""
                }));

            return new JsonResult(ListadoDescripciones);

        }
        internal IActionResult ValidarOperacionActualizacion(DTOActualizarCategorias ActualizarCategorias)
        {
            //cambiar los return y agregar "se actuializo bla bla bla , valor anteriores blabla bla , avalor nuevo bla bla bli

            try
            {    //si tengo ID_TIPO anterior + el texto del NUEVO_TIPO actualizo el TIPO, para lo cual
                 //Verifico que exista el TIPO anterior, genero el nuevo ID_TIPO y actualizo 
                if (ActualizarCategorias?.Anterior?.IdTipo != null && ActualizarCategorias?.Nueva?.DescripcionTipo != null && ActualizarCategorias.Nueva.IdTipo == null)
                {
                    ActualizarCategorias.Nueva.IdTipo = new UTL_Categorias().GenerarIdTipoProducto(ActualizarCategorias.Nueva.DescripcionTipo);
                    ActualizarCategorias.Nueva.DescripcionTipo = ActualizarCategorias.Nueva.DescripcionTipo.TrimEnd().ToUpper();

                    ProductosTipo? TipoAnteriorExiste = AdCategorias.ObtenerTipo(ActualizarCategorias.Anterior.IdTipo);

                    if (TipoAnteriorExiste != null)
                    {
                        try
                        {
                            AdCategorias.ActualizarTipoProd(ActualizarCategorias);
                        }
                        catch (DbUpdateException ex)
                        {
                            string Mensaje;
                            if (ex.InnerException != null) Mensaje = ex.InnerException.Message; else Mensaje = ex.Message;

                            return new ContentResult()
                            {
                                StatusCode = 400,
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
                            Content = "Error: El campo 'NombreDescripcion' no puede estar vacio",
                            ContentType = "text/plain"

                        };
                    }

                }
                //Si no hay ID_TIPOS verifico si existe diferencia entre las DECRIPTIONS para actualizarlas
                else if (ActualizarCategorias?.Anterior?.IdTipo == null && ActualizarCategorias?.Nueva?.IdTipo == null)
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

                            if (ex.InnerException != null) Mensaje = ex.InnerException.Message; else Mensaje = ex.Message;

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
                            Content = "El campo 'NombreDescripcion' no puede estar vacio",
                            ContentType = "text/plain"

                        };

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
                // Axtualizar NombreDescripcion (cambiar el TIPO al que pertenece)
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
        internal IActionResult MapearNombresComponentesDTO()
        {
            List<ComponentesDescripcion>? NombresComponentes = _ComponentesProductos.ListarNombresComponentes();

            try
            {
                if (NombresComponentes != null)
                {
                    List<DTODescripcionComponentes> DTODescripcionesComponentes = new();

                    NombresComponentes.ForEach(componentes => DTODescripcionesComponentes.Add(new DTODescripcionComponentes()
                    {
                        NombreDescripcion = componentes.Descripcion ?? "",
                        IdAlmacenamiento = componentes.IdAlmacenamiento,
                        IdDescripcion = componentes.IdDescripcion,
                        IdFraccionamiento = componentes.IdFraccionamiento,
                    }));

                    return new JsonResult(DTODescripcionesComponentes);
                }
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    StatusCode = 500,
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "text/plain"

                };
            }


            return new JsonResult(null);

        }
        internal async Task<IActionResult> MapeoComponenteBD(DTODescripcionComponentes Componente)
        {
            ComponentesDescripcion componente = new ComponentesDescripcion()
            {
                Descripcion = Regex.Replace(Componente.NombreDescripcion, @"\s+", " ").Trim().ToUpper(),
                IdAlmacenamiento = Componente.IdAlmacenamiento ?? "",
                IdFraccionamiento = Componente?.IdFraccionamiento ?? "",
            };

            if (Componente?.IdDescripcion != 0)
            {
                componente.IdDescripcion = Componente!.IdDescripcion;
                var (statusCode, _error) = await AdCategorias.ModificarDescripcionComponente(componente);
                if (_error != null) return new ContentResult()
                {
                    StatusCode = 500,
                    Content = _error.InnerException?.Message ?? _error.Message,
                    ContentType = "text/plain"
                };

                return new StatusCodeResult((int)statusCode!);
            }
            else
            {
                var (StatusCode, error) = await AdCategorias.AgregarDescripcionCompoente(componente);
                if (error != null) return new ContentResult()
                {
                    StatusCode = 500,
                    Content = error.InnerException?.Message ?? error.Message,
                    ContentType = "text/plain"
                };

                return new StatusCodeResult((int)StatusCode!);
            }

        }

        internal async Task<IActionResult> RegistrarCambioEstadoTipoProducto(string idTipo)
        {
            ProductosTipo? TipoProducto = AdCategorias.ObtenerTipo(idTipo);

            if (TipoProducto != null)
            {
                TipoProducto.IdEstado = 0;
                var (statusCode, error) = await AdCategorias.MetodosProductos().DesactivarTipoProductoyRelaciones(TipoProducto);
                if (error != null)
                    return new ContentResult()
                    {
                        Content = error.InnerException?.Message ?? error.Message,
                        ContentType = "application/json",
                        StatusCode = 500
                    };
                if (statusCode == 200) return new StatusCodeResult((int)statusCode);
            }
            return new JsonResult(null);

        }
        internal async Task<IActionResult> RegistrarCambioEstadoDescripcionProducto(int idDescription)
        {
            var (Descripciones, error) = AdCategorias.ListarDescripcionesProductos(string.Empty);
            if (error != null) return new ContentResult()
            {
                Content = error.InnerException?.Message ?? error.Message,
                ContentType = "application/json",
                StatusCode = 500
            };

            ProductosDescripcion? productosDescripcion = Descripciones!.FirstOrDefault(x => x.IdDescripcion == idDescription);

            if (productosDescripcion != null)
            {
                productosDescripcion.IdEstado = 0;
                var (Resultado, Error) = await AdCategorias.MetodosProductos().DesactivarDescripcionProductoyRelaciones(productosDescripcion);

                if (error != null) return new ContentResult()
                {
                    Content = error.InnerException?.Message ?? error.Message,
                    ContentType = "application/json",
                    StatusCode = 500
                };

                if (Resultado == 200) return new StatusCodeResult((int)Resultado);
            }

            return new JsonResult(null);
        }

        internal JsonResult MapearTiposProductosDTO()
        {
            List<ProductosTipo>? TiposProductos = AdCategorias.MetodosProductos().ListarTiposProductos();

            List<DTOTiposProductos> DTOTiposProducto = new List<DTOTiposProductos>();

            foreach (var TipoProducto in TiposProductos ?? Enumerable.Empty<ProductosTipo>())
            {
                DTOTiposProducto.Add(new DTOTiposProductos()
                {
                    IdTipo = TipoProducto.IdTipo,
                    DescripcionTipo = TipoProducto.DescripcionTipo ?? "",
                });
            }

            return new JsonResult(DTOTiposProducto);
        }

        internal async Task<IActionResult> RegistrarCambioEstadoDescripcionComponente(int idDescripcion)
        {
            return null;
        }
    }
}
