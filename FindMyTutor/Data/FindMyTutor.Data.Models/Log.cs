using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Models
{
    public class Log : BaseModel<int>
    {
        public override int Id { get; set; }

        public string UserId { get; set; }

        public FindMyTutorUser User { get; set; }

        public LogType LogType { get; set; }

        public int ResourceId { get; set; }

        public ResourceType ResourceType { get; set; }

        public DateTime DateTime { get; set; }
    }
}
