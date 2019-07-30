using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Models
{
    public class Report : BaseModel<int>
    {
        public override int Id { get; set; }

        public string Rationale { get; set; }

        public string ResourceCreatorId { get; set; }

        public FindMyTutorUser ResourceCreator { get; set; }

        public string ReporterId { get; set; }

        public FindMyTutorUser Reporter { get; set; }

       


    }
}
