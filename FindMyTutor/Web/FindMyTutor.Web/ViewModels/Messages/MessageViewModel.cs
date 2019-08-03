using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Message
{
    public class MessageViewModel
    {
        public int Id { get; set; }

        [Display(Name = "До")]
        public string ReceiverName { get; set; }

        [Display(Name = "От")]
        public string SenderName { get; set; }

        public string RecipientId { get; set; }

        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        [Display(Name ="Дата на изпращане")]
        public string SendDate { get; set; }

        public int? OfferId { get; set; }

        [Display(Name ="Оферта")]
        public string OfferTitle { get; set; }

        public bool IsReceived { get; set; }
    }
}
