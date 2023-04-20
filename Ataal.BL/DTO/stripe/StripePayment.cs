using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.stripe
{
    public record StripePayment(
        int customerId,
        int problemId,
        string CardNumber,
        string ExpirationYear,
        string ExpirationMonth,
        string Cvc
        );

}
