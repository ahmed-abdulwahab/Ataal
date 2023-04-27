using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.problem
{
    public record NotificationDataDto(
      int? OfferId,
      string? CustomerName,
      int TechnId,
      string TechnicalName,
      int ProblemId,
      string Problem_Title,
        DateTime date);
   
}
