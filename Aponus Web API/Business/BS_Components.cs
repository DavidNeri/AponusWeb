using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Data_Transfer_objects;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Business
{
    public class BS_Components
    {
        internal JsonResult? DeterminarProp(EspecificacionesComponentes? Especificaciones)
        {
            return new ObtenerComponentes().ListarProp(Especificaciones);


        }
    }
}
