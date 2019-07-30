using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.Areas.Admin.Models
{
    public class ReportViewModel
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name ="Причина")]
        public string Rationale { get; set; }

        [BindNever]
        public string ResourceCreatorId { get; set; }

        [Display(Name ="Автор")]
        public string ResourceCreatorName { get; set; }

        [BindNever]
        public string ReporterId { get; set; }

        [Display(Name = "Докладващ")]
        public string ReporterName { get; set; }

        [BindNever]
        public int OfferId { get; set; }

        
    }
}
