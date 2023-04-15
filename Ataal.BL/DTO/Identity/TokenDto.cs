using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Identity
{
    public record TokenDto(string Token, DateTime Expiry);
}
