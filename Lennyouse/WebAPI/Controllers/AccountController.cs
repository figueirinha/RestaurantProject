using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Recodme.RD.Lennyouse.Data.UserInfo;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult<string> Login()
        {
            var mockUser = new IdentityUser();
            mockUser.Email = "m.figueirinha@recodme.pt";
            mockUser.PasswordHash = "asdfghjklç";
            return GenerateJsonWebToken(mockUser);
        }

        private string GenerateJsonWebToken(IdentityUser user)
        {
            var jwtKey = _config["Jwt:Key"];
            var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
            var key = new SymmetricSecurityKey(keyBytes);

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var issuer = _config["Jwt:Issuer"];
            var audience = _config["jwt:Audience"];

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email)
            };

            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}