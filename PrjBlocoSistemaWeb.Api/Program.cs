using Microsoft.EntityFrameworkCore;
using PrjBlocoSistemaWeb.Application.Conta.Profile;
using PrjBlocoSistemaWeb.Application.Conta;
using PrjBlocoSistemaWeb.Application.Streaming;
using PrjBlocoSistemaWeb.Repository.Repository;
using PrjBlocoSistemaWeb.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddControllers().AddJsonOptions(x =>
//   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

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
builder.Services.AddScoped<PlaylistRepository>();

//Services
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<BandaService>();
builder.Services.AddScoped<MusicaService>();
builder.Services.AddScoped<PlaylistService>();

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
