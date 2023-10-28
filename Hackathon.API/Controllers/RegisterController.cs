using Hackathon.API.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [ApiController]
    [Route("/api/Register")]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public IActionResult RegisterUser([FromBody]UserDTO userCredentials)
        {
            if(userCredentials.CheckLoginCredentials(userCredentials))
            { 
                return BadRequest("Sorry, an account with this email adress already exists");
            }
            else
            {
                userCredentials.RegisterUser(userCredentials);
                return Ok("Registration Succesful");
            }
            
        }
    }
}
