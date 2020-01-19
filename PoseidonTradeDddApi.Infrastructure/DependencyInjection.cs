using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.AspNetIdentity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Constants;
using PoseidonTradeDddApi.Infrastructure.Identity;
using PoseidonTradeDddApi.Infrastructure.Persistence;

namespace PoseidonTradeDddApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services
                .AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            if (environment.IsEnvironment("Test"))
            {
                services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                    {
                        options.Clients.Add(IdentityServerConfig.TestClient);
                    })
                    .AddInMemoryIdentityResources(IdentityServerConfig.Ids)
                    .AddInMemoryApiResources(IdentityServerConfig.TestApis)
                    .AddTestUsers(IdentityServerConfig.TestUsers);

                services.AddAuthentication()
                    .AddIdentityServerJwt();
            }
            else
            {
                var identityServerBuilder = services.AddIdentityServer()
                    .AddInMemoryIdentityResources(IdentityServerConfig.Ids)
                    .AddInMemoryApiResources(IdentityServerConfig.Apis)
                    .AddInMemoryClients(IdentityServerConfig.Clients)
                    .AddAspNetIdentity<ApplicationUser>()
                    .AddProfileService<ProfileService<ApplicationUser>>();

                // not recommended for production - you need to store your key material somewhere secure
                identityServerBuilder.AddDeveloperSigningCredential();

                services.AddTransient<IIdentityService, IdentityService>();

                services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = configuration.GetSection("IdentityServerSettings")["Authority"];
                        options.ApiName = IdentityServerConfig.PoseidonApiName;
                        options.ApiSecret = "8D969CCE-E211-41CE-BC10-35943D0B1447";
                    });

                services.AddAuthorization(options =>
                {
                    options.AddPolicy(RoleNames.Admin, policy => policy.RequireClaim(JwtClaimTypes.Role, RoleNames.Admin));
                });
            }

            return services;
        }
    }
}
