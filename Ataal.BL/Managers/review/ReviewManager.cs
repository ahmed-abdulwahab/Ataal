using Ataal.BL.DtO.Customer;
using Ataal.BL.DTO.Review;
using Ataal.BL.DTO.Section;
using Ataal.BL.DTO.Technical;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Repos.Reviews;
using Ataal.DAL.Repos.Section;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalDto = Ataal.BL.DTO.Review.TechnicalDto;

namespace Ataal.BL.Managers.review
{
    public class ReviewManager:IReviewManager
    {
        private readonly IReviewRepo _reviewRepo;
        public ReviewManager(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public int DeleteReview(int id)
        {
            var DeletedReview = _reviewRepo.DeleteReview(id);
            if (DeletedReview == null) return 0;
            return _reviewRepo.DeleteReview(id);
        }

        public List<ReviewGetDto>? GetAllReviews()
        {
            var ReviewsList=_reviewRepo.GetAllReviews();
            var Reviews = ReviewsList.Select(R =>
                                            new ReviewGetDto(
                                                ReviewId:R.ID,
                                                CustomerId: R.Customer_ID,
                                                TechnicalId: R.Technical_ID,
                                                Description: R.Description,
                                                DateTime: R.date)).ToList();
            if (Reviews == null)
                return null;
            else
                return Reviews;

        }

        public ReviewGetDto GetReviewbyId(int id)
        {
                var ReviewinDBbyID = _reviewRepo.GetReviewById(id);
                if (ReviewinDBbyID == null) return null;
                var ReviewDto = new ReviewGetDto( ReviewinDBbyID.ID,
                                                  ReviewinDBbyID.Customer_ID,
                                                  ReviewinDBbyID.Technical_ID,
                                                  ReviewinDBbyID.Description,
                                                  ReviewinDBbyID.date);
                return ReviewDto;
            
        }

        public List<ReviewGetDto>? GetReviewsByCustomerId(int customerId)
        {
            var ReviewsList = _reviewRepo.GetReviewsByCustomerId(customerId);
            var Reviews = ReviewsList.Select(R =>
                                            new ReviewGetDto(
                                                ReviewId:R.ID,
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
