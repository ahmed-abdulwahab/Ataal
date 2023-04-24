using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Section
{
	public record SectionDetailsDto( int id ,
		                             string Name ,
									 string Description  ,
                                     string? Photo,
									 ICollection<SectionProblemReadDto>? SectionProblemReadDtos   ,
									 ICollection<SectionTecnicalReadDto>? SectionTecnicalReadDtos ,
									 ICollection<SectionKeyWordReadDto>? SectionKeyWordReadDtos   );

}


