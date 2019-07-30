using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.Areas.Admin.Models.Reports
{
    public class AllReportsViewModel
    {
        public IEnumerable<ReportViewModel> Offers { get; set; }

        public IEnumerable<ReportCommentViewModel> Comments { get; set; }


    }
}
