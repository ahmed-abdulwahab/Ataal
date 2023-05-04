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
        public IActionResult Search(string query)
        {

            var result = _problemManager.Search(query);

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
