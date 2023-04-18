using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Review
{
   public record ReviewCreationDto(int Customer_Id,int Technical_Id,string Description);
    
}
