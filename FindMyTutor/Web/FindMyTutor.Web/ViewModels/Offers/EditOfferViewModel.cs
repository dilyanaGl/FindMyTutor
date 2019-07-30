using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Offers
{
    public class EditOfferViewModel
    {
        [Display(Name = "Подготовка за:")]
        public IEnumerable<SelectListItem> SubjectNames { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Избери валиден предмет за подготовка")]
        public int SubjectNameId { get; set; }

        [BindNever]
        public int Id { get; set; }    

        [Display(Name = "Цена")]
        public int Price { get; set; }

        [Display(Name = "Цена на запитване")]
        public bool SharePriceOptions { get; set; }

        [Display(Name = "Добави изображение")]
        [Url(ErrorMessage = "Невалиден UsRL")]
        public string ImageUrl { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Офертата трябва да има заглавие")]
        [MinLength(3, ErrorMessage = "Заглавието на офертата поне 3 символа")]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Офертата трябва да има описание")]
        [Display(Name = "Описание")]
        [MinLength(3, ErrorMessage = "Описанието трябва да бъде поне 3 символа")]
        public string Description { get; set; }
    }
}
