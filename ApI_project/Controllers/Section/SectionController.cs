using Ataal.BL.DTO.Section;
using Ataal.BL.Managers.Section;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ataal.Controllers.Section
{
	[Route("api/[controller]")]
	[ApiController]
	public class SectionController : ControllerBase
	{
		private readonly ISectionManger sectionManger;
        public SectionController(ISectionManger _sectionManger)
        {
            sectionManger = _sectionManger;
        }

		[HttpGet]
		[Route("AllSectionWithDetails")]
		public IActionResult GetAllSectioninDetails()
		{ 
		  var AllSection = sectionManger.getAllSSsectionWithDeatailsDtos();
			return Ok(AllSection);
		}

		[HttpDelete]
		[Route("DeleteSection")]
		public IActionResult DeleteSection(int id)
		{
			var SelectedSection = sectionManger.DeleteSection(id);
			if (SelectedSection == null) return BadRequest();
			return Ok(SelectedSection);
		}

		[HttpGet]
		[Route("GetSectionWithDetails")]
		public IActionResult GetSectionByIdWithDetails(int id)
		{
			var Section = sectionManger.GetSectionByIDinDetails(id);
			return Ok(Section);
		}

		[HttpGet]
		[Route("AllSectionWithoutDetails")]
		public IActionResult GetAllSection()
		{
			var AllSection = sectionManger.getAllSectionDtos();
			return Ok(AllSection);
		}

		[HttpGet]
		[Route("GetSectionByID")]
		public IActionResult GetByID(int id)
		{
			var SelectedSection = sectionManger.GetSectionByID(id);
			if (SelectedSection == null) return BadRequest();
			return Ok(SelectedSection);
		}
        [HttpGet]
        [Route("GetAllTechnicalsForCustomerSectionsSideBar/{SectionId}")]
        public IActionResult GetAllTechnicalsForCustomerSectionsSideBar(int SectionId)
        {
			var Technicals = sectionManger.GetTechnicalsForCustomersSectionSidebar(SectionId);
			if (Technicals == null)
				return NotFound();
			return Ok(Technicals);
        }

        [HttpPost]
		[Route("AddSection")]
		public IActionResult AddNewSection([FromForm]AddSectionDto NewSection)
		{
			var TargetSection = sectionManger.AddNewSection(NewSection);
			if(TargetSection == null) return BadRequest(new { TargetSection = NewSection });
			return Ok(TargetSection);
		}

		[HttpPut]
		[Route("UpdateSection")]
		public IActionResult UpdateSection(SectionDto section , int id)
		{
			var TargetSection = sectionManger.UpdateSectionById(section ,id);
			if (TargetSection == null) return NotFound();
			return Ok(TargetSection);
		}


	}
}
