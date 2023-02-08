using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using ToDoList;
using ToDoList.Data;
using ToDoList.Models.Database;

namespace ToDoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            GenerateData(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void GenerateData(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var uManager = services.GetRequiredService<UserManager<UserData>>();
                    DataGenerator.Generate(context, uManager);
                }
                catch (Exception ex)
                {
                    throw;
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}