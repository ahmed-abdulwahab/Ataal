using Ataal.BL.DTO.problem;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Repos.problem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.problem
{
    public class ProblemManager: IProblemManager
    {
        private readonly IProblemRepo _problemRepo;
        public ProblemManager(IProblemRepo problemRepo)
        {
            _problemRepo= problemRepo;
        }
        public List<ProblemReturnDto>? GetProblemsForTechnical(GetProblemsPagingDto GetProblemsPaging)
        {

            var ProblemList = _problemRepo.GetAllProblems(GetProblemsPaging.TechnicalId, GetProblemsPaging.SectonId, GetProblemsPaging.PageNumber);
            if (ProblemList != null)
            {
                var problems = ProblemList.Select(P =>
                              new ProblemReturnDto(Title: P.Problem_Title,
                                                    Description: P.Description,
                                                    Key_Word: P.KeyWord?.KeyWord_Name,
                                                    PhotoPath1: P.PhotoPath1,
                                                    PhotoPath2: P.PhotoPath2,
                                                    PhotoPath3: P.PhotoPath3,
                                                    PhotoPath4: P.PhotoPath4)).ToList();
                return problems;
            }
            return null;

        }
    }
}
