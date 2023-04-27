using Ataal.BL.DTO.Report;
using Ataal.BL.Managers.Report;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ataal.Controllers.Report
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        public IReportManger ReportManger { get; }

        public ReportController(IReportManger reportManger)
        {
            ReportManger = reportManger;
        }

        // GET: api/<ReportController>
        [HttpGet]
        public ActionResult<IEnumerable<ReportDTO>> Get()
        {
            var reportsDTO = ReportManger.getAll();
            if (reportsDTO == null)
            {
                return NoContent();
            }
            return Ok(reportsDTO);
        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public ActionResult<ReportDTO> Get(int id)
        {
            var reportDTO = ReportManger.getByID(id);

            if (reportDTO == null)
            {
                return NoContent();
            }
            return Ok(reportDTO);
        }

        // POST api/<ReportController>
        [HttpPost]
        public ActionResult Post(ReportPostDTO reportDTO)
        {
            if(ReportManger.createReport(reportDTO))
                return NoContent();
            return BadRequest();
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(ReportManger.DeleteById(id))
                return NoContent();
            return BadRequest();
        }
    }
}
