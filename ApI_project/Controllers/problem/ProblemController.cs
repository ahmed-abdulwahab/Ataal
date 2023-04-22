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
        public IActionResult GetAllProblems([FromBody]GetProblemsPagingDto GetProblemsPaging)
        {
            var problems = _problemManager.GetProblemsForTechnical(GetProblemsPaging);
            if (problems == null)
                return BadRequest();
            else
                return Ok(problems);
        }
        [HttpGet]
        [Route("{ProblemId}")]
        public IActionResult GetProblemById(int ProblemId)
        {
            var problemDto=_problemManager.GetProblemById(ProblemId);
            if(problemDto!=null)
            {
                return Ok(problemDto);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("ProblemIsSolved/{ProblemId}")]
        public IActionResult ProblemIsSolved(int ProblemId)
        {
            var value=_problemManager.ProblemIsSolved(ProblemId);
            if (value > 0)
                return Ok("Solved");
            else if (value == -1)
                return Ok("Already_Solved");
            
            return NotFound();
        }
        [HttpPost]
        [Route("CustomerAcceptOffer")]
        public IActionResult CustomerAcceptOffer(CustomerAcceptedProblemOfferDto CAPDto)
        {
            var Value = _problemManager.CustomerAcceptedOffer(CAPDto);
            if(Value>0)
                return Ok();
            else
                return BadRequest();
        }

    }
}
