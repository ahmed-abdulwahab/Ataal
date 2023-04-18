﻿using Ataal.BL.DTO.recommendation;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Data.Repos.Technical_Repo;
using Ataal.DAL.Repos.customer;
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

        public RecommendationManager(IRecommendationRepo recommendationRepo,
                                    ITechnicalRepo technicalRepo,
                                    ICustomerRepo customerRepo)
        {
            _recommendationRepo = recommendationRepo;
            _technicalRepo= technicalRepo;
            _customerRepo = customerRepo;
        }
        public int AddRecommendation(AddRecommendationDto Dto)
        {
            var Technical = _technicalRepo.getNormalTechnicalById(Dto.TechnicalId);
            var Customer = _customerRepo.GetNormalCustomerById(Dto.CustomerId);
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
            Customer.NotificationCounter = Customer.NotificationCounter + 1;
            return _recommendationRepo.AddRecommendationForCustomer(Recommendation);
        }
    }
}
