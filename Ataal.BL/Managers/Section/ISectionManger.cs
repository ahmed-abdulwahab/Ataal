using Ataal.BL.DTO.Customer;
using Ataal.BL.DTO.Section;
using Ataal.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.Section
{
	public interface ISectionManger
	{
		//public List<SectionDetailsDto> getAllSSsectionWithDeatailsDtos();
		public List<SectionDto> getAllSectionDtos();
		public SectionDto GetSectionByID(int id);
		public SectionDetailsDto GetSectionByIDinDetails(int id);
		public int UpdateSectionById(SectionDto sectionDto, int id);
		public Task<int?> AddNewSection(AddSectionDto addSectionDto);
		public Task<string?>? ReturnImagePath(IFormFile File);
		public int DeleteSection(int id);

	}
}
