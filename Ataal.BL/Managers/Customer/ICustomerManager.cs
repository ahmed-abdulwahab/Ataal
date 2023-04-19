﻿using Ataal.BL.DTO.Customer;
using Ataal.BL.DTO.Identity;
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

        public  Task<int?> UpdatedProblem(updatedProblemDto CustDto);
        public Problem? ReturnProblemByID(int ProblemID);
        public int ModifyingTechnical_Rate(int TechnicalId);

        public int CustomerAddingRate(RateCreationDto rateCreationDto);
        public Technical gettechnical(int techincalid);
        public int AddingTechnicalReview(ReviewCreationDto ReviewDto);
        public bool DeleteProblemWithImagesByProblemID(int ProblemID);
        public int? UpdateReview(ReviewUpdatedDto ReviewUpdated);
        public bool DeleteReview(int ReviewId);

        public bool BlockTechnical(BlockAndUnblockTechnicalAndCustomersDto BDto);
        public bool UnBlockTechnical(BlockAndUnblockTechnicalAndCustomersDto BDto);

        public bool BlockCustomer(BlockAndUnblockTechnicalAndCustomersDto BDto);
        public bool UnBlockCustomer(BlockAndUnblockTechnicalAndCustomersDto BDto);

        public Task<RegisterUserDto> CreateCustomer(RegisterUserDto customer);

        public ICollection<UnBlocked_BlockedCustomersDto> GetBlockedCustomers(int TechnicalId);
        public ICollection<UnBlocked_BlockedCustomersDto> GetUnBlockedCustomers(int TechnicalId);

    }

}
