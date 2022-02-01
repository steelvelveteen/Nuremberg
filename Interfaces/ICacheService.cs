namespace Nuremberg.Interfaces;

public interface ICacheService
{
    Task<T?> Get<T>(string key);
    Task<T> Set<T>(string key, T value);
}