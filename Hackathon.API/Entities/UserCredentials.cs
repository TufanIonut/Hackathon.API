using Dapper;
using Hackathon.API.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Hackathon.API.Entities
{
    public class UserCredentials
    {
        public int IdUser { get; set; }
        public string EmailAdress { get; set; }

        public string UserPassword { get; set; }

        public List<UserRoles> userRoles { get; set; }

        public bool CheckLoginCredentials(UserCredentials credentials)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Email", credentials.EmailAdress);
            parameters.Add("Password", credentials.UserPassword);
            parameters.Add("IsValid", DbType.Boolean, direction: ParameterDirection.Output);
            DataBaseConnection dataBaseConnection = new DataBaseConnection();
            var connection = dataBaseConnection.ConnectToDataBase();
            connection.Execute("CheckLoginCredentials", parameters, commandType: CommandType.StoredProcedure);
            bool isValid = parameters.Get<int>("IsValid") == 1;

            if (isValid)
            {
                return true;
            }
            return false;
        }
    }
}