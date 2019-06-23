using System;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Data.Services.Recommendations
{
    using DTO;

    public interface IRecommendationService
    {
        IEnumerable<Recommendation> GetRecommendationsForUser(string userId);

        IEnumerable<Recommendation> GetRecommendationsForTutor(string tutorId);

        void Recommend(string recommenderId, string recommendeeId);

        void RecommendToAFriend(string recommenderId, string recommendeeId, string recommendToId);

        void DeleteRecommendation(int id);
    }
}
