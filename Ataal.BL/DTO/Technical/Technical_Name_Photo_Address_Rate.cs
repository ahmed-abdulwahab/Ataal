using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Technical
{
    public record Technical_Name_Photo_Address_Rate
    (   int Id,
        string Name,
        byte[] Photo,
        int Rate,
        string Address
    );
}
