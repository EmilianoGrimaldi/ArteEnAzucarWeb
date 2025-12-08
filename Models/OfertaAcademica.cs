using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArteEnAzucarWeb.Models
{
    public enum TipoOferta
    {
        Curso,
        Seminario,
        Taller // Agregué uno común por si acaso
    }

    public class OfertaAcademica
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [StringLength(500)] // O el largo que prefieras
        [DataType(DataType.MultilineText)] // Ayuda a que en el HTML se vea como un cuadro de texto grande
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Importante para la moneda
        [Range(0, 1000000)] // Evita precios negativos
        public decimal Precio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "El cupo debe ser mayor a 0")]
        public int CupoMaximo { get; set; }

        public int DuracionSemanas { get; set; }

        [Required]
        public TipoOferta TipoOferta { get; set; }

        // --- RELACIÓN INVERSA ---
        // Esto es vital. Nos permite decir: "Dame el curso de Pastelería y muéstrame todos sus alumnos"
        public List<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }
}