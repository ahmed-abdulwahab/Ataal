using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.Technical
{
    public record ReturnTechnicalForBlockListDto(
                            int id,
                            string name,
                            
                           
                            
                            string? Photo,
                            int Rate,
                            string? Brief,
                            string Address);
    
}
