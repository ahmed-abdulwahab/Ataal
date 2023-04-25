using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Section
{
    public record CustomerDto(string Frist_Name ,
                              string Last_Name ,
                              string? ExpirationYear,
                              string? ExpirationMonth ,
                              string? photo);
}
