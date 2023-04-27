using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Repos.recommendation
{
    public class RecommendationRepo: IRecommendationRepo
    {
        private readonly AtaalContext _context;
        public RecommendationRepo(AtaalContext context)
        {
            _context = context;
        }
        public int AddRecommendationForCustomer(Recommendation recommendation)
        {
            _context.Recommendations.Add(recommendation);
            return SaveChanges();
        }
        public List<Recommendation> GetAllRecommendations()
        {
            return _context.Recommendations.ToList();
        }
        public int SaveChanges()
        {
           return _context.SaveChanges();
        }

    }
}
