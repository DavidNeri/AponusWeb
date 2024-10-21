using NtpClient;

namespace Aponus_Web_API.Utilidades
{
    public class UTL_Fechas
    {
        public static DateTime ObtenerFechaHora()   
        {
            DateTime FechaHora = DateTime.Now;
            string[] servidoresNTP = { "Time.Windows.com", "pool.ntp.org", "south-america.pool.ntp.org", "Time.Windows.com" }; // Lista de servidores NTP
            bool ConexionExistosa = false;

            foreach (string Servidor in servidoresNTP)
            {
                try
                {
                    INtpConnection Conexion = new NtpConnection(Servidor);
                    FechaHora = Conexion.GetUtc().AddHours(-3);
                    ConexionExistosa = true;

                    break;                        
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al conectarse al servidor NTP {Servidor}: {ex.Message}");
                }
            }

            if (!ConexionExistosa)FechaHora = DateTime.Now;

            return FechaHora;

        }
        
    }

   
}
