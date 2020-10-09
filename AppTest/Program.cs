using primecore.service.util;
using PrimeCore.Service;
using PrimeCore.Service.core;
using PrimeCore.Service.Identity;
using System;
using System.Threading.Tasks;

namespace AppTest
{
    class Program
    {
        static async Task Main()
        {
            var primeCore = new PrimeCoreKey
            {
                //overrides default values
                CoreKeyConfig = new CoreKeyConfig
                {
                    Length = 50,
                    UseSalt = false,
                    CoreKeyFormatterConfig = new CoreKeyFormatterConfig
                    {
                        Format = PrimeFormatter.Ignore,
                        IsStrictedLength = false
                    }
                }
            };

            var primeKey = primeCore.CreateKey();


            Console.WriteLine(primeKey.Result);
            Console.WriteLine(primeCore.IsSalted(primeKey));

            var re = primeCore.ReKey(primeKey);
            Console.WriteLine(re);

            primeCore.AddToIgnore(new CoreKey[1] { primeKey });

            await foreach (var item in primeCore.ReadIgnoredKeysAsync())
            {
                Console.WriteLine(item.Result);
            }

            var keyDescriptor = new KeyDescriptor
            {
                SecretKey = new SecretKey
                {
                    Secret = "superSecretKey"
                },
                KeySignature = new KeySignature
                {
                    Signature = "mycoolapp"
                }
            };

            var ke = new PrimeIdentityKey(keyDescriptor);
            var key = ke.CreateKey("test");

            Console.WriteLine(key.Result);
            var result = ke.WritePayload();
            var unknown = ke.WritePayload(keyDescriptor, key.Result);
            Console.WriteLine(result);
            Console.WriteLine(unknown);
        }
    }
}
