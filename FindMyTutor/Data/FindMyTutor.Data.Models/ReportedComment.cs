using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Models
{
    public class ReportedComment : Report
    {
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
