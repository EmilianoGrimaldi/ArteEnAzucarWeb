using Microsoft.EntityFrameworkCore;
using ArteEnAzucarWeb.Models;

namespace ArteEnAzucarWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<OfertaAcademica> OfertasAcademicas { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- 1. RELACIÓN CURSO -> INSCRIPCIONES (LO NUEVO) ---
            // Cuando se borra una OfertaAcademica, se borran sus Inscripciones en cascada.
            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.OfertaAcademica)
                .WithMany(o => o.Inscripciones)
                .HasForeignKey(i => i.OfertaAcademicaId)
                .OnDelete(DeleteBehavior.Cascade);
            // ^^^ Esto asegura que si borras el curso, SQL borra las inscripciones asociadas.


            // --- 2. RELACIÓN INSCRIPCION <-> PAGO ---
            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Pago)
                .WithOne(p => p.Inscripcion)
                .HasForeignKey<Pago>(p => p.InscripcionId)
                // OJO AQUÍ: Si borras la inscripción (por el cascade de arriba), 
                // ¿qué pasa con el pago?
                // Si pones 'Restrict', te dará error al intentar borrar el curso porque hay pagos colgados.
                // Lo ideal aquí suele ser Cascade también (borrar inscripción -> borrar pago) 
                // o SetNull si permites pagos huérfanos.
                // Para simplificar tu vida y evitar errores de SQL, lo cambiaré a Cascade aquí también:
                .OnDelete(DeleteBehavior.Cascade);


            // --- 3. CONFIGURACIONES DE DATOS ---
            modelBuilder.Entity<OfertaAcademica>()
                .Property(o => o.Precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Pago>()
                .Property(p => p.Monto)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Estudiante>()
                .HasIndex(e => e.Email)
                .IsUnique();
        }
    }
}