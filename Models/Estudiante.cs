using System.Collections.Generic; // Asegúrate de tener este using

namespace ArteEnAzucarWeb.Models
{
    public class Estudiante : Usuario
    {
        // Constructor de instancia (se ejecuta cada vez que haces un 'new Estudiante')
        public Estudiante()
        {
            // Inicializamos la lista para evitar errores de referencia nula
            Inscripciones = new List<Inscripcion>();
        }

        // Relación: Un estudiante tiene muchas inscripciones
        // Quitamos el ';' que sobraba al final
        public List<Inscripcion> Inscripciones { get; set; }
        // Mover a controlador o servicios la logica
       /* public void Registrarse()
        {
            // Lógica para registrarse en la plataforma
        }

        public void InscribirseACurso(OfertaAcademica curso) // Corregí el typo "Incscribirse"
        {
            // Ejemplo de lógica simple:
            var nuevaInscripcion = new Inscripcion { *//* asignar propiedades *//* };
            this.Inscripciones.Add(nuevaInscripcion);
        }

        public void CancelarInscripcion(Inscripcion inscripcion)
        {
            // Lógica para cancelar
            this.Inscripciones.Remove(inscripcion);
        }

        public void PagarCurso(Inscripcion inscripcion, Pago pago)
        {
            // Lógica para pagar un curso
        }

        public List<Inscripcion> VerMisCursos()
        {
            return Inscripciones;
        }*/
    }
}