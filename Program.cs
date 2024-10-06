using Microsoft.EntityFrameworkCore;
using ClinicaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionando a configuração do banco de dados Oracle
builder.Services.AddDbContext<ClinicaContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

// Configuração do middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
