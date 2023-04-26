using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Customer
{
    public record updatedProblemDto(int Problem_id,
                                    string Title,
                                    string Description,
                                    int Section_ID,
                                    int KyeWord_ID,
                                    IFormFile? File1,
                                    IFormFile? File2,
                                    IFormFile? File3,
                                    IFormFile? File4);
    
}
