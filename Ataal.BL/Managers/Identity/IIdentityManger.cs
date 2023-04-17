using Ataal.BL.DTO.Identity;
using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.Identity
{
    public interface IIdentityManger
    {

       public  Task<AppUser> CheckUserName(string name);
       public  Task<bool> CheckPassword(AppUser user, string password);
        public Task<IList<Claim>> GetClaims(AppUser user);
        public Task<string> GetToken(IList<Claim> claimsList);
        public Task<IdentityResult> CreateUser(AppUserDto user, string password);

        public Task<IdentityResult> AddClaims(AppUserDto user, List<Claim> claims);


    }
}
