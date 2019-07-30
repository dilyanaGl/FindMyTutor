using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Services.DTO
{
    public class MailMessageDTO
    {
        public string SenderName { get; set; }

        public string SenderId { get; set; }

        public int MessagesCount { get; set; }

        public string Topic { get; set; }
    }
}
