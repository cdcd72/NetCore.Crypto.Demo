namespace CryptoCore.SecretConfiguration
{
    public interface IDbSettingsResolved
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// 連線類型
        /// </summary>
        string ConnectionType { get; }
    }
}
