using System;
using System.Collections.Generic;

namespace CryptoCore.Crypto
{
    public class Decryptor : IDecryptor
    {
        private readonly ICryptoAlgorithm _crypto;

        #region Constructor

        public Decryptor(ICryptoAlgorithm crypto)
        {
            _crypto = crypto ?? throw new ArgumentNullException(nameof(crypto));
        }

        #endregion

        /// <summary>
        /// 解密(依據字典鍵值)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public string Decrypt(string key, IDictionary<string, string> keyValues)
        {
            var value = keyValues[key];
            return DecryptValue(value);
        }

        /// <summary>
        /// 解密(純文字)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Decrypt(string text)
        {
            return DecryptValue(text);
        }

        #region Private Method

        private string DecryptValue(string encodedString)
        {
            return _crypto.Decrypt(encodedString);                        
        }

        #endregion
    }
}