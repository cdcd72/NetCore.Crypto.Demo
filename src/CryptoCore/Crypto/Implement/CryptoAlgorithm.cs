using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CryptoCore.Crypto
{
    public class CryptoAlgorithm : ICryptoAlgorithm
    {
        private readonly ICryptoTransform _encryptor;
        private readonly ICryptoTransform _decryptor;

        #region Constructor

        public CryptoAlgorithm(string password, string salt, SymmetricAlgorithm algorithm)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (salt == null) throw new ArgumentNullException(nameof(salt));

            // 利用 Rfc2898DeriveBytes 產生衍生金鑰
            DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            var rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            var rgbIv = rgb.GetBytes(algorithm.BlockSize >> 3);

            _encryptor = algorithm.CreateEncryptor(rgbKey, rgbIv);
            _decryptor = algorithm.CreateDecryptor(rgbKey, rgbIv);
        }

        #endregion

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">純文字</param>
        /// <returns></returns>
        public string Encrypt(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            using (var ms = new MemoryStream())
            {
                using (var stream = new CryptoStream(ms, _encryptor, CryptoStreamMode.Write))
                {
                    using (var writer = new StreamWriter(stream, Encoding.Unicode))
                    {
                        writer.Write(text);
                    }
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text">純文字</param>
        /// <returns></returns>
        public string Decrypt(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            using (var ms = new MemoryStream(Convert.FromBase64String(text)))
            {
                using (var stream = new CryptoStream(ms, _decryptor, CryptoStreamMode.Read))
                {
                    using (var reader = new StreamReader(stream, Encoding.Unicode))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        /// <summary>
        /// SHA384 雜湊
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string HashBySHA384(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            var textBytes = Encoding.UTF8.GetBytes(text);

            // SHA384 Hasher
            var hasher = new SHA384CryptoServiceProvider();

            // 初始化 Hasher
            hasher.Initialize();

            // 計算雜湊並轉換為 base64 字串
            return Convert.ToBase64String(hasher.ComputeHash(textBytes));
        }
    }
}
