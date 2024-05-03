// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes = {"CatalogFullPermission","CatalogReadPermission"} },
            new ApiResource("ResourceDiscount"){Scopes = {"ResourceFullPermission"} },
            new ApiResource("ResourceOrder"){Scopes = {"OrderFullPermission"} }
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("ResourceFullPermission","Full authority for Discount operations"),
            new ApiScope("OrderFullPermission","Full authority for Order operations")
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // Visitors
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName ="MultiShop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission" }
            },

            // Manager
            new Client
            {
                ClientId ="MultiShopManagerId",
                ClientName ="MultiShop Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission" }
            },

            // Admin
            new Client
            {
                ClientId ="MultiShopAdminId",
                ClientName = "MultiShop Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogFullPermission", "ResourceFullPermission", "OrderFullPermission" ,
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 600
            }

        };

    }
}