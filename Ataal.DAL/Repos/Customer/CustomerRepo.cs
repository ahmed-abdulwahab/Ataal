using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ataal.DAL.Repos.Customer
{
    public class CustomerRepo:ICustomerRepo
    {
        private readonly AtaalContext _ataalContext;
        public CustomerRepo(AtaalContext ataalContext)
        {
            _ataalContext = ataalContext;
        }

        public int? AddCustomerProblem(Problem problem)
        {
            _ataalContext.Set<Problem>().Add(problem);
            SaveChanges();
            return problem.Problem_ID;
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
        public int DeleteProblem(int ProblemID)
        {
            var problem = GetProblemByID(ProblemID);

            if(problem!=null)
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
            return _ataalContext.Technicals.FirstOrDefault(t=>t.Id== TechnicalId);
        }
        public int ModifyingTchnicalRate(int TechnicalID)
        {
            var Technical = GetTechnicalById(TechnicalID);
            if(Technical !=null)
            {
                if(Technical.CustomersRate!=null)
                {
                    var average = Technical.CustomersRate.Select(r => r.Rate_Value).Average();
                    if(average%10>0.5)
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


        public int SaveChanges()
        {
            return _ataalContext.SaveChanges();
        }

    }
}
