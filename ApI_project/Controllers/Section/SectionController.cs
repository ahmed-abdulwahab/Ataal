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

		//[HttpGet]
		//[Route("All Section With Details")]
		//public IActionResult GetAllSectioninDetails()
		//{ 
		//  var AllSection = sectionManger.getAllSSsectionWithDeatailsDtos();
		//	return Ok(AllSection);
		//}

		[HttpGet]
		[Route("All Section Without Details")]
		public IActionResult GetAllSection()
		{
			var AllSection = sectionManger.getAllSectionDtos();
			return Ok(AllSection);
		}

		[HttpGet]
		[Route("Get Section By ID")]
		public IActionResult GetByID(int id)
		{
			var SelectedSection = sectionManger.GetSectionByID(id);
			if (SelectedSection == null) return BadRequest();
			return Ok(SelectedSection);
		}

		[HttpPost]
		[Route("Add New Section")]
		public IActionResult AddNewSection(AddSectionDto NewSection)
		{
			var TargetSection = sectionManger.AddNewSection(NewSection);
			if(TargetSection == null) return BadRequest(new { TargetSection = NewSection });
			return Ok(TargetSection);
		}

		[HttpPut]
		[Route("Update Section")]
		public IActionResult UpdateSection(SectionDto section , int id)
		{
			var TargetSection = sectionManger.UpdateSectionById(section ,id);
			if (TargetSection == null) return NotFound();
			return Ok(TargetSection);
		}


	}
}
