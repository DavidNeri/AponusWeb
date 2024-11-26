namespace Aponus_Web_API.Utilidades
{
    public class UTL_Entorno
    {
        private readonly IWebHostEnvironment _entorno;

        public UTL_Entorno(IWebHostEnvironment entorno)
        {
            _entorno = entorno;
        }
        public bool EsDesarollo()
        {
            return _entorno.IsDevelopment();
        }
        public bool EsProduccion()
        {
            return _entorno.IsProduction();

        }
    }
}
