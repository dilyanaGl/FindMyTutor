using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FindMyTutor.Data.Models
{
    // Add profile data for application users by adding properties to the FindMyTutorUser class
    public class FindMyTutorUser : IdentityUser
    {
        public FindMyTutorUser()
        {
            this.ReveivedMessages = new List<Message>();
            this.SentMessages = new List<Message>();
            this.GivenReviews = new List<Review>();
            this.ReceivedReviews = new List<Review>();
            this.MadeOffers = new List<Offer>();
            this.GivenRecommendations = new List<Recommendation>();
            this.ReceivedRecommendations = new List<Recommendation>();
            this.RecommendationsByFriends = new List<Recommendation>();
            this.TotalRating = 0;
            this.RatingsCount = 0;
        }

        public Role Role { get; set; }

        public ICollection<Recommendation> GivenRecommendations { get; set; }

        public ICollection<Recommendation> ReceivedRecommendations { get; set; }

        public ICollection<Recommendation> RecommendationsByFriends { get; set; }

        public ICollection<Message> SentMessages { get; set; }

        public ICollection<Message> ReveivedMessages { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Review> GivenReviews { get; set; }

        public ICollection<Review> ReceivedReviews { get; set; }

        public ICollection<Offer> MadeOffers { get; set; }

        public int RatingsCount { get; set; }

        public int TotalRating { get; set; }


    }
}
