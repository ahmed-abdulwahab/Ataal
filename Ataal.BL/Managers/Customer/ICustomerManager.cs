using Ataal.BL.DTO.Customer;
using Ataal.BL.DTO.Rate;
using Ataal.BL.DTO.Review;
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
        public  Task<int?> ReturnAddedProblemID(CustomerAddProblemDto CustDto);
        public Task<string?>? ReturnImagePath(IFormFile File);

        public  Task<int?> UpdatedProblem(updatedProblemDto CustDto);
        public Problem? ReturnProblemByID(int ProblemID);
        public int ModifyingTechnical_Rate(int TechnicalId);

        public int CustomerAddingRate(RateCreationDto rateCreationDto);
        public Technical gettechnical(int techincalid);
        public int AddingTechnicalReview(ReviewCreationDto ReviewDto);
        public bool DeleteProblemWithImagesByProblemID(int ProblemID);
        public int? UpdateReview(ReviewUpdatedDto ReviewUpdated);
        public bool DeleteReview(int ReviewId);
    }
}
