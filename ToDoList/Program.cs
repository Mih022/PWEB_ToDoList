using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using ToDoList;
using ToDoList.Data;
using ToDoList.Models.Database;
using ToDoList.Tests;

namespace ToDoList
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await GenerateData(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static async Task GenerateData(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                var uManager = services.GetRequiredService<UserManager<UserData>>();
                try
                {
                    DataGenerator.Generate(context, uManager);
                }
                catch (Exception ex)
                {
                    throw;
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
                await TestBase.Do_all_tests(context, uManager);
            }
        }
    }
}