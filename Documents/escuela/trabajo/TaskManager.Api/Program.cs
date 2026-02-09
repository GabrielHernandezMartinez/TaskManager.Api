using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- CAMBIO DE SEGURIDAD AQUÍ ---
// Obtenemos la conexión de forma segura desde la configuración
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));
// --------------------------------

var app = builder.Build();

// 2. Auto-crear base de datos al iniciar (Seniority boost)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// 3. Configurar Swagger y Rutas
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager API V1");
    c.RoutePrefix = string.Empty; // Swagger como página de inicio
});

app.UseAuthorization();
app.MapControllers();

app.Run();