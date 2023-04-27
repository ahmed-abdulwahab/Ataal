using Ataal.BL.Managers.Technical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Customer
{
    public record CustomerWithTechnicalsBlockedListDto(List<ReturnTechnicalForBlockListDto>BlockListDtos);
    
}
