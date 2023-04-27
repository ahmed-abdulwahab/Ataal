using Ataal.BL.DTO.recommendation;
using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.problem
{
    public record  NotificationDto( 
        //List<RecommendationCustomerDto> ?RecomenditionList,
        // List<OffersCustomerDto>? OffersList

        List<NotificationDataDto>Notifications
        );
    
}
