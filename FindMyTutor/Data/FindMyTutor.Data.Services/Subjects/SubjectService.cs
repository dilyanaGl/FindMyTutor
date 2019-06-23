using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Common;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Data.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> subjects;
        private readonly IRepository<SubjectName> subjectNames;

        public SubjectService(IRepository<Subject> subjects, IRepository<SubjectName> subjectNames)
        {
            this.subjects = subjects;
            this.subjectNames = subjectNames;
        }

        public IEnumerable<string> GetLevels(int subjectId)
        {
            return this.subjectNames.All()
                .Where(p => p.SubjectId == subjectId)
                .Select(p => p.Level)                
                .ToHashSet();
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return this.subjects
                .All()
                .ToArray();
        }
    }
}
