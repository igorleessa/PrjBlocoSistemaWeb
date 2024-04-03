using Microsoft.EntityFrameworkCore;
using PrjBlocoSistemaWeb.Application.Conta.Profile;
using PrjBlocoSistemaWeb.Application.Conta;
using PrjBlocoSistemaWeb.Application.Streaming;
using PrjBlocoSistemaWeb.Repository.Repository;
using PrjBlocoSistemaWeb.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PrjBlocoSistemaWebContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("PrjBlocoConnection"));
});


builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);


//Repositories
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<PlanoRepository>();
builder.Services.AddScoped<BandaRepository>();
builder.Services.AddScoped<MusicaRepository>();

//Services
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<BandaService>();
builder.Services.AddScoped<MusicaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
