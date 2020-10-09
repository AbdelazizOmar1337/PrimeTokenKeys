using PrimeCore.Service;
using PrimeCore.Service.Helpers;
using PrimeCore.Service.Identity;
using System.Threading.Tasks;

namespace primecore.service.util
{
    public class IdentityCoreKeyHandler
    {
        internal IdentityCoreKeyHandler()
        {
            this.KeyDescriptor ??= new KeyDescriptor();
            this.PrimeCoreKey ??= new PrimeCoreKey()
            {
                CoreKeyConfig = new CoreKeyConfig
                {
                    UseSalt = false,
                    Length = 25,
                    CoreKeyFormatterConfig = new CoreKeyFormatterConfig
                    {
                        IsStrictedLength = true,
                        Format = PrimeFormatter.Ignore
                    }
                }
            };
        }
        public KeyDescriptor KeyDescriptor { get; set; }
        private PrimeCoreKey PrimeCoreKey { get; set; }
        public async Task<string> StartEncrypting(KeyDescriptor keyDescriptor, string payload)
        {

            return await Task.Run(() =>
            {
                var enc = this.Encrypt(keyDescriptor, payload);
                var enc1 = enc.Insert(10, "+/" + PrimeCoreKey.CreateKey().Result);
                var enc2 = enc1.Insert(35, "__");

                return enc2;
            });
        }
        public async Task<string> StartDecrypting(KeyDescriptor keyDescriptor, string encryptedData)
        {

            return await Task.Run(() =>
            {
                var res = encryptedData.Remove(10, 29);
                return this.Decrypt(keyDescriptor, res);
            });
        }




    }
}
