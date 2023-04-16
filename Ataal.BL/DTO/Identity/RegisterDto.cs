using System;
using System.Collections.Generic;
using System.Linq;

namespace Ataal.BL.DtO.Identity
{
    public record RegisterDto(string UserName,
        string Email,
        string Password);
}
