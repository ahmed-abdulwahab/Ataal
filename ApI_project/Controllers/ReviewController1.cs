using Ataal.BL.DTO.Review;
using Ataal.BL.Managers.review;
using Ataal.BL.Managers.Section;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ataal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController1 : ControllerBase
    {
        private readonly IReviewManager _reviewManager;
        public ReviewController1(IReviewManager reviewManager)
        {
            _reviewManager = reviewManager;
        }

        [HttpGet]
        [Route("GetAllReviews")]
        public IActionResult GetAllReviews()
        {
            var Reviews = _reviewManager.GetAllReviews();
            if (Reviews == null)
                return NotFound();
            else
                return Ok(Reviews);
        }

        [HttpGet]
        [Route("GetReviewByID/{id}")]
        public IActionResult GetReviewByID(int id)
        {
            var Review = _reviewManager.GetReviewbyId(id);
            if (Review == null)
                return NotFound();
            else
                return Ok(Review);
        }

        [HttpDelete]
        [Route("DeleteReview")]
        public IActionResult DeleteSection(int id)
        {
            var SelectedReview = _reviewManager.DeleteReview(id);
            if (SelectedReview == null) return BadRequest();
            return Ok(SelectedReview);
        }


        [HttpGet]
        [Route("GetReviewByCustomerId/{CustomerId}")]
        public IActionResult GetReviewByCustomerId(int CustomerId)
        {
            var Review = _reviewManager.GetReviewsByCustomerId(CustomerId);
            if (Review == null)
                return NotFound();
            else
                return Ok(Review);
        }
    }
}
