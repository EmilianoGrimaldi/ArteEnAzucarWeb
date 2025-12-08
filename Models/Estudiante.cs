
namespace ArteEnAzucarWeb.Models
{
    public class Estudiante : Usuario
    {
        // Relación: Un estudiante tiene muchas inscripciones
        public List<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
        public void Registrarse()
        {             // Lógica para registrarse en la plataforma
        }
        public void IncscribirseACurso(OfertaAcademica curso)
        {             // Lógica para inscribirse a un curso
        }

        public List<Inscripcion> VerMisCursos()
        {
            //Muestra los cursos inscriptos del estudiante
            return Inscripciones;
        }
    }
}
