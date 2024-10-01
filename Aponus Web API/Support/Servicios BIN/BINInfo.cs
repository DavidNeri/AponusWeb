using System.Reflection;

namespace Aponus_Web_API.Support.Servicios_BIN
{
    public class BINInfo
    {
        public string Scheme { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public BankInfo Bank { get; set; } = new BankInfo();
    }

    public class BankInfo
    {
        public string Name { get; set; }
        
    }
   

}
