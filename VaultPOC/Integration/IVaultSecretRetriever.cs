using System.Collections.Generic;
using System.Threading.Tasks;

namespace VaultPOC.Integration
{
    public interface IVaultSecretRetriever
    {
        Task<Dictionary<string, string>> GetSecretsAsync();
    }
}
