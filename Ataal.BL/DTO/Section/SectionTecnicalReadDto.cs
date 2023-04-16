using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Section
{
	public record SectionTecnicalReadDto(  int Id,
										   string Phone,
										   int Rate,
										   string Brief);
}
