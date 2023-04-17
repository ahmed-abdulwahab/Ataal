using System;
using System.Collections.Generic;
using System.Linq;

namespace Ataal.BL.DtO.Identity
{
    public record RegisterDto(
        string Email,
        string Password,
        string phone,
        string firstName,
        string lastName,
        string Address,
        string userName
        );
}
