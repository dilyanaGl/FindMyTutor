using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Messages
{
    public class RespondViewModel
    {
        [Display(Name = "Съдържание")]
        [Required(ErrorMessage = "Съобщението трябва да има съдържание")]
        [MinLength(3, ErrorMessage = "Темата трябва да бъде поне 3 символа")]
        public string Content { get; set; }

        [BindNever]
        public string RecipientId { get; set; }


        public DateTime SendDate { get; set; } 
    }
}
