namespace FindMyTutor.Data.Models
{
    using System;

    public class Review : BaseModel<int>
    {
        public Review()
        {
            this.IsBannedByAdministrator = false;
            this.PublicationDate = DateTime.Now;

        }

        public override int Id { get; set; }

        public string ReviewerId { get; set; }

        public FindMyTutorUser Reviewer { get; set; }

        public string RevieweeId { get; set; }

        public FindMyTutorUser Reviewee { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool IsBannedByAdministrator { get; set; }

        public double? Rating { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }




    }
}