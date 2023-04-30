using Ataal.BL.DtO.Customer;
using Ataal.BL.DTO.Technical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Review
{
    public record ReviewIDDto(int id,
                              TechnicalDto? Technical_Info,
                              CustomerReviewDto? Customer_Info,
                              string Description,
                              DateTime date);
    
}
