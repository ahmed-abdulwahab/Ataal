using Ataal.BL.DTO.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ataal.BL.DtO.Identity
{
    public record RegisterAdminDto
    {
        public string AppUserId { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
         public string Password { get; set; }

        public AppUserDto AppUser { get; set; }

    }
      
}
