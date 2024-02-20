using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using CourceProject.Components.Models;
using System.Text;

namespace CourceProject.Components.Services
{
    public class PassswordEncryptor:IEncryptor
    {
        /* private readonly byte[] key;// = Encoding.UTF8.GetBytes("MySecretKey12345");
        // private CryptoString s;
         public PassswordEncryptor(IOptions<CryptoString> options)
         {
             //s=options.Value;
             key = Encoding.UTF8.GetBytes(options.Value.Key);
         }
         public string Encrypt(string password)
         {
             using Aes aes = Aes.Create();
             aes.Key = key;
             byte[] encryptedBytes;

             using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
             using (MemoryStream ms = new MemoryStream())
             using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
             {
                 byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                 cs.Write(passwordBytes, 0, passwordBytes.Length);
                 cs.FlushFinalBlock();
                 encryptedBytes = ms.ToArray();
             }

             return Convert.ToBase64String(encryptedBytes);
         }

         public string Decrypt(string encryptedPassword)
         {
             byte[] encryptedBytes = Convert.FromBase64String(encryptedPassword);

             using Aes aes = Aes.Create();
             aes.Key = key;

             string decryptedPassword;

             using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
             using (MemoryStream ms = new MemoryStream(encryptedBytes))
             using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
             using (StreamReader sr = new StreamReader(cs))
             {
                 decryptedPassword = sr.ReadToEnd();
             }

             return decryptedPassword;
         }*/
        private readonly byte[] key; // = Encoding.UTF8.GetBytes("YourSecretKey12345");
        private readonly byte[] iv; // = Encoding.UTF8.GetBytes("YourIV12345");

        public PassswordEncryptor(IOptions<CryptoString> options)
        {
            //s=options.Value;
            key = Encoding.UTF8.GetBytes(options.Value.Key);
            iv = Encoding.UTF8.GetBytes(options.Value.Key);
        }
        public string Encrypt(string plainText)
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

        public string Decrypt(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }


    }
}
