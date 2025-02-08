
using Aponus_Web_API.Modelos;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Auditorias
    {
        private AponusContext aponusContext;

        public AD_Auditorias(AponusContext _aponusContext)
        {
            aponusContext = _aponusContext;
        }

        internal async Task<(IEnumerable<Auditorias>?, Exception? error)> Listar()
        {
            try
            {
                IEnumerable<Auditorias> QueryAuditorias = aponusContext.Auditorias
                    .Select(x => new Auditorias()
                    {
                        Accion = x.Accion,
                        Fecha = x.Fecha,
                        ValoresNuevos = x.ValoresNuevos,
                        ValoresPrevios = x.ValoresPrevios,
                        Usuario = x.Usuario,
                        Tabla = x.Tabla,
                        IdRegistro = x.IdRegistro,
                        IdAuditoria = x.IdAuditoria
                    })
                    .AsEnumerable();

                return (QueryAuditorias, null);
            }
            catch (Exception ex)
            {

                return (null, ex);
            }
        }
    }
}
