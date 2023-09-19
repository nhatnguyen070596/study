using System;
namespace study.Repositories.Interface
{
	public interface IRedisRepository
	{
        public Task<T> GetCacheData<T>(string key);
        public Task<object> RemoveData(string key);
        public Task<bool> SetCacheData<T>(string key, T value, DateTimeOffset expirationTime);
    }
}

