using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Necesario para 'Column' y 'ForeignKey'

namespace ArteEnAzucarWeb.Models
{
    public enum MetodoPago
    {
        TarjetaCredito,
        Debito,
        Transferencia
    }

    public class Pago
    {
        [Key]
        public int Id { get; set; }

        // IMPORTANTE: EF Core necesita saber el tipo de dato SQL para decimales (18 dígitos, 2 decimales)
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        // CORRECCIÓN: Agregado 'public' para que se guarde en la BD
        [Required]
        public DateTime FechaPago { get; set; } = DateTime.Now;

        // CORRECCIÓN: Agregado 'public'. 
        // True = Aprobado, False = Rechazado/Pendiente
        public bool EstadoPago { get; set; } = false;

        [Required]
        public MetodoPago MetodoPago { get; set; }

        // --- Relación 1 a 1 con Inscripción ---
        // Esto es necesario para que la Inscripcion sepa cual es su pago

        public int InscripcionId { get; set; } // Clave foránea

        // Al poner [JsonIgnore] evitas ciclos infinitos si alguna vez conviertes esto a JSON (API)
        // pero por ahora no es estrictamente necesario, solo buena práctica.
        [ForeignKey("InscripcionId")]
        public Inscripcion Inscripcion { get; set; } = null!;
    }
}