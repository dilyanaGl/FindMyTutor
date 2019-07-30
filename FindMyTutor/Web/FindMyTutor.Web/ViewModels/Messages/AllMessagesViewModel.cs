using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Message
{
    public class AllMessagesViewModel
    {
        public ICollection<MessageViewModel> UnreadMessages { get; set; }

        public ICollection<MessageViewModel> ReadMessages { get; set; }

        public ICollection<MessageViewModel> SentMessages { get; set; }
    }
}
