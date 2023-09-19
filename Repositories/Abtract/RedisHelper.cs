using System;
using StackExchange.Redis;
using study.Repositories.Interface;

namespace study.Repositories.Abtract
{
	public abstract class RedisHelper
	{

        private IDatabase _redis;
        private ITeamRepository teamRepository;

        public RedisHelper(IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase(0);
        }

        protected RedisHelper(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public Task<T> GetCacheData<T>(string key)
        {
            try
            {
                LogHelper.Writelog(LogKafka.Topic1Name, key, LogType.LogInfo);
                dynamic output = _redis.StringGet(key).ToString();
                return output;
            }
            catch (Exception ex)
            {
                LogHelper.Writelog(LogKafka.Topic1Name, ex.Message, LogType.LogError);
                throw new NotImplementedException();
            }
        }

        public Task<object> RemoveData(string key)
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

        public Task<bool> SetCacheData<T>(string key, T value, DateTimeOffset expirationTime)
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

