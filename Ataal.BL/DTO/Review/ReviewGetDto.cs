using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Review
{
    public record ReviewGetDto(int CustomerId,
                               int TechnicalId,
                               string Description,
                               DateTime DateTime
                               );
    
}
