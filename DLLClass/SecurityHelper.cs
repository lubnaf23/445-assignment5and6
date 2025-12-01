using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DLLClass
{
    public static class SecurityHelper
    {
        public static string HashString(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public static string Encrypt(string plaintext, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = GetKeyBytes(key);
                aes.IV = new byte[16];

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] bytes = Encoding.UTF8.GetBytes(plaintext);
                byte[] encrypted = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);

                return Convert.ToBase64String(encrypted);
            }
        }

        public static string Decrypt(string ciphertext, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = GetKeyBytes(key);
                aes.IV = new byte[16];

                ICryptoTransform dec = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] bytes = Convert.FromBase64String(ciphertext);
                byte[] decrypted = dec.TransformFinalBlock(bytes, 0, bytes.Length);

                return Encoding.UTF8.GetString(decrypted);
            }
        }

        private static byte[] GetKeyBytes(string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] finalKey = new byte[32]; // 256-bit key
            Array.Copy(keyBytes, finalKey, Math.Min(keyBytes.Length, finalKey.Length));
            return finalKey;
        }
    }
}
