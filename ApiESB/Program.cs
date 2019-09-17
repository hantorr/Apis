using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.IO;
using Microsoft.Extensions.DependencyInjection;


namespace ApiESB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {

            var builder = WebHost.CreateDefaultBuilder(args);

            builder.ConfigureServices(s => s.AddSingleton(builder))
            .ConfigureAppConfiguration(
                    ic => ic.AddJsonFile(Path.Combine("configuration", "configuration.json"))
            ).UseStartup<Startup>();

            IWebHost host = builder.Build();
            return host;
        

        }

    }
}
