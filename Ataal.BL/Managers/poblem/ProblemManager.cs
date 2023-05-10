using Ataal.BL.DTO.Customer;
using Ataal.BL.DTO.problem;
using Ataal.BL.DTO.Review;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Data.Repos.Technical_Repo;
using Ataal.DAL.Repos.customer;
using Ataal.DAL.Repos.problem;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ataal.BL.Managers.problem
{
    public class ProblemManager: IProblemManager
    {
        private readonly IProblemRepo _problemRepo;
        private readonly ITechnicalRepo _technicalRepo;
        private readonly ICustomerRepo customerRepo;

        public ProblemManager(IProblemRepo problemRepo, ITechnicalRepo technicalRepo, ICustomerRepo customerRepo)
        {
            _problemRepo= problemRepo;
            _technicalRepo= technicalRepo;
            this.customerRepo = customerRepo;
        }
        public List<ProblemReturnDto>? GetProblemsForTechnical(GetProblemsPagingDto GetProblemsPaging)
        {

            var ProblemList = _problemRepo.GetAllProblems(GetProblemsPaging.TechnicalId, GetProblemsPaging.SectonId, GetProblemsPaging.PageNumber);
            if (ProblemList != null)
            {
                var problems = ProblemList.Select(P =>
                              new ProblemReturnDto(
                                  id:P.Problem_ID,
                                  CustomerName: $"{P.Customer.Frist_Name} {P.Customer.Last_Name}",
                                  TechnicanName: P.Technical?.Frist_Name + "" + P.Technical?.Last_Name,
                                  TechId:P.Technical_ID,
                                  Title: P.Problem_Title,
                                                    Description: P.Description,
                                                    Date:P.dateTime,
                                                    IsSolved: P.Solved,
                                                    IsVIP: P.VIP,
                                                    Section_id:P.Section.Section_ID,
                                                    Key_WordId: P.KeyWord?.KeyWord_ID,
                                                    Key_Word: P.KeyWord?.KeyWord_Name,
                                                    CustomerPhoto:P.Customer.Photo,
                                                    PhotoPath1: P.PhotoPath1,
                                                    PhotoPath2: P.PhotoPath2,
                                                    PhotoPath3: P.PhotoPath3,
                                                    PhotoPath4: P.PhotoPath4,
                                                    AcceptedOfferID: null,
                                                    AcceptDate : null,
                                                    OfferID:null)).ToList();
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
                                                   CustomerName:$"{P.Customer.Frist_Name} {P.Customer.Last_Name}",
                                                   TechnicanName: P.Technical?.Frist_Name + "" + P.Technical?.Last_Name,
                                                   TechId:P.Technical_ID,
                                                   Title: P.Problem_Title,
                                                    Description: P.Description,
                                                    Date:P.dateTime,
                                                    IsSolved:P.Solved,
                                                    IsVIP:P.VIP,
                                                    Section_id: P.Section.Section_ID,
                                                    Key_WordId:P.KeyWord?.KeyWord_ID,
                                                    Key_Word: P.KeyWord?.KeyWord_Name,
                                                    CustomerPhoto:P.Customer.Photo,
                                                    PhotoPath1: P.PhotoPath1,
                                                    PhotoPath2: P.PhotoPath2,
                                                    PhotoPath3: P.PhotoPath3,
                                                    PhotoPath4: P.PhotoPath4,
                                                    AcceptedOfferID:null,
                                                    AcceptDate: null,
                                                    OfferID:null
                );
            return ProblemReturnDto;
           
        }

        public int? CustomerAcceptedOffer(CustomerAcceptedProblemOfferDto CAPDto)
        {
            var technical = _technicalRepo.getNormalTechnicalById(CAPDto.TechnicalId);
            if (technical != null)
            {
                return _problemRepo.CustomerAcceptedProblem_Offer(CAPDto.TechnicalId, CAPDto.ProblemId, CAPDto.OfferId);
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

        public List<ProblemReturnDto> GetAllSolvedProblems(int TechnicalId)
        {
            var AllSolvedProblems = _problemRepo.GetAllSolvedProblems(TechnicalId);

            if (AllSolvedProblems == null) return null;

            return AllSolvedProblems.Select(P => new ProblemReturnDto(
                        id: P.Problem_ID,
                        CustomerName: $"{P.Customer.Frist_Name} {P.Customer.Last_Name}",
                         TechnicanName: P.Technical?.Frist_Name +""+ P.Technical?.Last_Name,
                        TechId:P.Technical_ID,
                        Title: P.Problem_Title,
                        Description: P.Description,
                        IsSolved: P.Solved,   
                        Date:P.dateTime,
                        IsVIP: P.VIP,
                        Key_WordId:P.KeyWord?.KeyWord_ID ?? -1,
                        Section_id: P.Section?.Section_ID ?? -1,
                        Key_Word: P.KeyWord?.KeyWord_Name ?? "error",
                        CustomerPhoto:P.Customer.Photo,
                        PhotoPath1: P.PhotoPath1 ?? "error",
                        PhotoPath2: P.PhotoPath2 ?? "error" ,
                        PhotoPath3: P.PhotoPath3 ?? "error",
                        PhotoPath4: P.PhotoPath4 ?? "error",
                        AcceptedOfferID: null,
                        AcceptDate: null,
                        OfferID:null

                )).ToList();
        }

        public List<ProblemInfoForTechnical> Search(string query, int TechnicalId)
        {
            var allProblemsThatAppearedInSearch = _problemRepo.get_All_Problems_for_Search(query, TechnicalId);

            return allProblemsThatAppearedInSearch.Select(P => new ProblemInfoForTechnical(
                     id: P.Problem_ID,
                    Title: P.Problem_Title,
                    Date: P.dateTime,
                    Description: P.Description,
                    IsVIP: P.VIP,
                    Key_Word: P.KeyWord?.KeyWord_Name
                )).ToList();
        }

        public List<ProblemInfoForTechnical> ProblemInfoForTechnical(int SectionID, int TechnicalId)
        {
            try
            {
                var allProblems = _problemRepo.get_All_Problems_forTechincal(SectionID, TechnicalId);

                var all_Problems_info_DTO = allProblems.Select(P => new ProblemInfoForTechnical
                (
                    id: P.Problem_ID,
                    Title: P.Problem_Title,
                    Date: P.dateTime,
                    Description: P.Description,
                    IsVIP: P.VIP,
                    Key_Word: P.KeyWord?.KeyWord_Name
                )).ToList();

                return all_Problems_info_DTO;
            }
            catch
            {
                return null!;
            }

        }

        public Sidebar_Customer GetCoustomerByProblemID(int ProblemId)
        {
            Problem problem = _problemRepo.GetProblemById(ProblemId)!;
            var coustomer = customerRepo.GetNormalCustomerById(problem.Customer_ID);

            var customerSideBarDto = new Sidebar_Customer
            (
                                       id: coustomer!.Id,
                                       firstName: coustomer.Frist_Name,
                                       lastName: coustomer.Last_Name,
                                       Photo: coustomer.Photo,
                                       address: coustomer.Address!,

                                       numOfProblems: coustomer.Problems!.Count()

                                 

            ); ;
            return customerSideBarDto;
        }

        public List<ProblemInfoForTechnical> ProblemInfoForTechnical(int TechnicalId)
        {
            try
            {
                var allProblems = _problemRepo.get_All_Problems_forTechincal(TechnicalId);

                var all_Problems_info_DTO = allProblems.Select(P => new ProblemInfoForTechnical
                (
                    id: P.Problem_ID,
                    Title: P.Problem_Title,
                    Date: P.dateTime,
                    Description: P.Description,
                    IsVIP: P.VIP,
                    Key_Word: P.KeyWord?.KeyWord_Name
                )).ToList();

                return all_Problems_info_DTO;
            }
            catch
            {
                return null!;
            }

        }


        public List<Problem>? GetAllProblems()
        {
            var ProblemList = _problemRepo.GetAllProblems();
            if (ProblemList == null)
                return null;
            else
                return ProblemList;
        }



        public List<ProblemReturnDto> GetAllofferdProblems(int TechnicalId)
        {
            //var AllSolvedProblems = _problemRepo.GetAllofferdProblems(TechnicalId);

            var allOffers = _problemRepo.GetAllofferdProblems(TechnicalId);

            if (allOffers == null) return null;

            return allOffers.Select(o => new ProblemReturnDto(
                        id: o.problem.Problem_ID,
                         TechnicanName: o.problem.Technical?.Frist_Name + "" + o.problem.Technical?.Last_Name,
                        TechId: o.problem.Technical_ID,
                        Title: o.problem.Problem_Title,
                        Description: o.problem.Description,
                        IsSolved: o.problem.Solved,
                        Date: o.problem.dateTime,
                        IsVIP: o.problem.VIP,
                        Key_WordId: o.problem.KeyWord?.KeyWord_ID ?? -1,
                        Section_id: o.problem.Section?.Section_ID ?? -1,
                        Key_Word: o.problem.KeyWord?.KeyWord_Name ?? "error",
                        PhotoPath1: o.problem.PhotoPath1 ?? "error",
                        PhotoPath2: o.problem.PhotoPath2 ?? "error",
                        PhotoPath3: o.problem.PhotoPath3 ?? "error",
                        PhotoPath4: o.problem.PhotoPath4 ?? "error",
                        AcceptedOfferID : o.problem.AcceptedOfferID,
                        AcceptDate: o.AcceptedDate,
                        OfferID:o.Id

                )).OrderByDescending(p => p.AcceptDate).ToList();

        }

    }
}
