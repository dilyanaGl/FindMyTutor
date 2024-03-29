﻿namespace FindMyTutor.Data.Services.DTO
{
    using System;

    public class OfferDTO
    {
        public string SubjectName { get; set; }

        public string Level { get; set; }

        public string TutorId { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public double? Price { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int SubjectId { get; set; }

        public string Address { get; set; }
    }
}