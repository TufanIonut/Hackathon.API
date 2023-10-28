using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Entities
{
    public class UserCredentials
    {
        public int IdUser { get; set; }
        public string EmailAdress { get; set; }

        public string Password { get; set; }
        
        public List<UserRoles> userRoles { get; set; }
    }
}