using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Common;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Data.Services.Recommendations
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRepository<Recommendation> recommendations;

        public RecommendationService(IRepository<Recommendation> recommendations)
        {
            this.recommendations = recommendations;
        }

        public void DeleteRecommendation(int id)
        {
            var recommendation = this.recommendations.All().FirstOrDefault(p => p.Id == id);
            this.recommendations.Remove(recommendation);
            this.recommendations.SaveChangesAsync();
        }

        public IEnumerable<Recommendation> GetRecommendationsForTutor(string tutorId)
        {
            return this.recommendations
                .All()
                .Where(p => p.RecommendeeId == tutorId)
                .ToArray();
        }

        public IEnumerable<Recommendation> GetRecommendationsForUser(string userId)
        {
            return this.recommendations
                .All()
                .Where(p => p.RecommendToId == userId)
                .ToArray();
        }

        public void Recommend(string recommenderId, string recommendeeId)
        {
            var recommendation = new Recommendation
            {
                RecommendeeId = recommendeeId,
                RecommenderId = recommenderId
            };

            this.recommendations.Add(recommendation);
            this.recommendations.SaveChangesAsync();
        }

        public void RecommendToAFriend(string recommenderId, string recommendeeId, string recommendToId)
        {
            var recommendation = new Recommendation
            {
                RecommendeeId = recommendeeId,
                RecommenderId = recommenderId,
                RecommendToId = recommendToId
            };

            this.recommendations.Add(recommendation);
            this.recommendations.SaveChangesAsync();

        }
    }
}
