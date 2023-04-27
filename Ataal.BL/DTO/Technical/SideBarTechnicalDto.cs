using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Technical
{
    public record SideBarTechnicalDto
    (
        string Name,
        string Email,
        string Phone,
        string? Photo,
        int Rate,
        string Address,
        int NumOfReviews,
        int NumOfSolvedProblems
    );
}
