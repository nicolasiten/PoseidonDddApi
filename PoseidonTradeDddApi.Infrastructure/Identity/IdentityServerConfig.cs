﻿using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using static IdentityServer4.IdentityServerConstants;

namespace PoseidonTradeDddApi.Infrastructure.Identity
{
    public static class IdentityServerConfig
    {
        public const string PoseidonApiName = "poseidonApi";

        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource(PoseidonApiName, "Poseidon Trade API")
                {
                    UserClaims =
                    {
                        JwtClaimTypes.Role,
                        JwtClaimTypes.Email
                    }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "poseidonCredentialClient",
                    ClientName = "Poseidon Credentials Client",

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("85ace06d-d634-4e75-97a5-ebedba3c71ac".Sha256()) },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,

                    AllowedScopes = 
                    { 
                        "openid", 
                        "profile", 
                        PoseidonApiName,
                        StandardScopes.OfflineAccess
                    }
                }
            };

        public static Client TestClient =>
            new Client
            {
                ClientId = "PoseidonTradeDddApi.Tests",

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedScopes =
                {
                    "openid",
                    "profile",
                    "PoseidonTradeDddApi.Api.Tests",
                }
            };

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5975EA9F-EA1E-478D-8262-A7900EF9BD65",
                    Username = "user@poseidon.com",
                    Password = "Poseidon!1",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "user@poseidon.com")
                    }
                }
            };
    }
}
