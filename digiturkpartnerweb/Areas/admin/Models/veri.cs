using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace digiturkpartnerweb.Areas.admin.Models
{
    public class veri
    {

        static public string enc_sifre = "5305804345huSeyiN";

        static public class Crypto
        {
            private static readonly byte[] salt = Encoding.ASCII.GetBytes(enc_sifre);

            public static string Encrypt(string textToEncrypt, string encryptionPassword)
            {
                var algorithm = GetAlgorithm(encryptionPassword);
                byte[] encryptedBytes;
                using (ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV))
                {
                    byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);
                    encryptedBytes = InMemoryCrypt(bytesToEncrypt, encryptor);
                }
                return Convert.ToBase64String(encryptedBytes);
            }

            public static string Decrypt(string encryptedText, string encryptionPassword)
            {
                var algorithm = GetAlgorithm(encryptionPassword);

                byte[] descryptedBytes;
                using (ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV))
                {
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                    descryptedBytes = InMemoryCrypt(encryptedBytes, decryptor);
                }
                return Encoding.UTF8.GetString(descryptedBytes);
            }

            // Performs an in-memory encrypt/decrypt transformation on a byte array.   

            private static byte[] InMemoryCrypt(byte[] data, ICryptoTransform transform)
            {
                MemoryStream memory = new MemoryStream();
                using (Stream stream = new CryptoStream(memory, transform, CryptoStreamMode.Write))
                {
                    stream.Write(data, 0, data.Length);
                }
                return memory.ToArray();
            }
            // Defines a RijndaelManaged algorithm and sets its key and Initialization Vector (IV)   
            // values based on the encryptionPassword received.   
            private static RijndaelManaged GetAlgorithm(string encryptionPassword)
            {
                // Create an encryption key from the encryptionPassword and salt.   
                var key = new Rfc2898DeriveBytes(encryptionPassword, salt);

                // Declare that we are going to use the Rijndael algorithm with the key that we've just got.  
                var algorithm = new RijndaelManaged();
                int bytesForKey = algorithm.KeySize / 8;
                int bytesForIV = algorithm.BlockSize / 8;
                algorithm.Key = key.GetBytes(bytesForKey);
                algorithm.IV = key.GetBytes(bytesForIV);
                return algorithm;
            }

        }
    }
}