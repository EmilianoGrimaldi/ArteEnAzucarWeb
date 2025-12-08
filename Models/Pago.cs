namespace ArteEnAzucarWeb.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        DateTime FechaPago { get; set; }

        bool EstadoPago { get; set; } // Ejemplo: true (completado), false (pendiente)  

        public string MetodoPago { get; set; } // Ejemplo: "Tarjeta de crédito", "Debito", "Transferencia"

        public bool ProcesarPago()
        {
            // Lógica para procesar el pago
            // Aquí podrías integrar con una pasarela de pagos real
            EstadoPago = true; // Simulamos que el pago fue exitoso
            FechaPago = DateTime.Now;
            return EstadoPago;
        }

        public void GenerarRecibo()
        {
            // Lógica para generar un recibo de pago
        }   
    }
}
