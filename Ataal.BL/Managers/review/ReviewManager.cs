using Ataal.BL.DTO.Review;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Repos.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.review
{
    public class ReviewManager:IReviewManager
    {
        private readonly IReviewRepo _reviewRepo;
        public ReviewManager(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }
        public List<ReviewGetDto>? GetAllReviews()
        {
            var ReviewsList=_reviewRepo.GetAllReviews();
            var Reviews = ReviewsList.Select(R =>
                                            new ReviewGetDto(
                                                CustomerId: R.Customer_ID,
                                                TechnicalId: R.Technical_ID,
                                                Description: R.Description,
                                                DateTime: R.date)).ToList();
            if (Reviews == null)
                return null;
            else
                return Reviews;

        }
        public List<ReviewGetDto>? GetReviewsByCustomerId(int customerId)
        {
            var ReviewsList = _reviewRepo.GetReviewsByCustomerId(customerId);
            var Reviews = ReviewsList.Select(R =>
                                            new ReviewGetDto(
                                                CustomerId: R.Customer_ID,
                                                TechnicalId: R.Technical_ID,
                                                Description: R.Description,
                                                DateTime: R.date)).ToList();
            if (Reviews == null)
                return null;
            else
                return Reviews;
        }
    }
}
