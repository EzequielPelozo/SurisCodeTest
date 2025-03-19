using Microsoft.EntityFrameworkCore;
using TestSurisCode.Data;
using TestSurisCode.Repository.IRepository;
using TestSurisCode.Repository;
using TestSurisCode.SurisCodeMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregamos los repositorios
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

// Agregamos el automapper
builder.Services.AddAutoMapper(typeof(SurisCodeMapper));

// Soporte para CORS
// Se pueden habilitar: 1-Un dominio, 2-multiples dominios, 3-cualquier dominio (Tener en cuenta Seguridad)
// Usamos de ejemplo dominio: http://localhost:5173, se debe cambiar por el correcto
// se usa (*) para todos los dominios.
builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build =>
{
    build.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Soporte para CORS
app.UseCors("PolicyCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
