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
        public List<Problem>? GetAllProblems(int TechnicalID)
        {
            var Technical = _ataalContext.Technicals.
                    Include(t => t.Sections).Include(c=>c.Blocked_Customers_Id)
                    .FirstOrDefault(T => T.Id == TechnicalID);

            if (Technical != null && Technical.Blocked_Customers_Id != null)
            {
                var TechIDs = Technical.Blocked_Customers_Id.Select(C => C.Id).ToList();
                return _ataalContext.Set<Problem>().Include(p=>p.KeyWord).Where(P => !TechIDs.Contains(P.Customer_ID)
                                                            && Technical.Sections.Contains(P.Section)).ToList();
            }
            else if (Technical == null)
                return null;
            return _ataalContext.Set<Problem>().Include(p=>p.KeyWord).Where(P => Technical.Sections
                                               .Contains(P.Section)).ToList();
        }



    }
}
