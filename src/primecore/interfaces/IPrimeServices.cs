namespace PrimeCore.interfaces
{
    public interface IPrimeServices<Tin> where Tin : new()
    {

        
        void AddToIgnore(Tin[] keys);
        bool IsIgnored(Tin key);
    }
}