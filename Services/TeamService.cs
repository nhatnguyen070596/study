using StackExchange.Redis;
using study.Repositories.Abtract;
using study.Repositories.Interface;
using study.Services.Interface;

namespace study.Services
{
    public class TeamService :ITeamService
	{
        private readonly ITeamRepository _team;
        private readonly IRedisRepository _redis;


        public TeamService(ITeamRepository teamRepository, IRedisRepository redisRepository)
        {
         
            _team = teamRepository;
            _redis = redisRepository;
        }


        public Task<int> AddTeam(Team team)
        {
            var variable = _team.AddTeam(team);
            return variable;
        }

        public Task<int> DeleteTeam(int teamId)
        {
            var variable = _team.DeleteTeam(teamId);
            return variable;
        }

        public Task<int> EditTeam(Team team)
        {
            var variable = _team.EditTeam(team);
            return variable;
        }

        public Task<List<Team>> GetAllTeams()
        {
            var variable = _team.GetAllTeams();
            //var redis = _redis.GetCacheData<RedisOutput>("nhat");
            //LogHelper.Writelog(LogKafka.Topic1Name, redis.ToString(), LogType.LogInfo);


            //_redis.SetCacheData("nhat", "testredis",new DateTimeOffset());
            string messageLog = "GetAllTeams";
            LogHelper.Writelog(LogKafka.Topic1Name,messageLog,LogType.LogInfo);
            return variable;
        }

        public Task<Team> GetTeamById(int teamId)
        {
            var variable = _team.GetTeamById(teamId);
            return variable;
        }
    }
}

