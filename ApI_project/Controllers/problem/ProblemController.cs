using Ataal.BL.Managers.problem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ataal.Controllers.problem
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        private readonly IProblemManager _problemManager;
        public ProblemController(IProblemManager problemManager)
        {
            _problemManager= problemManager;
        }
        [HttpGet]
        public IActionResult GetAllProblems(int TechnicalID)
        {
            var problems=_problemManager.GetProblemsForTechnical(TechnicalID);
            if (problems == null)
                return BadRequest();
            else
                return Ok(problems);
        }
    }
}
