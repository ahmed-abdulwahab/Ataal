using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Offer
{public record 
    GetByIdOffer(int Technicalid, int problemID, double OfferSalary, string? OfferMassege,int offerId,bool Acepted);
   
}
