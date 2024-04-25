using Microsoft.EntityFrameworkCore;
using TeatruBE.Models;
using TeatruBE.Repositories;
using TeatruBE.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();

builder.Services.AddScoped<TeatruContext>();
builder.Services.AddTransient<ISpectacolRepository, SpectacolRepository>();
builder.Services.AddScoped<ISpectacolService, SpectacolService>();


builder.Services.AddDbContext<TeatruContext>(options =>
        options.UseSqlServer("Server=localhost;Database=Teatru;User Id=SA;Password=MyPassword123#;TrustServerCertificate=true;"));

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