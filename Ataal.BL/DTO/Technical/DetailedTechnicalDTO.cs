using Ataal.BL.DtO.Review;
using Ataal.BL.DtO.Section;
using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;

namespace Ataal.BL.DtO.technical
{
    public record DetailedTechnicalDTO
        (
            int id,
            string name,
            string eamil,
            string user_Name,
            string Phone,
            byte[]? Photo,
            int Rate,
            string? Brief,
            string Address,


            IEnumerable<ReviewDto>? Reviews,
            IEnumerable<Section_Name_And_Id_DtO>? Sections

        );
}
