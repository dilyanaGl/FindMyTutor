using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Models
{
    public class Recommendation : BaseModel<int>
    {

        public Recommendation()
        {
            this.PublicationTime = DateTime.Now;
        }

        public override int Id { get; set; }

        public string RecommenderId { get; set; }

        public FindMyTutorUser Recommender { get; set; }

        public string RecommendeeId { get; set; }

        public FindMyTutorUser Recommendee { get; set; }

        public string RecommendToId { get; set; }

        public FindMyTutorUser RecommendTo { get; set; }

        public bool RecommendToAFriend { get; set; }

        public DateTime PublicationTime { get; set; }

        public string Content { get; set; }
    }
}
