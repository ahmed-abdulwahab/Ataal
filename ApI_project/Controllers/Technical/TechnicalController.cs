using Ataal.BL.DtO.technical;
using Ataal.BL.DTO.Offer;
using Ataal.BL.DTO.Technical;
using Ataal.BL.Managers.Offer;
using Ataal.BL.Managers.Section;
using Ataal.BL.Mangers.technical;
using Ataal.BL.Mangers.Technical;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stripe_Payments_Web_Api.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ataal.Controllers.Technical
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalController : ControllerBase
    {
        private readonly ItechnicalManger ITechnicalManger;
        private readonly IOfferManger offerManger;

        public TechnicalController(ItechnicalManger itechnicalManger,IOfferManger offerManger)
        {
            this.ITechnicalManger = itechnicalManger;
            this.offerManger = offerManger;
        }
        // GET: api/<TechnicalController>
        [HttpGet]
        public ActionResult<List<Technical_Name_Photo_Address_Rate>> GetAllTehnicals()
        {
            var AllTechnicals = ITechnicalManger.GetAllTechnicals();

            if (AllTechnicals == null) { return NotFound(); }


            return AllTechnicals;

        }

        [HttpPost]
        [Route("AddSectionstoTechnican")]
        public IActionResult AddSectionstoTechnican(AddSectionstoTechnicalDto Dto)
        {
            var Result = ITechnicalManger.AddSectionsToTechnical(Dto);
            if (Result == false)
                return NotFound();
            return Ok(Result);
        }

        [HttpGet]
        [Route("GetAllTechnicalsForSectionId/{SectionId}")]
        public ActionResult<List<ReturnTechnicalWithNameandIdDto>> GetAllTechnicalsForSectionId(int SectionId)
        {
            var AllTechnicals = ITechnicalManger.getAllTechnicalForSectionId(SectionId);

            if (AllTechnicals == null) { return NotFound(); }


            return Ok(AllTechnicals);

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
        public async Task<ActionResult> Put(int id, TechnicalUpdateDto technical)
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


        [HttpGet("GetPoints/{id}")]
        public ActionResult GetPoints(int id)
        {
            return Ok(ITechnicalManger.getPoints(id));
        }

        [HttpGet("decrese/{technicalID}")]
        public ActionResult decreasePoints(int technicalID)
        {
            return Ok(ITechnicalManger.decreasePoints(technicalID));
        }



        [HttpGet]
        [Route("getTechnicalNotification/{TechnicalID}")]
        public ActionResult<int> getTechnicalNotification(int TechnicalID)
        {
            var Notification = ITechnicalManger.getTechnicalNotification(TechnicalID);

            return Ok(Notification);

        }

        [HttpGet]
        [Route("setTechnicalNotificationZero/{TechnicalID}")]
        public ActionResult<int> setTechnicalNotificationZero(int TechnicalID)
        {
            var Notification = ITechnicalManger.setTechnicalNotificationZero(TechnicalID);

            return Ok(Notification);

        }
    }
}
