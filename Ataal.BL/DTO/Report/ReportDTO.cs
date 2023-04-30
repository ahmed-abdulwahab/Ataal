using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Report
{
    public record ReportDTO(int id, int Review_ID, string Cause ,string? Description ,DateTime Created_Date);
}
