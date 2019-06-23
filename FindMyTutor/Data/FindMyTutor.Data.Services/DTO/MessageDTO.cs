using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Services.DTO
{
    public class MessageDTO
    {
        public string Subject { get; set; }

        public string Content { get; set; }

        public DateTime SendDate { get; set; }

        public string SenderId { get; set; }

        public string ReceiverId { get; set; }
    }
}
