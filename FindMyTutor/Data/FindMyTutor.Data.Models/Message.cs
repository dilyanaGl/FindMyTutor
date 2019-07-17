namespace FindMyTutor.Data.Models
{
    using System;
    public class Message : BaseModel<int>
    {
        public Message()
        {
            this.SendDate = DateTime.Now;
            this.IsRead = false;
        }

        public override int Id { get; set; }

        public string SenderId { get; set; }

        public FindMyTutorUser Sender { get; set; }

        public string ReceiverId { get; set; }

        public FindMyTutorUser Receiver { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public DateTime SendDate { get; set; }

        public bool IsRead { get; set; }

        public int? OfferId { get; set; }

        public Offer Offer { get; set; }

        
    }
}