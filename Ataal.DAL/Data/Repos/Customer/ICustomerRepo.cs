using Ataal.DAL.Data.Models;
using Ataal.DAL.Data.Repos.Customer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Repos
{
    public interface ICustomerRepo
    {
        public int? AddCustomerProblem(Problem problem);
        public Problem? GetProblemByID(int ProblemID);
        public int DeleteProblem(int ProblemID);
        public int AddTechnicalRate(Rate rate);
        public int ModifyingTchnicalRate(int TechnicalID);//int Technical Repository
        public Technical? GetTechnicalById(int TechnicalId);

        public Models.Customer CreateCustomer(Models.Customer customer);

        public int SaveChanges();
    }
}
