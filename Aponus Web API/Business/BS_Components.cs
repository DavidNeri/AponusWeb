using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Data_Transfer_objects;

namespace Aponus_Web_API.Business
{
    public class BS_Components
    {
        internal Task<List<EspecificacionesComponentes>>? ListarComponentes(int? idDescription)
        {
            return new ObtenerComponentes().ListarComponentes(idDescription);


        }
    }
}
