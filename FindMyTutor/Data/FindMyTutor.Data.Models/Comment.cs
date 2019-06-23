namespace FindMyTutor.Data.Models
{
    using System;

    public class Comment : BaseModel<int>
    {
        public Comment()
        {
            this.PublicationDate = DateTime.Now;
        }

        public override int Id { get; set; }

        public string CommenterId { get; set; }

        public FindMyTutorUser Commenter { get; set; }

        public int OfferId { get; set; }

        public Offer Offer { get; set; }       

        public int Rating { get; set; }

        public string Content { get; set; }

        public DateTime PublicationDate { get; set; }

    }
}