using BLL;
using BLLL;
using Dal;
using DALe;
using Engine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using ProgettoGestioneRistorantiWeb;
using UI;

namespace ProgettoGestioneRistoranti
{
    internal static class Program2
    {
        public static IConfiguration Configuration { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            
            var services = new ServiceCollection();


            services.AddDbContext<GestioneRistorantiContext>(options =>
                options.UseSqlServer(
                Configuration.GetConnectionString("GestioneRistorantiConnectionString")));

            services.AddScoped<BlPrenotazioni>();
            services.AddScoped<BlRistoranti>();
            services.AddScoped<BlUtenti>();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddScoped<DalUtenti>();
            //services.AddScoped<BlUtenti>();

            //services.AddScoped<intAnimali, Animale>();

            services.AddScoped<DalRistoranti>();
            //services.AddScoped<DalPrenotazioni>();
            //services.AddScoped<BlPrenotazioni>();

            services.AddTransient<Login>();
            //services.AddTransient<Homepage>();
            //services.AddTransient<ElencoPrenotazioni>();
            services.AddTransient<InsertUtente>();

            ServiceProvider = services.BuildServiceProvider();
            Utility.ServiceProvider = ServiceProvider;

            var loginForm = ServiceProvider.GetRequiredService<Login>();
            //var dal = serviceProvider.GetRequiredService<DalUtenti>();
            Application.Run(loginForm);
        }
    }
}