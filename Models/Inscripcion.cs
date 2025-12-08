using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArteEnAzucarWeb.Models
{
    public enum EstadoInscripcion
    {
        Activo,
        Cancelado,
        Completado
    }
    public class Inscripcion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FechaInscripcion { get; set; } = DateTime.Now;

        [Required]
        public EstadoInscripcion Estado { get; set; } = EstadoInscripcion.Activo;

        // --- Relaciones ---

        [Required]
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; } = null!;

        [Required]
        public int OfertaAcademicaId { get; set; }
        public OfertaAcademica OfertaAcademica { get; set; } = null!;

        // RELACIÓN 1 a 1 OBLIGATORIA
        // Al quitar el '?' y poner [Required], EF Core sabe que 
        // una inscripción no puede existir sin su pago correspondiente.
        [Required]
        public Pago Pago { get; set; } = null!;
    }
}