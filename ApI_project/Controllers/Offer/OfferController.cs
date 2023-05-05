using Ataal.BL.DTO.Offer;
using Ataal.BL.Managers.Offer;
using Ataal.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ataal.Controllers.Offer
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferManger offerManger;

        public OfferController(IOfferManger offerManger)
        {
            this.offerManger = offerManger;
        }

        // GET: api/<OfferController>

        [HttpGet("ttt/{technicalId}")]
        public ActionResult<List<OfferDTO>> get_offers_technical(int technicalId)          
        {
             var allOfferDTO = offerManger.getAll_Offers(technicalId,-1);
            if(allOfferDTO==null)
                return NoContent();
            return Ok(allOfferDTO);
        }

        [HttpGet("{technicalId}/{problemId}")]
        public ActionResult<List<OfferDTO>> get_offers_technical_specific_Problem(int technicalId,int problemId)
        {
            var allOfferDTO = offerManger.getAll_Offers(technicalId, problemId);
            if (allOfferDTO == null)
                return NoContent();
            return Ok(allOfferDTO);
        }

        // GET api/<OfferController>/5
        [HttpGet("offer/{id}")]
        public ActionResult<OfferDTO> getOfferById(int id)
        {
            var offerDTO = offerManger.getByID(id);

            if (offerDTO == null)
                return NoContent();
            return Ok(offerDTO);
        }


        [HttpGet("offer/{TechnicalID}/{ProblemID}")]
        public ActionResult<OfferDTO> getOfferByIdForpayment(int TechnicalID,int ProblemID)
        {
            var offerDTO = offerManger.getByIDUsingTechnical(TechnicalID, ProblemID);

            return Ok(offerDTO);
        }

        // POST api/<OfferController>
        [HttpPost]
        public ActionResult<int> postOffer(OfferDTO offer)
        {
            var is_Saved = offerManger.createOffer(offer);

            if (!is_Saved) return BadRequest(0);

            return Ok(1);
        }

        // DELETE api/<OfferController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (offerManger.deleteOffer(id))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{TechnicalID}/{ProblemID}")]
        public ActionResult DeleteByTechnicalID(int TechnicalID, int ProblemID)
        {
            if (offerManger.deleteOfferByTechnicalandProblemId(TechnicalID, ProblemID))
                return Ok();
            return BadRequest();
        }
    }
}
