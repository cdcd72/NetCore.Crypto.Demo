using System.Collections.Generic;

namespace CryptoCore.Crypto
{
    public interface IDecryptor
    {
        /// <summary>
        /// 解密(依據字典鍵值)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        string Decrypt(string key, IDictionary<string, string> keyValues);

        /// <summary>
        /// 解密(純文字)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string Decrypt(string text);
    }
}