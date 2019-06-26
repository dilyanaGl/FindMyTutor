using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyTutor.Web.ViewModels.Common;

namespace FindMyTutor.Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public IEnumerable<SubjectViewModel> Subjects { get; set; }

        public IEnumerable<string> Levels { get; set; }

        public IEnumerable<string> ButtonStyles { get; set; }
    }
}
