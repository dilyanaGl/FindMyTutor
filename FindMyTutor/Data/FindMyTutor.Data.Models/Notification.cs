using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Models
{
    public class Notification : BaseModel<int>
    {
        public override int Id { get; set; }

        public string NotificationRecipientId { get; set; }

        public FindMyTutorUser NotificationRecipient { get; set; }         

        public MessageType MessageType { get; set; }

        public bool IsSeen { get; set; }

        public int? ResourceId { get; set; }

        
    }
}
