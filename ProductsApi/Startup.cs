using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ProductsApi {
    public class Startup {


        public void ConfigureServices (IServiceCollection services) {

            services.AddMvcCore ()
                .AddAuthorization ()
                .AddJsonFormatters ();
            
            services.AddCors (options => {
                options.AddPolicy ("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed ((host) => true)
                    .AllowAnyMethod ()
                    .AllowAnyHeader ()
                    .AllowCredentials ());
            });

            ConfigureAuthService (services);

        }

        public void Configure (IApplicationBuilder app) {
            app.UseAuthentication ();

            app.UseMvc ();
        }

        private void ConfigureAuthService (IServiceCollection services) {
            var identityUrl = "http://localhost:5000";
            
            // prevent from mapping "sub" claim to nameidentifier.
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear ();

            services.AddAuthentication (options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            
            }).AddJwtBearer (options => {
                options.Authority = identityUrl;
                options.Audience = "productApi";
                options.RequireHttpsMetadata = false;
            });
        }
    }
}