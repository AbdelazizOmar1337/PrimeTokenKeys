using System;
using System.Security.Cryptography;

namespace PrimeCore.Service.Helpers
{
    public class KeySalt
    {
        internal static string RNGCrypto(string str)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[4];

            rng.GetBytes(buffer);
            string salt = BitConverter.ToString(buffer);
            return str + salt;
        }
    }
}
