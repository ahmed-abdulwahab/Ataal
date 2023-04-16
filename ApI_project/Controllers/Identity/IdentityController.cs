using Ataal.BL;
using Ataal.BL.DtO.Identity;
using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Identity;
using Ataal.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ataal.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly AtaalContext context;

        public IdentityController(IConfiguration configuration,
            UserManager<AppUser> userManager, AtaalContext _context)
        {
            _configuration = configuration;
            _userManager = userManager;
            context = _context;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<tokenDto>> Login_Clean(LoginDto credentials)
        {

            var user = await _userManager.FindByNameAsync(credentials.UserName);
            if (user == null) { return NotFound(); }

            var isAuthenitcated = await _userManager.CheckPasswordAsync(user, credentials.Password);
            if (!isAuthenitcated) { return Unauthorized(); }


            var claimsList = await _userManager.GetClaimsAsync(user);

            var secretKeyString = _configuration.GetValue<string>("SecretKey")!;
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
            var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

            //Combination SecretKey, HashingAlgorithm
            var siginingCreedentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);

            var expiry = DateTime.Now.AddDays(20);

            //Create Token Object
            var token = new JwtSecurityToken(
                claims: claimsList,
                expires: expiry,
                signingCredentials: siginingCreedentials);

            //Convert Object Token To String
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);


            return new tokenDto(tokenString, expiry);
        }



        [HttpPost]
        [Route("AdminRegister")]
        public async Task<ActionResult> AdminRegister(RegisterDto registerDto)
        {
            var UserToAdd = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };


            var result = await _userManager.CreateAsync(UserToAdd, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var admin = new Admin
            {
                AppUserId = UserToAdd.Id,
            };

            //Try to Add Admin to Db
            //context.Admins.Add(admin);
            //context.SaveChanges();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, UserToAdd.Id),
                new Claim(ClaimTypes.Role, Constants.Roles.Admin)
            };

            await _userManager.AddClaimsAsync(UserToAdd, claims);

            return NoContent();
        }

        [HttpPost]
        [Route("TechnicalRegister")]
        public async Task<ActionResult> TechnicalRegister(RegisterDto registerDto)
        {
            var UserToAdd = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(UserToAdd, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var customer = new DAL.Data.Models.Technical
            {
                AppUserId = UserToAdd.Id,
            };
            customer.AppUser = UserToAdd;
            context.Technicals.Add(customer);
            context.SaveChanges();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, UserToAdd.Id),
                new Claim(ClaimTypes.Role, Constants.Roles.technical)
            };

            await _userManager.AddClaimsAsync(UserToAdd, claims);

            return NoContent();
        }

        [HttpPost]
        [Route("CustomerRegister")]
        public async Task<ActionResult> CustomerRegister(RegisterDto registerDto)
        {
            var UserToAdd = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(UserToAdd, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, UserToAdd.Id),
                new Claim(ClaimTypes.Role, Constants.Roles.Customer)
            };

            var customer = new Customer
            {
                AppUserId = UserToAdd.Id,
            };

            //Add Customer To DB


            await _userManager.AddClaimsAsync(UserToAdd, claims);

            return NoContent();
        }

    }
}
