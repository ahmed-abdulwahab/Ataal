using Ataal.BL.DtO.technical;
using Ataal.BL.DTO.Technical;
using Ataal.BL.Mangers.technical;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ataal.Controllers.Technical
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalController : ControllerBase
    {
        private readonly ItechnicalManger ITechnicalManger;

        public TechnicalController(ItechnicalManger itechnicalManger)
        {
            this.ITechnicalManger = itechnicalManger;
        }
        // GET: api/<TechnicalController>
        [HttpGet]
        public ActionResult<List<Technical_Name_Photo_Address_Rate>> GetAllTehnicals()
        {
            var AllTechnicals = ITechnicalManger.GetAllTechnicals();

            if (AllTechnicals == null) { return NotFound(); }


            return AllTechnicals;

        }

        // GET api/<TechnicalController>/5
        [HttpGet("TechnicalProfile/{id}")]
        public async Task<ActionResult<DetailedTechnicalDTO>> Get(int id)
        {
            var technical = ITechnicalManger.GetTechnical_Profile(id);
            if(technical == null) 
            {
                return NotFound();
            }

            return await technical;
        }

        // GET api/<TechnicalController>/5
        [HttpGet("SideBarInfo/{id}")]
        public async Task<ActionResult<SideBarTechnicalDto>> GetSomeInfo(int id)
        {
            var technical = ITechnicalManger.GetTechnical_SomeInfo(id);
            if (technical == null)
            {
                return NotFound();
            }

            return await technical;
        }

        // PUT api/<TechnicalController>/5
        [HttpPut("update/{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] TechnicalUpdateDto technical)
        {
            var technicalUpdated = await ITechnicalManger.updateTechnical(id, technical);

            if (technicalUpdated == -1) return NotFound();

            return NoContent();
        }

        // DELETE api/<TechnicalController>/5
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var technical = ITechnicalManger.deleteTechnical(id);

            if(technical == -1) { return NotFound(); }

            return Ok();

        }
    }
}
