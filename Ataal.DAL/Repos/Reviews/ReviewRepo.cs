using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Repos.Reviews
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly AtaalContext _ataalContext;
        public ReviewRepo(AtaalContext ataalContext)
        {
            _ataalContext = ataalContext;
        }
        public Review? GetReviewById(int ReviewId)
        {
          return  _ataalContext.Reviews.FirstOrDefault(r=>r.ID== ReviewId);
        }
        public List<Review> GetAllReviews()
        {
            return _ataalContext.Reviews.ToList();
        }
        public List<Review> GetReviewsByCustomerId(int CustomerId)
        {
            return _ataalContext.Reviews.Where(R=>R.Customer_ID==CustomerId).ToList();
        }

        public int SaveChanges()
        {
            return _ataalContext.SaveChanges();
        }

    }
}
