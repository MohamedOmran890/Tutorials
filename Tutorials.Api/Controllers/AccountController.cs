
using System;
using System.Data.Common;

using System.Security.Claims;
using System.Reflection;
using Tutorial.Infstructures.DTO ;
using Microsoft.AspNetCore.Mvc;
using Tutorials.Data.Context;
using Tutorials.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using System.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

using Microsoft.IdentityModel.Tokens;



namespace Tutorials.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO UserDto)
        {
            if (ModelState.IsValid)
            {
                // using auto mapper 

                var user = _mapper.Map<User>(UserDto);
                IdentityResult result = await _userManager.CreateAsync(user, UserDto.Password);
                if (result.Succeeded)
                {
                    return Ok("Account Add Success");
                }
                else return BadRequest(result);

            }
            return BadRequest(ModelState);

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO UserDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(UserDto.UserName);
                if (user != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(user, UserDto.Password);
                    if (found)
                    {
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Name, UserDto.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) ,
                        new Claim(JwtRegisteredClaimNames.NameId, user.Id) };

                        var roles = await _userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            Claim claim = new Claim(JwtRegisteredClaimNames.Name, UserDto.UserName);
                            claims.Append(claim);
                        }
                        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));


                        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        JwtSecurityToken Token = new JwtSecurityToken(
                            issuer: _configuration["Jwt:Issuer"],
                            audience: _configuration["Jwt:Audience"],
                            claims: claims,
                            expires: DateTime.Now.AddMinutes(120),
                            signingCredentials: signingCredentials
                        );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(Token),
                            expiration = Token.ValidTo
                        });


                    }
                }
                return Unauthorized();

            }
            return Unauthorized();

        }

    }
}
