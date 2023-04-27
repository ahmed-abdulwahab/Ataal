using Ataal.BL.DTO.recommendation;
using Ataal.BL.Managers.recommendation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ataal.Controllers.recommendation
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationManager _recommendationManager;
        public RecommendationController(IRecommendationManager recommendationManager)
        {
            _recommendationManager = recommendationManager;
        }

        [HttpPost]
        [Route("AddingRecommendation")]
        public IActionResult AddingRecommendation(AddRecommendationDto Dto)
        {
            var Recommendation=_recommendationManager.AddRecommendation(Dto);
            if (Recommendation == -1)
                return BadRequest("Cannot_Make_Another_One");
            if (Recommendation == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet]
        [Route("GetAllRecommendations")]
        public IActionResult GetAllRecommendations()
        {
            var Recommendations=_recommendationManager.GetAllRecommendations();
            if (Recommendations == null)
                return NotFound();
            return Ok(Recommendations);
        }
    }
}
