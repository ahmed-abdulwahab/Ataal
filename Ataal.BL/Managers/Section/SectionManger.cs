using Ataal.BL.DTO.Section;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Repos.Section;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Ataal.BL.Managers.Section
{
	public class SectionManger : ISectionManger
	{
		private ISectionRepo sectionRepo;
        public SectionManger( ISectionRepo _sectionRepo)
        {
            sectionRepo = _sectionRepo;
        }

		public int AddNewSection(AddSectionDto SectionDto)
		{
			if (SectionDto == null) return 0;
			var AddedSection = new DAL.Data.Models.Section
			{
				Section_ID = SectionDto.id,
				Section_Name = SectionDto.Name,
				Description = SectionDto.Description,
			};
		 return	sectionRepo.AddNewSection(AddedSection);
		}

		public List<SectionDto> getAllSectionDtos()
		{
			var SectionFromDB = sectionRepo.GetAllSections();

			var SectionDto = SectionFromDB
				.Select(t => new SectionDto(ID: t.Section_ID,
													Name: t.Section_Name,
													Description: t.Description));
			return SectionDto.ToList();
		}

		public List<SectionDetailsDto> getAllSSsectionWithDeatailsDtos()
		{
			var SectionFromDB = sectionRepo.GetAllSections();

			var SectionDto = SectionFromDB
				.Select(t => new SectionDetailsDto(id: t.Section_ID,
													 Name: t.Section_Name,
													 Description: t.Description,
													 SectionProblemReadDtos: t.Problems.Select(p => new SectionProblemReadDto(id: p.Problem_ID,
																															 title: p.Problem_Title,
																															 Description: p.Description)).ToList(),
													 SectionTecnicalReadDtos: t.Technicals.Select(t => new SectionTecnicalReadDto(Id: t.Id,
																															   Phone: t.Phone,
																															   Rate: t.Rate,
																															   Brief: t.Brief)).ToList(),
													 SectionKeyWordReadDtos: t.KeyWords.Select(k => new SectionKeyWordReadDto(Id: k.KeyWord_ID,
																															   Name: k.KeyWord_Name)).ToList()
																			   ));
			return SectionDto.ToList();
		}

		public SectionDto GetSectionByID(int id)
		{
			var SectionByIDInDB = sectionRepo.GetSectionById(id);
			if (SectionByIDInDB == null) return null;
			var sectionDto = new SectionDto(SectionByIDInDB.Section_ID,SectionByIDInDB.Section_Name,SectionByIDInDB.Description);
			return sectionDto;
		}

		public int UpdateSectionById(SectionDto section, int id)
		{
		   var MappedSection = new DAL.Data.Models.Section
		   {
			   Section_ID = section.ID,
			   Section_Name = section.Name,
			   Description = section.Description,
		   };
			var SelectedItem = sectionRepo.UpdateSection(MappedSection, id);
		   if (SelectedItem == null) return 0;
		   return SelectedItem.Section_ID;
	
			
		}
	}
}
