using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ataal.DAL.Repos.customer
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly AtaalContext _ataalContext;
        public CustomerRepo(AtaalContext ataalContext)
        {
            _ataalContext = ataalContext;
        }


        public Customer? GetNormalCustomerById(int CustomerId)
        {
            return _ataalContext.Customers.Include(c => c.AppUser).FirstOrDefault(c => c.Id == CustomerId);
             
        }

        public Customer? GetOffersForCustomerById(int CustomerId)
        {
            return _ataalContext.Customers.Include(c => c.AppUser)
                .Include(c => c.Problems)
                .ThenInclude(p => p.Offers).
                ThenInclude(o => o.technical).FirstOrDefault(c => c.Id == CustomerId);

        }
        public Customer? GetRecommenditionForCustomerById(int CustomerId)
        {
            return _ataalContext.Customers.Include(c => c.AppUser)
                .Include(c => c.Problems)
                .ThenInclude(p => p.Recommendations).
                ThenInclude(o=>o.Technical).FirstOrDefault(c => c.Id == CustomerId);

        }







        //   .Include(c=>c.Problems).ThenInclude(p=>p.r).ThenInclude(p=>p.Offers).ThenInclude(o=>o.technical)

        public Customer? GetCustomerWithBlockedListById(int CustomerId)
        {
            return _ataalContext.Customers.Include(c=>c.Blocked_Technicals_Id).FirstOrDefault(C=>C.Id==CustomerId);
        }

        public int? AddCustomerProblem(Problem problem)
        {
            _ataalContext.Set<Problem>().Add(problem);
            SaveChanges();
            return problem.Problem_ID;
        }
        public List<Problem> GetAllProblemsForCustomer(int CustomerId)
        {
            return _ataalContext.Problems.
                        Include(p=>p.KeyWord).
                        Where(P=>P.Customer_ID==CustomerId).ToList();
        }

        public Customer? GetAllBlockedTechnicalFromCustomer(int CustomerId)
        {
            var Customer= GetCustomerWithBlockedList(CustomerId);
             if(Customer!=null && Customer.Blocked_Technicals_Id!=null)
                return Customer;
            return null;
        }


        public async Task<Customer>? UpdateCustomerProfile(int CustomerId)
        {
            return await _ataalContext.Customers.FindAsync(CustomerId);
        }


        public Problem? GetProblemByID(int ProblemID)
        {
            var problem = _ataalContext.Set<Problem>().FirstOrDefault(P => P.Problem_ID == ProblemID);
            if (problem != null)
            {
                return problem;
            }
            return null;
        }

       
        public int? UpdateCustomerProblem(Problem problem)
        {
          var UpdatedProblem=  GetProblemByID(problem.Problem_ID);
            UpdatedProblem.Problem_Title = problem.Problem_Title;
            UpdatedProblem.Description = problem.Description;
            UpdatedProblem.Section_ID = problem.Section_ID;
            UpdatedProblem.KeyWord_ID=problem.KeyWord_ID;
            UpdatedProblem.PhotoPath1 = problem.PhotoPath1;
            UpdatedProblem.PhotoPath2 = problem.PhotoPath2;
            UpdatedProblem.PhotoPath3 = problem.PhotoPath3;
            UpdatedProblem.PhotoPath4 = problem.PhotoPath4;

            SaveChanges();
            return problem.Problem_ID;
        }
      
        public Customer? GetCustomerWithBlockedList(int CustomerId)
        {
            return _ataalContext.Customers.
                        Include(C => C.Blocked_Technicals_Id).
                        FirstOrDefault(c => c.Id == CustomerId);
            
        }
        public Technical? GetTechnicalWithBlockedList(int TechnicalId)
        {
            return _ataalContext.Technicals.
                        Include(C => C.Blocked_Customers_Id).
                        FirstOrDefault(c => c.Id == TechnicalId);

        }


        public int DeleteProblem(int ProblemID)
        {
            var problem = GetProblemByID(ProblemID);

            if (problem != null)
            {
                _ataalContext.Set<Problem>().Remove(problem);
                return SaveChanges();
            }

            return 0;
        }
        public int AddTechnicalRate(Rate rate)
        {
            var techID = rate.Technical_ID;
            var custID = rate.Customer_ID;
            var rate2 = _ataalContext.Set<Rate>().FirstOrDefault(r => r.Customer_ID == custID && r.Technical_ID == techID);
            if (rate2 != null)
                rate2.Rate_Value = rate.Rate_Value;
            else
                _ataalContext.Set<Rate>().Add(rate);

            return SaveChanges();
        }
        public Technical? GetTechnicalById(int TechnicalId)
        {
            return _ataalContext.Technicals.FirstOrDefault(t => t.Id == TechnicalId);
        }
        public int ModifyingTchnicalRate(int TechnicalID)
        {
            var Technical = GetTechnicalById(TechnicalID);
            if (Technical != null)
            {
                if (Technical.CustomersRate != null)
                {
                    var average = Technical.CustomersRate.Select(r => r.Rate_Value).Average();
                    if (average % 10 > 0.5)
                    {
                        Technical.Rate = (int)++average;
                    }
                    else
                    {
                        Technical.Rate = (int)average;
                    }


                    return SaveChanges();
                }

            }
            return 0;

        }
        public int AddTechnicalReview(Review Review)
        {
            _ataalContext.Reviews.Add(Review);
            return SaveChanges();
        }
        public int? DeleteReview(int ReviewId)
        {
            var review = _ataalContext.Set<Review>().FirstOrDefault(r => r.ID == ReviewId);
            if (review == null) { return null; }
            _ataalContext.Set<Review>().Remove(review);
            return SaveChanges();


        }
       

        public int? UpdateReview(int id,string Desc)
        {
            var Updatedreview = _ataalContext.Set<Review>().FirstOrDefault(r => r.ID == id);
            if (Updatedreview == null) { return null; }

            Updatedreview.Description = Desc;
             Updatedreview.date = DateTime.Now;
            return SaveChanges();


        }
        public int? BlockTechnical(Customer customer,Technical technical)
        {


            //var CustomerWithBlockedList = GetCustomerWithBlockedList(CustomerId);
            if (customer.Blocked_Technicals_Id != null)
            {
                customer.Blocked_Technicals_Id.Add(technical);
                return SaveChanges();
            }


            //}

            return 0;
        }

        public int? UnBlockTechnical(Customer customer, Technical technical)
        {
            if (customer.Blocked_Technicals_Id != null)
            {
                customer.Blocked_Technicals_Id.Remove(technical);
                return SaveChanges();
            }

            return 0;
        }
        public int? BlockCustomer(Customer customer, Technical technical)
        {


            //var CustomerWithBlockedList = GetCustomerWithBlockedList(CustomerId);
            if (technical.Blocked_Customers_Id != null)
            {
                technical.Blocked_Customers_Id.Add(customer);
                return SaveChanges();
            }


            //}

            return 0;
        }

        public int? UnBlockCustomer(Customer customer, Technical technical)
        {
            if (technical.Blocked_Customers_Id != null)
            {
                technical.Blocked_Customers_Id.Remove(customer);
                return SaveChanges();
            }

            return 0;
        }


        public int SaveChanges()
        {
            return _ataalContext.SaveChanges();
        }

        public Customer CreateCustomer(Customer customer)
        {
            try
            {
                _ataalContext.Customers.Add(customer);
                _ataalContext.SaveChanges();
                return customer;
            }
            catch
            {
                return null!;
            }
        }

        public int assignCustomerPayemntId(int CustomerId, string PayemntId)
        {
            
            var customer = GetNormalCustomerById(CustomerId);
            if (customer == null)
                return 0;

            customer.CreatedPayemntId= PayemntId;
            return _ataalContext.SaveChanges();
        }
        public int GetNotificationCount(int CustomerId)
        {
            return _ataalContext.Customers.FirstOrDefault(c => c.Id == CustomerId).NotificationCounter;
        }
    }
}
