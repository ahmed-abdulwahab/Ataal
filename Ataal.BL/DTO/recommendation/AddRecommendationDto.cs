using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.recommendation
{
    public record AddRecommendationDto(int CustomerId,int ProblemId,int TechnicalId,DateTime Date);
    
}
