using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Section
{
	public record SectionDto(int ID,
						     string Name,
						     string Description,
                             string? Photo
                             )
		;
}
