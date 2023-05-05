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
        private readonly ILogger<StripeController> logger;

        public StripeController(IStripeAppService stripeService,ILogger<StripeController> logger)
        {
            _stripeService = stripeService;
            this.logger = logger;
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




















        [HttpPost("Subscribe")]
        public async Task<IActionResult> AddStripeTechnical(
    [FromBody] StripePayment stripePayment,
    CancellationToken ct)
        {

            var payment_State = await _stripeService.AddStripePayment_Technical_Async(stripePayment,
                ct);
            logger.LogInformation(payment_State.ToString());
            if (payment_State == true)
                return NoContent();
            else
                return BadRequest();
        }



    }
}

