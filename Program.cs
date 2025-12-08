using ArteEnAzucarWeb.Services;
using ArteEnAzucarWeb.Data;       // <--- 1. AGREGAR ESTE USING (Tu DbContext)
using Microsoft.EntityFrameworkCore; // <--- 2. AGREGAR ESTE USING (Para SQL Server)

namespace ArteEnAzucarWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // --- INICIO DE CONFIGURACIÓN DE BASE DE DATOS ---

            // Leemos la cadena de conexión del appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                   ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            // Inyectamos el DbContext usando SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // --- FIN DE CONFIGURACIÓN DE BASE DE DATOS ---


            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();
            builder.Services.AddScoped<IPasswordService, PasswordService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();

            app.Run();
        }
    }
}