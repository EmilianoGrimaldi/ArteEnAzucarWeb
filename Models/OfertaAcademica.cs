namespace ArteEnAzucarWeb.Models
{
    public class OfertaAcademica
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaInicio { get; set; }
        public int CupoMaximo { get; set; }

        public int DuracionSemanas { get; set; }

        public string Tipo { get; set; } // Ejemplo: "Curso", "Seminario"
        public string GetDetalles()
        {
            return $"{Titulo} - {Descripcion}, Precio: {Precio}, Inicio: {FechaInicio.ToShortDateString()}, Cupo Máximo: {CupoMaximo}";
        }
    }
}
