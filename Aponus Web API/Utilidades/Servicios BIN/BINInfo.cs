using System.Reflection;

namespace Aponus_Web_API.Utilidades.Servicios_BIN
{
    public class BINInfo
    {
        public string Scheme { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public BankInfo Bank { get; set; } = new BankInfo();
    }

    public class BankInfo
    {
        public string Name { get; set; } = string.Empty;
        
    }
   

}
