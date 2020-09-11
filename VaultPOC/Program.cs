using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using VaultPOC.Extensions;
using VaultPOC.Integration;

namespace VaultPOC
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddConfigurations(config)
                        .AddServices();
                })
                .Build();

            var service = ActivatorUtilities.CreateInstance<VaultSecretRetriever>(host.Services);

            var _ = await service.GetSecretsAsync();
        }
    }
}
