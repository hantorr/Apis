using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CustumerApi
{
    public class Startup {

        public void ConfigureServices (IServiceCollection services) {
            services.AddMvcCore();

            services.AddAuthentication ("Bearer")
                .AddJwtBearer ("Bearer", options => {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;

                    options.Audience = "customerApi";
                });
        }

        public void Configure (IApplicationBuilder app) {
            app.UseAuthentication ();

            app.UseMvc ();
        }


    }

}