using PrimeCore.Service;
using PrimeCore.Service.Identity;

namespace PrimeCore.interfaces
{
    public interface IPrimeIdentityServices
    {
      
        IdentityCoreKey CreateKey(string user);
        string WritePayload();
        string ReKey(KeyDescriptor descriptor, IdentityCoreKey key, string keyPayload);
    }
}