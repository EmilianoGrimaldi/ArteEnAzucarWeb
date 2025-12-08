namespace ArteEnAzucarWeb.Models
{
    public abstract class Usuario
    {
        public int Id { get;}
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // En producción, esto se cifra
    }
}
