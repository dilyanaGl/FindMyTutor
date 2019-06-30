using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Models
{
    public class SubjectName : BaseModel<int>
    {
        public SubjectName()
        {
            this.Offers = new List<Offer>();
        }

        public override int Id { get; set; }

        public String Name { get; set; }

        public int SubjectId { get; set; }

        public string Level { get; set; }

        public string LevelEnglish { get; set; }

        public Subject Subject { get; set; }

        public ICollection<Offer> Offers { get; set; }
    }
}
