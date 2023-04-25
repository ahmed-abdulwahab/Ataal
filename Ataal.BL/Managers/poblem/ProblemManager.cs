using Ataal.BL.DTO.problem;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Data.Repos.Technical_Repo;
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
        private readonly ITechnicalRepo _technicalRepo;
        public ProblemManager(IProblemRepo problemRepo, ITechnicalRepo technicalRepo)
        {
            _problemRepo= problemRepo;
            _technicalRepo= technicalRepo;
        }
        public List<ProblemReturnDto>? GetProblemsForTechnical(GetProblemsPagingDto GetProblemsPaging)
        {

            var ProblemList = _problemRepo.GetAllProblems(GetProblemsPaging.TechnicalId, GetProblemsPaging.SectonId, GetProblemsPaging.PageNumber);
            if (ProblemList != null)
            {
                var problems = ProblemList.Select(P =>
                              new ProblemReturnDto(
                                  id:P.Problem_ID,
                                  Title: P.Problem_Title,
                                                    Description: P.Description,
                                                    Date:P.dateTime,
                                                    IsSolved: P.Solved,
                                                    IsVIP: P.VIP,
                                                    Key_Word: P.KeyWord?.KeyWord_Name,
                                                    PhotoPath1: P.PhotoPath1,
                                                    PhotoPath2: P.PhotoPath2,
                                                    PhotoPath3: P.PhotoPath3,
                                                    PhotoPath4: P.PhotoPath4)).ToList();
                return problems;
            }
            return null;

        }
        public List<ReturnProblemsBySectionIdandPageNumberDto>? GetProblemsForTechnical(GetProblemForCustomersSectionsParametersDto Dto)
        {
            var ProblemList = _problemRepo.GetAllProblemsForCustomersSection(Dto.SectonId,Dto.PageNumber);
            if (ProblemList != null)
            {
                var problems = ProblemList.Select(P =>
                              new ReturnProblemsBySectionIdandPageNumberDto(Title: P.Problem_Title,
                                                    Description: P.Description,
                                                    Date:P.dateTime,
                                                    Key_Word: P.KeyWord?.KeyWord_Name,
                                                    PhotoPath1: P.PhotoPath1,
                                                    PhotoPath2: P.PhotoPath2,
                                                    PhotoPath3: P.PhotoPath3,
                                                    PhotoPath4: P.PhotoPath4)).ToList();
                return problems;
            }
            return null;
        }
        public ProblemReturnDto? GetProblemById(int ProblemId)
        {
           var P= _problemRepo.GetProblemById(ProblemId);
            if (P == null)
                return null;
            var ProblemReturnDto = new ProblemReturnDto
                 (
                                                   id:P.Problem_ID,
                                                   Title: P.Problem_Title,
                                                    Description: P.Description,
                                                    Date:P.dateTime,
                                                    IsSolved:P.Solved,
                                                    IsVIP:P.VIP,
                                                    Key_Word: P.KeyWord?.KeyWord_Name,
                                                    PhotoPath1: P.PhotoPath1,
                                                    PhotoPath2: P.PhotoPath2,
                                                    PhotoPath3: P.PhotoPath3,
                                                    PhotoPath4: P.PhotoPath4
                );
            return ProblemReturnDto;
           
        }

        public int CustomerAcceptedOffer(CustomerAcceptedProblemOfferDto CAPDto)
        {
            var technical = _technicalRepo.getNormalTechnicalById(CAPDto.TechnicalId);
            if (technical != null)
            {
                technical.NotificationCounter=technical.NotificationCounter+1;
                return _problemRepo.CustomerAcceptedProblem_Offer(CAPDto.TechnicalId, CAPDto.ProblemId);
            }
            return 0;
        }

        public int ProblemIsSolved(int ProblemId)
        {
            var problem = _problemRepo.GetProblemById(ProblemId);
            if(problem!=null)
            {
                return _problemRepo.ProblemIsSolved(ProblemId);
                
            }
            return 0;
        }
        public int ProblemIsVIP(int ProblemId)
        {
            var problem = _problemRepo.GetProblemById(ProblemId);
            if (problem == null)
                return 0;
          return _problemRepo.ProblemisVIP(ProblemId);
            
        }
    }
}
