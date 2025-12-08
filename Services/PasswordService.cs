using BCrypt.Net;

namespace ArteEnAzucarWeb.Services
{
    public interface IPasswordService
    {
        string Hash(string password);
        bool Verify(string password, string hash);
    }

    public class PasswordService : IPasswordService
    {
        public string Hash(string password)
        {
            // Genera un salt y hashea la contraseña.
            // 12 es el "WorkFactor" (costo). Cuanto más alto, más seguro pero más lento.
            // 10-12 es el estándar actual.
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        public bool Verify(string password, string hash)
        {
            // Compara la contraseña plana con el hash guardado
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}