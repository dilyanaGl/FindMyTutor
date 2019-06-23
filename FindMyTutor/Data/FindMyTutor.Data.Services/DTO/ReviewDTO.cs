using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Services.DTO
{
    public class ReviewDTO
    {
        public string ReviewerId { get; set; }

        public string RevieweeId { get; set; }

        public DateTime PublicationDate { get; set; }

        public double? Rating { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
