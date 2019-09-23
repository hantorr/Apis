using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.Extensions.Logging;

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
                 .ConfigureLogging((hostingContext, loggingbuilder) =>
                {
                    loggingbuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    loggingbuilder.AddConsole();
                    loggingbuilder.AddDebug();
                })
                .UseIISIntegration ()
                .Configure (app => {
                    app.UseOcelot ().Wait ();
                });
            IWebHost host = builder.Build();
            return host;
        }


    }
}