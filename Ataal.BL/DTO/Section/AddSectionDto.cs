using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Section
{
	public record AddSectionDto(int id ,
		                        string Name ,
								string Description ,
		                        IFormFile? File1
								);
	
}
