using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGetway {
    public class Startup {

        public void ConfigureServices (IServiceCollection services) {

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }

        /* private readonly IConfiguration _cfg;
         public Startup(IConfiguration configuration)
         {
             _cfg = configuration;
         }

         // This method gets called by the runtime. Use this method to add services to the container.
         public void ConfigureServices(IServiceCollection services)
         {
             var identityUrl = _cfg.GetValue<String>("IdentityUrl");
             var authenticationProviderKey = "IdentityApiKey";

             services.AddCors(options =>
             {
                 options.AddPolicy("CorsPolicy",
                     builder => builder
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .SetIsOriginAllowed((host) => true)
                     .AllowCredentials());
             });

             services.AddAuthentication().AddJwtBearer(authenticationProviderKey, x =>
             {
                 x.Authority = identityUrl;
                 x.RequireHttpsMetadata = false;
                 x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                 {
                     ValidAudiences = new[] { "custumer" }
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

             services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

             services.AddOcelot(_cfg);
         }

         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
         public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
         {

             app.UseCors("CorsPolicy");

             if (env.IsDevelopment())
             {
                 app.UseDeveloperExceptionPage();
             }
             else
             {
                 // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                 app.UseHsts();
             }
             app.UseHttpsRedirection();
             app.UseMvc();
             await app.UseOcelot();
         }
         */
    }
}