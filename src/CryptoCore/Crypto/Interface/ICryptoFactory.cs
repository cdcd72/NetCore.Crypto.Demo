using System;
using System.Security.Cryptography;

namespace CryptoCore.Crypto
{
    public interface ICryptoFactory
    {
        /// <summary>
        /// 創建 CryptoAlgorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        ICryptoAlgorithm Create<T>(string password, string salt) where T : SymmetricAlgorithm, new();

        /// <summary>
        /// 創建 CryptoAlgorithm
        /// </summary>
        /// <param name="type"></param>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        ICryptoAlgorithm Create(Type type, string password, string salt);
    }
}