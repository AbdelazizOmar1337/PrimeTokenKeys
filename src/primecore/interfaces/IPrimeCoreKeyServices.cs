using PrimeCore.Service;

namespace PrimeCore.interfaces
{
    public interface IPrimeCoreKeyServices
    {
        CoreKey CreateKey();
        bool IsSalted(CoreKey key);
        string ReKey(CoreKey key);
    }
}
