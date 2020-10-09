using PrimeCore.Service.Store;
using System.Collections.Generic;

namespace PrimeCore.Service
{
    /// <summary>
    /// Provides the configurations of the key
    /// </summary>
    public class CoreKeyConfig
    {
        /// <summary>
        /// Provides the configurations of the key
        /// </summary>
        public CoreKeyConfig()
        {
            Length = 50;
            UseSalt = false;
            CoreKeyFormatterConfig = new CoreKeyFormatterConfig { Format = PrimeFormatter.Ignore, IsStrictedLength = true };
            IgnoredKeys = PrimeStore.IgnoredKeys;

        }
        /// <summary>
        /// Get or set the max length of the generated key, Default is 50
        /// </summary>
        public byte Length { get; set; }
        /// <summary>
        /// Determine if the key will add salt inside it, Default is <see langword="false"/>
        /// </summary>
        public bool UseSalt { get; set; }
        /// <summary>
        /// Add some configurations to the key
        /// </summary>
        public CoreKeyFormatterConfig CoreKeyFormatterConfig { get; set; }
        /// <summary>
        /// Add specfic keys so they will never be regenerated again, By default every key is unique
        /// </summary>
        public ICollection<IPrimeKey> IgnoredKeys { get; set; }
    }
}