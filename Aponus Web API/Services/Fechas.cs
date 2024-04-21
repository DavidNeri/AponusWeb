using NtpClient;
using System.Net.NetworkInformation;

namespace Aponus_Web_API.Services
{
    public class Fechas
    {
        public static DateTime ObtenerFechaHora()
        {
            DateTime FechaHora = new DateTime();
            string[] servidoresNTP = { "Time.Windows.com", "pool.ntp.org", "south-america.pool.ntp.org", "Time.Windows.com" }; // Lista de servidores NTP
            bool ConexionExistosa = false;

            foreach (string Servidor in servidoresNTP)
            {
                try
                {
                    Ping ping = new Ping();
                    PingReply Respuesta = ping.Send(Servidor, 1000);

                    if (Respuesta != null && Respuesta.Status == IPStatus.Success)
                    {
                        INtpConnection Conexion = new NtpConnection(Servidor);
                        FechaHora = Conexion.GetUtc().AddHours(-3);
                        ConexionExistosa = true;
                        break;
                    }
                }
                catch (PingException) { }
            }

            if (!ConexionExistosa)FechaHora = DateTime.Now;

            return FechaHora;

        }
    }
}
