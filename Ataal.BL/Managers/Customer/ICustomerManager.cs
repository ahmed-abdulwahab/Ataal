using Ataal.BL.DTO.Customer;
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
        public Problem? ReturnProblemByID(int ProblemID);
        public bool DeleteProblemWithImagesByProblemID(int ProblemID);
    }
}
