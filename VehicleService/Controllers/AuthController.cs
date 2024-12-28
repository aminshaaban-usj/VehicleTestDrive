using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace VehicleServiceAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        public ActionResult Login(string username, string password)
        {
            var Myconfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            if (username == Myconfig.GetValue<string>("JWT:username") && password == Myconfig.GetValue<string>("JWT:password"))
            {
                int userid = 1;
                var token = CreateJWT(userid, username);
                return Ok(new { Status = true, Message = "success", Data = new { Token = token } });
            }
            return BadRequest();
        }

        private string CreateJWT(int userId, string username)
        {
            var Myconfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, username.ToString())
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Myconfig.GetValue<string>("JWT:key")));
            var token = new JwtSecurityToken(
                issuer: Myconfig.GetValue<string>("JWT:issuer"),
                audience: Myconfig.GetValue<string>("JWT:audience"),
                expires: DateTime.Now.AddDays(1),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
