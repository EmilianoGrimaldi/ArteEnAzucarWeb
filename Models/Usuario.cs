using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore; // Necesario para [Index]

namespace ArteEnAzucarWeb.Models
{
    // Agregamos el índice único al Email a nivel de clase o propiedad (forma moderna)
    [Index(nameof(Email), IsUnique = true)]
    public abstract class Usuario
    {
        [Key]
        public int Id { get; set; } // Agregado el SET

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100)]
        public required string Nombre { get; set; } // Uso de 'required' de .NET 8

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [MaxLength(100)]
        public required string Email { get; set; }

        // OJO: Esta propiedad representa el HASH en la base de datos
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        // Propiedad opcional para manejar Salt si no usas Identity completo
        public string? PasswordSalt { get; set; }

        // Agregamos fecha de registro (muy útil en auditoría)
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}