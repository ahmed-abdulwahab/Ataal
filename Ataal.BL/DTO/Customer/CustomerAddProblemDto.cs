using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Customer
{
    public record CustomerAddProblemDto(string Title
                                       ,string Description
                                       ,int Section_ID
                                       ,int Customer_ID
                                       ,int KyeWord_ID
                                       ,IFormFile? File1
                                       ,IFormFile? File2
                                       ,IFormFile? File3
                                       ,IFormFile? File4
        );

}
