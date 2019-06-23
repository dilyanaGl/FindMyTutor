using System;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Common;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Data.Services.Reviews
{
    using DTO;

    public interface IReviewService
    {
        IEnumerable<Review> GetReviewsForOffer(int id);

        void AddReview(ReviewDTO reviewDTO);
        
        void RemoveReview(int id);

    }
}
