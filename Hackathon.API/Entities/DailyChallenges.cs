using Dapper;
using Hackathon.API.Infrastructure;
using System.Data;

namespace Hackathon.API.Entities
{
    public class DailyChallenges
    {
        public int IdChallenge { get; set; }
        public string challengeDescription { get; set; }
        
        public void insertUserChallenge(int id, int challengeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            parameters.Add("challengeId", challengeId);
            DataBaseConnection dataBaseConnection = new DataBaseConnection();
            var connection = dataBaseConnection.ConnectToDataBase();
            connection.Execute("insertUserChallenge", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
