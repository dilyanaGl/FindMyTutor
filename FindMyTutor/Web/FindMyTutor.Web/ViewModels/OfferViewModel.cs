using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Offers
{
    public class OfferViewModel
    {
        public string SubjectName { get; set; }

        public string Level { get; set; }

        public string TutorName { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public string PublishDate { get; set; }        

        public double Price { get; set; }

        
    }
}
