using Ataal.DAL.Data.Models;
using Ataal.DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Repos.recommendation
{
    public interface IRecommendationRepo
    {
        public int AddRecommendationForCustomer(Recommendation recommendation);
        public List<Recommendation> GetAllRecommendations();
        public int SaveChanges();
    }
}
