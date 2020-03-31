using System.Collections.Generic;

namespace CryptoCore.SecretConfiguration
{
    public class DbSettings : IDbSettingsStructure
    {
        public Dictionary<string, string> ConnectionStrings { get; set; } = new Dictionary<string, string>();

        public string ConnectionType { get; set; }
    }
}
