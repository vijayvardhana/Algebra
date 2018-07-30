using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra.Entities.Models
{
    public class UserLoginInfo
    {
        public UserLoginInfo(string loginProvider, string providerKey, string displayName) { }
        public string LoginProvider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderKey { get; set; }
    }
}
