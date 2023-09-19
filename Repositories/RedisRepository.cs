using System;
using study.Repositories.Interface;
using StackExchange.Redis;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace study.Repositories
{
    public class RedisRepository : IRedisRepository
    {
        private IDatabase _redis;
        public RedisRepository(IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase(0);
        }

        Task<T> IRedisRepository.GetCacheData<T>(string key)
        {
            try
            {
                LogHelper.Writelog(LogKafka.Topic1Name, key, LogType.LogInfo);
                string output = _redis.StringGet(key);
                RedisOutput redisCache = new (key, output);
                return Task.FromResult((T)Convert.ChangeType(redisCache, typeof(T)));
            }
            catch (Exception ex)
            {
                LogHelper.Writelog(LogKafka.Topic1Name, ex.Message, LogType.LogError);
                throw new NotImplementedException();
            }
        }

        Task<object> IRedisRepository.RemoveData(string key)
        {
            try
            {
                LogHelper.Writelog(LogKafka.Topic1Name, key, LogType.LogInfo);
                dynamic output = _redis.KeyDelete(key);
                return output;
            }
            catch (Exception ex)
            {
                LogHelper.Writelog(LogKafka.Topic1Name, ex.Message, LogType.LogError);
                throw new NotImplementedException();
            }
        }

        Task<bool> IRedisRepository.SetCacheData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            try
            {
                LogHelper.Writelog(LogKafka.Topic1Name, value.ToString(), LogType.LogInfo);
                dynamic status = _redis.SetAdd(key, value.ToString());
                return status;
            }
            catch (Exception ex)
            {
                LogHelper.Writelog(LogKafka.Topic1Name, ex.Message, LogType.LogError);
                throw new NotImplementedException();
            }
        }
    }
}

