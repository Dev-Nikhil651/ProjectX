using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApplication24.Controllers.LoginController
{
    public class CryptoHelper
    {
        private static byte[] GetKey(string username)
        {
            return SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(username));
        }

        public static string EncryptPassword(string username, string password)
        {
            byte[] key = GetKey(username);
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = new byte[16];
                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(password);
                    return Convert.ToBase64String(encryptor.TransformFinalBlock(bytes, 0, bytes.Length));
                }
            }
        }

        public static string DecryptPassword(string username, string encryptedPassword)
        {
            byte[] key = GetKey(username);
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = new byte[16];
                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    byte[] bytes = Convert.FromBase64String(encryptedPassword);
                    return Encoding.UTF8.GetString(decryptor.TransformFinalBlock(bytes, 0, bytes.Length));
                }
            }
        }
    }

}