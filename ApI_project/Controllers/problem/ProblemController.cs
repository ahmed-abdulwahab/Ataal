using Ataal.BL.DTO.problem;
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

        [HttpPost]
        public IActionResult GetAllProblems(GetProblemsPaging GetProblemsPaging)
        {
            var problems=_problemManager.GetProblemsForTechnical(GetProblemsPaging);
            if (problems == null)
                return BadRequest();
            else
                return Ok(problems);
        }
    }
}
