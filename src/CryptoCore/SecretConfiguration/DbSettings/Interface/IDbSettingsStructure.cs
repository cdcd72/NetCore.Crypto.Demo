using System.Collections.Generic;

namespace CryptoCore.SecretConfiguration
{
    public interface IDbSettingsStructure
    {
        /// <summary>
        /// 多個連線字串
        /// </summary>
        Dictionary<string, string> ConnectionStrings { get; }

        /// <summary>
        /// 連線類型
        /// </summary>
        string ConnectionType { get; }
    }
}
