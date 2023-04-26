using Ataal.BL;
using Ataal.BL.DtO.Identity;
using Ataal.BL.DTO.Identity;
using Ataal.BL.Managers.Customer;
using Ataal.BL.Managers.Identity;
using Ataal.BL.Mangers.technical;
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
        private readonly IIdentityManger IdentityManger;
        private readonly ItechnicalManger ItechnicalManger;
        private readonly ICustomerManager customerManager;

        public IdentityController(IIdentityManger identityManger,
            ItechnicalManger ITechnicalManger,
            ICustomerManager customerManager)
        {
            IdentityManger = identityManger;
            ItechnicalManger = ITechnicalManger;
            this.customerManager = customerManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<tokenDto>> Login_Clean(LoginDto credentials)
        {

            var user = await IdentityManger.CheckUserName(credentials.UserName);
            if (user == null) { return NotFound(); }

            var isAuthenitcated = await IdentityManger.CheckPassword(user, credentials.Password);
            if (!isAuthenitcated) { return Unauthorized(); }

            var claimsList = await IdentityManger.GetClaims(user);

            var tokenString = await IdentityManger.GetToken(claimsList);

            return new tokenDto(tokenString);
        }

        [HttpPost]
        [Route("TechnicalRegister")]
        public async Task<ActionResult> TechnicalRegister(RegisterDto registerDto)
        {
            var UserToAdd = new AppUserDto()
            {
                userName = registerDto.userName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.phone
            };
           

            var result = await IdentityManger.CreateUser(UserToAdd, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var technical = new RegisterUserDto
            (
                AppUserId : UserToAdd.Id,
                firstName : registerDto.firstName,
                lastName : registerDto.lastName,
                Address : registerDto.Address,
                AppUser : UserToAdd
            );

           await ItechnicalManger.addTechnical(technical);
            

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, UserToAdd.Id),
                new Claim(ClaimTypes.Role, Constants.Roles.Technical)
            };

            await IdentityManger.AddClaims(UserToAdd, claims);

            return NoContent();
        }

        [HttpPost]
        [Route("CustomerRegister")]
        public async Task<ActionResult> CustomerRegister(RegisterDto registerDto)
        {


            var UserToAdd = new AppUserDto()
            {
                userName = registerDto.userName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.phone
            };


            var result = await IdentityManger.CreateUser(UserToAdd, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var technical = new RegisterUserDto
            (
                AppUserId: UserToAdd.Id,
                firstName: registerDto.firstName,
                lastName: registerDto.lastName,
                Address: registerDto.Address,
                AppUser: UserToAdd
            );

            //Add Customer
             await customerManager.CreateCustomer(technical);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, UserToAdd.Id),
                new Claim(ClaimTypes.Role, Constants.Roles.Customer)
            };

            await IdentityManger.AddClaims(UserToAdd, claims);

            return NoContent();
        }

    }
}
