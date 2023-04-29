using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Repos.Section;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Ataal.DAL.Repos.problem
{
    public class ProblemRepo:IProblemRepo
    {
        private readonly AtaalContext _ataalContext;
        private readonly ISectionRepo _sectionRepo;
        public ProblemRepo(AtaalContext ataalContext, ISectionRepo sectionRepo)
        {
            _ataalContext = ataalContext;
            _sectionRepo = sectionRepo;
        }
        public Problem? GetProblemById(int ProblemId)
        {
            return _ataalContext.Problems.Include(P=>P.KeyWord).Include(p=>p.Customer).FirstOrDefault(p=>p.Problem_ID== ProblemId);    
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
                                                            ).OrderByDescending(S=>S.VIP==true)
                                                            .Skip(3 * (pageNumber - 1)).Take(3).ToList();
            }
            else if (Technical == null)
                return null;
            return _ataalContext.Set<Problem>().Include(p => p.KeyWord)
                                            .Where(P => P.Section_ID == SectionId && P.Solved == false)
                                            .OrderByDescending(S => S.VIP == true)
                                            .Skip(3 * (pageNumber - 1)).Take(3).ToList();
        }
        public List<Problem>? GetAllProblemsForCustomersSection(int SectionId, int pageNumber)
        {
            var section = _sectionRepo.GetSectionById(SectionId);
            if (section == null)
            {
                return null;
            }
            return _ataalContext.Set<Problem>().Include(p => p.KeyWord).Where(P =>
                                                           P.Section_ID == SectionId
                                                           && P.Solved == false
                                                           )
                                                          .Skip(3 * (pageNumber - 1)).Take(3).ToList();


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
        public int ProblemisVIP(int ProblemId)
        {
            var problem = GetProblemById(ProblemId);
            if (problem == null)
                return 0;
            problem.VIP = true;
            return SaveChanges();
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

        public List<Problem> GetAllSolvedProblems(int TechnicalId)
        {
             var AllProblemsForSpecificTechnical = _ataalContext.Problems.Where(p => p.Technical_ID == TechnicalId);

             if (AllProblemsForSpecificTechnical == null) return null;

             return AllProblemsForSpecificTechnical.ToList();
        }

        public List<Problem> get_All_Problems_forTechincal(int SectionId,int TechnicalId)
        {
            Technical technical = _ataalContext.Technicals
                .Include(T=>T.Blocked_Customers_Id)?.FirstOrDefault(T=>T.Id == TechnicalId) ?? null!;    //I will replace 1 with that come from identity      

            var Blocked_Customers_ID = technical?.Blocked_Customers_Id?.Select(C=>C.Id).ToList() ?? new List<int>();

            return _ataalContext.Problems.Include(P=>P.KeyWord)
                .Where(p =>  !(Blocked_Customers_ID.Contains(p.Customer_ID)) && p.Section_ID==SectionId && p.Solved==false ).ToList();
        }
    }
}
