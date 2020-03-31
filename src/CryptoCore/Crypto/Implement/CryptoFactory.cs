using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CryptoCore.Crypto
{

    public class CryptoFactory : ICryptoFactory
    {
        /// <summary>
        /// 創建 CryptoAlgorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public ICryptoAlgorithm Create<T>(string password, string salt) where T : SymmetricAlgorithm, new()
        {
            return new CryptoAlgorithm(password, salt, new T());
        }

        /// <summary>
        /// 創建 CryptoAlgorithm
        /// </summary>
        /// <param name="type"></param>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public ICryptoAlgorithm Create(Type type, string password, string salt)
        {
            var tempType = Activator.CreateInstance(type);

            if (!(tempType is SymmetricAlgorithm parsedType) ) throw new ArgumentException(nameof(type));

            return new CryptoAlgorithm(password, salt, parsedType);
        }
    }
}
