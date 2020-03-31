using System;

namespace CryptoCore.Crypto
{
    public class Encryptor : IEncryptor
    {
        private readonly ICryptoAlgorithm _crypto;

        #region Constructor

        public Encryptor(ICryptoAlgorithm crypto)
        {
            _crypto = crypto ?? throw new ArgumentNullException(nameof(crypto));
        }

        #endregion

        /// <summary>
        /// 加密(純文字)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Encrypt(string text)
        {
            return EncryptValue(text);
        }

        #region Private Method

        private string EncryptValue(string text)
        {
            return _crypto.Encrypt(text);
        }

        #endregion
    }
}
