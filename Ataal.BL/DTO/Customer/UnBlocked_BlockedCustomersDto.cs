using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Customer
{
    public record UnBlocked_BlockedCustomersDto
    (
        int CustomerId,
        byte[]? Photo,
        string Name

    );
}
