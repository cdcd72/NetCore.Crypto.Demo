using CryptoCore.Crypto;
using Microsoft.Extensions.Options;
using System;

namespace CryptoCore.SecretConfiguration
{
    /// <summary>
    /// 橋接 DbSettings
    /// 描述：在已透過 DI 將組態 DbSettings 區段綁定至 DbSettings 物件情況下，對其物件進行其它操作(ex. 驗證、解密...)
    /// </summary>
    public class DbSettingsBridge : IDbSettingsResolved
    {
        private readonly IOptions<DbSettings> _dbSettings;
        private readonly IDecryptor _decryptor;

        public DbSettingsBridge(IOptionsSnapshot<DbSettings> dbSettings, ISettingsValidator validator, IDecryptor decryptor) 
        {
            _dbSettings = dbSettings ?? throw new ArgumentNullException(nameof(dbSettings));
            _decryptor = decryptor ?? throw new ArgumentException(nameof(decryptor));
            if (validator == null) throw new ArgumentNullException(nameof(validator));

            if (!validator.TryValidate(dbSettings.Value, out var validationException))
                throw validationException;
        }

        public string ConnectionType => _dbSettings.Value.ConnectionType;

        public string ConnectionString => _decryptor.Decrypt(ConnectionType, _dbSettings.Value.ConnectionStrings);
    }
}
