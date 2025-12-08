
namespace ArteEnAzucarWeb.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public DateTime FechaInscripcion { get; set; } = DateTime.Now;
        public bool Estado { get; set; }  // Activo, En curso, Finalizado

        // --- Relaciones (Foreign Keys) ---

        // Conexión con el Estudiante
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; } = null!;

        // Conexión con la Oferta (Curso o Seminario)
        public int OfertaAcademicaId { get; set; }
        public OfertaAcademica OfertaAcademica { get; set; } = null!;

        // Conexión con el Pago (Relación 1 a 1 opcional)
        public Pago? Pago { get; set; }

    }
}
