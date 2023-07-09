using Microsoft.Extensions.DependencyInjection;
using Twileloop.SessionGuard.Persistance;
using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Demo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ApplicationConfiguration.Initialize();
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<Main>();
                Application.Run(mainForm);
            }
        }

        //Dependency Injections
        static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPersistance<MyData>, Persistance<MyData>>();
            services.AddSingleton<Main>();
        }
    }
}