using Ataal.BL.Managers.problem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ataal.Controllers.Search
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProblemManager _problemManager;
        public SearchController(IProblemManager problemManager)
        {
            _problemManager = problemManager;
        }
        [HttpGet]
        [Route("{TechnicalId}")]
        public IActionResult Search(string query, int TechnicalId)
        {

            var result = _problemManager.Search(query, TechnicalId);

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
