using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FindMyTutor.Web.ViewModels.Comments;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FindMyTutor.Web.ViewModels.Offers
{
    public class OfferDetailsViewModel
    {
        [BindNever]
        public int Id { get; set; }
        
        [BindNever]
        public string TutorId { get; set; }

        [Display(Name = "Заглавие")]
        public string Title { get; set; }
       
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name ="Изображение")]
        public string ImageUrl { get; set; }

        [Display(Name = "Цена")]
        public string PriceDisplay { get; set; }

        [Display(Name="Преподавател")]
        public string TutorName { get; set; }

        [Display(Name ="Дата на публикуване")]
        public DateTime PublishDate { get; set; }

        [Display(Name ="Офертата е валидна до:")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name ="Предмет")]
        public string Subject { get; set; }

        [Display(Name ="Ниво")]
        public string Level { get; set; }

        [Display(Name ="Категория")]
        public string SubjectName { get; set; }

        [Display(Name ="Коментари")]
        public IEnumerable<CommentViewModel> Comments { get; set; }

        [Display(Name ="Добави коментар")]
        public AddCommentViewModel AddComment { get; set; }

    }
}
