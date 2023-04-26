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

        // POST api/<OfferController>
        [HttpPost]
        public ActionResult postOffer(OfferDTO offer)
        {
            var is_Saved = offerManger.createOffer(offer);

            if (!is_Saved) return BadRequest();

            return NoContent();
        }

        // DELETE api/<OfferController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (offerManger.deleteOffer(id))
                return Ok();
            return BadRequest();
        }
    }
}
