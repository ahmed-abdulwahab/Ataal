using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Repos.problem
{
    public interface IProblemRepo
    {
        public Problem? GetProblemById(int ProblemId);
        public List<Problem>? GetAllProblems(int TechnicalID, int SectionId, int pageNumber);
        public List<Problem>? GetAllProblemsForCustomersSection(int SectionId, int pageNumber);
        public int ProblemIsSolved(int ProblemId);
        public int CustomerAcceptedProblem_Offer(int TechnicalId,int ProblemId);
        public int ProblemisVIP(int ProblemId);
        
        public int SaveChanges();

    }
}
