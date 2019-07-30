using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Comments
{
    public class CommentViewModel
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name ="Съдържание")]
        public string Content { get; set; }

        [Display(Name ="Дата на публикуване")]
        public DateTime PublishDate { get; set; }

        [Display(Name ="Рейтинг")]
        public double? Rating { get; set; }

        [Display(Name ="Име")]
        [BindNever]
        public string CommenterName { get; set; }

        [BindNever]
        public int OfferId { get; set; }


    }
}
