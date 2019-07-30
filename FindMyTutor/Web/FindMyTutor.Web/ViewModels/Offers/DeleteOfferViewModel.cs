using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Offers
{
    public class DeleteOfferViewModel
    {
        [Display(Name = "Подготовка за:")]
        public string SubjectName { get; set; }

        [BindNever]
        public int Id { get; set; }

        public DateTime PublishDate { get; set; } = DateTime.Now;

        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddDays(14);

        [Display(Name = "Цена")]
        public string PriceDisplay { get; set; }

        [Display(Name = "Изображение")]
        public string ImageUrl { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

  
        [Display(Name = "Заглавие на оферта")]
        public string Title { get; set; }

     
        [Display(Name = "Описание на оферта")]     
        public string Description { get; set; }
    }
}
