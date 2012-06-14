using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MudHook.Core
{    
    public class MudHookSecurity
    {                
        public static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {            
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSalt =
                new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSalt[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSalt[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSalt);
        }
    }
}
