using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Technical
{
    public record TechnicalUpdateDto
    (
      int Id,
      string? firstName,
      string? lastName,
      string? Phone,
      string? Email,
      string? Address,
      string? userName,
      byte[]? photo,
      string? Breif

    );
}
