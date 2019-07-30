using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Models
{
    public class ReportedOffer : Report
    {
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
