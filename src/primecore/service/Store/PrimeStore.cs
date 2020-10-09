using System.Collections.Generic;

namespace PrimeCore.Service.Store
{
    public class PrimeStore
    {
        internal static List<IPrimeKey> IgnoredKeys = new List<IPrimeKey>();
        internal static string[] chars = new string[26]
        {
            "q", "w", "e", "r", "t", "y","u","i","o","p","a","s","d","f","g","h","j","k","l","z","x","c","v","b","n","m"
        };
        internal static byte[] nums = new byte[10]
        {
            0,1,2,3,4,5,6,7,8,9
        };




    }
}
