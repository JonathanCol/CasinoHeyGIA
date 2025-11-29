namespace CasinoHeyGIA.Application.Interfaces
{
    public interface ICacheService
    {
        void SetAsync(string key, string data, TimeSpan? expiration = null);
    }
}
