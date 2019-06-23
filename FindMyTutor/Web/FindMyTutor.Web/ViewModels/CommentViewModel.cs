using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        public string Username { get; set; }

        public string Title { get; set; }

        public double Rating { get; set; }

        public string Content { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
