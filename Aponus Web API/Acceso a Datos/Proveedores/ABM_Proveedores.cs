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

        public IActionResult NuevoProveedor(DTOProveedores Proveedor)
        {
            if(Proveedor.Nombre ==null && Proveedor.Apellido == null && Proveedor.NombreClave == null) return new ContentResult()
            {
                Content= "Completar Nombre, Apellido y/o Razon Social",
                ContentType="application/json",
                StatusCode=400,

            };

            try
            {
                AponusDBContext.Proveedores.Add(new Models.Proveedores()
                {
                    NombreClave= !string.IsNullOrEmpty(Proveedor.NombreClave) ? 
                                    Proveedor.NombreClave.Trim().ToUpper().Replace(" ","") :
                                    Proveedor.Apellido.Trim().ToUpper().Replace(" ", "") + " " + 
                                    Proveedor.Nombre.Trim().ToUpper().Replace(" ", ""),

                    Nombre = !string.IsNullOrEmpty(Proveedor.Nombre) ? Proveedor.Nombre.Trim().ToUpper().Replace(" ", "") : null,
                    Apellido= !string.IsNullOrEmpty(Proveedor.Apellido) ? Proveedor.Apellido.Trim().ToUpper().Replace(" ", "") : null,
                    Pais= !string.IsNullOrEmpty(Proveedor.Pais) ? Proveedor.Pais.Trim().ToUpper().Replace(" ", "") : null,
                    Ciudad= !string.IsNullOrEmpty(Proveedor.Ciudad) ? Proveedor.Ciudad.Trim().ToUpper().Replace(" ", "") : null,
                    Provincia= !string.IsNullOrEmpty(Proveedor.Provincia) ? Proveedor.Provincia.Trim().ToUpper().Replace(" ", "") : null,
                    Localidad= !string.IsNullOrEmpty(Proveedor.Localidad) ? Proveedor.Localidad.Trim().ToUpper().Replace(" ", "") : null,
                    Calle= !string.IsNullOrEmpty(Proveedor.Calle) ? Proveedor.Calle.Trim().ToUpper().Replace(" ", "") : null,
                    Altura= !string.IsNullOrEmpty(Proveedor.Altura) ? Proveedor.Altura.Trim().ToUpper().Replace(" ", "") : null,
                    CodigoPostal= !string.IsNullOrEmpty(Proveedor.CodigoPostal) ? Proveedor.CodigoPostal.Trim().ToUpper().Replace(" ", "") : null,
                    Telefono1= !string.IsNullOrEmpty(Proveedor.Telefono1) ? Proveedor.Telefono1.Trim().ToUpper().Replace(" ", "") : null,
                    Telefono2= !string.IsNullOrEmpty(Proveedor.Telefono2) ? Proveedor.Telefono2.Trim().ToUpper().Replace(" ", "") : null,
                    Telefono3= !string.IsNullOrEmpty(Proveedor.Telefono3) ? Proveedor.Telefono3.Trim().ToUpper().Replace(" ", "") : null,
                    Email= !string.IsNullOrEmpty(Proveedor.Email) ? Proveedor.Email.Trim().ToUpper().Replace(" ", "") : null,
                    IdFiscal =Proveedor.IdFiscal.Trim().ToUpper().Replace(" ","").Replace("-","").Replace("_",""),
                    FechaRegistro = new Fechas().ObtenerFechaHora(),
                    IdUsuarioRegistro = Proveedor.IdUsuarioRegistro
                });

                AponusDBContext.SaveChanges();

                return new StatusCodeResult(200);
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

        internal IActionResult ActualizarProveedor(DTOProveedores Proveedor)
        {
            if (Proveedor.Nombre == null && Proveedor.Apellido == null && Proveedor.NombreClave == null) return new ContentResult()
            {
                Content = "Completar Nombre, Apellido y/o Razon Social",
                ContentType = "application/json",
                StatusCode = 400,

            };

            try
            {
                AponusDBContext.Proveedores.Update(new Models.Proveedores()
                {
                    NombreClave = !string.IsNullOrEmpty(Proveedor.NombreClave) ?
                                     Proveedor.NombreClave.Trim().ToUpper().Replace(" ", "") :
                                     Proveedor.Apellido.Trim().ToUpper().Replace(" ", "") + " " +
                                     Proveedor.Nombre.Trim().ToUpper().Replace(" ", ""),

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
                    FechaRegistro = new Fechas().ObtenerFechaHora(),
                    IdUsuarioRegistro = Proveedor.IdUsuarioRegistro
                });

                AponusDBContext.SaveChanges();

                return new StatusCodeResult(200);

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

        internal IActionResult Eliminar(int idProveedor)
        {
            try
            {
                Models.Proveedores? Proveedor = AponusDBContext.Proveedores.Find(idProveedor);

                if (Proveedor != null)
                {
                    Proveedor.IdEstado= Convert.ToInt32("0x00", 16);
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

        internal IActionResult Listar()
        {
            try
            {
                List<DTOProveedores> Listado = AponusDBContext.Proveedores
                    .Where(x=> Convert.ToInt32(x.IdEstado) == Convert.ToInt32("0x01",16))
                    .Select(x=> new DTOProveedores()
                    {
                        Altura= x.Altura,
                        Apellido= x.Apellido,
                        Calle = x.Calle,    
                        Ciudad = x.Ciudad,
                        CodigoPostal= x.CodigoPostal,
                        Email= x.Email,
                        IdFiscal= x.IdFiscal,
                        Localidad= x.Localidad,
                        Pais=x.Pais,
                        NombreClave= x.NombreClave,
                        Telefono1= x.Telefono1, 
                        Telefono2= x.Telefono2,
                        Telefono3= x.Telefono3,
                        Nombre  = x.Nombre, 
                        Provincia= x.Provincia,
                        
                    })
                    .OrderBy(x => x.Apellido)
                    .ThenBy(x => x.Nombre)
                    .ThenBy(x=>x.NombreClave)
                    .ToList();

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
