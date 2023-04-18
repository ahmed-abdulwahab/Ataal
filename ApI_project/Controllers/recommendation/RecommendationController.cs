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
            if (Recommendation == 0)
                return BadRequest();
            return Ok();
        }
    }
}
