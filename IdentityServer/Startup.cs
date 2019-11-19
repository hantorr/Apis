// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using IdentityServer4.Configuration;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }

        public Startup(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        //Pasar como param los datos del clientID y Secret
        public void ConfigureServices(IServiceCollection services)
        {
             var rsa = new RsaKeyService(Environment, TimeSpan.FromDays(30));
                services.AddTransient<RsaKeyService>(provider => rsa);

            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApis())
                .AddInMemoryClients(Config.GetClients());

            Environment.Equals(false);
            if (Environment.IsDevelopment())
            {
                builder.AddSigningCredential(rsa.GetKey());
                //builder.AddDeveloperSigningCredential();
            }
            else
            { 
                builder.AddSigningCredential(rsa.GetKey());
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // uncomment if you want to support static files
            //app.UseStaticFiles();

            app.UseIdentityServer();

            // uncomment, if you want to add an MVC-based UI
            //app.UseMvcWithDefaultRoute();
        }

    }
}
