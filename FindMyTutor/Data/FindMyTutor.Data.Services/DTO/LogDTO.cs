using FindMyTutor.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Services.DTO
{
   public class LogDTO
    {
        public string UserId { get; set; }

        public LogType LogType { get; set; }

        public int ResourceId { get; set; }

        public ResourceType ResourceType { get; set; }

        public DateTime DateTime { get; set; }
    }
}
