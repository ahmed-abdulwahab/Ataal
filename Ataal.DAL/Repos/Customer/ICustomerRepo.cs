using Ataal.DAL.Data.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ataal.DAL.Repos.Customer
{
	public interface ICustomerRepo
    {
        public int? AddCustomerProblem(Problem problem);
        public Problem? GetProblemByID(int ProblemID);
        public int DeleteProblem(int ProblemID);
        public int AddTechnicalRate(Rate rate);
        public int ModifyingTchnicalRate(int TechnicalID);//int Technical Repository
        public Technical? GetTechnicalById(int TechnicalId);

        public int AddTechnicalReview(Review Review);
        public int? DeleteReview(int ReviewId);

        public int? UpdateReview(int id, string Desc);
        public int SaveChanges();
    }
}
