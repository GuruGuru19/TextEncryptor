using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TextEncryptor
{
    internal static class Encryptor
    {
        public static string Encrypt(string text, string keyText, byte[] IV)
        {
            if (text.Length < 1)
            {
                return "";
            }
            byte[] key = Encoding.UTF8.GetBytes(keyText);
            AesManaged aes = new AesManaged();
            aes.Key = key;
            aes.IV = IV;

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] InputBytes = Encoding.UTF8.GetBytes(text);
            cryptoStream.Write(InputBytes, 0, InputBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] Encrypted = memoryStream.ToArray();

            return Convert.ToBase64String(Encrypted);
        }

        public static string Decrypt(string text, string keyText, byte[] IV)
        {
            if (text.Length<1)
            {
                return "";
            }
            byte[] key = Encoding.UTF8.GetBytes(keyText);
            AesManaged aes = new AesManaged();
            aes.Key = key;
            aes.IV = IV;

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

            byte[] InputBytes = Convert.FromBase64String(text);
            cryptoStream.Write(InputBytes, 0, InputBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] Decrypted = memoryStream.ToArray();

            return UTF8Encoding.UTF8.GetString(Decrypted, 0, Decrypted.Length);
        }
    }
}
