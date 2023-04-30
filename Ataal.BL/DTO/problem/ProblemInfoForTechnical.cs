using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.problem
{
    public record ProblemInfoForTechnical (
        int id,
        string Title,
        string Description,
        DateTime? Date,
        bool IsVIP,
        string? Key_Word
        );
}
