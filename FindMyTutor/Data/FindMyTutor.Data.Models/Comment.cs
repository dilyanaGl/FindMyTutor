namespace FindMyTutor.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Comment : BaseModel<int>
    {
        public Comment()
        {
            this.PublicationDate = DateTime.Now;
            this.Reports = new List<ReportedComment>();
        }

        public string CommenterId { get; set; }

        public FindMyTutorUser Commenter { get; set; }

        public int OfferId { get; set; }

        public Offer Offer { get; set; }       

        public int Rating { get; set; }

        public string Content { get; set; }

        public DateTime PublicationDate { get; set; }

        public ICollection<ReportedComment> Reports { get; set; }
        public override int Id { get; set; }
    }
}