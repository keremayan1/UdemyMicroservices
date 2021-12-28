// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace FreeCourse.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog") { Scopes = { "catalog_fullpermisson" } },
            new ApiResource("photo_stock_catalog") { Scopes = { "photo_stock_fullpermisson" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.Email(),
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                        new IdentityResource(){Name = "roles",DisplayName = "Roles",Description = "Kullanici Rolleri",UserClaims = new[]{"role"}}
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {// Scope Tanimlama Her bir mikroservis icin tanimlama
              new ApiScope("catalog_fullpermisson","Catalog API icin full erisim"),
              new ApiScope("photo_stock_fullpermisson","Photo Stock API icin full erisim"),
              new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
              new Client
              {
                  ClientName = "Asp.Net Core MVC",
                  ClientId = "WebMvcClient",
                  ClientSecrets = {new Secret("secret".Sha256())},
                  AllowedGrantTypes = GrantTypes.ClientCredentials,
                  AllowedScopes = { "catalog_fullpermisson", "photo_stock_fullpermisson",IdentityServerConstants.LocalApi.ScopeName },
              },
              new Client
              {
                  ClientName = "Asp.Net Core MVC",
                  ClientId = "WebMvcClientForUser",
                  AllowOfflineAccess = true,
                  ClientSecrets = {new Secret("secret".Sha256())},
                  AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                  AllowedScopes = { IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile,IdentityServerConstants.StandardScopes.OfflineAccess, IdentityServerConstants.LocalApi.ScopeName, "roles"},
                  AccessTokenLifetime = 1*60*60,
                  RefreshTokenExpiration = TokenExpiration.Absolute,
                  AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                  RefreshTokenUsage = TokenUsage.ReUse 
              },



            };
    }
}