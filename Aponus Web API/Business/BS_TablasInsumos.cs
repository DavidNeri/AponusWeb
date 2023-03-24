using Aponus_Web_API.Acceso_a_Datos.Insumos;
using Aponus_Web_API.Data_Transfer_objects;

namespace Aponus_Web_API.Business
{
    public class BS_TablasInsumos
    {
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
