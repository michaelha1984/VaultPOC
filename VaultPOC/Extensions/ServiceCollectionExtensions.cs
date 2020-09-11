using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaultPOC.Integration;
using VaultPOC.Models;

namespace VaultPOC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IVaultSecretRetriever, VaultSecretRetriever>();

            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<VaultOptions>(configuration.GetSection(VaultOptions.Vault));

            return services;
        }
    }
}
