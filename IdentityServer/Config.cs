// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
              new ApiScope("customerApi", "Api Customer"),
              new ApiScope("productApi", "Api Product")
        };

        public static IEnumerable<ApiResource> GetApis()
        {
            // tabla Apis
            return new List<ApiResource>
            {
                new ApiResource("customerApi", "Api Customer"),
                new ApiResource("productApi", "Api Product")
            };
        }


        //tabla para obtener los registros asociados al cliente
        //ClientId y lo relaciona con los accesos AllowedScopes
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                    {
                        ClientId = "client",
                        // no interactive user, use the clientid/secret for authentication
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        // secret for authentication
                        ClientSecrets =
                        {
                            new Secret("secret".Sha512())
                        },
                        AllowAccessTokensViaBrowser = true,
                        // scopes that client has access to
                        AllowedScopes =
                        {
                          "customerApi",
                          "productApi"
                        }
                    }
            };
        }
    }
}