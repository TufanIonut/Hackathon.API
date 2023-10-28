using Dapper;
using Hackathon.API.Entities;
using Hackathon.API.Infrastructure;
using System.Data;
using System.Net;

namespace Hackathon.API.DTOs
{
    public class UserDTO
    {
        public string EmailAdress { get; set; }
        public string UserPassword { get; set; }

        public void RegisterUser(UserDTO userDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmailAdress", userDTO.EmailAdress);
            parameters.Add("UserPassword", userDTO.UserPassword);
            DataBaseConnection dataBaseConnection = new DataBaseConnection();
            var connection = dataBaseConnection.ConnectToDataBase();
            connection.Execute("InsertUser",parameters , commandType: CommandType.StoredProcedure);
        }
        public bool CheckLoginCredentials(UserDTO credentials)
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
