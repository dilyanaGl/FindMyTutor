using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FindMyTutor.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace FindMyTutor.Web.Areas.Identity.Account.Models
{
    [AllowAnonymous]
    public class RegisterViewModel : PageModel
    {
        [Required(ErrorMessage ="Полето е задължително")]
        [MinLength(3, ErrorMessage = "Потребителското име трябва да бъде дълго поне 3 символа")]
        [Display(Name ="Потрбителско име")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [MinLength(3, ErrorMessage = "Името трябва да бъде дълго поне 3 символа")]
        [Display(Name ="Име")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [EmailAddress(ErrorMessage = "Невалиден имейл адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [MinLength(6, ErrorMessage ="Паролата трябва да бъде дълга поне 6 символа")]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Compare("Password", ErrorMessage = "Паролите не съответстват")]
        [Display(Name = "Повторете паролата")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }

        public bool IsTutor { get; set; }

        
        
    }
}
