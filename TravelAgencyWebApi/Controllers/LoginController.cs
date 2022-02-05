using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyWebApi.Models;

namespace TravelAgencyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _config;

        //2 constructor injection
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        //3.httpPost

        [HttpPost("token")]
        public IActionResult Login([FromBody] UserModel user)
        {
            IActionResult response = Unauthorized();

            var loginUser = AuthenticateUser(user);
            //validate and generate token
            if (loginUser != null)
            {
                var tokenString = GenerateJWToken(loginUser);
                response = Ok(new { token = tokenString });

            }

            return response;
        }


        //4.Authenticate user

        private UserModel AuthenticateUser(UserModel user)
        {
            UserModel loginUser = null;
            //validate the credential
            //Retrieve datea from db
            if (user.UserName == "Ganesh")
            {
                loginUser = new UserModel
                {
                    UserName = "Ganesh",
                    EmailId = "ganesh@gmail.com",
                    DateOfJoining = new DateTime(2020, 12, 10),
                    Role = "Administrator"

                };
            }
            return loginUser;
        }

        //5.Generate jwt token
        private string GenerateJWToken(UserModel loginUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //securitykey


            //sigiin credential

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //claims
            //token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credential

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        }
    }
