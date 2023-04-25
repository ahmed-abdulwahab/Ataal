using Ataal.BL.DTO.Section;
using Ataal.BL.DTO.Technical;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Repos.Section;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
		private readonly IWebHostEnvironment _env;
		public SectionManger( ISectionRepo _sectionRepo , IWebHostEnvironment env)
        {
            sectionRepo = _sectionRepo;
			_env = env;
        }

		public async Task<int?> AddNewSection(AddSectionDto SectionDto)
		{
			if (SectionDto == null) return 0;
			var AddedSection = new DAL.Data.Models.Section
			{
				Section_ID = SectionDto.id,
				Section_Name = SectionDto.Name,
				Description = SectionDto.Description,
				Photo = await ReturnImagePath(SectionDto.File1),

			};
		 return	sectionRepo.AddNewSection(AddedSection);
		}

		public List<SectionDto> getAllSectionDtos()
		{
			var SectionFromDB = sectionRepo.GetAllSections();
			//string filePath = SectionFromDB.Select(f=>f.Photo).SingleOrDefault();
			//IFormFile file = new FormFile(new FileStream(filePath, FileMode.Open), 0, new FileInfo(filePath).Length, null, Path.GetFileName(filePath));
			var SectionDto = SectionFromDB
				.Select(t => new SectionDto(ID: t.Section_ID,
											Name: t.Section_Name,
											Description: t.Description,
										    Photo:t.Photo

											)) ;
			return SectionDto.ToList();
		}

		public List<SectionDetailsDto> getAllSSsectionWithDeatailsDtos()
		{
			var SectionFromDB = sectionRepo.GetAllSections();
			if (SectionFromDB == null) return null;
			var SectionDto = SectionFromDB
				.Select(t => new SectionDetailsDto(id: t.Section_ID,
												   Name: t.Section_Name,
												   Description: t.Description,
												   Photo:t.Photo,
												   SectionProblemReadDtos: t.Problems?.Select(p => new SectionProblemReadDto(id: p.Problem_ID,
																															  title: p.Problem_Title,
																															  Description: p.Description)).ToList(),
													 SectionTecnicalReadDtos: t.Technicals?.Select(t => new SectionTecnicalReadDto(Id: t.Id,
																															      Rate: t.Rate,
																															      Brief: t.Brief)).ToList(),
													 SectionKeyWordReadDtos: t.KeyWords?.Select(k => new SectionKeyWordReadDto(Id: k.KeyWord_ID,
																														       Name: k.KeyWord_Name)).ToList()
																			   ));
			return SectionDto.ToList();
		}


        public List<SectionDetialsDtoCustomer> getAllSectionWithDeatailsDtos_Customer()
        {
            var SectionFromDB = sectionRepo.GetAllSections_Customer();
            if (SectionFromDB == null) return null;
            var SectionDto = SectionFromDB
                .Select(t => new SectionDetialsDtoCustomer(id: t.Section_ID,
                                                   Name: t.Section_Name,
                                                   Description: t.Description,
                                                   Photo: t.Photo,
                                                    ProblemWithCustomerDtos: t.Problems?.Select(p => new ProblemWithCustomerDto(id: p.Problem_ID,
                                                                                                                     title: p.Problem_Title,
                                                                                                                     Description: p.Description,
                                                                                                                     CustomerDto: p.Customer != null ? new CustomerDto(Frist_Name: p.Customer.Frist_Name,
                                                                                                                                                                       Last_Name: p.Customer.Last_Name,
                                                                                                                                                                       ExpirationYear: p.Customer.ExpirationYear,
                                                                                                                                                                       ExpirationMonth: p.Customer.ExpirationMonth,
                                                                                                                                                                       photo: p.Customer.Photo) : null)).ToList(),
                                                   SectionTecnicalReadDtos: t.Technicals?.Select(t => new SectionTecnicalReadDto(Id: t.Id,
                                                                                                                                  Rate: t.Rate,
                                                                                                                                  Brief: t.Brief)).ToList(),
                                                   SectionKeyWordReadDtos: t.KeyWords?.Select(k => new SectionKeyWordReadDto(Id: k.KeyWord_ID,
                                                                                                                               Name: k.KeyWord_Name)).ToList()
                                                                               ));
            return SectionDto.ToList();
        }

        public List<ReturnTechnicalsForCustomersSectionsDto>? GetTechnicalsForCustomersSectionSidebar(int SectionId)
		{
			var Technicalslist = sectionRepo.GetAllTechnicalsForSectionIdSortedByRate(SectionId);
			if (Technicalslist == null)
				return null;
			var Technicals = Technicalslist.Select(S => new ReturnTechnicalsForCustomersSectionsDto(

												name: $"{S.Frist_Name} {S.Last_Name}",
												phone: S.AppUser.PhoneNumber,
												Brief: S.Brief,
												Rate: S.Rate,
												address: S.Address
												//photo:S.Photo
												)).ToList();

			return Technicals;
		}


        public SectionDto GetSectionByID(int id)
		{
			var SectionByIDInDB = sectionRepo.GetSectionById(id);
			if (SectionByIDInDB == null) return null;
			var sectionDto = new SectionDto(SectionByIDInDB.Section_ID,SectionByIDInDB.Section_Name,SectionByIDInDB.Description ,SectionByIDInDB.Photo );
			return sectionDto;
		}

		public async Task<string?> ReturnImagePath(IFormFile File)
		{
			if (File != null)
			{
				var fileName = $"{Guid.NewGuid()}{Path.GetExtension(File.FileName)}";
				var filePath = Path.Combine(_env.WebRootPath, fileName);

				// Save the image to disk
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await File.CopyToAsync(stream);
				}
				return fileName;
			}
			return null;
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

		public SectionDetialsDtoCustomer GetSectionByIDinDetails(int id)
		{
			var SectioninDetails = getAllSectionWithDeatailsDtos_Customer().FirstOrDefault(s => s.id == id);
			if (SectioninDetails == null) return null;
			return SectioninDetails;
		
		}

		public int DeleteSection(int id)
		{
			var DeletedSection = sectionRepo.DeleteSection(id);
			if (DeletedSection == null) return 0;
			return sectionRepo.DeleteSection(id);
		}


    }
}
