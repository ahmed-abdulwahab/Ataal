using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.stripe
{
    public record StripeCustomer(string Name,
        string Email,
        string CustomerId);
   
}
