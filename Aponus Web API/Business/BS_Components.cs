using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq.Expressions;
using System.Data.Entity.Validation;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Aponus_Web_API.Data_Transfer_Objects;

namespace Aponus_Web_API.Business
{
    public class BS_Components
    {
        internal JsonResult? DeterminarProp(DTOComponente? Especificaciones)
        {
            return new ObtenerComponentes().ListarProp(
                CategorizarPropiedades(Especificaciones).Item1,
                CategorizarPropiedades(Especificaciones).Item2);

        }

        internal IActionResult GuardarComponente(DTOComponente componente)
        {
            try
            {

                if (componente.idComponente != null && componente.IdDescripcion != null)
                {
                    new OperacionesComponentes().GuardarComponente(new ComponentesDetalle()
                    {
                        IdInsumo = componente.idComponente,
                        Diametro = componente.Diametro,
                        Altura = componente.Altura,
                        IdDescripcion = (int)componente.IdDescripcion,
                        DiametroNominal = componente.DiametroNominal,
                        Espesor = componente.Espesor,
                        IdAlmacenamiento = componente.idAlmacenamiento,
                        IdFraccionamiento = componente.idFraccionamiento,
                        Longitud = componente.Longitud,
                        Perfil = componente.Perfil,
                        Peso = componente.Peso,
                        Tolerancia = componente.Tolerancia,


                    });
                    return new StatusCodeResult(200);
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = "El Codigo de Componente y la Descripcion no pueden ser nulos",
                        ContentType = "text/plan",
                        StatusCode = 400

                    };
                }
            }
            catch (DbUpdateException ex)
            {
                string Mensaje;
                if (ex.InnerException.Message != null) 
                    Mensaje = ex.InnerException.Message;
                else Mensaje = ex.Message;

                
                    return new ContentResult()
                    {
                        Content = Mensaje,
                        ContentType = "text/plan",
                        StatusCode = 500,
                    };
                
            }
            
        }

        internal IActionResult GuardarComponentesProducto(List<DTOComponentesProducto> ComponentesProd)
        {
            bool ChkIdProd = ComponentesProd.All(x => x.IdProducto != null);
            ComponentesProductos CP = new ComponentesProductos();
            
            if (ChkIdProd)
            {
                foreach (DTOComponentesProducto Componente in ComponentesProd)
                {
                    try
                    {
                        CP.GuardarComponenteProd(new Productos_Componentes
                        {
                            IdProducto = Componente.IdProducto,
                            IdComponente = Componente.IdComponente,
                            Cantidad = Componente.Cantidad,
                            Longitud = Componente.Largo,
                            Peso = Componente.Peso,
                        });

                    }
                    catch (DbUpdateException)
                    {
                        return new ContentResult { Content = "Error al actualizar la Base de Datos", ContentType = "text/plan", StatusCode = 400 };
                    }
                    catch (DbEntityValidationException ex)
                    {
                        string Mensaje = "";

                        foreach (var entityValidationError in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                Mensaje += "Error de validación: Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage + "\n";
                            }
                        }

                        return new ContentResult { Content = Mensaje, StatusCode = 400 };

                    }
                    catch (InvalidOperationException)
                    {
                        return new ContentResult { Content = "Operacion Invalida", ContentType = "text/plan", StatusCode = 400 };
                    }
                    catch (Exception )
                    {
                        return new ContentResult { Content = "Objeto Inexistente", ContentType = "text/plan", StatusCode = 400 };
                    }


                }
            }
            else
            {
                return new ContentResult { Content = "Faltan Datos", ContentType = "text/plan", StatusCode = 400 };
            }

            return new StatusCodeResult(200);

        }

        internal IActionResult ListarComponentes(int? IdDescripcion)
        {
            return new ObtenerComponentes().Listar(IdDescripcion);
        }

        internal JsonResult? ObtenerIdComponente(DTOComponente? Especificaciones)
        {

            return new ObtenerComponentes().ObtenerId(CategorizarPropiedades(Especificaciones).Item2);

        }

        internal IActionResult ObtenerPropsComponentes()
        {
            string? TipoMapeado;

            ComponentesDetalle intancia = new ComponentesDetalle();
            var Tipo = intancia.GetType();
            var propiedades = Tipo.GetProperties();

            List<DTOInfoPropsComponentes> ListaInfoProps = new List<DTOInfoPropsComponentes>();

            var MapeoTipos = new Dictionary<Type, string>
            {
            { typeof(int), "int" },
            { typeof(string), "string" },
            { typeof(decimal), "decimal" },
            { typeof(int?), "int" },
            { typeof(decimal?), "decimal" },

            };
            foreach (var item in propiedades)
            {
               

                if (MapeoTipos.TryGetValue(item.PropertyType, out TipoMapeado) && !item.Name.Contains("IdInsumo"))
                {
                    ListaInfoProps.Add(new DTOInfoPropsComponentes()
                    {
                       Nombre= item.Name,
                        Tipo = TipoMapeado,

                    });
                }
            }

           
            return new JsonResult(ListaInfoProps);
            
        }
        //operacionescompoenentes.listarprops
        internal async Task<IActionResult> ObtenerTipoAlmacenamiento( )
        {
            
            return await new OperacionesComponentes().ListarTiposAlacenamiento();
        }

        private (string[], List<(string Nombre, string Valor)>) CategorizarPropiedades(DTOComponente? Especificaciones)
        {
            var propiedadesNulas = new string[0];
            List<(string Nombre, string Valor)> propiedadesNoNulas = new List<(string, string)>();
            var propiedades = typeof(DTOComponente).GetProperties();

            foreach (var propiedad in propiedades)
            {
                var valor = propiedad.GetValue(Especificaciones);
                bool propiedadExiste = typeof(ComponentesDetalle).GetProperty(propiedad.Name) != null;
                if (valor == null && propiedad.Name != "idComponente" && propiedadExiste)
                {
                    Array.Resize(ref propiedadesNulas, propiedadesNulas.Length + 1);
                    propiedadesNulas[propiedadesNulas.Length - 1] = propiedad.Name;
                }
                else if (valor != null)
                {
                    string _valor = valor.ToString();
                    propiedadesNoNulas.Add((propiedad.Name, _valor));

                }
            }

            return (propiedadesNulas,propiedadesNoNulas);

        }
            
    }
}
