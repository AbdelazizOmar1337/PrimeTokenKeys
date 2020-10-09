using PrimeCore.Service.Helpers;
using PrimeCore.Service.Store;
using System;
using System.Linq;
using System.Text;

namespace PrimeCore.Service.util
{
    internal static class PrimeGenerator
    {


        internal static CoreKey NewKey(this PrimeCoreKey prime, CoreKeyConfig config)
        {
            var maxLength = config.Length;
            var keyBuilder = new StringBuilder();
            var format = config.CoreKeyFormatterConfig;
            for (int i = 0; i <= maxLength; i++)
            {
                GeneratedKeys(out string firstSmallChar, out string secondSmallChar, out int num, out string bigChar);

                var combined = $"{firstSmallChar}{secondSmallChar}{num}{bigChar}";
                if (config.UseSalt)
                {
                    keyBuilder.Append(KeySalt.RNGCrypto(combined));
                }
                keyBuilder.Append(combined);

                if (keyBuilder.Length > config.Length)
                {
                    keyBuilder.Remove(maxLength, keyBuilder.Length - maxLength);
                    break;
                }
            }
            if (PrimeStore.IgnoredKeys.Any(x => x.Result == keyBuilder.ToString()))
                NewKey(prime, config);

            if (format.Format == PrimeFormatter.Ignore || format.Format == null)
                return new CoreKey { Result = keyBuilder.ToString() };

            if (format.IsStrictedLength)
                return new CoreKey { Result = KeyFormatter.UseUnderscore(keyBuilder.ToString(), config) };

            return new CoreKey { Result = KeyFormatter.UseUnderscore(keyBuilder.ToString()) };
        }

        private static void GeneratedKeys(out string firstSmallChar, out string secondSmallChar, out int num, out string bigChar)
        {
            var charRandom = new Random().Next(0, 26);
            var numRandom = new Random().Next(0, 10);
            firstSmallChar = PrimeStore.chars[charRandom];
            secondSmallChar = PrimeStore.chars[charRandom.ReInvoke()];
            num = PrimeStore.nums[numRandom] * 2;
            bigChar = PrimeStore.chars[charRandom.ReInvoke()].ToUpper();
        }

        internal static string Refactor(this PrimeCoreKey prime, CoreKeyConfig primeCofing, CoreKey key)
        {
            var _ = key.Result;
            var __ = _.ToCharArray();
            var config = primeCofing;
            var format = primeCofing.CoreKeyFormatterConfig;

            var keyBuilder = new StringBuilder();
            for (int i = 0; i < __.Length; i++)
            {
                var charRandom = new Random().Next(0, 26);
                var numRandom = new Random().Next(0, 10);
                var firstSmallChar = PrimeStore.chars[charRandom];
                var secondSmallChar = PrimeStore.chars[charRandom.ReInvoke()];
                var num = PrimeStore.nums[numRandom] * 2;
                var bigChar = PrimeStore.chars[charRandom.ReInvoke()].ToUpper();
                if (_.Length - i != 4)
                {
                    continue;
                }
                else
                {
                    var combine = new char[] { __[i], __[i + 1], __[i + 2], __[i + 3] };
                    if (config.UseSalt)
                        keyBuilder.Append(new string(combine));

                    __[i] = char.Parse(firstSmallChar);
                    __[i + 1] = char.Parse(secondSmallChar);
                    __[i + 2] = (char)num;
                    __[i + 3] = char.Parse(bigChar);
                    keyBuilder.Append(combine);

                }
                if (keyBuilder.Length >= config.Length)
                {
                    keyBuilder.Remove(config.Length, keyBuilder.Length - config.Length);
                    break;
                }


            }
            if (PrimeStore.IgnoredKeys.Any(x => x.Result == keyBuilder.ToString()))
                Refactor(prime, config, key);

            if (keyBuilder.Length < config.Length) //fail
                return NewKey(prime, config).Result;

            if (format.Format == PrimeFormatter.Ignore || format.Format == null)
                return keyBuilder.ToString();


            if (format.IsStrictedLength)
                return KeyFormatter.UseUnderscore(keyBuilder.ToString(), config);

            return KeyFormatter.UseUnderscore(keyBuilder.ToString());
        }
    }

}
