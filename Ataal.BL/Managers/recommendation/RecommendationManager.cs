using Ataal.BL.DTO.recommendation;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Data.Repos.Technical_Repo;
using Ataal.DAL.Repos.customer;
using Ataal.DAL.Repos.problem;
using Ataal.DAL.Repos.recommendation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.recommendation
{
    public class RecommendationManager: IRecommendationManager
    {
        private readonly IRecommendationRepo _recommendationRepo;
        private readonly ITechnicalRepo _technicalRepo;
        private readonly ICustomerRepo _customerRepo;
        //private readonly ICustomerRepo _problemRebp;
        private readonly IProblemRepo _problemRepo;

        public RecommendationManager(IRecommendationRepo recommendationRepo,
                                    ITechnicalRepo technicalRepo,
                                    ICustomerRepo customerRepo,
                                    IProblemRepo problemRepo
            )
        {
            _recommendationRepo = recommendationRepo;
            _technicalRepo= technicalRepo;
            _customerRepo = customerRepo;
            _problemRepo = problemRepo;
        }
        public int AddRecommendation(AddRecommendationDto Dto)
        {
            var Technical = _technicalRepo.getNormalTechnicalById(Dto.TechnicalId);
            var Customer = _customerRepo.GetNormalCustomerById(Dto.CustomerId);
            var Customer_Problem = _problemRepo.GetProblemById(Dto.ProblemId);
            var Recommendations = _recommendationRepo.GetAllRecommendations();
            foreach(var Reco in Recommendations)
            {
                if ((Reco.Customer_ID == Dto.CustomerId) && (Reco.Problem_ID == Dto.ProblemId))
                    return -1;
            }
            //var RecommendationsCustomerIDs = Recommendations.Select(R => R.Customer_ID).ToList();
            //var RecommendationsProblemIDs=Recommendations.Select(R=>R.Problem_ID).ToList();
            //if (RecommendationsCustomerIDs.Contains(Dto.CustomerId) && RecommendationsProblemIDs.Contains(Dto.ProblemId))
                //return 0;
            if (Technical == null || Customer == null)
                return 0;
            
            var Recommendation = new Recommendation
            {
                Customer_ID = Dto.CustomerId,
                Technical_ID = Dto.TechnicalId,
                Problem_ID = Dto.ProblemId,
                Date = DateTime.Now
            };
            Technical.NotificationCounter = Technical.NotificationCounter + 1;
            Customer_Problem.Customer.NotificationCounter = Customer_Problem.Customer.NotificationCounter + 1;
            return _recommendationRepo.AddRecommendationForCustomer(Recommendation);
        }
        public List<ReturnRecommendationDto>? GetAllRecommendations()
        {
            var RecommendationsList = _recommendationRepo.GetAllRecommendations();
            var Recommendations = RecommendationsList.Select(R =>
                                new ReturnRecommendationDto(
                                    DateTime: R.Date,
                                    CustomerId: R.Customer_ID,
                                    TechnicalId: R.Technical_ID,
                                    ProblemId: R.Problem_ID)).ToList();
            if (Recommendations == null)
                return null;
            return Recommendations;
        }
    }
}
