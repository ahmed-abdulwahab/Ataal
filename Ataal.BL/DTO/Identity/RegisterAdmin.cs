using System;
using System.Collections.Generic;
using System.Linq;

namespace Ataal.BL.DtO.Identity
{
    public record RegisterAdmin(
        string Email,
        string Password,
        string userName
        );
}
