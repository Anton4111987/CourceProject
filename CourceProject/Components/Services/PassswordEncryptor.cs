using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using CourceProject.Components.Models;
using System.Text;
using System.Globalization;

namespace CourceProject.Components.Services
{
    public class PasswordEncryptor:IEncryptor
    {
        private readonly byte[] key;
        private readonly byte[] iv;

        public PasswordEncryptor(IOptions<CryptoString> options)
        {
            key = Encoding.UTF8.GetBytes(options.Value.Key!);
            iv = Encoding.UTF8.GetBytes(options.Value.Key!);
        }
        public PasswordEncryptor(string Key, string Iv)
        {

            var Ke = Encoding.Default.GetChars(Encoding.Default.GetBytes(Key));
            var i = Encoding.Default.GetChars(Encoding.Default.GetBytes(Iv));
            this.key =Encoding.UTF8.GetBytes(Ke);
            this.iv = Encoding.UTF8.GetBytes(i);
        }
        public string Encrypt(string? plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public string Decrypt(string? cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText!)))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}
