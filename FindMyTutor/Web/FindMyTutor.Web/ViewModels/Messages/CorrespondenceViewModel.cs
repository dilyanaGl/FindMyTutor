using FindMyTutor.Web.ViewModels.Message;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Messages
{
    public class CorrespondenceViewModel
    {        
        public string Interlocutor { get; set; }

        public ICollection<MessageViewModel> Messages { get; set; }

        public RespondViewModel Respond { get; set; }
    }
}
