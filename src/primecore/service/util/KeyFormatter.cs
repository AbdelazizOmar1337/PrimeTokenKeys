using System.Text;

namespace PrimeCore.Service.util
{
    public class KeyFormatter
    {
        public static string UseUnderscore(string key)
        {
            var length = key.Length;
            var miniDiv = 2;
            var mini = 10;
            if (length < mini)
            {
                return key.Insert(0, "_");
            }
            else
            {
                var temp = new StringBuilder(key);
                //var currentLength = length - mini;
                int i = mini;
                while (i <= length)
                {
                    i += 5;
                    miniDiv++;
                }
                for (int x = miniDiv; x <= length; x += miniDiv)
                {
                    temp.Insert(x, "_");
                }
                return temp.ToString();

            }
        }
        public static string UseUnderscore(string key, CoreKeyConfig config)
        {
            var length = key.Length;
            var miniDiv = 2;
            var mini = 10;
            if (length < mini)
            {
                return key.Insert(0, "_");
            }
            else
            {
                var keyBuilder = new StringBuilder(key);
                for (int i = mini; i <= length; i += 5)
                {
                    miniDiv++;
                }
                for (int x = miniDiv; x <= length; x += miniDiv)
                {
                    keyBuilder.Insert(x, "_");
                }
                if (config.CoreKeyFormatterConfig.IsStrictedLength)
                    keyBuilder.Remove(config.Length, keyBuilder.Length - config.Length);

                return keyBuilder.ToString();

            }
        }
    }
}
