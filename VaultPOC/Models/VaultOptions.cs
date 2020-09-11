using System.ComponentModel.DataAnnotations;

namespace VaultPOC.Models
{
    public class VaultOptions
    {
        public const string Vault = "Vault";

        [Required]
        [Url(ErrorMessage = "Invalid Vault URL")]
        public string Url { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
