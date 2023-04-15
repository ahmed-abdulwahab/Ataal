using Ataal.DAL.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ataal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public ValuesController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Admin")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetDataForAdmins()
        {
            return Ok(new { Data = "Admin" });
        }

        [HttpGet]
        [Route("Customer")]
        [Authorize(Policy = "Customer")]
        public async Task<ActionResult> GetDataForCustomers()
        {
            return Ok(new { Data = "Customer" });
        }


        [HttpGet]
        [Route("Technical")]
        [Authorize(Policy = "Technical")]
        public async Task<ActionResult> GetDataForTechnical()
        {
            return Ok(new { Data = "Technical" });
        }
    }
}
