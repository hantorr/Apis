using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGetway
{


    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {

            var identityUrl = "http://localhost:5000";

            services.AddCors(options =>
              {
                  options.AddPolicy("CorsPolicy",

                      builder => builder
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .SetIsOriginAllowed((host) => true)
                      .AllowCredentials());
              });
            services.AddAuthentication("Bearer")
           .AddJwtBearer("Bearer", x =>
           {
                  x.Authority = identityUrl;
                  x.RequireHttpsMetadata = false;
                  x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                  {
                      ValidAudiences = new[] { "custumerApi, productApi" }
                  };
                  x.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents()
                  {
                      OnAuthenticationFailed = async ctx =>
                      {
                          int i = 0;
                      },
                      OnTokenValidated = async ctx =>
                      {
                          int i = 0;
                      },
                      OnMessageReceived = async ctx =>
                      {
                          int i = 0;
                      }
                  };
              });

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.Configure<IISOptions>(options =>
                {
                    options.ForwardClientCertificate = false;
                }
                );

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }


    }
}