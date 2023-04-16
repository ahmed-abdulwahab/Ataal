using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int SaveChanges()
        {
            return _ataalContext.SaveChanges();
        }
    }
}
