using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Repos.problem
{
    public class ProblemRepo:IProblemRepo
    {
        private readonly AtaalContext _ataalContext;
        public ProblemRepo(AtaalContext ataalContext)
        {
            _ataalContext = ataalContext;
        }
        public Problem? GetProblemById(int ProblemId)
        {
            return _ataalContext.Problems.Include(P=>P.KeyWord).FirstOrDefault(p=>p.Problem_ID== ProblemId);    
        }
        public List<Problem>? GetAllProblems(int TechnicalID, int SectionId, int pageNumber)
        {
            var Technical = _ataalContext.Technicals.
                    Include(t => t.Sections).Include(c=>c.Blocked_Customers_Id)
                    .FirstOrDefault(T => T.Id == TechnicalID);

            if (Technical != null && Technical.Blocked_Customers_Id != null)
            {
                var TechIDs = Technical.Blocked_Customers_Id.Select(C => C.Id).ToList();
                return _ataalContext.Set<Problem>().Include(p => p.KeyWord).Where(P => !TechIDs.Contains(P.Customer_ID)
                                                            && P.Section_ID == SectionId
                                                            &&P.Solved==false
                                                            ).Skip(3 * (pageNumber - 1)).Take(3).ToList();
            }
            else if (Technical == null)
                return null;
            return _ataalContext.Set<Problem>().Include(p => p.KeyWord).Where(P => P.Section_ID == SectionId && P.Solved == false).Skip(3 * (pageNumber - 1)).Take(3).ToList();
        }

        public int ProblemIsSolved(int ProblemId)
        {
            var problem = GetProblemById(ProblemId);
            if(problem!=null&&problem.Solved!=true)
            {
                problem.Solved = true;
                return SaveChanges();
            }
            if (problem != null && problem.Solved == true)
            {

                return -1;
            }
            return 0;
        }

        public int CustomerAcceptedProblem_Offer(int TechnicalId, int ProblemId)
        {
            var problem = _ataalContext.Problems.FirstOrDefault(p => p.Problem_ID == ProblemId);
            problem.Technical_ID = TechnicalId;
            return SaveChanges();
        }
        public int SaveChanges()
        {
            return _ataalContext.SaveChanges();
        }

    }
}
