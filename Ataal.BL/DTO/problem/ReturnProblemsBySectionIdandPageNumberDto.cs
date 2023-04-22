using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.problem
{
    public record ReturnProblemsBySectionIdandPageNumberDto(            
                                                        string Title,
                                                        string Description,
                                                        DateTime Date,
                                                        string? Key_Word,
                                                        string? PhotoPath1,
                                                        string? PhotoPath2,
                                                        string? PhotoPath3,
                                                        string? PhotoPath4);
    
}
