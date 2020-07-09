using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public string GetToken()
        {
            //3+2
            SecurityToken securityToken = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes("laozhanglaozhanglaozhanglaozhanglaozhang")),
                    SecurityAlgorithms.HmacSha256),
                issuer: "issure",
                audience: "audience",

                expires: DateAndTime.Now.AddHours(1),

                //授权策略
                claims: new Claim[] {
                new Claim(ClaimTypes.Role,"Admin")
                }
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
