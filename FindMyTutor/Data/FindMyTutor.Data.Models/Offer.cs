using System;
using System.Collections.Generic;

namespace FindMyTutor.Data.Models
{
    public class Offer : BaseModel<int>
    {
        public Offer()
        {
            this.Comments = new List<Comment>();
            this.Messages = new List<Message>();
        }

        public override int Id { get; set; }

        public SubjectName Subject { get; set; }

        public int SubjectId { get; set; }

        public string TutorId { get; set; }

        public FindMyTutorUser Tutor { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public double Price { get; set; }

        public ICollection<Message> Messages { get; set; }

        public int RatingsCount { get; set; }

        public int TotalRating { get; set; }


    }
}
