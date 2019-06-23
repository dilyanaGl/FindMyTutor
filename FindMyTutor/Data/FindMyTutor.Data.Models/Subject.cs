namespace FindMyTutor.Data.Models
{
    using System.Collections.Generic;

    public class Subject : BaseModel<int>
    {
        public Subject()
        {
            this.SubCategories = new List<SubjectName>();
        }

        public override int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SubjectName> SubCategories { get; set; }

    }
}