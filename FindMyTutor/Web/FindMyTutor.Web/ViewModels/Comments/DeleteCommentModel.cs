using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Comments
{
    public class DeleteCommentModel
    {
        [Required]
        [BindNever]
        public int CommentId { get; set; }

        [Required]
        [Display(Name ="Съдържание")]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Автор")]
        public string Author { get; set; }

        [BindNever]
        public string AuthorId { get; set; }
    }
}
