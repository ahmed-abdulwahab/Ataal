using Ataal.BL.DtO.Customer;
using Ataal.BL.DtO.Review;
using Ataal.BL.DtO.Section;
using Ataal.BL.DtO.technical;
using Ataal.BL.Mangers.technical;
using Ataal.DAL.Data.Repos.Technical_Repo;

namespace Ataal.BL.Mangers.Technical
{
    public class TechnicalManger : ItechnicalManger
    {
        private readonly ITechnicalRepo technicalRepo;

        public TechnicalManger(ITechnicalRepo technicalRepo)
        {
            this.technicalRepo = technicalRepo;
        }

        public technicalDtO GetTechnical_Profile(int id)
        {
            var technical = technicalRepo.getTechnicalByID(id);

            if (technical == null)
                return null!;

            return new technicalDtO(

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
    }
}
