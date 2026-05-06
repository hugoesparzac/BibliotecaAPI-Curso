using BibliotecaAPI.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// area de servicios
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opciones =>
    opciones.UseNpgsql("name=DefaultConnection"));

var app = builder.Build();

// area de middlewares

app.MapControllers();

app.Run();
