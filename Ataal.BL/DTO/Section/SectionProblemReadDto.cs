using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Section
{
	public record SectionProblemReadDto(int id,
                                         string title,
                                         string Description,
                                         DateTime Date,
                                         string? keyword,
                                         string? Photo1,
                                         string? Photo2,
                                         string? Photo3,
                                         string? Photo4
                            );
}
