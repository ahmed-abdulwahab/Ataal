﻿using Ataal.BL.DTO.Customer;
using Ataal.BL.DTO.problem;
using Ataal.BL.DTO.Review;
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

        public List<ProblemInfoForTechnical> ProblemInfoForTechnical(int TechnicalId);

        public List<ProblemInfoForTechnical> Search(string query, int TechnicalId);

        public int ProblemIsVIP(int ProblemId);
        public List<ProblemReturnDto>? GetProblemsForTechnical(GetProblemsPagingDto GetProblemsPaging);
        public List<ReturnProblemsBySectionIdandPageNumberDto>? GetProblemsForTechnical(GetProblemForCustomersSectionsParametersDto Dto);

        public int ProblemIsSolved(int ProblemId);
        public ProblemReturnDto? GetProblemById(int ProblemId);
        public List<ProblemReturnDto> GetAllSolvedProblems(int TechnicalId);
        public List<ProblemReturnDto> GetAllofferdProblems(int TechnicalId);

        public int?CustomerAcceptedOffer(CustomerAcceptedProblemOfferDto CAPDto);

        public List<Problem>? GetAllProblems ();
        public List<ProblemInfoForTechnical> ProblemInfoForTechnical(int SectionID, int TechnicalId);         //for technical view problems (brief)
        public Sidebar_Customer GetCoustomerByProblemID(int ProblemId);

    }

}
