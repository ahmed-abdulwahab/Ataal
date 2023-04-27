using Ataal.BL.DTO.recommendation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.recommendation
{
    public interface IRecommendationManager
    {
        public int AddRecommendation(AddRecommendationDto Dto);
        public List<ReturnRecommendationDto>? GetAllRecommendations();
    }
}
