using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Messages
{
    public class SenderViewModel
    {
        [Display(Name ="От:")]
        public string SenderName { get; set; }

        public string SenderId { get; set; }

        [Display(Name ="Брой съобщения")]
        public int MessagesCount { get; set; }

        [Display(Name ="Тема")]
        public string Topic { get; set; }
    }
}
