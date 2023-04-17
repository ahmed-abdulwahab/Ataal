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
        public List<Problem>? GetAllProblems(int TechnicalID, int SectionId, int pageNumber);

    }
}
