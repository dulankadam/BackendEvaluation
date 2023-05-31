using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace BackendEvaluation.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("GetProduct","Get Product By Id"),
                new ApiScope("CreateProducts","Create Products"),
                new ApiScope("EditProducts","Edit Products"),
                new ApiScope("DeleteProducts","Delete Products"),
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
            new Client
            {
                ClientId = "GetProduct",
                ClientName = "Get Product By Id",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("BackendEvaluation".Sha256()) },
                AllowedScopes = { "GetProduct" }
            },
            new Client
            {
                ClientId = "CreateProducts",
                ClientName = "Create Products",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("BackendEvaluation".Sha256()) },
                AllowedScopes = { "CreateProducts" }
            },
            new Client
            {
                ClientId = "EditProducts",
                ClientName = "Edit Products",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("BackendEvaluation".Sha256()) },
                AllowedScopes = { "EditProducts" }
            },
            new Client
            {
                ClientId = "DeleteProducts",
                ClientName = "Delete Products",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("BackendEvaluation".Sha256()) },
                AllowedScopes = { "DeleteProducts" }
            },
            new Client
            {
                ClientId = "mvc",
                ClientSecrets = { new Secret("BackendEvaluation".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,
            
                // where to redirect to after login
                RedirectUris = { "https://localhost:5002/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                AllowOfflineAccess = true,

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "GetProduct"
                }
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:44300/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                AllowOfflineAccess = true,
                 AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
            },
            };
    }
}