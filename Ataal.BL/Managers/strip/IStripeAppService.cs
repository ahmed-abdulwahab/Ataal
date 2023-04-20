using System;
using Ataal.BL.DTO.stripe;
using Ataal.DAL.Data.Models;


namespace Stripe_Payments_Web_Api.Contracts
{
    public interface IStripeAppService
    {
        //Task <int> AddStripeCustomerAsync(int CustomerId, CancellationToken ct);
        Task<bool> AddStripePaymentAsync(StripePayment customer1, CancellationToken ct);
        
    }
}

