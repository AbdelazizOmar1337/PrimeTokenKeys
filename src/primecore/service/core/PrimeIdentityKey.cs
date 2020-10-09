using primecore.service.util;
using PrimeCore.interfaces;
using PrimeCore.Service.Identity;
using PrimeCore.Service.Store;
using System;
using System.Linq;

namespace PrimeCore.Service.core
{
    public class PrimeIdentityKey : IPrimeServices<IdentityCoreKey>, IPrimeIdentityServices
    {
        public PrimeIdentityKey(KeyDescriptor keyDescriptor)
        {
             handler = new IdentityCoreKeyHandler();
            KeyDescriptor = keyDescriptor;
        }

        public KeyDescriptor KeyDescriptor { get; set; }
        internal IdentityCoreKeyHandler handler { get; }
        //internal string UnknownPayload { get; set; }
        internal string UnkownKey { get; set; }
        public void AddToIgnore(IdentityCoreKey[] keys)
        {
            PrimeStore.IgnoredKeys.AddRange(keys);
        }

        public IdentityCoreKey CreateKey(string payload)
        {
           // UnknownPayload = payload;
            var key = handler.StartEncrypting(KeyDescriptor, payload).GetAwaiter().GetResult();
            UnkownKey = key;
            return new IdentityCoreKey
            {
                Result = key
            };
        }

        public bool IsIgnored(IdentityCoreKey key)
        {
            return PrimeStore.IgnoredKeys.Any(x => x.Result == key.Result);
        }

        /// <summary>
        /// Regenerated new key based on the encrypted key using it's KeyDescriptor and his original PayLoad that was inserted with it
        /// </summary>
        /// <param name="descriptor">Contains key signature,secretkey</param>
        /// <param name="key">encrypted key</param>
        /// <param name="originalPayload">original Payload</param>
        /// <returns></returns>
        public string ReKey(KeyDescriptor descriptor,IdentityCoreKey key,string originalPayload)
        {
            try
            {
                var result = handler.StartDecrypting(descriptor, key.Result).GetAwaiter().GetResult();
                if(result != originalPayload) throw new Exception("Payload doesn't match");

                var newKey = handler.StartEncrypting(descriptor, originalPayload).GetAwaiter().GetResult();
                return newKey;
            }
            catch (Exception ex)
            {
                throw new Exception($"The {originalPayload} doesn't exist in this key or {descriptor} doesn't match this key", ex);
            }
          
        }
        /// <summary>
        /// Decrypt the key of this instace
        /// </summary>
        /// <returns></returns>
        public string WritePayload()
        {
            var result = handler.StartDecrypting(KeyDescriptor,UnkownKey).GetAwaiter().GetResult();
            //UnknownPayload = result;
            return result;
        }
        public string WritePayload(KeyDescriptor keyDescriptor,string decrypted)
        {
            var result = handler.StartDecrypting(keyDescriptor, decrypted).GetAwaiter().GetResult();
            //UnknownPayload = result;
            return result;
        }

    }
}
