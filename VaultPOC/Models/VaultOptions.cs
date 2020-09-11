using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaultPOC.Models
{
    public class VaultOptions
    {
        public const string Vault = "Vault";

        [Url(ErrorMessage = "Invalid Vault URL")]
        public string Url { get; set; }

        public string Name { get; set; }
        public string Token { get; set; }
    }
}
