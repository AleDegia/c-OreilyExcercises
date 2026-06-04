using BLLL;
using Dal;
using DALe;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using ProgettoGestioneRistorantiWeb;
using UI;
using Microsoft.EntityFrameworkCore;

namespace ProgettoGestioneRistoranti
{
    internal static class Program2
    {
        public static IConfiguration Configuration { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddScoped<DbData<Utente>>();
            services.AddScoped<DalUtenti>();
            //services.AddScoped<BlUtenti>();

            //services.AddScoped<intAnimali, Animale>();

            services.AddScoped<DbData<Prenotazione>>();
            services.AddScoped<DalRistoranti>();
            //services.AddScoped<DalPrenotazioni>();
            //services.AddScoped<BlPrenotazioni>();

            services.AddTransient<Login>();
            //services.AddTransient<Homepage>();
            //services.AddTransient<ElencoPrenotazioni>();
            services.AddTransient<InsertUtente>();

            using var serviceProvider = services.BuildServiceProvider();
            
            var loginForm = serviceProvider.GetRequiredService<Login>();
            //var dal = serviceProvider.GetRequiredService<DalUtenti>();
            Application.Run(loginForm);
        }
    }
}