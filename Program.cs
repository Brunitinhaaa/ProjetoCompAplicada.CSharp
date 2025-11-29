using DotNetEnv;
using Microsoft.Extensions.Logging;
using ProjetoCompAplicada.CSharp.Configurations;
using ProjetoCompAplicada.CSharp.UseCases.Servicos;
using ProjetoCompAplicada.CSharp.Repositories;




var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment.EnvironmentName;

if (environment == "Development" && File.Exists(".env"))
{
    Env.Load(".env");
}
else if (File.Exists(".env.prod"))
{
    Env.Load(".env.prod");
}

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Warning);

builder.Services.ConfigureDatabase();
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServicoPublicQueryService, ServicoPublicQueryService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    Console.WriteLine("ProjetoCompAplicada.CSharp API iniciada (DEV)");

    var addresses = app.Urls.Any() ? string.Join(", ", app.Urls) : "http://localhost:5257";
    Console.WriteLine($"Swagger disponível em: {addresses}/swagger");
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
