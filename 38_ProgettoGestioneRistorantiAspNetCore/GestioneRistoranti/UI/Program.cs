using DALe;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgettoGestioneRistoranti;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProgettoGestioneRistorantiWeb
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //salvo valori del json in una variabile di tipo IConfiguration
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectionString = Configuration.GetConnectionString("GestioneRistorantiConnectionString");

            var services = new ServiceCollection();
            services.AddDbContext<GestioneRistorantiContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped(typeof(DbData<>));
            using var serviceProvider = services.BuildServiceProvider();
            Application.Run(new Login());
        }
    }
}