using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Section
{
    public record ProblemWithCustomerDto(int id,
                                         string title,
                                         string Description,
                                         CustomerDto? CustomerDto
                           );
}
