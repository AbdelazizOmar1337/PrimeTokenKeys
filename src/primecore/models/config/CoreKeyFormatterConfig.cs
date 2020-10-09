namespace PrimeCore.Service
{
    public class CoreKeyFormatterConfig
    {
        /// <summary>
        /// Determine how the key would be displayed, Default is <see cref="PrimeFormatter.Ignore"/>
        /// </summary>
        public PrimeFormatter? Format { get; set; }
        /// <summary>
        /// Prevents key exceeds maximum length while using <see cref="PrimeFormatter.UseUnderscore"/>, Default is <see langword="true"/>
        /// </summary>
        public bool IsStrictedLength { get; set; }

    }

}