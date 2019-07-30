using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Comments
{
    public class CommentReportViewModel
    {
        [Required]
        [BindNever]
        public int CommentId { get; set; }

        [Display(Name = "Основание")]
        [Required(ErrorMessage ="Докладването трябва да има основание.")]
        [MinLength(3, ErrorMessage ="Основанието трябва да бъде дълго поне 3 символа.")]
        public string Rationale { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [BindNever]
        public int OfferId { get; set; }


    }
}
