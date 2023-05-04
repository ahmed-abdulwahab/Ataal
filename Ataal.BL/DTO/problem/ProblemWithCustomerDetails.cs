using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.problem
{
    public record ProblemWithCustomerDetails(
                                         int id,
                                         string title,
                                         string Description,
                                         DateTime Date,
                                         int CustomerId,
                                         string CustomerName,
                                         string? CustomerPhoto,
                                         string? keyword,
                                         string? Photo1,
                                         string? Photo2,
                                         string? Photo3,
                                         string? Photo4

        );
    
}
