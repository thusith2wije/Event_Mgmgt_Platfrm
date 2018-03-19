using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TIQRI.EMP.WebAPI.Models;
using TIQRI.EMP.WebAPI.Models.AppSettings;
using TIQRI.EMP.ApplicationCore.Interfaces;
using TIQRI.EMP.ApplicationCore.Entities;

namespace TIQRI.EMP.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        public UserController(IOptions<AppSettings> appSettings, IUserService userService, IUserRepository userRepository)
        {
            _appSettings = appSettings.Value;
            _userService = userService;
            _userRepository = userRepository;
        }
        
        [HttpPost("register")]
        public IActionResult Post([FromBody]LoginUserModel loginUserModel)
        {
            try
            {
                if (loginUserModel != null)
                {
                    var user = new User
                    {
                        CreatedBy = loginUserModel.UserName,
                        UserName = loginUserModel.UserName,
                        Password = loginUserModel.Password,
                        FirstName = loginUserModel.FirstName,
                        LastName = loginUserModel.LastName,
                        Email = loginUserModel.Email,
                        CreatedDate = DateTime.Now
                    };

                    _userRepository.Add(user);
                }
            }
            catch (Exception ex)
            {
            }

            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginUserModel loginUserModel)
        {
            var user = _userService.Authenticate(loginUserModel.UserName, loginUserModel.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, loginUserModel.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            //var userClaims = await _userManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, loginUserModel.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64));
            //claims.AddRange(user.Claims.ToArray());
            //foreach (var x in userClaims)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, x));
            //}

            var jwt = new JwtSecurityToken(
                claims: claims);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);


            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Username = loginUserModel.UserName,
                Token = tokenString
            });

            // Bearer Token 
        }
    }
}           