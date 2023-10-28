using Dapper;
using Hackathon.API.Infrastructure;
using Microsoft.OpenApi.Any;
using System.Data;

namespace Hackathon.API.DTOs
{
    public class ElectronicsDTO
    {
        public int IdUser { get; set; }
        public string PartnerName { get; set; }
        public string CategoryName { get; set; }
        public string Model { get; set; }
        public string Series { get; set; }
        public string EnergeticClass { get; set; }
        public string EnergyUsed { get; set; }

        public int returnPartnerID (string PartnerName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("PartnerName", PartnerName);
            parameters.Add("PartnerId", DbType.Int32, direction: ParameterDirection.Output);
            DataBaseConnection dataBaseConnection = new DataBaseConnection();
            var connection = dataBaseConnection.ConnectToDataBase();
            connection.Execute("GetPartnerIdByPartnerName", parameters, commandType: CommandType.StoredProcedure);
            int PartnerId = parameters.Get<int>("PartnerId");
            return PartnerId;
        }
        public int returnCategoryID(string CategoryName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CategoryName", CategoryName);
            parameters.Add("CategoryId", DbType.Int32, direction: ParameterDirection.Output);
            DataBaseConnection dataBaseConnection = new DataBaseConnection();
            var connection = dataBaseConnection.ConnectToDataBase();
            connection.Execute("GetCategoryIdByCategoryName", parameters, commandType: CommandType.StoredProcedure);
            int CategoryId = parameters.Get<int>("CategoryId");
            return CategoryId;
        }
    }
}
