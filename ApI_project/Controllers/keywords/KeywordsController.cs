using Ataal.BL.Managers.keywords;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ataal.Controllers.keywords
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeywordsController : ControllerBase
    {
        private readonly IKeywordsManager _keywordsManager;
        public KeywordsController(IKeywordsManager keywordsManager)
        {
            _keywordsManager = keywordsManager;
        }
        [HttpGet]
        [Route("GetAllKeyWordsBySectionId/{sectionId}")]
        public IActionResult GetAllKeywordsBySectionId(int sectionId)
        {
            var Keywords = _keywordsManager.GetAllKeywordsBySectionId(sectionId);
            if (Keywords == null)
            {
                return NotFound();

            }
            return Ok(Keywords);
        }
    }
}
