using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ProjetoCompAplicada.CSharp.Data;

namespace ProjetoCompAplicada.CSharp.Configurations;

public static class DatabaseConfig
{
    public static void ConfigureDatabase(this IServiceCollection services)
    {
        Env.Load();

        var server = Environment.GetEnvironmentVariable("MYSQL_SERVER");
        var port = Environment.GetEnvironmentVariable("MYSQL_PORT");
        var database = Environment.GetEnvironmentVariable("MYSQL_DATABASE");
        var user = Environment.GetEnvironmentVariable("MYSQL_USER");
        var password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");

        var connectionString = $"Server={server};Port={port};Database={database};User={user};Password={password};TreatTinyAsBoolean=true";

        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}
