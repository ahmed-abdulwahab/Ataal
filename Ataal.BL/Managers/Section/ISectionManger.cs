using Ataal.BL.DTO.Customer;
using Ataal.BL.DTO.Section;
using Ataal.BL.DTO.Technical;
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
		public List<SectionDetailsDto> getAllSSsectionWithDeatailsDtos();
        public List<SectionDetialsDtoCustomer> getAllSectionWithDeatailsDtos_Customer();
        public List<SectionDto> getAllSectionDtos();
		public SectionDto GetSectionByID(int id);
		public List<ReturnTechnicalsForCustomersSectionsDto>? GetTechnicalsForCustomersSectionSidebar(int SectionId);

        public SectionDetialsDtoCustomer GetSectionByIDinDetails(int id);
		public int UpdateSectionById(SectionDto sectionDto, int id);
		public Task<int?> AddNewSection(AddSectionDto addSectionDto);
		public Task<string?>? ReturnImagePath(IFormFile File);
		public int DeleteSection(int id);

	}
}
