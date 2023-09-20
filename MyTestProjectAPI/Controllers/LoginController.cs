using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyTestProjectAPI.Models;

namespace MyTestProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginUser user)
        {
            var user Authenticate(user);

            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }
            return NotFound("User Not Found");
        }

        
    }
}
