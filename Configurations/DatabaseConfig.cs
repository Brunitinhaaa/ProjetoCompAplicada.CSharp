using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ProjetoCompAplicada.CSharp.Data;

namespace ProjetoCompAplicada.CSharp.Configurations;

public static class DatabaseConfig
{
    public static void ConfigureDatabase(this IServiceCollection services)
    {
        Env.Load();

        var server = Environment.GetEnvironmentVariable("DB_SERVER");
        var port = Environment.GetEnvironmentVariable("DB_PORT");
        var database = Environment.GetEnvironmentVariable("DB_DATABASE");
        var user = Environment.GetEnvironmentVariable("DB_USER");
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

        var connectionString = $"Server={server};Port={port};Database={database};User={user};Password={password};TreatTinyAsBoolean=true";

        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}
