using EmailSender.DataAccess.Data;
using EmailSender.DataAccess.DTOS.Account;
using EmailSender.Models;
using EmailSender.Utility;
using EmailSender.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

namespace EmailSender.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JWTService _jwtService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        public AccountController(JWTService jwtService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,ApplicationDbContext context)
        {
            _jwtService = jwtService;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }


        [Authorize]
        [HttpGet("refresh-token")]
        public async Task<ActionResult<UserDto>> RefreshToken()
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.Email)?.Value);
            return await CreateApplicationUserDto(user);
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null) return Unauthorized("Invalid username or password");

            

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized(new { error = "Invalid username or password" });

            return await CreateApplicationUserDto(user);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (await CheckEmailExistAsync(model.Email))
            {
                return BadRequest(new { error = $"An existing account is using {model.Email}, pelase try another emal address" });
            }

            var userToAdd = new ApplicationUser
            {
                Name = model.Name.ToLower(),
                UserName = model.Email.ToLower(),
                Email = model.Email.ToLower(),
                Role = model.Role,
            };


            var result = await _userManager.CreateAsync(userToAdd, model.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            ApplicationUser user = _context.ApplicationUsers.FirstOrDefault(u => u.Email == userToAdd.Email);
            if (user == null) return BadRequest();

            if (model.Role != null)
            {
                if (model.Role == WebSiteRole.Role_Analist)
                {
                    _userManager.AddToRoleAsync(user, WebSiteRole.Role_Analist).GetAwaiter().GetResult();
                }
                else
                {
                    _userManager.AddToRoleAsync(user, WebSiteRole.Role_User).GetAwaiter().GetResult();
                }
            }
            else
            {
                _userManager.AddToRoleAsync(user, WebSiteRole.Role_User).GetAwaiter().GetResult();
            }



            return Ok(new JsonResult(new { title = "Account Created", message = "Your account has created succesfully, you can login" }));

        }


        


        #region Private Helper Methods

        private async Task<UserDto> CreateApplicationUserDto(ApplicationUser applicationUser)
        {
            return new UserDto
            {
                Name = applicationUser.Name,
                JWT = await _jwtService.CreateJWT(applicationUser)
            };
        }

        private async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email.ToLower());
        }

        #endregion


    }
}
