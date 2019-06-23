using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.DTO;
using FindMyTutor.Common;

namespace FindMyTutor.Data.Services.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> reviews;

        public ReviewService(IRepository<Review> reviews)
        {
            this.reviews = reviews;
        }

        public void AddReview(ReviewDTO reviewDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Review> GetReviewsForOffer(int id)
        {
            return this.reviews.All()
                .Where(p => p.Id == id)
                .ToArray();
        }

        public void RemoveReview(int id)
        {
            var review = this.reviews.All()
                .FirstOrDefault(p => p.Id == id);
            this.reviews.Remove(review);
            this.reviews.SaveChangesAsync();

            this.reviews.SaveChangesAsync();
        }
    }
}
