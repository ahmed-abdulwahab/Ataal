using Ataal.BL.DtO.Identity;
using Ataal.BL.DTO.Identity;
using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Identity;
using Ataal.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.Identity
{
    public class IdentityManager : IIdentityManger
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        //private readonly AtaalContext context;

        public IdentityManager(IConfiguration configuration,
            UserManager<AppUser> userManager, AtaalContext _context)
        {
            _configuration = configuration;
            _userManager = userManager;
           // context = _context;
        }

        public async Task<bool> CheckPassword(AppUser user, string password)
        {

           return await _userManager.CheckPasswordAsync(user, password);


        }

        public async Task<AppUser> CheckUserName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user == null) { return null; }


            return user;
        }

        public async Task<IdentityResult> CreateUser(AppUserDto user, string password)
        {
            var AppUser = new AppUser()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.userName,
            };

            var result = await _userManager.CreateAsync(AppUser, password);
            
            user.Id = AppUser.Id;

            return result;
        }

        public async  Task<IList<Claim>> GetClaims(AppUser user)
        {
            return await _userManager.GetClaimsAsync(user);
        }

        public async Task<string> GetToken(IList<Claim> claimsList)
        {
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

            return tokenString;
        }

        public async Task<IdentityResult> AddClaims(AppUserDto user, List<Claim> claims)
        {
            var AppUser = await _userManager.FindByIdAsync(user.Id);

            return await _userManager.AddClaimsAsync(AppUser!, claims);
        }
    } 
}
