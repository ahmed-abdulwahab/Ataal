using System;
using Ataal.BL.DTO.stripe;
using Ataal.BL.Managers.problem;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Data.Repos.Technical_Repo;
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
        private readonly ITechnicalRepo technicalRepo;
        private readonly IProblemManager _problemManager;

        public StripeAppService(
            ChargeService chargeService,
            CustomerService customerService,
            IProblemManager problemManager,
            ICustomerRepo customerRepo,
            TokenService tokenService,
            ITechnicalRepo technicalRepo
            )
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _customerRepo = customerRepo;
            _problemManager = problemManager;
            _tokenService = tokenService;
            this.technicalRepo = technicalRepo;
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










        public async Task<bool> AddStripePayment_Technical_Async(StripePayment payment_State, CancellationToken ct)
        {
            try
            {
                var technical = technicalRepo.getTechnicalByID(payment_State.customerId);
                TokenCreateOptions tokenOptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Name = technical.Frist_Name,
                        Number = payment_State.CardNumber,
                        ExpYear = payment_State.ExpirationYear,
                        ExpMonth = payment_State.ExpirationMonth,
                        Cvc = payment_State.Cvc
                    }
                };

                // Create new Stripe Token
                Token stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);

                // Set Customer options using
                CustomerCreateOptions customerOptions = new CustomerCreateOptions
                {
                    Name = $"{technical.Frist_Name} {technical.Last_Name}",
                    Source = stripeToken.Id,
                };

                // Create Tecnical at Stripe
                var createdCustomer = await _customerService.CreateAsync(customerOptions, null, ct);

                //_customerRepo.assignCustomerPayemntId(payment_State.customerId, createdCustomer.Id);


                //var customertest = _customerRepo.GetNormalCustomerById(payment_State.customerId);

                ChargeCreateOptions paymentOptions = new ChargeCreateOptions
                {
                    Customer = createdCustomer.Id,
                    Currency = "USD",
                    Amount = payment_State.price * 100
                };

                // Create the payment
                await _chargeService.CreateAsync(paymentOptions, null, ct);
                if (technical.Points == null)
                    technical.Points = 0;
                technical.Points += (payment_State.price * 10);
                technicalRepo.saveChanges();
                return true;
            }
            catch
            {
                return false;
            }

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

