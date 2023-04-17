using Ataal.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Identity
{
    public class AppUser: IdentityUser
    {
        [RegularExpression("^01[0125][0-9]{8}$")]
        [Required]
        public override string? PhoneNumber { get; set; } 

        public Admin? Admin { get; set; }
        public Technical? Technical { get; set; }

        public Customer? Customer { get; set; }
    }
}
