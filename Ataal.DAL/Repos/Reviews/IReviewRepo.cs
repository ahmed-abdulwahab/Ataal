﻿using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Repos.Reviews
{
    public interface IReviewRepo
    {

        public void AddReview(Review review);
        public Review? GetReviewById(int ReviewId);
        public List<Review> GetAllReviews();
        public List<Review> GetReviewsByCustomerId(int CustomerId);

        public int DeleteReview(int id);
        public int SaveChanges();
    }
}
