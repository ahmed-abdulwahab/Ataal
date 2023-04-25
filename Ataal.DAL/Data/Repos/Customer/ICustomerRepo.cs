using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Repos.customer
{
    public interface ICustomerRepo
    {
        public Customer? GetRecommenditionForCustomerById(int CustomerId);
        public Customer? GetOffersForCustomerById(int CustomerId);
        public int GetNotificationCount(int CustomerId);
        public Customer? GetNormalCustomerById(int CustomerId);
        public Customer? GetCustomerWithBlockedList(int CustomerId);
        public List<Problem> GetAllProblemsForCustomer(int CustomerId);
        public Task<Customer>? UpdateCustomerProfile(int CustomerId);
        public Customer? GetAllBlockedTechnicalFromCustomer(int CustomerId);
        public Technical? GetTechnicalWithBlockedList(int TechnicalId);
        public int? AddCustomerProblem(Problem problem);
        public Problem? GetProblemByID(int ProblemID);
        public int DeleteProblem(int ProblemID);
        public int AddTechnicalRate(Rate rate);
        public int ModifyingTchnicalRate(int TechnicalID);//int Technical Repository
        public Technical? GetTechnicalById(int TechnicalId);
        public int assignCustomerPayemntId(int CustomerId,string PayemntId);
        public Customer CreateCustomer(Customer customer);
        public int? UpdateReview(int id, string Desc);
        public int? DeleteReview(int ReviewId);
        public int AddTechnicalReview(Review Review);
        public int? UpdateCustomerProblem(Problem problem);




        public int? BlockTechnical(Customer customer, Technical technical);

        public int? UnBlockTechnical(Customer customer, Technical technical);

        public int? BlockCustomer(Customer customer, Technical technical);

        public int? UnBlockCustomer(Customer customer, Technical technical);

        public int SaveChanges();
    }
}
