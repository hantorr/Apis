using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGetway {
    public class Program {
        public static void Main (string[] args) {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args) {

            IWebHostBuilder builder = WebHost.CreateDefaultBuilder(args);

            builder.UseKestrel ()
                .UseContentRoot (Directory.GetCurrentDirectory ())
                .ConfigureAppConfiguration ((hostingContext, config) => {
                    config
                        .SetBasePath (hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile (Path.Combine ("configuration", "configuration.json"))
                        .AddEnvironmentVariables ();
                })
                .ConfigureServices (s => {
                    s.AddOcelot ();
                })
                .ConfigureLogging ((hostingContext, logging) => {
                    //add your logging
                })
                .UseIISIntegration ()
                .Configure (app => {
                    app.UseOcelot ().Wait ();
                });
            IWebHost host = builder.Build();
            return host;
        }

        /*public static IWebHost CreateWebHostBuilder(string[] args)
        {

            var builder = WebHost.CreateDefaultBuilder(args);

            builder.ConfigureServices(s => s.AddSingleton(builder))
            .ConfigureAppConfiguration(
                    ic => ic.AddJsonFile(Path.Combine("configuration", "configuration.json"))
            ).UseStartup<Startup>();

            IWebHost host = builder.Build();
            return host;
        

        }*/

    }
}