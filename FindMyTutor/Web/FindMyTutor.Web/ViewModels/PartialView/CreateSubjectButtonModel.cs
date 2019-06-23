using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.PartialView
{
    using Home;

    public class CreateSubjectButtonModel
    {
        public SubjectViewModel Subject { get; set; }

        public string ButtonStyle { get; set; }
    }
}
