using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using static IdentityServer4.IdentityServerConstants;

namespace PoseidonTradeDddApi.Infrastructure.Identity
{
    public static class IdentityServerConfig
    {
        public const string PoseidonApiName = "poseidonApi";
        public const string PoseidonTestApiName = "PoseidonTradeDddApi.ApiAPI";

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
                    ApiSecrets = { new Secret("8D969CCE-E211-41CE-BC10-35943D0B1447".Sha256()) },
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

                    AccessTokenType = AccessTokenType.Reference,
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
                ClientId = PoseidonTestApiName,

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedScopes =
                {
                    "openid",
                    "profile",
                    PoseidonTestApiName,
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

        public static IEnumerable<ApiResource> TestApis =>
        new ApiResource[]
        {
            new ApiResource(PoseidonTestApiName, "Poseidon Trade API Tests")
            {
                UserClaims =
                {
                    JwtClaimTypes.Role,
                    JwtClaimTypes.Email
                }
            }
        };
    }
}
