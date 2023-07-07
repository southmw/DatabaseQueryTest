using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseQueryTest
{
    /// <summary>
    /// AES암호화 클래스
    /// </summary>
    public class AesCrypt
    {
        // 암호화 Seed
        private readonly byte[] KeyValue = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x01, 0x02, 0x03, 
                                            0x04, 0x05, 0x01, 0x02, 0x03, 0x04, 0x05, 0x01,
                                            0x02, 0x03, 0x04, 0x05, 0x01, 0x02, 0x03, 0x04,
                                            0x05, 0x01, 0x02, 0x03, 0x04, 0x05, 0x03, 0x04};
        private readonly byte[] IVValue = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x01, 0x02, 0x03,
                                            0x04, 0x05, 0x01, 0x02, 0x03, 0x04, 0x05, 0x01};

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="aSeedValue">암호화 시드</param>
        public AesCrypt(byte[]? key = null, byte[]? iv =null)
        {
           if(key != null) {
                KeyValue = key;
           }

           if(iv != null) {
                IVValue = iv;
            }
        }

        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if(string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));
            if(Key == null || Key.Length <= 0)
                throw new ArgumentNullException(nameof(Key));
            if(IV == null || IV.Length <= 0)
                throw new ArgumentNullException(nameof(IV));

            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using(Aes aesAlg = Aes.Create()) {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using MemoryStream msEncrypt = new();
                using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
                using(StreamWriter swEncrypt = new(csEncrypt)) {
                    //Write all data to the stream.
                    swEncrypt.Write(plainText);
                }
                encrypted = msEncrypt.ToArray();
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public string EncryptString_Aes(string plainText)
        {
            return Convert.ToBase64String(EncryptStringToBytes_Aes(plainText, KeyValue, IVValue));
        }

        public string DecryptString_Aes(string cipherText)
        {
            return DecryptStringFromBytes_Aes(Convert.FromBase64String(cipherText), KeyValue, IVValue);
        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if(cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException(nameof(cipherText));
            if(Key == null || Key.Length <= 0)
                throw new ArgumentNullException(nameof(Key));
            if(IV == null || IV.Length <= 0)
                throw new ArgumentNullException(nameof(IV));

            // Declare the string used to hold
            // the decrypted text.
            string? plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using(Aes aesAlg = Aes.Create()) {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using MemoryStream msDecrypt = new(cipherText);
                using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new(csDecrypt);

                // Read the decrypted bytes from the decrypting stream
                // and place them in a string.
                plaintext = srDecrypt.ReadToEnd();
            }

            return plaintext;
        }
    }
}
