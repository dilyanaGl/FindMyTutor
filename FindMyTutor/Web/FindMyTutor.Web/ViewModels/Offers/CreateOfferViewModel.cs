using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FindMyTutor.Web.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FindMyTutor.Web.ViewModels.Offers
{
    public class CreateOfferViewModel
    {     
        [Display(Name ="Предмет")]
        public ICollection<SelectListItem> Subjects { get; set; }

        [Display(Name ="Ниво")]
        public ICollection<SelectListItem> Levels { get; set; }

        [Display(Name ="Подготовка за:")]
        public ICollection<SelectListItem> SubjectNames { get; set; }

        [Display(Name = "Подготовка за:")]
        [Range(1, int.MaxValue, ErrorMessage ="Избери валиден предмет за подготовка")]        
        public int SubjectNameId { get; set; }

        public DateTime PublishDate { get; set; } = DateTime.Now;

        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddDays(14);

        [Display(Name = "Цена")]
        public double? Price { get; set; }

        [Display(Name ="Цена на запитване")]
        public bool SharePriceOptions { get; set; }

        [Display(Name = "Добави изображение")]
        [Url(ErrorMessage = "Невалиден UsRL")]
        public string ImageUrl { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Офертата трябва да има заглавие")]
        [MinLength(3, ErrorMessage ="Заглавието на офертата поне 3 символа")]
        [Display(Name = "Заглавие на оферта")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Офертата трябва да има описание")]
        [Display(Name = "Описание на оферта")]
        [MinLength(3, ErrorMessage ="Описанието трябва да бъде поне 3 символа")]
        public string Description { get; set; }

    }
}
