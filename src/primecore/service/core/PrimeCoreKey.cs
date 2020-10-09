using PrimeCore.interfaces;
using PrimeCore.Service.Store;
using PrimeCore.Service.util;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeCore.Service
{
    /// <summary>
    /// Provides the core functionality of PrimeKey
    /// </summary>
    public class PrimeCoreKey : IPrimeServices<CoreKey>, IPrimeCoreKeyServices
    {
        internal PrimeCoreKey(CoreKeyConfig primeConfig)
        {
            CoreKeyConfig = primeConfig;
        }
        /// <summary>
        /// Override default configrations of the key
        /// </summary>
        public CoreKeyConfig CoreKeyConfig { get; set; }

        /// <summary>
        /// Create new instance of key, also provides the core functionalities of PrimeKey
        /// </summary>
        public PrimeCoreKey()
        {
            CoreKeyConfig ??= new CoreKeyConfig();
        }

        public bool IsSalted(CoreKey key)
        {
            return key.Result.Any(x => x.Equals('-'));
        }

        public CoreKey CreateKey()
        {
            return this.NewKey(CoreKeyConfig);
        }

        public void AddToIgnore(CoreKey[] keys)
        {
            PrimeStore.IgnoredKeys.AddRange(keys);
            CoreKeyConfig.IgnoredKeys = PrimeStore.IgnoredKeys;

        }


        public string ReKey(CoreKey key)
        {
            return this.Refactor(CoreKeyConfig, key);
        }

        public bool IsIgnored(CoreKey key)
        {
            return PrimeStore.IgnoredKeys.Any(x => x.Result == key.Result);

        }
        public void RemoveFromIgnores(CoreKey key)
        {
            PrimeStore.IgnoredKeys.Remove(key);
            CoreKeyConfig.IgnoredKeys = PrimeStore.IgnoredKeys;

        }
        public async IAsyncEnumerable<IPrimeKey> ReadIgnoredKeysAsync()
        {
            for (int i = 0; i < PrimeStore.IgnoredKeys.Count; i++)
            {
                await Task.Delay(0);
                yield return PrimeStore.IgnoredKeys[i];
            }
        }
    }
}