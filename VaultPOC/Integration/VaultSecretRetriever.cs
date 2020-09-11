using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VaultPOC.Models;

namespace VaultPOC.Integration
{
    public class VaultSecretRetriever : IVaultSecretRetriever
    {
        private readonly VaultOptions _options;

        public VaultSecretRetriever(
            IOptions<VaultOptions> options)
        {
            _options = options.Value;
        }

        public async Task<Dictionary<string, string>> GetSecretsAsync()
        {
            // Creating an instance of the HTTP Client
            HttpClient client = new HttpClient();
            
            //Setting the URL to our HashiCorp Secret
            string url = "http://127.0.0.1:8200/v1/secret/data/" + _options.Name; // This is secret/name
            
            // Setting the Token Header and the Root Token
            client.DefaultRequestHeaders.Add("X-Vault-Token", _options.Token);
            
            // Setting the Content-type to application/json
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var response = await client.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            var data = json["data"]["data"];

            var secrets = JsonConvert.DeserializeObject<Dictionary<string, string>>(data.ToString());

            return secrets;
        }
    }
}
