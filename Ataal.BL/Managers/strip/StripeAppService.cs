using System;
using Ataal.BL.DTO.stripe;
using Ataal.BL.Managers.problem;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Repos.customer;
using Stripe;
using Stripe_Payments_Web_Api.Contracts;


namespace Stripe_Payments_Web_Api.Application
{
    public class StripeAppService : IStripeAppService
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;
        private readonly IProblemManager _problemManager;

        public StripeAppService(
            ChargeService chargeService,
            CustomerService customerService,
            IProblemManager problemManager,
            ICustomerRepo customerRepo,
            TokenService tokenService)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _customerRepo = customerRepo;
            _problemManager = problemManager;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Create a new customer at Stripe through API using customer and card details from records.
        /// </summary>
        /// <param name="customer">Stripe Customer</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns>Stripe Customer</returns>



        
        public async Task<bool> AddStripePaymentAsync(StripePayment customer1, CancellationToken ct)
        {
            var customer2 = _customerRepo.GetNormalCustomerById(customer1.customerId);
            TokenCreateOptions tokenOptions = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Name = customer2.Frist_Name,
                    Number = customer1.CardNumber,
                    ExpYear = customer1.ExpirationYear,
                    ExpMonth = customer1.ExpirationMonth,
                    Cvc = customer1.Cvc
                }
            };

            // Create new Stripe Token
            Token stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);

            // Set Customer options using
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Name = $"{customer2.Frist_Name} {customer2.Last_Name}",
                Email = customer2.Email,
                Source = stripeToken.Id
            };

            // Create customer at Stripe
            var createdCustomer = await _customerService.CreateAsync(customerOptions, null, ct);
            _customerRepo.assignCustomerPayemntId(customer1.customerId, createdCustomer.Id);
            var customertest = _customerRepo.GetNormalCustomerById(customer1.customerId);
            ChargeCreateOptions paymentOptions = new ChargeCreateOptions
            {
                Customer = customertest.CreatedPayemntId,
                Currency="USD",
                ReceiptEmail= customertest.Email,
                Amount = 2000
            };

            // Create the payment
            await _chargeService.CreateAsync(paymentOptions, null, ct);
            _problemManager.ProblemIsVIP(customer1.problemId);
            return true;
        }

        

        /// <summary>
        /// Add a new payment at Stripe using Customer and Payment details.
        /// Customer has to exist at Stripe already.
        /// </summary>
        /// <param name="payment">Stripe Payment</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns><Stripe Payment/returns>

    }
}

