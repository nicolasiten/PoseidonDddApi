using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource(PoseidonApiName, "Poseidon Trade API")
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

                    AllowedScopes = { "openid", "profile", PoseidonApiName }
                }
            };

    }
}
