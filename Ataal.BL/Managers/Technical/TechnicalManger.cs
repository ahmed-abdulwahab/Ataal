using Ataal.BL.DtO.Customer;
using Ataal.BL.DTO.Identity;
using Ataal.BL.DtO.Review;
using Ataal.BL.DtO.Section;
using Ataal.BL.DtO.technical;
using Ataal.BL.DTO.Identity;
using Ataal.BL.DTO.Technical;
using Ataal.BL.Mangers.technical;
using Ataal.DAL.Data.Identity;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Data.Repos.Technical_Repo;
using Microsoft.AspNetCore.Identity;
using System.Security;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ataal.BL.Mangers.Technical
{
    public class TechnicalManger : ItechnicalManger
    {
        private readonly ITechnicalRepo technicalRepo;
        private readonly UserManager<AppUser> _userManager;


        public TechnicalManger(ITechnicalRepo technicalRepo,UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            this.technicalRepo = technicalRepo;
        }

        public DetailedTechnicalDTO GetTechnical_Profile(int id)
        {
            var technical = technicalRepo.getTechnicalByID(id);

            if (technical == null)
                return null!;

            return new DetailedTechnicalDTO(

                id : technical.Id,
                name : technical.Frist_Name + " " + technical.Last_Name,
                user_Name : technical.AppUser.UserName ?? "",
                eamil : technical.AppUser.Email ?? "",
                Phone : technical.AppUser.PhoneNumber!,
                Photo : technical.Photo,
                Rate : technical.Rate,
                Brief : technical.Brief,
                Address : technical.Address,
                Reviews: technical.Reviews?.Select(R => new ReviewDto
                (
                    id: R.ID,
                    Customer_Info: new CustomerReviewDto
                    (
                        id: R.Customer_ID,
                        name: R.Customer.Frist_Name + " " + R.Customer.Last_Name,
                        Photo: R.Customer.Photo
                    ),
                    Description: R.Description,
                    date: R.date
                )),


                    Sections: technical.Sections?.Select(S => new Section_Name_And_Id_DtO
                    (
                        id: S.Section_ID,
                        Name: S.Section_Name

                ))
            );
        }
   
        public List<Technical_Name_Photo_Address_Rate> GetAllTechnicals()
        {
            var AllTechnicals = technicalRepo.getAllTechnical();

            if ( AllTechnicals == null ) { return null; }

            return AllTechnicals.Select(T => new Technical_Name_Photo_Address_Rate(
                Id: T.Id,
                Name: T.Frist_Name + " " + T.Last_Name,
                Photo: T.Photo!,
                Address: T.Address,
                Rate: T.Rate
                )).ToList();
        }
        public List<ReturnTechnicalWithNameandIdDto>? getAllTechnicalForSectionId(int SectionId)
        {
            var AllTechnicals = technicalRepo.getAllTechnicalForSectionId(SectionId);
            if(AllTechnicals == null )
            {
                return null;
            }
            return AllTechnicals.Select(T => new ReturnTechnicalWithNameandIdDto(
                Id: T.Id,
                Name: $"{T.Frist_Name} {T.Last_Name}")).ToList();
        }

        public int deleteTechnical(int id)
        {

            var technical = technicalRepo.deleteTechnical(id);
            if (technical == null) { return -1; }

            return 1;
        }

        

        public int updateTechnical(int id, TechnicalUpdateDto technical)
        {

            var technicalToUpdate = technicalRepo.getTechnicalByID(id);

            if (technicalToUpdate == null) { return -1; }

            technicalToUpdate.Frist_Name= technical.firstName ?? technicalToUpdate.Frist_Name;

            technicalToUpdate.Last_Name = technical.lastName ?? technicalToUpdate.Last_Name;
            
            technicalToUpdate.Photo = technical.photo ?? technicalToUpdate.Photo;

            technicalToUpdate.Address = technical.Address ?? technicalToUpdate.Address;

            technicalToUpdate.Brief = technical.Breif ?? technicalToUpdate.Brief;

            technicalToUpdate.AppUser.PhoneNumber = technical.Phone ?? technicalToUpdate.AppUser.PhoneNumber;

            technicalToUpdate.AppUser.UserName = technical.userName ?? technicalToUpdate.AppUser.UserName;

            technicalToUpdate.AppUser.Email = technical.Email ?? technicalToUpdate.AppUser.Email;

            var result = technicalRepo.updateTechnical(id, technicalToUpdate);

           
            if (result == null) return -1;

            return 1;
         }

        public async Task<RegisterUserDto> addTechnical(RegisterUserDto technical)
        {

            var AppUser = await _userManager.FindByIdAsync(technical.AppUser.Id);

            var Technical = new DAL.Data.Models.Technical() {        
                Frist_Name = technical.firstName,
                Last_Name = technical.lastName,
                Address = technical.Address,
                AppUser = AppUser,
                AppUserId = technical.AppUserId                    
            };

           var result = technicalRepo.CreateTechnical(Technical);

            if (result == null) return null;

            return technical;
        }
    }
}
