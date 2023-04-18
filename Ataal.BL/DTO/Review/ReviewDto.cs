using Ataal.BL.DtO.Customer;
using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ataal.BL.DtO.Review
{
    public record ReviewDto(int id, CustomerReviewDto Customer_Info, string Description, DateTime date);
}
