using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyTestProjectAPI.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MyTestProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;
        // Constructor to inject IConfiguration
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Auth([FromBody] LoginUser user)
        {
            // Authenticate the user
            var authUser = Authenticate(user);

            if (authUser != null)
            {
                // Generate a JWT token
                var token = GenerateToken(authUser);

                // Create a response object with token information
                var response = new AuthenticationResponse
                {
                    AccessToken = token, // Set the access token
                    TokenType = "Bearer", // Set the token type
                    ExpiresIn = 3600 // Set the expiration time (in seconds)
                };

                return Ok(response); // Return the response objec
            }
            return NotFound("User Not Found");
        }

        // Method to generate a JWT token
        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                 new Claim(ClaimTypes.NameIdentifier, user.UserName),
                 new Claim(ClaimTypes.GivenName, user.Name),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Surname, user.Surname),
            };

          
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        // Method to authenticate a user
        private User Authenticate(LoginUser user)
        {
            // Check if the user exists in the default data
            var currentUser = Helpers.Data.Users.FirstOrDefault(
                u =>
                u.UserName.ToLower() == user.UserName.ToLower() &&
                u.Password == user.Password);

            if(currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}
