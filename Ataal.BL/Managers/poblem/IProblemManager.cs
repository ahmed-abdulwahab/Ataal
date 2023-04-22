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
        public int ProblemIsVIP(int ProblemId);
        public List<ProblemReturnDto>? GetProblemsForTechnical(GetProblemsPagingDto GetProblemsPaging);
        public List<ReturnProblemsBySectionIdandPageNumberDto>? GetProblemsForTechnical(GetProblemForCustomersSectionsParametersDto Dto);

        public int ProblemIsSolved(int ProblemId);
        public ProblemReturnDto? GetProblemById(int ProblemId);

        public int CustomerAcceptedOffer(CustomerAcceptedProblemOfferDto CAPDto);
    }

}
