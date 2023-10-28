using Hackathon.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        [Route("/api/Login")]
        [HttpPost]
        public IActionResult LoginUser([FromBody]UserCredentials userCredentials)
        {

            return Ok("Login Successfull");
        }

    }
}
