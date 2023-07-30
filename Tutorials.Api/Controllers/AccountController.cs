
using System.Reflection;
using Tutorials.Api.DTO;
using Microsoft.AspNetCore.Mvc;
using Tutorials.Data.Context ;
using Tutorials.Data.Entities ;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper ;
namespace Tutorials.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager  , IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO UserDto)
        {
            if (ModelState.IsValid)
            {
                // using auto mapper 
            
            var user   =  _mapper.Map<User>(UserDto);
            IdentityResult result =  await  _userManager.CreateAsync(user , UserDto.Password);
            if (result.Succeeded)
            {
                return  Ok ("Account Add Success");
            }
            else return BadRequest(result);

            }
            return BadRequest(ModelState);





        }

    }
}
