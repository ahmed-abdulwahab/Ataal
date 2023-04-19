using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.recommendation
{
    public record ReturnRecommendationDto(DateTime DateTime,
                                          int CustomerId,
                                          int TechnicalId,
                                          int ProblemId);
    
}
