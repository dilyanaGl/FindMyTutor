using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Message
{
    public class CreateMessageViewModel
    {
        [Required(ErrorMessage ="Съобщението трябва да има тема")]
        [MinLength(3, ErrorMessage ="Темата трябва да бъде поне 3 символа")]
        [Display(Name ="Тема")]
        public string Subject { get; set; }

        [Display(Name ="Съдържание")]
        [Required(ErrorMessage = "Съобщението трябва да има съдържание")]
        [MinLength(3, ErrorMessage = "Темата трябва да бъде поне 3 символа")]
        public string Content { get; set; }

        [BindNever]
        public string RecipientId { get; set; }

        [BindNever]
        public int OfferId { get; set; }

        public DateTime SendDate { get; set; } 


    }
}
