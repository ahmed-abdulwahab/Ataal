using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Report
{
    public record ReportPostDTO(int Review_ID,int technicalid, string Cause, string? Description, DateTime Created_Date);

}
