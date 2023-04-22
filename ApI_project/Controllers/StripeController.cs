using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ataal.BL.DTO.stripe;
using Microsoft.AspNetCore.Mvc;
using Stripe_Payments_Web_Api.Contracts;

namespace Stripe_Payments_Web_Api.Controllers
{
    [Route("api/[controller]")]
    public class StripeController : Controller
    {
        private readonly IStripeAppService _stripeService;

        public StripeController(IStripeAppService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost("payment/add")]
        public async Task<IActionResult> AddStripeCustomer(
            [FromBody] StripePayment stripePayment,
            CancellationToken ct)
        {
            var createdCustomer = await _stripeService.AddStripePaymentAsync(stripePayment,
                ct);
            if (createdCustomer == true)
                return NoContent();
            else
                return BadRequest();
        }

        
    }
}

