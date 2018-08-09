using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.Models
{
    public class UserLoginInfo
    {
        public UserLoginInfo(string loginProvider, string providerKey, string displayName) { }
        [MaxLength(100)]
        public string LoginProvider { get; set; }
        [MaxLength(100)]
        public string ProviderDisplayName { get; set; }
        [MaxLength(100)]
        public string ProviderKey { get; set; }
    }
}
