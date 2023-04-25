using Ataal.BL.DtO.technical;
using Ataal.BL.DTO.Customer;
using Ataal.BL.DTO.Identity;
using Ataal.BL.DTO.problem;
using Ataal.BL.DTO.Rate;
using Ataal.BL.DTO.Review;
using Ataal.BL.DTO.Technical;
using Ataal.BL.Managers.Technical;
using Ataal.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.Customer
{
    public interface ICustomerManager
    {
        public NotificationDto GetAllNotification(int CustomerId);
        public int GetNotificationCount(int CustomerId);
        public oneCustomerDto? GetCustomerById(int id);
        public  Task<int?> ReturnAddedProblemID(CustomerAddProblemDto CustDto);
        public Task<string?>? ReturnImagePath(IFormFile File);
        public List<ProblemReturnDto>? ReturnProblemsForCustomers(int CustomerId);
        public Task<int?> UpdateCustomerProfile(int CustomerId, UpdatedCustomerProfileDto Dto);
        public CustomerWithTechnicalsBlockedListDto? GetAllBlockedTechnicals(int CustomerId);
        public  Task<int?> UpdatedProblem(updatedProblemDto CustDto);
        public Problem? ReturnProblemByID(int ProblemID);
        public int ModifyingTechnical_Rate(int TechnicalId);

        public int CustomerAddingRate(RateCreationDto rateCreationDto);
        public Ataal.DAL.Data.Models.Technical gettechnical(int techincalid);
        public int AddingTechnicalReview(ReviewCreationDto ReviewDto);
        public bool DeleteProblemWithImagesByProblemID(int ProblemID);
        public int? UpdateReview(ReviewUpdatedDto ReviewUpdated);
        public bool DeleteReview(int ReviewId);

        public bool BlockTechnical(BlockAndUnblockTechnicalAndCustomersDto BDto);
        public bool UnBlockTechnical(BlockAndUnblockTechnicalAndCustomersDto BDto);

        public bool BlockCustomer(BlockAndUnblockTechnicalAndCustomersDto BDto);
        public bool UnBlockCustomer(BlockAndUnblockTechnicalAndCustomersDto BDto);

        public Task<RegisterUserDto> CreateCustomer(RegisterUserDto customer);

    }

}
