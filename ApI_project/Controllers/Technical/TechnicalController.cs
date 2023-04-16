using Ataal.BL.DtO.technical;
using Ataal.BL.Mangers.technical;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ataal.Controllers.Technical
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalController : ControllerBase
    {
        private readonly ItechnicalManger itechnicalManger;

        public TechnicalController(ItechnicalManger itechnicalManger)
        {
            this.itechnicalManger = itechnicalManger;
        }
        // GET: api/<TechnicalController>
        //[HttpGet]
        //public IEnumerable<TechnicalDTO> Get()
        //{

        //    return ();
            
        //}

        // GET api/<TechnicalController>/5
        [HttpGet("{id}")]
        public ActionResult<technicalDtO> Get(int id)
        {
            var technical = itechnicalManger.GetTechnical_Profile(id);
            if(technical == null) 
            {
                return NotFound();
            }

            return technical;
        }

        // POST api/<TechnicalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TechnicalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TechnicalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
