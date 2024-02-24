using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Acceso_a_Datos.Insumos;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Business
{
    public class BS_Supplies
    {

        internal async Task<JsonResult> ObtenerNuevoIdComponente(string ComponentDescription)
        {
            return await new OperacionesComponentes().ObtenerNuevoId(ComponentDescription);
        }
        internal IActionResult GuardarInsumoProducto(DTOComponente componente)
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
                        Content = "El Codigo de Insumo y la Descripcion no pueden ser nulos",
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

        internal int? ObtenerTablaInsumo(Insumos Insumo)
        {

            try
            {
                return new TablaInsumo().ObtenerTabla(Insumo);
            }
            catch (Exception)
            {

                return null;
            }
            


        }
    }
}
