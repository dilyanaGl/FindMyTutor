using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Messages
{
    public class MailViewModel
    {
        public IEnumerable<SenderViewModel> Senders { get; set; }
    }
}
