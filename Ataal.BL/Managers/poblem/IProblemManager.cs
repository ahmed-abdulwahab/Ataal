using Ataal.BL.DTO.problem;
using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.problem
{
    public interface IProblemManager
    {
        public List<ProblemReturnDto>? GetProblemsForTechnical(int TechnicalID);
    }
}
