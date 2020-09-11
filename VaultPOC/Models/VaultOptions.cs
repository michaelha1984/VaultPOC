using System.Collections.Generic;

namespace VaultPOC.Models
{
    public class VaultOptions
    {
        public const string Vault = "Vault";
        public string Url { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
