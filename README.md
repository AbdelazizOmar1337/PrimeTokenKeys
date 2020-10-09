# PrimeTokenKeys
Generate custom unique Ids with secret token,signatures and more...

Create new advanced Ids in modern way
## 1-Advanced
using SecretKey, Signature and your payload
```csharp
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

            var primeKey = new PrimeIdentityKey(keyDescriptor);
            var key = primeKey.CreateKey("test");
            //OAkfqznOh/+/un2Orm6Pzm0Xuh6Amm16Muh__16iTzM3Wju2sQQ==
            
            var payload = key.WritePayload(keyDescriptor, key.Result);
            //test
```

## 2-SimpleWay
# no secretkeys or signatures
```csharp
            var primeCore = new PrimeCoreKey
            {
                //overrides default values
                CoreKeyConfig = new CoreKeyConfig
                {
                    Length = 50,
                    UseSalt = false,
                    CoreKeyFormatterConfig = new CoreKeyFormatterConfig
                    {
                        Format = PrimeFormatter.Ignore, // or UseUnderscore
                        IsStrictedLength = false
                    }
                }
            };
            var primeKey = primeCore.CreateKey();
            //jc8Vhx2Jak18Jvn18Bll6Lsj12Kvn18Nzz12Xeb4Tvb2Maa16V

            Console.WriteLine(primeKey.Result);
            Console.WriteLine(primeCore.IsSalted(primeKey));

            var re = primeCore.ReKey(primeKey);
            Console.WriteLine(re);

            primeCore.AddToIgnore(new CoreKey[1] { primeKey });

            await foreach (var item in primeCore.ReadIgnoredKeysAsync())
            {
                Console.WriteLine(item.Result);
            }
```

