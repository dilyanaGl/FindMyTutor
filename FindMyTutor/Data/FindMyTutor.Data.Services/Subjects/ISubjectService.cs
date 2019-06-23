using System;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Data.Services.Subjects
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();

        IEnumerable<string> GetLevels(int subjectId);
        
    }
}
