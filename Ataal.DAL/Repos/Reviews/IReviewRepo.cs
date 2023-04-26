using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Repos.Reviews
{
    public interface IReviewRepo
    {

        public Review? GetReviewById(int ReviewId);
       
        public int SaveChanges();
    }
}
