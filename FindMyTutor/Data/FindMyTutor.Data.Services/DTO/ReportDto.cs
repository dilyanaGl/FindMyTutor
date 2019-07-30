using FindMyTutor.Data.Models;
using System;
using System.Collections.Generic;

using System.Text;

namespace FindMyTutor.Data.Services.DTO
{
    public class ReportDTO
    {
        public string Rationale { get; set; }

        public string CreatorId { get; set; }     

        public string ReporterId { get; set; }

        public int ResourceId { get; set; }

        public ResourceType ResourceType { get; set; }

    }
}
