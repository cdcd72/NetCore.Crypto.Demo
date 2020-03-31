namespace CryptoCore.Crypto
{
    public interface ICryptoAlgorithm
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">純文字</param>
        /// <returns></returns>
        string Encrypt(string text);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text">純文字</param>
        /// <returns></returns>
        string Decrypt(string text);

        /// <summary>
        /// SHA384 雜湊
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string HashBySHA384(string text);
    }
}