namespace CryptoCore.Crypto
{
    public interface IEncryptor
    {
        /// <summary>
        /// 加密(純文字)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string Encrypt(string text);
    }
}
