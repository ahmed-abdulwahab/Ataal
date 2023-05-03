using Ataal.BL.DtO.Section;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Technical
{
    public record AllTechnicansWithSectionsForCustomerDto(
                                            int Id,
                                            string? Name,
                                            string? Phone,
                                            string? Email,
                                            string? Address,
                                            string? photo,
                                            string? Breif,
                                            int ? rate,
                                            IEnumerable<Section_Name_And_Id_DtO>? Sections

        );
    
}
