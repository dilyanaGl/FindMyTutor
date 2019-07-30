using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Services.DTO
{
    public class EditOfferDTO
    {
        public int SubjectNameId { get; set; }

        public int Id { get; set; }
        
        public double? Price { get; set; }
        
        public bool SharePriceOptions { get; set; }

        public string ImageUrl { get; set; }
        
        public string Address { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
