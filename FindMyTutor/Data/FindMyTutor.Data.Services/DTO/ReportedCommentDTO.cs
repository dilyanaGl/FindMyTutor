using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Services.DTO
{
    public class ReportedCommentDTO 
    {
        public string Rationale { get; set; }

        public string CreatorId { get; set; }

        public string ReporterId { get; set; }

        public int CommentId { get; set; }

        public string Content { get; set; }


    }
}
