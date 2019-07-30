using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Comments
{
    public class AddCommentViewModel
    {
        [Display(Name ="Коментар")]
        [Required(ErrorMessage ="Коментарът трябва да бъде дълъг поне 3 символа!")]
        [MinLength(3, ErrorMessage ="Коментарът трябва да бъде дълъг поне 3 символа!")]
        public string Content { get; set; }

        
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Display(Name ="Оцени офертата")]
        public double? Rating { get; set; }

        public int OfferId { get; set; }
    }
}
