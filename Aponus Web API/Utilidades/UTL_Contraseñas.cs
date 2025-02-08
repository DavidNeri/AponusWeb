using System.Security.Cryptography;

namespace Aponus_Web_API.Utilidades
{
    public class UTL_Contraseñas
    {
        public static (string HasContraseña, string sal) HashContraseña(string contraseña)
        {
            byte[] saltBytes = new byte[16];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            string salt = Convert.ToBase64String(saltBytes);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password: contraseña, salt: saltBytes, iterations: 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20); // Genera un hash de 20 bytes
                return (Convert.ToBase64String(hash), salt); // Devuelve el hash y la sal
            }
        }

        public static bool VerificarContraseña(string Contraseña, string HashContraseñaDB, string SalContraseñaDB)
        {
            byte[] salBytes = Convert.FromBase64String(SalContraseñaDB);

            using var pbkdf2 = new Rfc2898DeriveBytes(Contraseña, salBytes, 10000);
            byte[] Hash = pbkdf2.GetBytes(20);
            string HashContraseña = Convert.ToBase64String(Hash);

            return HashContraseña == HashContraseñaDB;
        }
    }
}
