﻿using Ataal.BL.DTO.Review;
using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.review
{
    public interface IReviewManager
    {
        public ReviewGetDto GetReviewbyId(int id);
        public List<ReviewGetDto>? GetAllReviews();
        public List<ReviewGetDto>? GetReviewsByCustomerId(int customerId);
        public int DeleteReview(int id);
    }
}
