namespace PrimeCore.Service
{

    public enum PrimeFormatter
    {
        /// <summary>
        /// Insert underscore at relevance locations, The length of the key will be increased due to `Underscores`, 
        /// you may disable this by using <see cref="CoreKeyFormatterConfig.IsStrictedLength"/>
        /// </summary>
        UseUnderscore = 0,
        /// <summary>
        /// Use default generated key
        /// </summary>
        Ignore = 1
    }

}
