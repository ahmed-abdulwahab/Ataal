using Ataal.BL.DtO.Identity;
using Ataal.DAL.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Identity
{
    public record RegisterUserDto
    (
        string AppUserId,
        string firstName,
        string lastName,
        string Address,
   
        AppUserDto AppUser
    );
}
