using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("GestioneRistorantiConnectionString");

        services.AddDbContext<GestioneRistorantiDbContext>(options =>
            options.UseSqlServer(connectionString));

        //"Ogni volta che qualcuno chiede un IRistorantiRepository, crea un RistorantiRepository"
        services.AddScoped<IRistorantiRepository, RistorantiRepository>();
        services.AddScoped<IUtentiRepository, UtentiRepository>();
        services.AddScoped<IPrenotazioniRepository, PrenotazioniRepository>();
        services.AddScoped<ITipologieRepository, TipologieRepository>();

        return services;
    }
}


/*
 this IServiceCollection -> rende AddInfrastructure un extension method, così puoi chiamarlo come un metodo naturale di builder.Services.
 */