using Microsoft.EntityFrameworkCore;
using ClinicaAPI.Data;
using ClinicaAPI.Services;
using ClinicaAPI.Services.Interfaces;
using ClinicaAPI.Service.Interfaces;
using ClinicaAPI.Service;
using ClinicaAPI.ML;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ClinicaContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddHttpClient<IViaCepService, ViaCepService>();
builder.Services.AddScoped<ISentimentService, SentimentService>();
SentimentModel.TrainAndSaveModel();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }

