using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.problem
{
    public record ProblemReturnDto(
        int id,
        string?CustomerName,
        string?TechnicanName,
        int ?TechId,
        string Title,
        string Description,
        DateTime? Date,
        bool IsSolved,
        bool IsVIP,
        int Section_id,
        int? Key_WordId,
        string? Key_Word,
        string?CustomerPhoto,
        string? PhotoPath1,
        string? PhotoPath2,
        string? PhotoPath3,
        string? PhotoPath4
        );
    
}
