using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Acceso_a_Datos.Proveedores
{
    public class ABM_Proveedores
    {
        private readonly AponusContext AponusDBContext;
        public ABM_Proveedores() { AponusDBContext = new AponusContext(); }

        public IActionResult Guardar(DTOProveedores Proveedor)
        {
            DateTime FechaRegistro = Fechas.ObtenerFechaHora();

            string NombreClave = !string.IsNullOrEmpty(Proveedor.NombreClave) ?
                                    Proveedor.NombreClave.Trim().ToUpper() :
                                    Proveedor.Apellido.Trim().ToUpper() + " " +
                                    Proveedor.Nombre.Trim().ToUpper();           
            
            try
            {
                if (Proveedor.IdEntidad != null)
                {
                    var Existente = AponusDBContext.Proveedores.FirstOrDefault(x => x.IdEntidad == Proveedor.IdEntidad);                   

                    if (Existente != null)
                    {

                        Existente.NombreClave = NombreClave ?? Existente.NombreClave;
                        Existente.Pais = Proveedor.Pais ?? Existente.Pais;
                        Existente.Localidad = Proveedor.Localidad ?? Existente.Localidad;
                        Existente.Calle = Proveedor.Calle ?? Existente.Calle;
                        Existente.Altura = Proveedor.Altura ?? Existente.Altura;
                        Existente.CodigoPostal = Proveedor.CodigoPostal ?? Existente.CodigoPostal;
                        Existente.Telefono1 = Proveedor.Telefono1 ?? Existente.Telefono1;
                        Existente.Telefono2 = Proveedor.Telefono2 ?? Existente.Telefono2;
                        Existente.Telefono3 = Proveedor.Telefono3 ?? Existente.Telefono3;
                        Existente.Email = Proveedor.Email ?? Existente.Email;
                        Existente.IdFiscal = Proveedor.IdFiscal ?? Existente.IdFiscal;
                        Existente.Ciudad = Proveedor.Ciudad ?? Existente.Ciudad;
                        Existente.Provincia = Proveedor.Provincia ?? Existente.Provincia;
                        Existente.Apellido = Proveedor.Apellido ?? Existente.Apellido;
                        Existente.Nombre = Proveedor.Nombre ?? Existente.Nombre;
                        Existente.IdUsuarioRegistro = Proveedor.IdUsuarioRegistro ?? Existente.IdUsuarioRegistro;
                        Existente.Barrio = Proveedor.Barrio ?? Existente.Barrio;

                        AponusDBContext.SaveChanges();
                    }                   

                    return new StatusCodeResult(200);

                }
                else
                {
                    Models.Clientes_Proveedores NuevoProveedor = new Models.Clientes_Proveedores()
                    {
                        NombreClave = !string.IsNullOrEmpty(Proveedor.NombreClave) ?
                                        Proveedor.NombreClave.Trim().ToUpper() :
                                        Proveedor.Apellido.Trim().ToUpper() + " " +
                                        Proveedor.Nombre.Trim().ToUpper(),

                        Nombre = !string.IsNullOrEmpty(Proveedor.Nombre) ? Proveedor.Nombre.Trim().ToUpper().Replace(" ", "") : null,
                        Apellido = !string.IsNullOrEmpty(Proveedor.Apellido) ? Proveedor.Apellido.Trim().ToUpper().Replace(" ", "") : null,
                        Pais = !string.IsNullOrEmpty(Proveedor.Pais) ? Proveedor.Pais.Trim().ToUpper().Replace(" ", "") : null,
                        Ciudad = !string.IsNullOrEmpty(Proveedor.Ciudad) ? Proveedor.Ciudad.Trim().ToUpper().Replace(" ", "") : null,
                        Provincia = !string.IsNullOrEmpty(Proveedor.Provincia) ? Proveedor.Provincia.Trim().ToUpper().Replace(" ", "") : null,
                        Localidad = !string.IsNullOrEmpty(Proveedor.Localidad) ? Proveedor.Localidad.Trim().ToUpper().Replace(" ", "") : null,
                        Calle = !string.IsNullOrEmpty(Proveedor.Calle) ? Proveedor.Calle.Trim().ToUpper().Replace(" ", "") : null,
                        Altura = !string.IsNullOrEmpty(Proveedor.Altura) ? Proveedor.Altura.Trim().ToUpper().Replace(" ", "") : null,
                        CodigoPostal = !string.IsNullOrEmpty(Proveedor.CodigoPostal) ? Proveedor.CodigoPostal.Trim().ToUpper().Replace(" ", "") : null,
                        Telefono1 = !string.IsNullOrEmpty(Proveedor.Telefono1) ? Proveedor.Telefono1.Trim().ToUpper().Replace(" ", "") : null,
                        Telefono2 = !string.IsNullOrEmpty(Proveedor.Telefono2) ? Proveedor.Telefono2.Trim().ToUpper().Replace(" ", "") : null,
                        Telefono3 = !string.IsNullOrEmpty(Proveedor.Telefono3) ? Proveedor.Telefono3.Trim().ToUpper().Replace(" ", "") : null,
                        Email = !string.IsNullOrEmpty(Proveedor.Email) ? Proveedor.Email.Trim().ToUpper().Replace(" ", "") : null,
                        IdFiscal = Proveedor.IdFiscal.Trim().ToUpper().Replace(" ", "").Replace("-", "").Replace("_", ""),
                        FechaRegistro = FechaRegistro,
                        IdUsuarioRegistro = Proveedor.IdUsuarioRegistro,

                    };

                    AponusDBContext.Proveedores.Add(NuevoProveedor);
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

                excepcion.Content = !string.IsNullOrEmpty(ex.InnerException.Message) ? "Error:\n"+ex.InnerException.Message : "Error:\n"+ex.Message;

                return excepcion;   
            }

        }        

        internal IActionResult Eliminar(int idProveedor)
        {
            try
            {
                Models.Clientes_Proveedores? Proveedor = AponusDBContext.Proveedores.Find(idProveedor);

                if (Proveedor != null)
                {
                    Proveedor.IdEstado= 0;
                    AponusDBContext.Proveedores.Update(Proveedor);
                    AponusDBContext.SaveChanges();

                    return new StatusCodeResult(200);

                }else
                {
                    return new ContentResult()
                    {
                        ContentType = "application/json",
                        StatusCode = 400,
                        Content ="No se encontró el Proveedor"
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

                excepcion.Content = !string.IsNullOrEmpty(ex.InnerException.Message) ? "Error:\n" + ex.InnerException.Message : "Error:\n" + ex.Message;

                return excepcion;
            }
            


        }

        internal IActionResult Listar(int? IdProveedor = null)
        {
            try
            {
                IQueryable<DTOProveedores> Listado = AponusDBContext.Proveedores
                   .Where(x => x.IdEstado == 1)
                   .Select(x => new DTOProveedores()
                   {
                       Altura = x.Altura,
                       Apellido = x.Apellido,
                       Calle = x.Calle,
                       Ciudad = x.Ciudad,
                       CodigoPostal = x.CodigoPostal,
                       Email = x.Email,
                       IdFiscal = x.IdFiscal,
                       Localidad = x.Localidad,
                       Pais = x.Pais,
                       NombreClave = x.NombreClave,
                       Telefono1 = x.Telefono1,
                       Telefono2 = x.Telefono2,
                       Telefono3 = x.Telefono3,
                       Nombre = x.Nombre,
                       Provincia = x.Provincia,
                       Barrio = x.Barrio,
                       IdEntidad = x.IdEntidad,

                   })
                   .OrderBy(x => x.Apellido)
                   .ThenBy(x => x.Nombre)
                   .ThenBy(x => x.NombreClave);

                if (IdProveedor != null)
                {
                    return new JsonResult(Listado.FirstOrDefault(x => x.IdEntidad == IdProveedor));
                }

                return new JsonResult(Listado);
            }
            catch (Exception ex)
            {

                return new ContentResult()
                {
                    ContentType = "application/json",
                    StatusCode = 400,
                    Content = !string.IsNullOrEmpty(ex.InnerException.Message) ? "Error:\n" + ex.InnerException.Message : "Error:\n" + ex.Message
                };
            }
        }
    }
    
}
